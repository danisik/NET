namespace PresentationLayer
{
    partial class MainWindow
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyleColumnCity = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyleColumnJanuary = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyleColumnFebruary = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyleColumnMarch = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyleColumnApril = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyleColumnMay = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyleColumnJune = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyleColumnJuly = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyleColumnAugust = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyleColumnSeptember = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyleColumnOctober = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyleColumnNovember = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyleColumnDecember = new System.Windows.Forms.DataGridViewCellStyle();
            this.labelDataset = new System.Windows.Forms.Label();
            this.cmbDataset = new System.Windows.Forms.ComboBox();
            this.dataGridViewDataset = new System.Windows.Forms.DataGridView();
            this.columnCity = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.columnJanuary = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnFebruary = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnMarch = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnApril = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnMay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnJune = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnJuly = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnAugust = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnSeptember = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnOctober = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnNovember = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnDecember = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblSelectedMeasureText = new System.Windows.Forms.Label();
            this.btnNewRecordRow = new System.Windows.Forms.Button();
            this.btnManageCities = new System.Windows.Forms.Button();
            this.btnConfirmRecordChanges = new System.Windows.Forms.Button();
            this.btnDiscardRecordChanges = new System.Windows.Forms.Button();
            this.btnDeleteSelectedRecordRows = new System.Windows.Forms.Button();
            this.btnManageDatasets = new System.Windows.Forms.Button();
            this.btnManageTemperatures = new System.Windows.Forms.Button();
            this.lblDatasetMeasure = new System.Windows.Forms.Label();
            this.btnExportCSV = new System.Windows.Forms.Button();
            this.btnShowGraphs = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDataset)).BeginInit();
            this.SuspendLayout();
            // 
            // labelDataset
            // 
            this.labelDataset.AutoSize = true;
            this.labelDataset.Location = new System.Drawing.Point(47, 27);
            this.labelDataset.Name = "labelDataset";
            this.labelDataset.Size = new System.Drawing.Size(86, 13);
            this.labelDataset.TabIndex = 0;
            this.labelDataset.Text = "Vybraný dataset:";
            // 
            // cmbDataset
            // 
            this.cmbDataset.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDataset.FormattingEnabled = true;
            this.cmbDataset.Location = new System.Drawing.Point(139, 24);
            this.cmbDataset.Name = "cmbDataset";
            this.cmbDataset.Size = new System.Drawing.Size(204, 21);
            this.cmbDataset.TabIndex = 1;
            this.cmbDataset.SelectedIndexChanged += new System.EventHandler(this.cmbDataset_SelectedIndexChanged);
            // 
            // dataGridViewDataset
            // 
            this.dataGridViewDataset.AllowDrop = true;
            this.dataGridViewDataset.AllowUserToAddRows = false;
            this.dataGridViewDataset.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDataset.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.columnCity,
            this.columnJanuary,
            this.columnFebruary,
            this.columnMarch,
            this.columnApril,
            this.columnMay,
            this.columnJune,
            this.columnJuly,
            this.columnAugust,
            this.columnSeptember,
            this.columnOctober,
            this.columnNovember,
            this.columnDecember});
            this.dataGridViewDataset.Location = new System.Drawing.Point(12, 143);
            this.dataGridViewDataset.Name = "dataGridViewDataset";
            this.dataGridViewDataset.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewDataset.Size = new System.Drawing.Size(1020, 331);
            this.dataGridViewDataset.TabIndex = 2;
            this.dataGridViewDataset.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridViewDataset_CellBeginEdit);
            this.dataGridViewDataset.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewDataset_CellEndEdit);
            this.dataGridViewDataset.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dataGridViewDataset_EditingControlShowing);
            this.dataGridViewDataset.DragDrop += new System.Windows.Forms.DragEventHandler(this.dataGridViewDataset_DragDrop);
            this.dataGridViewDataset.DragOver += new System.Windows.Forms.DragEventHandler(this.dataGridViewDataset_DragOver);
            this.dataGridViewDataset.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dataGridViewDataset_MouseDown);
            this.dataGridViewDataset.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dataGridViewDataset_MouseMove);
            // 
            // columnCity
            // 
            dataGridViewCellStyleColumnCity.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            this.columnCity.DefaultCellStyle = dataGridViewCellStyleColumnCity;
            this.columnCity.HeaderText = "Město";
            this.columnCity.MaxDropDownItems = 1;
            this.columnCity.Name = "columnCity";
            this.columnCity.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.columnCity.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // columnJanuary
            // 
            dataGridViewCellStyleColumnJanuary.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyleColumnJanuary.Format = "N1";
            dataGridViewCellStyleColumnJanuary.NullValue = null;
            this.columnJanuary.DefaultCellStyle = dataGridViewCellStyleColumnJanuary;
            this.columnJanuary.HeaderText = "Leden";
            this.columnJanuary.Name = "columnJanuary";
            this.columnJanuary.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.columnJanuary.Width = 73;
            // 
            // columnFebruary
            // 
            dataGridViewCellStyleColumnFebruary.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyleColumnFebruary.Format = "N1";
            dataGridViewCellStyleColumnFebruary.NullValue = null;
            this.columnFebruary.DefaultCellStyle = dataGridViewCellStyleColumnFebruary;
            this.columnFebruary.HeaderText = "Únor";
            this.columnFebruary.Name = "columnFebruary";
            this.columnFebruary.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.columnFebruary.Width = 73;
            // 
            // columnMarch
            // 
            dataGridViewCellStyleColumnMarch.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyleColumnMarch.Format = "N1";
            dataGridViewCellStyleColumnMarch.NullValue = null;
            this.columnMarch.DefaultCellStyle = dataGridViewCellStyleColumnMarch;
            this.columnMarch.HeaderText = "Březen";
            this.columnMarch.Name = "columnMarch";
            this.columnMarch.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.columnMarch.Width = 73;
            // 
            // columnApril
            // 
            dataGridViewCellStyleColumnApril.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyleColumnApril.Format = "N1";
            dataGridViewCellStyleColumnApril.NullValue = null;
            this.columnApril.DefaultCellStyle = dataGridViewCellStyleColumnApril;
            this.columnApril.HeaderText = "Duben";
            this.columnApril.Name = "columnApril";
            this.columnApril.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.columnApril.Width = 73;
            // 
            // columnMay
            // 
            dataGridViewCellStyleColumnMay.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyleColumnMay.Format = "N1";
            dataGridViewCellStyleColumnMay.NullValue = null;
            this.columnMay.DefaultCellStyle = dataGridViewCellStyleColumnMay;
            this.columnMay.HeaderText = "Květen";
            this.columnMay.Name = "columnMay";
            this.columnMay.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.columnMay.Width = 73;
            // 
            // columnJune
            // 
            dataGridViewCellStyleColumnJune.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyleColumnJune.Format = "N1";
            dataGridViewCellStyleColumnJune.NullValue = null;
            this.columnJune.DefaultCellStyle = dataGridViewCellStyleColumnJune;
            this.columnJune.HeaderText = "Červen";
            this.columnJune.Name = "columnJune";
            this.columnJune.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.columnJune.Width = 73;
            // 
            // columnJuly
            // 
            dataGridViewCellStyleColumnJuly.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyleColumnJuly.Format = "N1";
            dataGridViewCellStyleColumnJuly.NullValue = null;
            this.columnJuly.DefaultCellStyle = dataGridViewCellStyleColumnJuly;
            this.columnJuly.HeaderText = "Červenec";
            this.columnJuly.Name = "columnJuly";
            this.columnJuly.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.columnJuly.Width = 73;
            // 
            // columnAugust
            // 
            dataGridViewCellStyleColumnAugust.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyleColumnAugust.Format = "N1";
            dataGridViewCellStyleColumnAugust.NullValue = null;
            this.columnAugust.DefaultCellStyle = dataGridViewCellStyleColumnAugust;
            this.columnAugust.HeaderText = "Srpen";
            this.columnAugust.Name = "columnAugust";
            this.columnAugust.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.columnAugust.Width = 73;
            // 
            // columnSeptember
            // 
            dataGridViewCellStyleColumnSeptember.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyleColumnSeptember.Format = "N1";
            dataGridViewCellStyleColumnSeptember.NullValue = null;
            this.columnSeptember.DefaultCellStyle = dataGridViewCellStyleColumnSeptember;
            this.columnSeptember.HeaderText = "Září";
            this.columnSeptember.Name = "columnSeptember";
            this.columnSeptember.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.columnSeptember.Width = 73;
            // 
            // columnOctober
            // 
            dataGridViewCellStyleColumnOctober.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyleColumnOctober.Format = "N1";
            dataGridViewCellStyleColumnOctober.NullValue = null;
            this.columnOctober.DefaultCellStyle = dataGridViewCellStyleColumnOctober;
            this.columnOctober.HeaderText = "Říjen";
            this.columnOctober.Name = "columnOctober";
            this.columnOctober.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.columnOctober.Width = 73;
            // 
            // columnNovember
            // 
            dataGridViewCellStyleColumnNovember.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyleColumnNovember.Format = "N1";
            dataGridViewCellStyleColumnNovember.NullValue = null;
            this.columnNovember.DefaultCellStyle = dataGridViewCellStyleColumnNovember;
            this.columnNovember.HeaderText = "Listopad";
            this.columnNovember.Name = "columnNovember";
            this.columnNovember.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.columnNovember.Width = 73;
            // 
            // columnDecember
            // 
            dataGridViewCellStyleColumnDecember.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyleColumnDecember.Format = "N1";
            dataGridViewCellStyleColumnDecember.NullValue = null;
            this.columnDecember.DefaultCellStyle = dataGridViewCellStyleColumnDecember;
            this.columnDecember.HeaderText = "Prosinec";
            this.columnDecember.Name = "columnDecember";
            this.columnDecember.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.columnDecember.Width = 73;
            // 
            // lblSelectedMeasureText
            // 
            this.lblSelectedMeasureText.AutoSize = true;
            this.lblSelectedMeasureText.Location = new System.Drawing.Point(9, 58);
            this.lblSelectedMeasureText.Name = "lblSelectedMeasureText";
            this.lblSelectedMeasureText.Size = new System.Drawing.Size(127, 13);
            this.lblSelectedMeasureText.TabIndex = 3;
            this.lblSelectedMeasureText.Text = "Vybraná jednotka teploty:";
            // 
            // btnNewRecordRow
            // 
            this.btnNewRecordRow.Location = new System.Drawing.Point(16, 98);
            this.btnNewRecordRow.Name = "btnNewRecordRow";
            this.btnNewRecordRow.Size = new System.Drawing.Size(105, 34);
            this.btnNewRecordRow.TabIndex = 5;
            this.btnNewRecordRow.Text = "Přidat řádku";
            this.btnNewRecordRow.UseVisualStyleBackColor = true;
            this.btnNewRecordRow.Click += new System.EventHandler(this.btnNewRecordRow_Click);
            // 
            // btnManageCities
            // 
            this.btnManageCities.Location = new System.Drawing.Point(928, 56);
            this.btnManageCities.Name = "btnManageCities";
            this.btnManageCities.Size = new System.Drawing.Size(105, 34);
            this.btnManageCities.TabIndex = 6;
            this.btnManageCities.Text = "Správa měst";
            this.btnManageCities.UseVisualStyleBackColor = true;
            this.btnManageCities.Click += new System.EventHandler(this.btnManageCities_Click);
            // 
            // btnConfirmRecordChanges
            // 
            this.btnConfirmRecordChanges.Location = new System.Drawing.Point(12, 480);
            this.btnConfirmRecordChanges.Name = "btnConfirmRecordChanges";
            this.btnConfirmRecordChanges.Size = new System.Drawing.Size(105, 34);
            this.btnConfirmRecordChanges.TabIndex = 7;
            this.btnConfirmRecordChanges.Text = "Potvrdit změny";
            this.btnConfirmRecordChanges.UseVisualStyleBackColor = true;
            this.btnConfirmRecordChanges.Click += new System.EventHandler(this.btnConfirmRecordChanges_Click);
            // 
            // btnDiscardRecordChanges
            // 
            this.btnDiscardRecordChanges.Location = new System.Drawing.Point(123, 480);
            this.btnDiscardRecordChanges.Name = "btnDiscardRecordChanges";
            this.btnDiscardRecordChanges.Size = new System.Drawing.Size(105, 34);
            this.btnDiscardRecordChanges.TabIndex = 8;
            this.btnDiscardRecordChanges.Text = "Zrušit změny";
            this.btnDiscardRecordChanges.UseVisualStyleBackColor = true;
            this.btnDiscardRecordChanges.Click += new System.EventHandler(this.btnDiscardRecordChanges_Click);
            // 
            // btnDeleteSelectedRecordRows
            // 
            this.btnDeleteSelectedRecordRows.Location = new System.Drawing.Point(127, 98);
            this.btnDeleteSelectedRecordRows.Name = "btnDeleteSelectedRecordRows";
            this.btnDeleteSelectedRecordRows.Size = new System.Drawing.Size(105, 34);
            this.btnDeleteSelectedRecordRows.TabIndex = 11;
            this.btnDeleteSelectedRecordRows.Text = "Odebrat označené řádky";
            this.btnDeleteSelectedRecordRows.UseVisualStyleBackColor = true;
            this.btnDeleteSelectedRecordRows.Click += new System.EventHandler(this.btnDeleteSelectedRecordRows_Click);
            // 
            // btnManageDatasets
            // 
            this.btnManageDatasets.Location = new System.Drawing.Point(927, 16);
            this.btnManageDatasets.Name = "btnManageDatasets";
            this.btnManageDatasets.Size = new System.Drawing.Size(105, 34);
            this.btnManageDatasets.TabIndex = 12;
            this.btnManageDatasets.Text = "Správa datasetů";
            this.btnManageDatasets.UseVisualStyleBackColor = true;
            this.btnManageDatasets.Click += new System.EventHandler(this.btnManageDatasets_Click);
            // 
            // btnManageTemperatures
            // 
            this.btnManageTemperatures.Location = new System.Drawing.Point(928, 96);
            this.btnManageTemperatures.Name = "btnManageTemperatures";
            this.btnManageTemperatures.Size = new System.Drawing.Size(105, 34);
            this.btnManageTemperatures.TabIndex = 13;
            this.btnManageTemperatures.Text = "Správa teplot";
            this.btnManageTemperatures.UseVisualStyleBackColor = true;
            this.btnManageTemperatures.Click += new System.EventHandler(this.btnManageTemperatures_Click);
            // 
            // lblDatasetMeasure
            // 
            this.lblDatasetMeasure.AutoSize = true;
            this.lblDatasetMeasure.Location = new System.Drawing.Point(142, 58);
            this.lblDatasetMeasure.Name = "lblDatasetMeasure";
            this.lblDatasetMeasure.Size = new System.Drawing.Size(0, 13);
            this.lblDatasetMeasure.TabIndex = 17;
            // 
            // btnExportCSV
            // 
            this.btnExportCSV.Location = new System.Drawing.Point(927, 480);
            this.btnExportCSV.Name = "btnExportCSV";
            this.btnExportCSV.Size = new System.Drawing.Size(105, 34);
            this.btnExportCSV.TabIndex = 20;
            this.btnExportCSV.Text = "Export do CSV";
            this.btnExportCSV.UseVisualStyleBackColor = true;
            this.btnExportCSV.Click += new System.EventHandler(this.btnExportCSV_Click);
            // 
            // btnShowGraphs
            // 
            this.btnShowGraphs.Location = new System.Drawing.Point(816, 480);
            this.btnShowGraphs.Name = "btnShowGraphs";
            this.btnShowGraphs.Size = new System.Drawing.Size(105, 34);
            this.btnShowGraphs.TabIndex = 21;
            this.btnShowGraphs.Text = "Data v grafech";
            this.btnShowGraphs.UseVisualStyleBackColor = true;
            this.btnShowGraphs.Click += new System.EventHandler(this.btnShowGraphs_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1047, 523);
            this.Controls.Add(this.btnShowGraphs);
            this.Controls.Add(this.btnExportCSV);
            this.Controls.Add(this.lblDatasetMeasure);
            this.Controls.Add(this.btnManageTemperatures);
            this.Controls.Add(this.btnManageDatasets);
            this.Controls.Add(this.btnDeleteSelectedRecordRows);
            this.Controls.Add(this.btnDiscardRecordChanges);
            this.Controls.Add(this.btnConfirmRecordChanges);
            this.Controls.Add(this.btnManageCities);
            this.Controls.Add(this.btnNewRecordRow);
            this.Controls.Add(this.lblSelectedMeasureText);
            this.Controls.Add(this.dataGridViewDataset);
            this.Controls.Add(this.cmbDataset);
            this.Controls.Add(this.labelDataset);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Zpracování naměřených teplot";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDataset)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelDataset;
        private System.Windows.Forms.ComboBox cmbDataset;
        private System.Windows.Forms.DataGridView dataGridViewDataset;
        private System.Windows.Forms.Label lblSelectedMeasureText;
        private System.Windows.Forms.Button btnNewRecordRow;
        private System.Windows.Forms.Button btnManageCities;
        private System.Windows.Forms.Button btnConfirmRecordChanges;
        private System.Windows.Forms.Button btnDiscardRecordChanges;
        private System.Windows.Forms.Button btnDeleteSelectedRecordRows;
        private System.Windows.Forms.Button btnManageDatasets;
        private System.Windows.Forms.Button btnManageTemperatures;
        private System.Windows.Forms.Label lblDatasetMeasure;
        private System.Windows.Forms.DataGridViewComboBoxColumn columnCity;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnJanuary;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnFebruary;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnMarch;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnApril;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnMay;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnJune;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnJuly;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnAugust;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnSeptember;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnOctober;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnNovember;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnDecember;
        private System.Windows.Forms.Button btnExportCSV;
        private System.Windows.Forms.Button btnShowGraphs;
    }
}

