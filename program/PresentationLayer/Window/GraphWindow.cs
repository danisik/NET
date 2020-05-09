using DataLayer.Data;
using DataLayer.Model;
using DataLayer.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace PresentationLayer.Window
{
    /// <summary>
    /// Window for displaying data into graph.
    /// </summary>
    public partial class GraphWindow : Form
    {
        // Database interface.
        private readonly DatabaseInterface databaseInterface;

        // Application name.
        private String appName = "";

        // Main window instance.
        private MainWindow mainWindow;

        // Map of graph types.
        private Dictionary<String, EGraphCustomType> graphTypes;

        // Currently selected graph type.
        private EGraphCustomType selectedGraphType;

        // Curently selected dataset.
        private Dataset selectedDataset;

        // Currently selected Month.
        private String selectedMonth = "";

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="mainWindow"> Instance of main window. </param>
        public GraphWindow(MainWindow mainWindow)
        {
            InitializeComponent();

            this.databaseInterface = mainWindow.DatabaseInterface;
            this.Text = mainWindow.AppName + " - Grafy";
            this.appName = mainWindow.AppName;
            this.mainWindow = mainWindow;

            graphTypes = new Dictionary<String, EGraphCustomType>();     

            initializeGraphsType();
            initializeDatasets();            
        }

        /// <summary>
        /// Initialize graph types with given names.
        /// </summary>
        private void initializeGraphsType()
        {
            graphTypes.Add("Průměrná teplota ve všech městech po měsíci", new EGraphCustomType("Průměrná teplota ve všech městech po měsíci", EDataType.NULL));
            graphTypes.Add("Porovnání teplot více měst po měsících", new EGraphCustomType("Porovnání teplot více měst po měsících", EDataType.CITY));
            graphTypes.Add("Teplota ve městech za měsíc", new EGraphCustomType("Teplota ve městech za měsíc", EDataType.MONTH));

            foreach (String graphTypeName in graphTypes.Keys)
            {
                cmbSelectedGraphType.Items.Add(graphTypeName);
            }
        }

        /// <summary>
        /// Initialize datasets in combobox.
        /// </summary>
        private void initializeDatasets()
        {
            foreach (String datasetName in this.mainWindow.Datasets.Keys)
            {
                cmbSelectedDatasetGraph.Items.Add(datasetName);
            }
        }

        /// <summary>
        /// Initialize cities / months in listbox, depends on selected graph type.
        /// </summary>
        private void initializeSelectedData()
        {
            lsbSelectedData.Items.Clear();
            switch (selectedGraphType.DataType)
            {
                case EDataType.NULL:
                    lsbSelectedData.Enabled = false;
                    break;
                case EDataType.CITY:
                    
                    lsbSelectedData.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
                    
                    foreach (String cityName in databaseInterface.getCitiesInDataset(selectedDataset.ID))
                    {
                        lsbSelectedData.Items.Add(cityName);
                    }

                    lsbSelectedData.Enabled = true;
                    break;
                case EDataType.MONTH:             
                    
                    foreach (String month in this.mainWindow.Months)
                    {
                        lsbSelectedData.Items.Add(month);
                    }
                    lsbSelectedData.SelectionMode = SelectionMode.One;

                    lsbSelectedData.Enabled = true;
                    if (selectedMonth.Length > 0) lsbSelectedData.SelectedItem = selectedMonth;
                    break;
                default:
                    return;
            }            
        }

        /// <summary>
        /// Display specific data into graph.
        /// </summary>
        /// <param name="title"></param>
        private void displayDataIntoGraph(String title)
        {            
            this.chartWithDisplayedDataset.Series.Clear();
            this.chartWithDisplayedDataset.Titles.Clear();
            this.chartWithDisplayedDataset.Legends.Clear();
            this.chartWithDisplayedDataset.Palette = ChartColorPalette.EarthTones;
            this.chartWithDisplayedDataset.ChartAreas[0].AxisX.LabelStyle.Font = new Font("Arial", 8, FontStyle.Regular);
            this.chartWithDisplayedDataset.ChartAreas[0].AxisY.LabelStyle.Font = new Font("Arial", 8, FontStyle.Regular);
            this.chartWithDisplayedDataset.ChartAreas[0].AxisX.Interval = 1;
            this.chartWithDisplayedDataset.ChartAreas[0].AxisX.LineWidth = 0;
            this.chartWithDisplayedDataset.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            this.chartWithDisplayedDataset.ChartAreas[0].AxisX.MinorGrid.Enabled = false;
            this.chartWithDisplayedDataset.ChartAreas[0].AxisX.MajorTickMark.Enabled = false;
            this.chartWithDisplayedDataset.ChartAreas[0].AxisX.MinorTickMark.Enabled = false;

            switch (selectedGraphType.DataType)
            {
                case EDataType.NULL:
                    createDataAverageTemperatureInAllCities(title);
                    title += " v datasetu '" + selectedDataset.Name + "'";
                    this.chartWithDisplayedDataset.Titles.Add(title);
                    lsbSelectedData.Enabled = false;

                    break;
                case EDataType.CITY:
                    createDataCompareTemperaturesInSelectedCities(title);
                    title += " v datasetu '" + selectedDataset.Name + "'";
                    this.chartWithDisplayedDataset.Titles.Add(title);
                    
                    break;
                case EDataType.MONTH:
                    createDataTemperaturesInCitiesInMonth(title);
                    title += " '" + selectedMonth + "' v datasetu '" + selectedDataset.Name + "'";
                    this.chartWithDisplayedDataset.Titles.Add(title);
                    
                    break;
            }
            this.chartWithDisplayedDataset.Titles[0].Font = new Font("Arial", 15, FontStyle.Bold);
        }

        /// <summary>
        /// Display data for 'Average Temperature In All Cities'.
        /// </summary>
        /// <param name="title"> Title of graph. </param>
        private void createDataAverageTemperatureInAllCities(String title)
        {
            Series series = this.chartWithDisplayedDataset.Series.Add(title);            
            Dictionary<int, List<double>> monthValues = new Dictionary<int, List<double>>();

            Dictionary<int, Record> records = databaseInterface.getRecords(selectedDataset.ID, this.mainWindow.Cities);

            double min = 0, max = 0;
            int i = 0;
            foreach (Record record in records.Values)
            {
                foreach (double monthValue in record.getMonths())
                {
                    if (!monthValues.ContainsKey(i)) monthValues.Add(i, new List<double>());
                    monthValues[i].Add(monthValue);
                    i++;
                }
                i = 0;
            }

            Dictionary<String, double> averageValuesPerMonth = new Dictionary<String, double>();
            List<String> months = this.mainWindow.Months;

            i = 0;
            foreach (List<double> values in monthValues.Values)
            {
                double averageValue = Utils.getAverageValue(values);
                averageValuesPerMonth.Add(months[i], averageValue);
                i++;

                if (averageValue > max) max = averageValue;
                if (averageValue < min) min = averageValue;
            }

            foreach (String month in averageValuesPerMonth.Keys)
            {
                series.Points.AddXY(month, averageValuesPerMonth[month]);
            }

            setMinMaxAxisY(min, max);
        }

        /// <summary>
        /// Display data for 'Compare Temperatures In Selected Cities'.
        /// </summary>
        /// <param name="title"> Title of graph. </param>
        private void createDataCompareTemperaturesInSelectedCities(String title)
        {
            Dictionary<int, Record> records = databaseInterface.getRecords(selectedDataset.ID, this.mainWindow.Cities);
            
            List<String> months = this.mainWindow.Months;

            Legend legend = this.chartWithDisplayedDataset.Legends.Add("Města");
            legend.LegendStyle = LegendStyle.Column;
            legend.CellColumns.Add(new LegendCellColumn()
            {
                ColumnType = LegendCellColumnType.SeriesSymbol,
                MinimumWidth = 250,
                MaximumWidth = 250
            });
            legend.CellColumns.Add(new LegendCellColumn()
            {
                ColumnType = LegendCellColumnType.Text,
                Alignment = ContentAlignment.MiddleLeft
            });

            double min = 0, max = 0;
            foreach (Record record in records.Values)
            {
                if (!lsbSelectedData.SelectedItems.Contains(record.City.Name)) continue;
                Series series = this.chartWithDisplayedDataset.Series.Add(record.City.Name);
                
                List<double> monthValues = record.getMonths();

                for (int i = 0; i < monthValues.Count; i++)
                {
                    series.Points.AddXY(months[i], monthValues[i]);

                    if (monthValues[i] > max) max = monthValues[i];
                    if (monthValues[i] < min) min = monthValues[i];
                }
            }
        
            setMinMaxAxisY(min, max);            
        }

        /// <summary>
        /// Display data for 'Temperatures In Cities In Month'.
        /// </summary>
        /// <param name="title"> Title of graph. </param>
        private void createDataTemperaturesInCitiesInMonth(String title)
        {
            Dictionary<int, Record> records = databaseInterface.getRecords(selectedDataset.ID, this.mainWindow.Cities);

            Series series = this.chartWithDisplayedDataset.Series.Add(title);

            this.chartWithDisplayedDataset.ChartAreas[0].AxisY.Interval = 1;

            double min = 0, max = 0;
            foreach (Record record in records.Values)
            {
                double monthValue = record.getMonths()[lsbSelectedData.SelectedIndex];
                series.Points.AddXY(record.City.Name, monthValue);

                if (monthValue > max) max = monthValue;
                if (monthValue < min) min = monthValue;
            }

            setMinMaxAxisY(min, max);
        }

        /// <summary>
        /// Set minimum and maximum for Y Axis.
        /// </summary>
        /// <param name="min"> Minimum value of Y axis.</param>
        /// <param name="max"> Maximum value of Y axis. </param>
        private void setMinMaxAxisY(double min, double max)
        {
            this.chartWithDisplayedDataset.ChartAreas[0].AxisY.Minimum = min;
            this.chartWithDisplayedDataset.ChartAreas[0].AxisY.Maximum = max + 2;
        }

        /// <summary>
        /// Click event for btnReturnFromGraph.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReturnFromGraph_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Selected Value Changed event for cmbSelectedGraphType.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbSelectedGraphType_SelectedValueChanged(object sender, EventArgs e)
        {
            graphTypes.TryGetValue(cmbSelectedGraphType.SelectedItem.ToString(), out EGraphCustomType graphType);

            if (selectedGraphType != null && selectedGraphType.Name.Equals(graphType.Name)) return;

            if (graphType != null)
            {
                selectedGraphType = graphType;
            }        

            if (selectedGraphType != null && selectedDataset != null)
            {
                initializeSelectedData();
                if (selectedGraphType.DataType != EDataType.NULL) lsbSelectedData.Enabled = true;
                this.chartWithDisplayedDataset.Series.Clear();
                this.chartWithDisplayedDataset.Titles.Clear();
                if (selectedGraphType.DataType != EDataType.NULL) return;
                displayDataIntoGraph(selectedGraphType.Name);
            }
        }

        /// <summary>
        /// Selected Value Changed for cmbSelectedDatasetGraph.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbSelectedDatasetGraph_SelectedValueChanged(object sender, EventArgs e)
        {
            this.mainWindow.Datasets.TryGetValue(cmbSelectedDatasetGraph.SelectedItem.ToString(), out Dataset dataset);

            if (selectedDataset != null && selectedDataset.Name.Equals(dataset.Name)) return;

            if (dataset != null)
            {
                selectedDataset = dataset;
            }

            if (selectedGraphType != null && selectedDataset != null)
            {
                initializeSelectedData();
                if (selectedGraphType.DataType != EDataType.NULL) lsbSelectedData.Enabled = true;
                if (selectedGraphType.DataType != EDataType.NULL && lsbSelectedData.SelectedItems.Count == 0) return;
                displayDataIntoGraph(selectedGraphType.Name);
            }
        }

        /// <summary>
        /// SelectedValueChanged for listbox lbsSelectedData.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbsSelectedData_SelectedValueChanged(object sender, EventArgs e)
        {               
            if (selectedGraphType != null && selectedDataset != null)
            {
                switch(selectedGraphType.DataType)
                { 
                    case EDataType.MONTH:
                        selectedMonth = lsbSelectedData.SelectedItem.ToString(); ;
                        break;
                    default:
                        break; ;
                }

                displayDataIntoGraph(selectedGraphType.Name);
            }
        }

        /// <summary>
        /// Display tooltip text for every line in chart.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chartWithDisplayedDataset_GetToolTipText(object sender, ToolTipEventArgs e)
        {
            switch (e.HitTestResult.ChartElementType)
            {
                case ChartElementType.DataPoint:
                    switch (selectedGraphType.DataType)
                    {
                        case EDataType.NULL:
                            var dataPointNull = e.HitTestResult.Series.Points[e.HitTestResult.PointIndex];
                            e.Text = string.Format("Měsíc:  {0}\nPrůměrná teplota:  {1} [{2}]", dataPointNull.AxisLabel, dataPointNull.YValues[0], selectedDataset.Measure.Tag);
                            break;
                        case EDataType.CITY:
                            var dataPointCity = e.HitTestResult.Series.Points[e.HitTestResult.PointIndex];
                            e.Text = string.Format("Teplota v měsíci {0}:  {1} [{2}]", dataPointCity.AxisLabel, dataPointCity.YValues[0], selectedDataset.Measure.Tag);
                            break;
                        case EDataType.MONTH:
                            var dataPointMonth = e.HitTestResult.Series.Points[e.HitTestResult.PointIndex];
                            e.Text = string.Format("Město:  {0}\nTeplota v měsíci {1}:  {2} [{3}]", dataPointMonth.AxisLabel, selectedMonth, dataPointMonth.YValues[0], selectedDataset.Measure.Tag);
                            break;
                    }
                    break;
            }
        }
    }
}
