using DataLayer.Data;
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
    public partial class ManageMeasuresWindow : Form
    {
        private readonly DatabaseInterface databaseInterface;
        private Dictionary<String, Measure> measures;
        private String appName = "";
        private MainWindow mainWindow;

        public ManageMeasuresWindow(MainWindow mainWindow)
        {
            InitializeComponent();
            this.databaseInterface = mainWindow.DatabaseInterface;
            this.appName = mainWindow.AppName;
            this.mainWindow = mainWindow;
            this.measures = databaseInterface.getMeasures();

            fillDataGridView();
        }

        private void fillDataGridView()
        {
            foreach (Measure measure in measures.Values)
            {
                DataGridViewRow row = new DataGridViewRow();
                DataGridViewTextBoxCell nameCell = new DataGridViewTextBoxCell();
                row.Cells.Add(nameCell);
                nameCell.Value = measure.Name;

                DataGridViewTextBoxCell tagCell = new DataGridViewTextBoxCell();
                row.Cells.Add(tagCell);
                tagCell.Value = measure.Tag;

                dataGridViewManageMeasures.Rows.Add(row);
            }
        }

        private void btnNewMeasureRow_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            DataGridViewTextBoxCell nameCell = new DataGridViewTextBoxCell();
            row.Cells.Add(nameCell);

            DataGridViewTextBoxCell tagCell = new DataGridViewTextBoxCell();
            row.Cells.Add(tagCell);

            dataGridViewManageMeasures.Rows.Add(row);
        }

        private void btnDeleteSelectedMeasuresRow_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection selectedRows = dataGridViewManageMeasures.SelectedRows;

            foreach (DataGridViewRow row in selectedRows)
            {
                dataGridViewManageMeasures.Rows.Remove(row);
            }
        }

        private void btnConfirmMeasureChanges_Click(object sender, EventArgs e)
        {
            // TODO: complete 



            /*
             
            List<int> datasetsToBeDeleted = new List<int>();
            List<Dataset> newDatasets = new List<Dataset>();
            Dictionary<int, Dataset> datasetsToBeUpdated = new Dictionary<int,Dataset>();






            List<String> citiesToBeDeleted = new List<String>();
            List<String> newCities = new List<String>();

            // Get new city names.
            foreach (DataGridViewRow row in dataGridViewManageCities.Rows)
            {

                if (row.Cells[0].Value == null) continue;
                String cityName = row.Cells[0].Value.ToString();

                if (!newCities.Contains(cityName)) newCities.Add(cityName);
            }

            // Check if currently stored city names in database are presented in new list.
            foreach (String cityName in cities.Keys)
            {
                // If currently stored city name is not presented in new list, then check
                // if deleting this city will result in database incompatibility.
                // Need to check if any record contains this city name.
                if (!newCities.Contains(cityName))
                {
                    bool isPresented = databaseInterface.testIfCityIsPresentedInRecords(cityName);
                    if (!isPresented)
                    {
                        citiesToBeDeleted.Add(cityName);
                    }
                    else
                    {
                        Utils.displayErrorMessageBox("Nelze upravit tabulku měst, protože název města '" + cityName + "' je používán v jednotlivých záznamech.",
                        appName, null);
                        return;
                    }
                }
                else
                {
                    newCities.Remove(cityName);
                }
            }

            if (newCities.Count == 0 && citiesToBeDeleted.Count == 0)
            {
                Utils.displayInfoMessageBox("Nebyla zaznamenána žádná změna.", appName);
                return;
            }

            bool success = databaseInterface.updateCities(newCities, citiesToBeDeleted);

            if (success)
            {
                Utils.displayInfoMessageBox("Úprava měst proběhla úspěšně.", appName);
                dataGridViewManageCities.Rows.Clear();
                cities = databaseInterface.getCities();
                fillDataGridView();
            }
            else
            {
                Utils.displayErrorMessageBox("Vyskytla se chyba při úpravě měst v databázi!",
                appName, null);
            }
            */
        }

        private void btnDiscardMeasureChanges_Click(object sender, EventArgs e)
        {
            dataGridViewManageMeasures.Rows.Clear();
            fillDataGridView();
        }

        private void btnReturnMeasure_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
