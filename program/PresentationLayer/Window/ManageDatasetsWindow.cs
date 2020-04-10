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

        public ManageDatasetsWindow(DatabaseInterface databaseInterface, String appName)
        {
            InitializeComponent();
            this.databaseInterface = databaseInterface;
            this.appName = appName;
            this.datasets = databaseInterface.getDatasets(databaseInterface.getMeasures());

            fillDataGridView();
        }

        private void fillDataGridView()
        {
            Dictionary<String, Measure> measures = databaseInterface.getMeasures();

            foreach (Dataset dataset in datasets.Values)
            {
                DataGridViewRow row = new DataGridViewRow();

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
            /*
            List<Dataset> datasetsToBeDeleted = new List<Dataset>();
            List<Dataset> newDatasets = new List<Dataset>();
            List<Dataset> datasetsToBeUpdated = new List<Dataset>();

            // Get new city names.
            foreach (DataGridViewRow row in dataGridViewManageDatasets.Rows)
            {
                String cityName = row.Cells[0].Value.ToString();
                if (cityName.Length == 0) continue;

                if (!newDatasets.Contains(cityName)) newDatasets.Add(cityName);
            }

            // Check if currently stored city names in database are presented in new list.
            foreach (String cityName in cities.Keys)
            {
                newDatasets.Remove(cityName);
            }

            if (newDatasets.Count == 0 && datasetsToBeDeleted.Count == 0)
            {
                Utils.displayInfoMessageBox("Nebyla zaznamenána žádná změna.", appName);
                return;
            }

            bool success = databaseInterface.updateDatasets(newDatasets, datasetsToBeDeleted);

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
            */
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
