using DataLayer.Data;
using DataLayer.Model;
using DataLayer.Utils;
using PresentationLayer.GUIElements;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace PresentationLayer.Window
{
    public partial class GraphWindow : Form
    {
        private readonly DatabaseInterface databaseInterface;
        private String appName = "";
        private MainWindow mainWindow;

        private Dictionary<String, GraphCustomType> graphTypes;
        private GraphCustomType selectedGraphType;
        private Dataset selectedDataset;
        private List<String> selectedCities;
        private String selectedMonth = "";

        public GraphWindow(MainWindow mainWindow)
        {
            InitializeComponent();

            this.databaseInterface = mainWindow.DatabaseInterface;
            this.Text = mainWindow.AppName + " - Grafy";
            this.appName = mainWindow.AppName;
            this.mainWindow = mainWindow;

            graphTypes = new Dictionary<String, GraphCustomType>();
            selectedCities = new List<String>();

            initializeGraphsType();
            initializeDatasets();            
        }

        private void initializeGraphsType()
        {
            graphTypes.Add("Průměrná teplota ve všech městech po měsíci", new GraphCustomType("Průměrná teplota ve všech městech po měsíci", EDataType.NULL));
            graphTypes.Add("Porovnání teplot více měst po měsících", new GraphCustomType("Porovnání teplot více měst po měsících", EDataType.CITY));
            graphTypes.Add("Teplota ve městech za měsíc", new GraphCustomType("Teplota ve městech za měsíc", EDataType.MONTH));

            foreach (String graphTypeName in graphTypes.Keys)
            {
                cmbSelectedGraphType.Items.Add(graphTypeName);
            }
        }

        private void initializeDatasets()
        {
            foreach (String datasetName in this.mainWindow.Datasets.Keys)
            {
                cmbSelectedDatasetGraph.Items.Add(datasetName);
            }
        }

        private void initializeSelectedData()
        {
            cmbSelectedData.Items.Clear();
            switch (selectedGraphType.DataType)
            {
                case EDataType.NULL:
                    lblSelectedDatas.Text = "";
                    cmbSelectedData.Enabled = false;                    
                    break;
                case EDataType.CITY:
                    lblSelectedDatas.Text = "Vybraná města:";
                    lblSelectedDatas.Location = new Point(12, 69);
                    cmbSelectedData.Items.AddRange(this.mainWindow.Cities.Keys.ToArray());
                    cmbSelectedData.Enabled = true;
                    if (selectedMonth.Length > 0) cmbSelectedData.SelectedItem = selectedMonth;
                    break;
                case EDataType.MONTH:
                    lblSelectedDatas.Text = "Vybraný měsíc:";
                    lblSelectedDatas.Location = new Point(12, 69);
                    cmbSelectedData.Items.AddRange(this.mainWindow.Months.ToArray());
                    cmbSelectedData.Enabled = true;
                    if (selectedMonth.Length > 0) cmbSelectedData.SelectedItem = selectedMonth;
                    break;
                default:
                    return;
            }            
        }

        private void displayDataIntoGraph(String title)
        {            
            this.chartWithDisplayedDataset.Series.Clear();
            this.chartWithDisplayedDataset.Titles.Clear();            
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
                    cmbSelectedData.Enabled = false;

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

        private void createDataCompareTemperaturesInSelectedCities(String title)
        {

        }

        private void createDataTemperaturesInCitiesInMonth(String title)
        {
            Dictionary<int, Record> records = databaseInterface.getRecords(selectedDataset.ID, this.mainWindow.Cities);
            Dictionary<String, double> values = new Dictionary<String, double>();

            Series series = this.chartWithDisplayedDataset.Series.Add(title);

            this.chartWithDisplayedDataset.ChartAreas[0].AxisY.Interval = 1;

            double min = 0, max = 0;
            foreach (Record record in records.Values)
            {
                double monthValue = record.getMonths()[cmbSelectedData.SelectedIndex];
                series.Points.AddXY(record.City.Name, monthValue);

                if (monthValue > max) max = monthValue;
                if (monthValue < min) min = monthValue;
            }

            setMinMaxAxisY(min, max);
        }

        private void setMinMaxAxisY(double min, double max)
        {
            this.chartWithDisplayedDataset.ChartAreas[0].AxisY.Minimum = min;
            this.chartWithDisplayedDataset.ChartAreas[0].AxisY.Maximum = max + 2;
        }

        private void btnReturnFromGraph_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbSelectedGraphType_SelectedValueChanged(object sender, EventArgs e)
        {
            graphTypes.TryGetValue(cmbSelectedGraphType.SelectedItem.ToString(), out GraphCustomType graphType);

            if (selectedGraphType != null && selectedGraphType.Name.Equals(graphType.Name)) return;

            if (graphType != null)
            {
                selectedGraphType = graphType;
            }

            selectedCities.Clear();
            initializeSelectedData();

            if (selectedGraphType != null && selectedDataset != null)
            {                
                if (selectedGraphType.DataType != EDataType.NULL) cmbSelectedData.Enabled = true;
                this.chartWithDisplayedDataset.Series.Clear();
                this.chartWithDisplayedDataset.Titles.Clear();
                if (selectedGraphType.DataType != EDataType.NULL) return;
                displayDataIntoGraph(selectedGraphType.Name);
            }
        }

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
                if (selectedGraphType.DataType != EDataType.NULL) cmbSelectedData.Enabled = true;
                if (selectedGraphType.DataType != EDataType.NULL && selectedCities.Count == 0) return;
                displayDataIntoGraph(selectedGraphType.Name);
            }
        }

        private void cmbSelectedDatas_SelectedValueChanged(object sender, EventArgs e)
        {                        
            if (selectedGraphType != null && selectedDataset != null)
            {
                switch(selectedGraphType.DataType)
                {
                    case EDataType.CITY:
                        selectedCities.Add(cmbSelectedData.SelectedItem.ToString());
                        break;
                    case EDataType.MONTH:
                        selectedMonth = cmbSelectedData.SelectedItem.ToString();
                        break;
                    default:
                        return;
                }

                displayDataIntoGraph(selectedGraphType.Name);
            }
        }

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
