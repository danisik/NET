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
    public partial class ManageCitiesWindow : Form
    {
        private readonly DatabaseInterface databaseInterface;
        private Dictionary<String, City> cities;
        private String appName = "";
        private MainWindow mainWindow;

        public ManageCitiesWindow(MainWindow mainWindow)
        {
            InitializeComponent();
            this.databaseInterface = mainWindow.DatabaseInterface;
            this.appName = mainWindow.AppName;
            this.mainWindow = mainWindow;
            this.cities = databaseInterface.getCities();

            fillDataGridView();
        }

        private void fillDataGridView()
        {
            foreach(String cityName in cities.Keys)
            {
                DataGridViewRow row = new DataGridViewRow();

                DataGridViewTextBoxCell cell = new DataGridViewTextBoxCell();                
                row.Cells.Add(cell);
                cell.Value = cityName;

                dataGridViewManageCities.Rows.Add(row);
            }
        }

        private void btnConfirmChanges_Click(object sender, EventArgs e)
        {
            List<String> citiesToBeDeleted = new List<String>();
            List<String> newCities = new List<String>();
            
            // Get new city names.
            foreach (DataGridViewRow row in dataGridViewManageCities.Rows)
            {

                if (row.Cells[0].Value == null)
                {
                    Utils.displayErrorMessageBox("Jeden z řádků nemá vyplněný název města!", appName, null);
                    return;
                }

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
        }

        private void btnDiscardChanges_Click(object sender, EventArgs e)
        {
            dataGridViewManageCities.Rows.Clear();
            fillDataGridView();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNewCityRow_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            DataGridViewTextBoxCell cell = new DataGridViewTextBoxCell();
            row.Cells.Add(cell);
            dataGridViewManageCities.Rows.Add(row);
        }

        private void btnDeleteSelectedCityRow_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection selectedRows = dataGridViewManageCities.SelectedRows;            
            
            foreach (DataGridViewRow row in selectedRows)
            {                          
                dataGridViewManageCities.Rows.Remove(row);
            }
        }
    }
}
