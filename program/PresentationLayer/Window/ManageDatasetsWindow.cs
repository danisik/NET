using DataLayer.Data;
using DataLayer.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer.Window
{
    public partial class ManageDatasetsWindow : Form
    {
        private readonly DatabaseInterface databaseInterface;
        private Dictionary<String, Dataset> datasets;
        private String appName = "";
        private MainWindow mainWindow;

        public ManageDatasetsWindow(MainWindow mainWindow)
        {
            InitializeComponent();
            this.databaseInterface = mainWindow.DatabaseInterface;
            this.appName = mainWindow.AppName;
            this.mainWindow = mainWindow;
            this.datasets = databaseInterface.getDatasets(databaseInterface.getMeasures());

            fillDataGridView();
        }

        private void fillDataGridView()
        {
            Dictionary<String, Measure> measures = databaseInterface.getMeasures();

            foreach (Dataset dataset in datasets.Values)
            {
                DataGridViewRow row = new DataGridViewRow();

                DataGridViewTextBoxCell idCell = new DataGridViewTextBoxCell();
                row.Cells.Add(idCell);
                idCell.Value = dataset.ID;

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

        private void btnNewDatasetRow_Click(object sender, EventArgs e)
        {
            Dictionary<String, Measure> measures = databaseInterface.getMeasures();

            DataGridViewRow row = new DataGridViewRow();
            DataGridViewTextBoxCell idCell = new DataGridViewTextBoxCell();
            row.Cells.Add(idCell);

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

        private void btnDeleteSelectedDatasetsRow_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection selectedRows = dataGridViewManageDatasets.SelectedRows;

            foreach (DataGridViewRow row in selectedRows)
            {
                dataGridViewManageDatasets.Rows.Remove(row);
            }
        }

        private void btnConfirmDatasetChanges_Click(object sender, EventArgs e)
        {
            List<int> datasetsToBeDeleted = new List<int>();
            List<Dataset> newDatasets = new List<Dataset>();
            Dictionary<int, Dataset> datasetsToBeUpdated = new Dictionary<int,Dataset>();

            Dictionary<String, Measure> measures = databaseInterface.getMeasures();

            foreach (DataGridViewRow row in dataGridViewManageDatasets.Rows)
            {
                Measure measure = null;
                measures.TryGetValue(row.Cells[2].Value.ToString(), out measure);

                if (row.Cells[1].Value == null)
                {
                    Utils.displayErrorMessageBox("Jeden z řádků nemá vyplněný název datasetu!", appName, null);
                    return;
                }

                if (row.Cells[2].Value == null) 
                {
                    Utils.displayErrorMessageBox("Jeden z řádků nemá vyplněný název jednotky teploty!", appName, null);
                    return;
                }

                if (measure == null)
                {
                    Utils.displayErrorMessageBox("Název vybrané jednotky teploty neodpovídá žádné hodnotě v databázi!", appName, null);
                    return;
                }

                int id = -1;
                if (row.Cells[0].Value == null)
                {
                    Dataset dataset = new Dataset(id, row.Cells[1].Value.ToString(), measure);
                    newDatasets.Add(dataset);
                }
                else
                {
                    Dataset dataset = new Dataset((int)row.Cells[0].Value, row.Cells[1].Value.ToString(), measure);
                    datasetsToBeUpdated.Add((int)row.Cells[0].Value, dataset);
                }
            }

            foreach (Dataset dataset in datasets.Values)
            {
                // TODO: error - není ve slovníku
                Dataset newDataset = datasetsToBeUpdated[dataset.ID];
                if (newDataset == null)
                {
                    datasetsToBeDeleted.Add(dataset.ID);
                    datasetsToBeUpdated.Remove(dataset.ID);                    
                }
                else
                {
                    
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

            bool success = databaseInterface.updateDatasets(newDatasets, datasetsToBeDeleted, datasetsToBeUpdated.Values.ToList());

            if (success)
            {
                Utils.displayInfoMessageBox("Úprava měst proběhla úspěšně.", appName);
                dataGridViewManageDatasets.Rows.Clear();
                datasets = databaseInterface.getDatasets(databaseInterface.getMeasures());
                fillDataGridView();
            }
            else
            {
                Utils.displayErrorMessageBox("Vyskytla se chyba při úpravě měst v databázi!",
                appName, null);
            }
        }

        private void btnDiscardDatasetChanges_Click(object sender, EventArgs e)
        {
            dataGridViewManageDatasets.Rows.Clear();
            fillDataGridView();
        }

        private void btnReturnDataset_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
