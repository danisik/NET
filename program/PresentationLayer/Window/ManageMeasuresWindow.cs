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
            this.Text = mainWindow.AppName + " - Správa jednotek teplot";
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
            List<String> measuresToBeDeleted = new List<String>();
            Dictionary<String, Measure> newMeasures = new Dictionary<String, Measure>();
            List<Measure> measuresToBeUpdated = new List<Measure>();

            foreach (DataGridViewRow row in dataGridViewManageMeasures.Rows)
            {

                if (row.Cells[0].Value == null)
                {
                    Utils.displayErrorMessageBox("Jeden z řádků nemá vyplněný název jednotky teploty!", appName);
                    return;
                }

                if (row.Cells[1].Value == null) 
                {
                    Utils.displayErrorMessageBox("Jeden z řádků nemá vyplněný symbol jednotky teploty!", appName);
                    return;
                }

                String measureName = row.Cells[0].Value.ToString();
                String measureTag = row.Cells[1].Value.ToString();

                if (!newMeasures.ContainsKey(measureName)) newMeasures.Add(measureName, new Measure(measureName, measureTag));
            }

            foreach (String measureName in measures.Keys)
            {
                if (!newMeasures.ContainsKey(measureName))
                {
                    bool isPresented = databaseInterface.testIfMeasureIsPresentedInDatasets(measureName);
                    if (!isPresented)
                    {
                        measuresToBeDeleted.Add(measureName);
                    }
                    else
                    {
                        Utils.displayErrorMessageBox("Nelze upravit tabulku jednotek teplot, protože název jednotky teploty '" + measureName + "' je používán v jednotlivých datasetech.",
                        appName);
                        return;
                    }
                }
                else
                {
                    Measure newMeasure = null;
                    newMeasures.TryGetValue(measureName, out newMeasure);
                    if (newMeasure == null) continue;

                    Measure oldMeasure = null;
                    measures.TryGetValue(measureName, out oldMeasure);
                    if (oldMeasure == null) continue;

                    if (!newMeasure.Tag.Equals(oldMeasure.Tag)) measuresToBeUpdated.Add(newMeasure);
                    newMeasures.Remove(measureName);
                }
            }

            if (measuresToBeDeleted.Count == 0 && newMeasures.Count == 0 && measuresToBeUpdated.Count == 0)
            {
                Utils.displayInfoMessageBox("Nebyla zaznamenána žádná změna.", appName);
                return;
            }
            bool success = databaseInterface.updateMeasures(newMeasures.Values.ToList(), measuresToBeDeleted, measuresToBeUpdated);

            if (success)
            {
                Utils.displayInfoMessageBox("Úprava měst proběhla úspěšně.", appName);
                dataGridViewManageMeasures.Rows.Clear();
                measures = databaseInterface.getMeasures();
                fillDataGridView();
            }
            else
            {
                Utils.displayErrorMessageBox("Vyskytla se chyba při úpravě jednotek teplot v databázi!",
                appName);
            }
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
