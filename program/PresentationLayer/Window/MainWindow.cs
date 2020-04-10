using DataLayer.Data;
using DataLayer.Utils;
using PresentationLayer.GUIElements;
using PresentationLayer.Window;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer
{
    public partial class MainWindow : Form
    {
        private readonly DatabaseInterface databaseInterface;
        private Dictionary<String, Dataset> datasets;
        private Dictionary<String, Measure> measures;
        private Dictionary<String, City> cities;
        private Dataset currentlySelectedDataset;
        private String appName = "";
        private Boolean isAppClosing = false;

        public MainWindow()
        {
            InitializeComponent();
            appName = this.Text;
            databaseInterface = new DatabaseInterface();                      

            measures = databaseInterface.getMeasures();
            datasets = databaseInterface.getDatasets(measures);
            cities = Utils.sortCities(databaseInterface.getCities());

            initializeComboBoxDataset();
            initializeComboBoxMeasure();
        }        

        private void initializeComboBoxDataset()
        {
            cmbDataset.Items.AddRange(datasets.Keys.ToArray());
        }

        private void initializeComboBoxMeasure()
        {
            cmbMeasure.Items.AddRange(measures.Keys.ToArray());
            if (cmbMeasure.Items.Count > 0) cmbMeasure.SelectedIndex = 0;
        }

        private void cmbDataset_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridViewDataset.Rows.Clear();

            Dataset selectedDataset = null;
            datasets.TryGetValue(datasets.Keys.ToList()[cmbDataset.SelectedIndex], out selectedDataset);

            if (selectedDataset == null)
            {
                Utils.displayErrorMessageBox("Dataset neexistuje!", appName, null);
                return;
            }
            else
            {
                // TODO: check if something in dataset is updated.
                // If true, then display messagebox with options.
                // If false, then display new dataset immediately.

                currentlySelectedDataset = selectedDataset;
                cmbMeasure.SelectedItem = selectedDataset.Measure.Name;

                dataGridViewDataset.Rows.Clear();
                fillDataGridView();                
            }
        }

        private void cmbMeasure_SelectedIndexChanged(object sender, EventArgs e)
        {
            Measure selectedMeasure = null;
            measures.TryGetValue(cmbMeasure.SelectedItem.ToString(), out selectedMeasure);

            if (selectedMeasure == null)
            {
                Utils.displayErrorMessageBox("Tato jednotka teploty neexistuje v databázi!", appName, null);
                return;
            }
            else
            {                
                // TODO: update measure tags in every cell.
            }
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            isAppClosing = true;
        }

        private void dataGridViewDataset_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            /* TODO: Test inserted values for city or months.
            if (String.IsNullOrEmpty(e.FormattedValue.ToString()) || isAppClosing)
            {
                return;
            }

            DataGridViewColumn validated_column = dataGridViewDataset.Columns[e.ColumnIndex];

            if (validated_column.Name.Equals("Město")) validateCity(e);
            else validateMonth(e);
            */
        }

        private void validateCity(DataGridViewCellValidatingEventArgs newValue)
        {
            if (newValue.FormattedValue.ToString().Length > 100)
            {
                Utils.displayErrorMessageBox("Název města je příliš dlouhý!", appName, newValue);
                return;
            }
        }

        private void validateMonth(DataGridViewCellValidatingEventArgs newValue)
        {
            Double ignored = new Double();

            if (!Double.TryParse(newValue.FormattedValue.ToString(), out ignored))
            {
                Utils.displayErrorMessageBox("Zadaná teplota musí být číslo!", appName, newValue);
                return;
            }
        }

        private void dataGridViewDataset_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                return;
            }

            // TODO: Delete temperature tag in value cell.
            //DataGridViewTextBoxCell cell = (DataGridViewTextBoxCell) dataGridViewDataset.Rows[e.RowIndex].Cells[e.ColumnIndex];


        }

        private void dataGridViewDataset_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                return;
            }

            // TODO: Add temperature tag after value for every month cell.
            //DataGridViewTextBoxCell cell = (DataGridViewTextBoxCell)dataGridViewDataset.Rows[e.RowIndex].Cells[e.ColumnIndex];
            //cell.Value = cell.Value + " " + currentlySelectedDataset.Measure.Tag;
        }

        private void fillDataGridView()
        {
            List<Record> records = Utils.sortedRecordsByOrder(
                databaseInterface.getRecords(currentlySelectedDataset.Name, cities)
                );

            foreach(Record record in records)
            {
                DataGridViewRow row = new DataGridViewRow();                
                List<Double> months = record.getMonths();

                CityCell cityCell = prepareCityCell();
                row.Cells.Add(cityCell);
                cityCell.Value = record.City.Name;

                foreach(Double month in months)
                {
                    MonthCell monthCell = new MonthCell();
                    row.Cells.Add(monthCell);
                    monthCell.Value = month;
                }
                dataGridViewDataset.Rows.Add(row);
            }            
        }

        private CityCell prepareCityCell() 
        {
            CityCell cityCell = new CityCell();
            foreach (String cityName in cities.Keys)
            {
                cityCell.Items.Add(cityName);
            }

            return cityCell;
        }

        private void btnNewRecordRow_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            row.Cells.Add(prepareCityCell());

            for (int i = 0; i < 12; i++)
            {
                MonthCell monthCell = new MonthCell();
                row.Cells.Add(monthCell);
            }
            dataGridViewDataset.Rows.Add(row);
        }

        private void btnDiscardRecordChanges_Click(object sender, EventArgs e)
        {
            dataGridViewDataset.Rows.Clear();
            fillDataGridView();
        }

        private void btnConfirmRecordChanges_Click(object sender, EventArgs e)
        {
            List<Record> newRows = new List<Record>();
            List<Record> rowsToBeDeleted = new List<Record>();
            List<Record> rowsToBeUpdated = new List<Record>();

            // TODO: check if rows can be inserted or deleted + updated.
            /*
            if (newRows.Count == 0 && rowsToBeDeleted.Count == 0 && rowsToBeUpdated.Count == 0)
            {
                Utils.displayInfoMessageBox("Nebyla zaznamenána žádná změna.", appName);
                return;
            }
            */

            //bool success = databaseInterface.updateRecords();
            bool success = true;

            if (success)
            {
                Utils.displayInfoMessageBox("Úprava řádek proběhla úspěšně.", appName);
                dataGridViewDataset.Rows.Clear();
                cities = databaseInterface.getCities();
                fillDataGridView();
            }
            else
            {
                Utils.displayErrorMessageBox("Vyskytla se chyba při úpravě záznamů v tabulce!", appName, null);
            }
        }

        private void btnDeleteSelectedRecordRows_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection selectedRows = dataGridViewDataset.SelectedRows;

            foreach (DataGridViewRow row in selectedRows)
            {
                dataGridViewDataset.Rows.Remove(row);
            }
        }

        private void btnManageDatasets_Click(object sender, EventArgs e)
        {
            new ManageDatasetsWindow(databaseInterface, appName).Show();
        }

        private void btnManageCities_Click(object sender, EventArgs e)
        {
            new ManageCitiesWindow(databaseInterface, appName).Show();
        }
    }
}
