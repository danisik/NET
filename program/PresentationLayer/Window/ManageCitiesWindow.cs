﻿using DataLayer.Data;
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
        private readonly DatabaseConnection databaseConnection;
        private Dictionary<String, City> cities;

        public ManageCitiesWindow(DatabaseConnection databaseConnection, Dictionary<String, City> cities)
        {
            InitializeComponent();
            this.databaseConnection = databaseConnection;
            this.cities = cities;

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
                String cityName = row.Cells[0].Value.ToString();
                if (cityName.Length == 0) continue;

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
                    // TODO test if database contains records with this city name.
                    // if true, then display prepared error message.
                    // if false, then add cityname to delete list.
                    bool test = false;
                    if (test)
                    {
                        citiesToBeDeleted.Add(cityName);
                    }
                    else 
                    {
                        Utils.displayErrorMessageBox("Nelze upravit tabulku měst, protože název města '" + cityName + "' je používán v jednotlivých záznamech.",
                        ", ", null);
                    }                    
                }
                else
                {
                    newCities.Remove(cityName);
                }
            }

            // TODO update table "City".
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