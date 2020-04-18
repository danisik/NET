namespace PresentationLayer.Window
{
    partial class GraphWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chartWithDisplayedDataset = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.cmbSelectedGraphType = new System.Windows.Forms.ComboBox();
            this.lblSelectYear = new System.Windows.Forms.Label();
            this.lblSelectedGraphType = new System.Windows.Forms.Label();
            this.cmbSelectedDatasetGraph = new System.Windows.Forms.ComboBox();
            this.btnReturnFromGraph = new System.Windows.Forms.Button();
            this.lblSelectedCities = new System.Windows.Forms.Label();
            this.cmbSelectedCities = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.chartWithDisplayedDataset)).BeginInit();
            this.SuspendLayout();
            // 
            // chartWithDisplayedDataset
            // 
            chartArea1.Name = "ChartArea1";
            this.chartWithDisplayedDataset.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartWithDisplayedDataset.Legends.Add(legend1);
            this.chartWithDisplayedDataset.Location = new System.Drawing.Point(12, 106);
            this.chartWithDisplayedDataset.Name = "chartWithDisplayedDataset";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartWithDisplayedDataset.Series.Add(series1);
            this.chartWithDisplayedDataset.Size = new System.Drawing.Size(776, 398);
            this.chartWithDisplayedDataset.TabIndex = 0;
            this.chartWithDisplayedDataset.Text = "chart1";
            // 
            // cmbSelectedGraphType
            // 
            this.cmbSelectedGraphType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSelectedGraphType.FormattingEnabled = true;
            this.cmbSelectedGraphType.Location = new System.Drawing.Point(98, 12);
            this.cmbSelectedGraphType.Name = "cmbSelectedGraphType";
            this.cmbSelectedGraphType.Size = new System.Drawing.Size(410, 21);
            this.cmbSelectedGraphType.TabIndex = 1;
            // 
            // lblSelectYear
            // 
            this.lblSelectYear.AutoSize = true;
            this.lblSelectYear.Location = new System.Drawing.Point(6, 43);
            this.lblSelectYear.Name = "lblSelectYear";
            this.lblSelectYear.Size = new System.Drawing.Size(86, 13);
            this.lblSelectYear.TabIndex = 2;
            this.lblSelectYear.Text = "Vybraný dataset:";
            // 
            // lblSelectedGraphType
            // 
            this.lblSelectedGraphType.AutoSize = true;
            this.lblSelectedGraphType.Location = new System.Drawing.Point(23, 15);
            this.lblSelectedGraphType.Name = "lblSelectedGraphType";
            this.lblSelectedGraphType.Size = new System.Drawing.Size(69, 13);
            this.lblSelectedGraphType.TabIndex = 3;
            this.lblSelectedGraphType.Text = "Vybraný graf:";
            // 
            // cmbSelectedDatasetGraph
            // 
            this.cmbSelectedDatasetGraph.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSelectedDatasetGraph.FormattingEnabled = true;
            this.cmbSelectedDatasetGraph.Location = new System.Drawing.Point(98, 39);
            this.cmbSelectedDatasetGraph.Name = "cmbSelectedDatasetGraph";
            this.cmbSelectedDatasetGraph.Size = new System.Drawing.Size(410, 21);
            this.cmbSelectedDatasetGraph.TabIndex = 4;
            // 
            // btnReturnFromGraph
            // 
            this.btnReturnFromGraph.Location = new System.Drawing.Point(12, 510);
            this.btnReturnFromGraph.Name = "btnReturnFromGraph";
            this.btnReturnFromGraph.Size = new System.Drawing.Size(105, 34);
            this.btnReturnFromGraph.TabIndex = 8;
            this.btnReturnFromGraph.Text = "Zavřít";
            this.btnReturnFromGraph.UseVisualStyleBackColor = true;
            this.btnReturnFromGraph.Click += new System.EventHandler(this.btnReturnFromGraph_Click);
            // 
            // lblSelectedCities
            // 
            this.lblSelectedCities.AutoSize = true;
            this.lblSelectedCities.Location = new System.Drawing.Point(12, 69);
            this.lblSelectedCities.Name = "lblSelectedCities";
            this.lblSelectedCities.Size = new System.Drawing.Size(80, 13);
            this.lblSelectedCities.TabIndex = 10;
            this.lblSelectedCities.Text = "Vybraná města:";
            // 
            // cmbSelectedCities
            // 
            this.cmbSelectedCities.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSelectedCities.FormattingEnabled = true;
            this.cmbSelectedCities.Location = new System.Drawing.Point(98, 66);
            this.cmbSelectedCities.Name = "cmbSelectedCities";
            this.cmbSelectedCities.Size = new System.Drawing.Size(410, 21);
            this.cmbSelectedCities.TabIndex = 11;
            // 
            // GraphWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 556);
            this.Controls.Add(this.cmbSelectedCities);
            this.Controls.Add(this.lblSelectedCities);
            this.Controls.Add(this.btnReturnFromGraph);
            this.Controls.Add(this.cmbSelectedDatasetGraph);
            this.Controls.Add(this.lblSelectedGraphType);
            this.Controls.Add(this.lblSelectYear);
            this.Controls.Add(this.cmbSelectedGraphType);
            this.Controls.Add(this.chartWithDisplayedDataset);
            this.Name = "GraphWindow";
            this.Text = "GraphWindow";
            ((System.ComponentModel.ISupportInitialize)(this.chartWithDisplayedDataset)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartWithDisplayedDataset;
        private System.Windows.Forms.ComboBox cmbSelectedGraphType;
        private System.Windows.Forms.Label lblSelectYear;
        private System.Windows.Forms.Label lblSelectedGraphType;
        private System.Windows.Forms.ComboBox cmbSelectedDatasetGraph;
        private System.Windows.Forms.Button btnReturnFromGraph;
        private System.Windows.Forms.Label lblSelectedCities;
        private System.Windows.Forms.ComboBox cmbSelectedCities;
    }
}