using DataLayer.Data;
using DataLayer.Model;
using DataLayer.Utils;
using PresentationLayer.GUIElements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ModelLayer.Managers;

namespace PresentationLayer.Window
{
    /// <summary>
    /// Window for managing datasets.
    /// </summary>
    public partial class ManageDatasetsWindow : Form
    {
        // Manager for manage datasets window.
        private ManageDatasetsWindowManager manageDatasetsWindowManager;

        // Map of datasets.
        private Dictionary<String, Dataset> datasets;

        // Application name.
        private String appName = "";

        // Main window instance.
        private MainWindow mainWindow;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="mainWindow"> Instance of main window. </param>
        public ManageDatasetsWindow(MainWindow mainWindow)
        {
            InitializeComponent();
            this.manageDatasetsWindowManager = new ManageDatasetsWindowManager();
            this.Text = mainWindow.AppName + " - Správa datasetů";
            this.appName = mainWindow.AppName;
            this.mainWindow = mainWindow;
            this.datasets = manageDatasetsWindowManager.getDatasets();

            fillDataGridView();
        }

        /// <summary>
        /// Fill DataGridView with default values.
        /// </summary>
        private void fillDataGridView()
        {
            Dictionary<String, Measure> measures = manageDatasetsWindowManager.getMeasures();

            foreach (Dataset dataset in datasets.Values)
            {
                DataGridViewRowWithId row = new DataGridViewRowWithId(dataset.ID);

                DataGridViewTextBoxCell datasetCell = new DataGridViewTextBoxCell();
                row.Cells.Add(datasetCell);
                datasetCell.Value = dataset.Name;

                DataGridViewComboBoxCell measureCell = new DataGridViewComboBoxCell();
                row.Cells.Add(measureCell);

                foreach (String measureName in measures.Keys)
                {
                    measureCell.Items.Add(measureName);
                    if (measureName.Equals(dataset.Measure.Name))
                    {
                        measureCell.Value = measureName;
                    }
                }

                dataGridViewManageDatasets.Rows.Add(row);
            }
        }

        /// <summary>
        /// Click event for btnNewDatasetRow.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNewDatasetRow_Click(object sender, EventArgs e)
        {
            Dictionary<String, Measure> measures = manageDatasetsWindowManager.getMeasures();

            DataGridViewRowWithId row = new DataGridViewRowWithId(-1);

            DataGridViewTextBoxCell datasetCell = new DataGridViewTextBoxCell();
            row.Cells.Add(datasetCell);

            DataGridViewComboBoxCell measureCell = new DataGridViewComboBoxCell();
            row.Cells.Add(measureCell);

            foreach (String measureName in measures.Keys)
            {
                measureCell.Items.Add(measureName);                
            }
            measureCell.Value = measureCell.Items[0];


            dataGridViewManageDatasets.Rows.Add(row);            
        }

        /// <summary>
        /// Click event for btnDeleteSelectedDatasetsRow.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeleteSelectedDatasetsRow_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection selectedRows = dataGridViewManageDatasets.SelectedRows;

            foreach (DataGridViewRow row in selectedRows)
            {
                dataGridViewManageDatasets.Rows.Remove(row);
            }
        }

        /// <summary>
        /// Click event for btnConfirmDatasetChanges.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConfirmDatasetChanges_Click(object sender, EventArgs e)
        {
            List<int> datasetsToBeDeleted = new List<int>();
            List<Dataset> newDatasets = new List<Dataset>();
            Dictionary<int, Dataset> datasetsToBeUpdated = new Dictionary<int,Dataset>();
            List<String> usedDatasets = new List<String>();

            Dictionary<String, Measure> measures = manageDatasetsWindowManager.getMeasures();

            foreach (DataGridViewRow row in dataGridViewManageDatasets.Rows)
            {
                DataGridViewRowWithId rowWithId = (DataGridViewRowWithId)row;

                Measure measure = null;
                measures.TryGetValue(row.Cells[1].Value.ToString(), out measure);

                if (usedDatasets.Contains(row.Cells[0].Value.ToString()))
                {
                    Utils.displayErrorMessageBox("Název datasetu '" + row.Cells[0].Value.ToString() + "' se už v tabulce nachází!", appName);
                    return;
                }

                if (row.Cells[0].Value == null)
                {
                    Utils.displayErrorMessageBox("Jeden z řádků nemá vyplněný název datasetu!", appName);
                    return;
                }

                if (row.Cells[1].Value == null) 
                {
                    Utils.displayErrorMessageBox("Jeden z řádků nemá vyplněný název jednotky teploty!", appName);
                    return;
                }

                if (measure == null)
                {
                    Utils.displayErrorMessageBox("Název vybrané jednotky teploty neodpovídá žádné hodnotě v databázi!", appName);
                    return;
                }

                int id = -1;
                if (rowWithId.Id == id)
                {
                    Dataset dataset = new Dataset(id, row.Cells[0].Value.ToString(), measure);
                    newDatasets.Add(dataset);
                }
                else
                {
                    Dataset dataset = new Dataset(rowWithId.Id, row.Cells[0].Value.ToString(), measure);
                    datasetsToBeUpdated.Add(rowWithId.Id, dataset);
                }

                usedDatasets.Add(row.Cells[0].Value.ToString());
            }

            foreach (Dataset dataset in datasets.Values)
            {                
                if (!datasetsToBeUpdated.ContainsKey(dataset.ID))
                {
                    datasetsToBeDeleted.Add(dataset.ID);
                    datasetsToBeUpdated.Remove(dataset.ID);                    
                }
                else
                {
                    Dataset newDataset = datasetsToBeUpdated[dataset.ID];
                    if (dataset.Name.Equals(newDataset.Name) && dataset.Measure.Name.Equals(newDataset.Measure.Name))
                    {
                        datasetsToBeUpdated.Remove(dataset.ID);
                    }
                }
            }

            if (newDatasets.Count == 0 && datasetsToBeDeleted.Count == 0 && datasetsToBeUpdated.Count == 0)
            {
                Utils.displayInfoMessageBox("Nebyla zaznamenána žádná změna.", appName);
                return;
            }

            bool success = manageDatasetsWindowManager.updateDatasets(newDatasets, datasetsToBeDeleted, datasetsToBeUpdated.Values.ToList());

            if (success)
            {
                Utils.displayInfoMessageBox("Úprava datasetů proběhla úspěšně.", appName);
                dataGridViewManageDatasets.Rows.Clear();
                datasets = manageDatasetsWindowManager.getDatasets();
                fillDataGridView();
            }
            else
            {
                Utils.displayErrorMessageBox("Vyskytla se chyba při úpravě datasetů v databázi!",
                appName);
            }
        }

        /// <summary>
        /// Click event for btnDiscardDatasetChanges.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDiscardDatasetChanges_Click(object sender, EventArgs e)
        {
            dataGridViewManageDatasets.Rows.Clear();
            fillDataGridView();
        }

        /// <summary>
        /// Click event for btnReturnDataset.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReturnDataset_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
