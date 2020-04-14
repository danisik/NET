using DataLayer.Data;
using DataLayer.Utils;
using PresentationLayer.GUIElements;
using PresentationLayer.Window;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace PresentationLayer
{
    public partial class MainWindow : Form
    {
        private readonly DatabaseInterface databaseInterface;
        private Dictionary<String, Dataset> datasets;
        private Dictionary<String, Measure> measures;
        private Dictionary<String, City> cities;
        private Dictionary<int, Record> records;
        private Dataset currentlySelectedDataset;
        private String appName = "";

        private Rectangle dragBoxFromMouseDownDataGridViewDataset;
        private int rowIndexFromMouseDownDataGridViewDataset;
        private int rowIndexOfItemUnderMouseToDropDataGridViewDataset;

        public MainWindow()
        {
            InitializeComponent();
            appName = this.Text;
            databaseInterface = new DatabaseInterface();

            measures = databaseInterface.getMeasures();
            datasets = databaseInterface.getDatasets(measures);
            cities = Utils.sortCities(databaseInterface.getCities());

            initializeComboBoxDataset();
        }

        private void changeButtonStatus(bool status)
        {
            btnNewRecordRow.Enabled = status;
            btnDeleteSelectedRecordRows.Enabled = status;
            btnConfirmRecordChanges.Enabled = status;
            btnDiscardRecordChanges.Enabled = status;
            btnExportCSV.Enabled = status;
        }

        private void initializeComboBoxDataset()
        {
            cmbDataset.Items.Clear();
            changeButtonStatus(false);
            if (datasets.Count > 0)
            {
                cmbDataset.Items.AddRange(datasets.Keys.ToArray());
            }
        }

        private void cmbDataset_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!btnDiscardRecordChanges.Enabled) changeButtonStatus(true);
            dataGridViewDataset.Rows.Clear();

            datasets.TryGetValue(datasets.Keys.ToList()[cmbDataset.SelectedIndex], out Dataset selectedDataset);

            if (selectedDataset == null)
            {
                Utils.displayErrorMessageBox("Dataset neexistuje!", appName);
                return;
            }
            else
            {
                // TODO: check if something in dataset is updated.
                // If true, then display messagebox with options.
                // If false, then display new dataset immediately.

                currentlySelectedDataset = selectedDataset;
                updateMeasureLabel();

                dataGridViewDataset.Rows.Clear();
                fillDataGridView();
            }
        }

        private void dataGridViewDataset_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.ColumnIndex > 0)
            {
                MonthCell monthCell = (MonthCell)dataGridViewDataset.Rows[e.RowIndex].Cells[e.ColumnIndex];
                monthCell.Value = monthCell.CellValue;
            }
        }

        private void dataGridViewDataset_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (e.Control is TextBox)
            {
                var tbox = (e.Control as TextBox);

                tbox.KeyPress -= dataGridViewDataset_TextBoxKeyPress;
                tbox.KeyPress += dataGridViewDataset_TextBoxKeyPress;
            }
        }
        private void dataGridViewDataset_TextBoxKeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == 8) return;

            if (dataGridViewDataset.CurrentCell is MonthCell)
            {
                MonthCell currentCell = (MonthCell) dataGridViewDataset.CurrentCell;
                if (Char.IsDigit(e.KeyChar) || (e.KeyChar == (',')))
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
            }
        }

        private void dataGridViewDataset_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex > 0)
            {
                MonthCell monthCell = (MonthCell)dataGridViewDataset.Rows[e.RowIndex].Cells[e.ColumnIndex];

                String newValue = monthCell.Value.ToString();

                if (!validateMonth(newValue))
                {
                    Utils.displayErrorMessageBox("Zadaná teplota musí být číslo!", appName);
                    monthCell.Value = monthCell.getText();
                    return;
                }
                monthCell.CellValue = Double.Parse(newValue);
                monthCell.Value = monthCell.getText();
            }
        }
      
        private bool validateMonth(String newValue)
        {
            if (!Double.TryParse(newValue, out Double ignored)) return false;
            else return true;
        }
        

        private void fillDataGridView()
        {
            dataGridViewDataset.Rows.Clear();
            records = databaseInterface.getRecords(currentlySelectedDataset.ID, cities);

            foreach (Record record in records.Values)
            {
                DataGridViewRowWithId row = new DataGridViewRowWithId(record.Id);                
                List<Double> months = record.getMonths();

                CityCell cityCell = prepareCityCell();
                row.Cells.Add(cityCell);
                cityCell.Value = record.City.Name;
                cityCell.CityName = record.City.Name;

                foreach (double monthValue in record.getMonths())
                {
                    MonthCell monthCell = new MonthCell();
                    row.Cells.Add(monthCell);
                    monthCell.CellValue = monthValue;
                    monthCell.MeasureTag = currentlySelectedDataset.Measure.Tag;
                    monthCell.Value = monthCell.getText();
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
            DataGridViewRowWithId row = new DataGridViewRowWithId(-1);

            row.Cells.Add(prepareCityCell());

            for (int i = 0; i < 12; i++)
            {
                MonthCell monthCell = new MonthCell();
                row.Cells.Add(monthCell);
                monthCell.MeasureTag = currentlySelectedDataset.Measure.Tag;
                monthCell.Value = monthCell.getText();
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
            List<Record> newRecords = new List<Record>();
            List<int> recordsToBeDeleted = new List<int>();
            Dictionary<int, Record> recordsToBeUpdated = new Dictionary<int, Record>();

            int order = 1;
            foreach (DataGridViewRow row in dataGridViewDataset.Rows)
            {
                DataGridViewRowWithId rowWithId = (DataGridViewRowWithId) row;
                
                if (rowWithId.Cells[0].Value == null)
                {
                    Utils.displayErrorMessageBox("Jeden z řádků nemá zvolené město!", appName);
                    return;
                }

                String cityName = rowWithId.Cells[0].Value.ToString();

                if (!cities.ContainsKey(cityName)) {
                    Utils.displayErrorMessageBox("Zvolené město neexistuje v databázi!", appName);
                    return;
                }


                cities.TryGetValue(cityName, out City city);

                Record record = new Record(rowWithId.Id, city,
                               Double.Parse(((MonthCell) rowWithId.Cells[1]).CellValue.ToString()),
                               Double.Parse(((MonthCell) rowWithId.Cells[2]).CellValue.ToString()),
                               Double.Parse(((MonthCell) rowWithId.Cells[3]).CellValue.ToString()),
                               Double.Parse(((MonthCell) rowWithId.Cells[4]).CellValue.ToString()),
                               Double.Parse(((MonthCell) rowWithId.Cells[5]).CellValue.ToString()),
                               Double.Parse(((MonthCell) rowWithId.Cells[6]).CellValue.ToString()),
                               Double.Parse(((MonthCell) rowWithId.Cells[7]).CellValue.ToString()),
                               Double.Parse(((MonthCell) rowWithId.Cells[8]).CellValue.ToString()),
                               Double.Parse(((MonthCell) rowWithId.Cells[9]).CellValue.ToString()),
                               Double.Parse(((MonthCell) rowWithId.Cells[10]).CellValue.ToString()),
                               Double.Parse(((MonthCell) rowWithId.Cells[11]).CellValue.ToString()),
                               Double.Parse(((MonthCell) rowWithId.Cells[12]).CellValue.ToString()),
                               order
                    );

                if (rowWithId.Id == -1)
                {
                    newRecords.Add(record);
                }
                else
                {
                    recordsToBeUpdated.Add(rowWithId.Id, record);
                }                                
                order++;
            }

            foreach (Record record in records.Values)
            {
                if (!recordsToBeUpdated.ContainsKey(record.Id))
                {
                    recordsToBeDeleted.Add(record.Id);
                    recordsToBeUpdated.Remove(record.Id);
                }
                else
                {
                    recordsToBeUpdated.TryGetValue(record.Id, out Record newRecord);

                    if (newRecord.City.Name.Equals(record.City.Name) &&
                        Utils.doubleEquals(newRecord.January, record.January) &&
                        Utils.doubleEquals(newRecord.February, record.February) &&
                        Utils.doubleEquals(newRecord.March, record.March) &&
                        Utils.doubleEquals(newRecord.April, record.April) &&
                        Utils.doubleEquals(newRecord.May, record.May) &&
                        Utils.doubleEquals(newRecord.June, record.June) &&
                        Utils.doubleEquals(newRecord.July, record.July) &&
                        Utils.doubleEquals(newRecord.August, record.August) &&
                        Utils.doubleEquals(newRecord.September, record.September) &&
                        Utils.doubleEquals(newRecord.October, record.October) &&
                        Utils.doubleEquals(newRecord.November, record.November) &&
                        Utils.doubleEquals(newRecord.December, record.December) &&
                        newRecord.Order == record.Order)
                    {
                        recordsToBeUpdated.Remove(record.Id);
                    }
                }
            }

            if (newRecords.Count == 0 && recordsToBeDeleted.Count == 0 && recordsToBeUpdated.Count == 0)
            {
                Utils.displayInfoMessageBox("Nebyla zaznamenána žádná změna.", appName);
                return;
            }

            bool success = databaseInterface.updateRecords(currentlySelectedDataset.ID, newRecords, recordsToBeDeleted, recordsToBeUpdated);

            if (success)
            {
                Utils.displayInfoMessageBox("Úprava řádek proběhla úspěšně.", appName);
                dataGridViewDataset.Rows.Clear();
                cities = databaseInterface.getCities();
                fillDataGridView();
            }
            else
            {
                Utils.displayErrorMessageBox("Vyskytla se chyba při úpravě záznamů v tabulce!", appName);
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

        private void updateCityCells()
        {
            foreach (DataGridViewRow row in dataGridViewDataset.Rows)
            {
                CityCell cityCell = (CityCell) row.Cells[0];
                cityCell.Items.Clear();
                foreach (String cityName in cities.Keys)
                {
                    cityCell.Items.Add(cityName);
                }
                cityCell.Value = cityCell.CityName;
            }
        }

        private void updateMonthCells()
        {
            foreach (DataGridViewRow row in dataGridViewDataset.Rows)
            {
                for (int i = 1; i < row.Cells.Count; i++)
                {
                    MonthCell monthCell = (MonthCell) row.Cells[i];

                    if (monthCell.MeasureTag == currentlySelectedDataset.Measure.Tag) break;

                    monthCell.MeasureTag = currentlySelectedDataset.Measure.Tag;
                    monthCell.Value = monthCell.getText();
                }
            }
        }

        private void btnManageDatasets_Click(object sender, EventArgs e)
        {
            ManageDatasetsWindow window = new ManageDatasetsWindow(this);
            window.ShowDialog();

            datasets = databaseInterface.getDatasets(measures);
            initializeComboBoxDataset();

            if (currentlySelectedDataset != null)
            {
                if (!datasets.ContainsKey(currentlySelectedDataset.Name))
                {
                    Utils.displayWarningMessageBox("Aktuálně zvolený dataset již neexistuje!", appName);
                    if (datasets.Count > 0)
                    {
                        cmbDataset.SelectedIndex = 0;
                        datasets.TryGetValue(datasets.Keys.ToList()[cmbDataset.SelectedIndex], out Dataset selectedDataset);

                        if (selectedDataset != null)
                        {
                            currentlySelectedDataset = selectedDataset;
                            updateMeasureLabel();
                        }
                    }
                    else
                    {
                        lblDatasetMeasure.Text = "";
                    }
                }
                else
                {
                    cmbDataset.SelectedItem = currentlySelectedDataset.Name;
                    updateMeasureLabel();
                }
            }         
        }

        private void btnManageCities_Click(object sender, EventArgs e)
        {
            ManageCitiesWindow window = new ManageCitiesWindow(this);
            window.ShowDialog();

            cities = databaseInterface.getCities();
            if (currentlySelectedDataset != null) updateCityCells();
        }

        private void btnManageTemperatures_Click(object sender, EventArgs e)
        {
            ManageMeasuresWindow window = new ManageMeasuresWindow(this);
            window.ShowDialog();

            measures = databaseInterface.getMeasures();
            datasets = databaseInterface.getDatasets(measures);            
            if (currentlySelectedDataset != null)
            {
                currentlySelectedDataset = datasets[currentlySelectedDataset.Name];
                updateMonthCells();
                updateMeasureLabel();
            }
        }

        private void updateMeasureLabel()
        {
            lblDatasetMeasure.Text = currentlySelectedDataset.Measure.Name + " [" + currentlySelectedDataset.Measure.Tag + "]";
        }

        private void dataGridViewDataset_MouseMove(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                // If the mouse moves outside the rectangle, start the drag.
                if (dragBoxFromMouseDownDataGridViewDataset != Rectangle.Empty &&
                !dragBoxFromMouseDownDataGridViewDataset.Contains(e.X, e.Y))
                {
                    // Proceed with the drag and drop, passing in the list item.                    
                    DragDropEffects dropEffect = dataGridViewDataset.DoDragDrop(
                          dataGridViewDataset.Rows[rowIndexFromMouseDownDataGridViewDataset],
                          DragDropEffects.Move);
                }
            }
        }

        private void dataGridViewDataset_MouseDown(object sender, MouseEventArgs e)
        {
            // Get the index of the item the mouse is below.
            rowIndexFromMouseDownDataGridViewDataset = dataGridViewDataset.HitTest(e.X, e.Y).RowIndex;

            if (rowIndexFromMouseDownDataGridViewDataset != -1)
            {
                // Remember the point where the mouse down occurred. 
                // The DragSize indicates the size that the mouse can move 
                // before a drag event should be started.                
                Size dragSize = SystemInformation.DragSize;

                // Create a rectangle using the DragSize, with the mouse position being
                // at the center of the rectangle.
                dragBoxFromMouseDownDataGridViewDataset = new Rectangle(
                          new Point(
                            e.X - (dragSize.Width / 2),
                            e.Y - (dragSize.Height / 2)),
                      dragSize);
            }
            else
                // Reset the rectangle if the mouse is not over an item in the ListBox.
                dragBoxFromMouseDownDataGridViewDataset = Rectangle.Empty;
        }

        private void dataGridViewDataset_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void dataGridViewDataset_DragDrop(object sender, DragEventArgs e)
        {
            // The mouse locations are relative to the screen, so they must be 
            // converted to client coordinates.
            Point clientPoint = dataGridViewDataset.PointToClient(new Point(e.X, e.Y));

            // Get the row index of the item the mouse is below. 
            rowIndexOfItemUnderMouseToDropDataGridViewDataset = dataGridViewDataset.HitTest(clientPoint.X, clientPoint.Y).RowIndex;

            // If the drag operation was a move then remove and insert the row.
            if (e.Effect == DragDropEffects.Move)
            {
                DataGridViewRowWithId rowToMove = e.Data.GetData(typeof(DataGridViewRowWithId)) as DataGridViewRowWithId;
                if (rowIndexOfItemUnderMouseToDropDataGridViewDataset == -1 || rowToMove.Index == -1) return;
                dataGridViewDataset.Rows.RemoveAt(rowIndexFromMouseDownDataGridViewDataset);
                dataGridViewDataset.Rows.Insert(rowIndexOfItemUnderMouseToDropDataGridViewDataset, rowToMove);

            }
        }

        private void btnExportCSV_Click(object sender, EventArgs e)
        {
            if (currentlySelectedDataset == null)
            {
                Utils.displayErrorMessageBox("Není zvolený žádný dataset!", appName);
                return;
            }

            if (dataGridViewDataset.Rows.Count == 0)
            {
                Utils.displayWarningMessageBox("V datasetu nejsou žádné záznamy!", appName);
                return;
            }

            List<String> columns = new List<String>();
            List<List<String>> values = new List<List<String>>();

            foreach (DataGridViewColumn column in dataGridViewDataset.Columns)
            {
                columns.Add(column.HeaderText);
            }

            foreach (DataGridViewRow row in dataGridViewDataset.Rows)
            {
                List<String> rowValues = new List<String>();

                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell is MonthCell)
                    {
                        MonthCell monthCell = (MonthCell)cell;
                        rowValues.Add(monthCell.CellValue.ToString());
                    }
                    else
                    {
                        rowValues.Add(cell.Value.ToString());
                    }

                }

                values.Add(rowValues);
            }

            bool success = Utils.exportDatasetToCSV(columns, values);

            if (success)
            {
                Utils.displayInfoMessageBox("Export dat z datasetu '" + currentlySelectedDataset.Name + "' byl úspešně proveden.", appName);
            }
            else
            {
                Utils.displayErrorMessageBox("Vyskytla se chyba při exportu dat z datasetu '" + currentlySelectedDataset.Name + "'", appName);
            }

        }

        public DatabaseInterface DatabaseInterface
        {
            get
            {
                return databaseInterface;
            }
        }

        public String AppName
        {
            get
            {
                return appName;
            }
        }
    }
}
