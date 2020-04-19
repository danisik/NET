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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chartWithDisplayedDataset = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.cmbSelectedGraphType = new System.Windows.Forms.ComboBox();
            this.lblSelectYear = new System.Windows.Forms.Label();
            this.lblSelectedGraphType = new System.Windows.Forms.Label();
            this.cmbSelectedDatasetGraph = new System.Windows.Forms.ComboBox();
            this.btnReturnFromGraph = new System.Windows.Forms.Button();
            this.lblSelectedDatas = new System.Windows.Forms.Label();
            this.cmbSelectedData = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.chartWithDisplayedDataset)).BeginInit();
            this.SuspendLayout();
            // 
            // chartWithDisplayedDataset
            // 
            chartArea2.Name = "ChartAreaWithDisplayedDataset";
            this.chartWithDisplayedDataset.ChartAreas.Add(chartArea2);
            this.chartWithDisplayedDataset.Location = new System.Drawing.Point(12, 106);
            this.chartWithDisplayedDataset.Name = "chartWithDisplayedDataset";
            series2.ChartArea = "ChartAreaWithDisplayedDataset";
            series2.Name = "SeriesWithDisplayedDataset";
            this.chartWithDisplayedDataset.Series.Add(series2);
            this.chartWithDisplayedDataset.Size = new System.Drawing.Size(1069, 398);
            this.chartWithDisplayedDataset.TabIndex = 0;
            this.chartWithDisplayedDataset.GetToolTipText += new System.EventHandler<System.Windows.Forms.DataVisualization.Charting.ToolTipEventArgs>(this.chartWithDisplayedDataset_GetToolTipText);
            // 
            // cmbSelectedGraphType
            // 
            this.cmbSelectedGraphType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSelectedGraphType.FormattingEnabled = true;
            this.cmbSelectedGraphType.Location = new System.Drawing.Point(98, 12);
            this.cmbSelectedGraphType.Name = "cmbSelectedGraphType";
            this.cmbSelectedGraphType.Size = new System.Drawing.Size(410, 21);
            this.cmbSelectedGraphType.TabIndex = 1;
            this.cmbSelectedGraphType.SelectedValueChanged += new System.EventHandler(this.cmbSelectedGraphType_SelectedValueChanged);
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
            this.cmbSelectedDatasetGraph.SelectedValueChanged += new System.EventHandler(this.cmbSelectedDatasetGraph_SelectedValueChanged);
            // 
            // btnReturnFromGraph
            // 
            this.btnReturnFromGraph.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnReturnFromGraph.Location = new System.Drawing.Point(12, 510);
            this.btnReturnFromGraph.Name = "btnReturnFromGraph";
            this.btnReturnFromGraph.Size = new System.Drawing.Size(105, 34);
            this.btnReturnFromGraph.TabIndex = 8;
            this.btnReturnFromGraph.Text = "Zavřít";
            this.btnReturnFromGraph.UseVisualStyleBackColor = true;
            this.btnReturnFromGraph.Click += new System.EventHandler(this.btnReturnFromGraph_Click);
            // 
            // lblSelectedDatas
            // 
            this.lblSelectedDatas.AutoSize = true;
            this.lblSelectedDatas.Location = new System.Drawing.Point(12, 69);
            this.lblSelectedDatas.Name = "lblSelectedDatas";
            this.lblSelectedDatas.Size = new System.Drawing.Size(0, 13);
            this.lblSelectedDatas.TabIndex = 10;
            // 
            // cmbSelectedData
            // 
            this.cmbSelectedData.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSelectedData.Enabled = false;
            this.cmbSelectedData.FormattingEnabled = true;
            this.cmbSelectedData.Location = new System.Drawing.Point(98, 66);
            this.cmbSelectedData.Name = "cmbSelectedData";
            this.cmbSelectedData.Size = new System.Drawing.Size(410, 21);
            this.cmbSelectedData.TabIndex = 11;
            this.cmbSelectedData.SelectedValueChanged += new System.EventHandler(this.cmbSelectedDatas_SelectedValueChanged);
            // 
            // GraphWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1093, 556);
            this.Controls.Add(this.cmbSelectedData);
            this.Controls.Add(this.lblSelectedDatas);
            this.Controls.Add(this.btnReturnFromGraph);
            this.Controls.Add(this.cmbSelectedDatasetGraph);
            this.Controls.Add(this.lblSelectedGraphType);
            this.Controls.Add(this.lblSelectYear);
            this.Controls.Add(this.cmbSelectedGraphType);
            this.Controls.Add(this.chartWithDisplayedDataset);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "GraphWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
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
        private System.Windows.Forms.Label lblSelectedDatas;
        private System.Windows.Forms.ComboBox cmbSelectedData;
    }
}