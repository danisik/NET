namespace PresentationLayer.Window
{
    partial class ManageDatasetsWindow
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridViewManageDatasets = new System.Windows.Forms.DataGridView();
            this.btnDeleteSelectedDatasetsRow = new System.Windows.Forms.Button();
            this.btnNewDatasetRow = new System.Windows.Forms.Button();
            this.btnReturnDataset = new System.Windows.Forms.Button();
            this.btnDiscardDatasetChanges = new System.Windows.Forms.Button();
            this.btnConfirmDatasetChanges = new System.Windows.Forms.Button();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewComboBoxColumn1 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.column_dataset_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnCityName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.measure_tag = new System.Windows.Forms.DataGridViewComboBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewManageDatasets)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewManageDatasets
            // 
            this.dataGridViewManageDatasets.AllowUserToAddRows = false;
            this.dataGridViewManageDatasets.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewManageDatasets.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.column_dataset_id,
            this.columnCityName,
            this.measure_tag});
            this.dataGridViewManageDatasets.Location = new System.Drawing.Point(12, 12);
            this.dataGridViewManageDatasets.Name = "dataGridViewManageDatasets";
            this.dataGridViewManageDatasets.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dataGridViewManageDatasets.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewManageDatasets.Size = new System.Drawing.Size(463, 287);
            this.dataGridViewManageDatasets.TabIndex = 1;
            // 
            // btnDeleteSelectedDatasetsRow
            // 
            this.btnDeleteSelectedDatasetsRow.Location = new System.Drawing.Point(481, 52);
            this.btnDeleteSelectedDatasetsRow.Name = "btnDeleteSelectedDatasetsRow";
            this.btnDeleteSelectedDatasetsRow.Size = new System.Drawing.Size(105, 34);
            this.btnDeleteSelectedDatasetsRow.TabIndex = 12;
            this.btnDeleteSelectedDatasetsRow.Text = "Odebrat označené řádky";
            this.btnDeleteSelectedDatasetsRow.UseVisualStyleBackColor = true;
            this.btnDeleteSelectedDatasetsRow.Click += new System.EventHandler(this.btnDeleteSelectedDatasetsRow_Click);
            // 
            // btnNewDatasetRow
            // 
            this.btnNewDatasetRow.Location = new System.Drawing.Point(481, 12);
            this.btnNewDatasetRow.Name = "btnNewDatasetRow";
            this.btnNewDatasetRow.Size = new System.Drawing.Size(105, 34);
            this.btnNewDatasetRow.TabIndex = 11;
            this.btnNewDatasetRow.Text = "Přidat řádku";
            this.btnNewDatasetRow.UseVisualStyleBackColor = true;
            this.btnNewDatasetRow.Click += new System.EventHandler(this.btnNewDatasetRow_Click);
            // 
            // btnReturnDataset
            // 
            this.btnReturnDataset.Location = new System.Drawing.Point(482, 266);
            this.btnReturnDataset.Name = "btnReturnDataset";
            this.btnReturnDataset.Size = new System.Drawing.Size(105, 34);
            this.btnReturnDataset.TabIndex = 15;
            this.btnReturnDataset.Text = "Zavřít";
            this.btnReturnDataset.UseVisualStyleBackColor = true;
            this.btnReturnDataset.Click += new System.EventHandler(this.btnReturnDataset_Click);
            // 
            // btnDiscardDatasetChanges
            // 
            this.btnDiscardDatasetChanges.Location = new System.Drawing.Point(481, 226);
            this.btnDiscardDatasetChanges.Name = "btnDiscardDatasetChanges";
            this.btnDiscardDatasetChanges.Size = new System.Drawing.Size(105, 34);
            this.btnDiscardDatasetChanges.TabIndex = 14;
            this.btnDiscardDatasetChanges.Text = "Zrušit změny";
            this.btnDiscardDatasetChanges.UseVisualStyleBackColor = true;
            this.btnDiscardDatasetChanges.Click += new System.EventHandler(this.btnDiscardDatasetChanges_Click);
            // 
            // btnConfirmDatasetChanges
            // 
            this.btnConfirmDatasetChanges.Location = new System.Drawing.Point(482, 186);
            this.btnConfirmDatasetChanges.Name = "btnConfirmDatasetChanges";
            this.btnConfirmDatasetChanges.Size = new System.Drawing.Size(105, 34);
            this.btnConfirmDatasetChanges.TabIndex = 13;
            this.btnConfirmDatasetChanges.Text = "Potvrdit změny";
            this.btnConfirmDatasetChanges.UseVisualStyleBackColor = true;
            this.btnConfirmDatasetChanges.Click += new System.EventHandler(this.btnConfirmDatasetChanges_Click);
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle2.NullValue = null;
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewTextBoxColumn1.FillWeight = 200F;
            this.dataGridViewTextBoxColumn1.HeaderText = "Dataset";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 200;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewTextBoxColumn2.FillWeight = 200F;
            this.dataGridViewTextBoxColumn2.HeaderText = "Dataset";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 200;
            // 
            // dataGridViewComboBoxColumn1
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            this.dataGridViewComboBoxColumn1.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewComboBoxColumn1.FillWeight = 150F;
            this.dataGridViewComboBoxColumn1.HeaderText = "Jednotka teploty";
            this.dataGridViewComboBoxColumn1.Name = "dataGridViewComboBoxColumn1";
            this.dataGridViewComboBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewComboBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewComboBoxColumn1.Width = 150;
            // 
            // column_dataset_id
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle1.NullValue = null;
            this.column_dataset_id.DefaultCellStyle = dataGridViewCellStyle1;
            this.column_dataset_id.FillWeight = 70F;
            this.column_dataset_id.HeaderText = "ID";
            this.column_dataset_id.Name = "column_dataset_id";
            this.column_dataset_id.ReadOnly = true;
            this.column_dataset_id.Width = 70;
            // 
            // columnCityName
            // 
            this.columnCityName.FillWeight = 200F;
            this.columnCityName.HeaderText = "Dataset";
            this.columnCityName.Name = "columnCityName";
            this.columnCityName.Width = 200;
            // 
            // measure_tag
            // 
            this.measure_tag.FillWeight = 150F;
            this.measure_tag.HeaderText = "Jednotka teploty";
            this.measure_tag.Name = "measure_tag";
            this.measure_tag.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.measure_tag.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.measure_tag.Width = 150;
            // 
            // ManageDatasetsWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(595, 311);
            this.Controls.Add(this.btnReturnDataset);
            this.Controls.Add(this.btnDiscardDatasetChanges);
            this.Controls.Add(this.btnConfirmDatasetChanges);
            this.Controls.Add(this.btnDeleteSelectedDatasetsRow);
            this.Controls.Add(this.btnNewDatasetRow);
            this.Controls.Add(this.dataGridViewManageDatasets);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ManageDatasetsWindow";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Správa datasetů";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewManageDatasets)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewManageDatasets;
        private System.Windows.Forms.Button btnDeleteSelectedDatasetsRow;
        private System.Windows.Forms.Button btnNewDatasetRow;
        private System.Windows.Forms.Button btnReturnDataset;
        private System.Windows.Forms.Button btnDiscardDatasetChanges;
        private System.Windows.Forms.Button btnConfirmDatasetChanges;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewComboBoxColumn dataGridViewComboBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_dataset_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnCityName;
        private System.Windows.Forms.DataGridViewComboBoxColumn measure_tag;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
    }
}