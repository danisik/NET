namespace PresentationLayer.Window
{
    partial class ManageMeasuresWindow
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
            this.dataGridViewManageMeasures = new System.Windows.Forms.DataGridView();
            this.columnCityName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnTag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnReturnMeasure = new System.Windows.Forms.Button();
            this.btnDiscardMeasureChanges = new System.Windows.Forms.Button();
            this.btnConfirmMeasureChanges = new System.Windows.Forms.Button();
            this.btnDeleteSelectedMeasuresRow = new System.Windows.Forms.Button();
            this.btnNewMeasureRow = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewManageMeasures)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewManageMeasures
            // 
            this.dataGridViewManageMeasures.AllowUserToAddRows = false;
            this.dataGridViewManageMeasures.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewManageMeasures.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.columnCityName,
            this.columnTag});
            this.dataGridViewManageMeasures.Location = new System.Drawing.Point(12, 12);
            this.dataGridViewManageMeasures.Name = "dataGridViewManageMeasures";
            this.dataGridViewManageMeasures.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dataGridViewManageMeasures.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewManageMeasures.Size = new System.Drawing.Size(343, 287);
            this.dataGridViewManageMeasures.TabIndex = 2;
            // 
            // columnCityName
            // 
            this.columnCityName.FillWeight = 200F;
            this.columnCityName.HeaderText = "Název";
            this.columnCityName.Name = "columnCityName";
            this.columnCityName.Width = 200;
            // 
            // columnTag
            // 
            this.columnTag.HeaderText = "Symbol";
            this.columnTag.Name = "columnTag";
            // 
            // btnReturnMeasure
            // 
            this.btnReturnMeasure.Location = new System.Drawing.Point(361, 266);
            this.btnReturnMeasure.Name = "btnReturnMeasure";
            this.btnReturnMeasure.Size = new System.Drawing.Size(105, 34);
            this.btnReturnMeasure.TabIndex = 20;
            this.btnReturnMeasure.Text = "Zavřít";
            this.btnReturnMeasure.UseVisualStyleBackColor = true;
            this.btnReturnMeasure.Click += new System.EventHandler(this.btnReturnMeasure_Click);
            // 
            // btnDiscardMeasureChanges
            // 
            this.btnDiscardMeasureChanges.Location = new System.Drawing.Point(360, 226);
            this.btnDiscardMeasureChanges.Name = "btnDiscardMeasureChanges";
            this.btnDiscardMeasureChanges.Size = new System.Drawing.Size(105, 34);
            this.btnDiscardMeasureChanges.TabIndex = 19;
            this.btnDiscardMeasureChanges.Text = "Zrušit změny";
            this.btnDiscardMeasureChanges.UseVisualStyleBackColor = true;
            this.btnDiscardMeasureChanges.Click += new System.EventHandler(this.btnDiscardMeasureChanges_Click);
            // 
            // btnConfirmMeasureChanges
            // 
            this.btnConfirmMeasureChanges.Location = new System.Drawing.Point(361, 186);
            this.btnConfirmMeasureChanges.Name = "btnConfirmMeasureChanges";
            this.btnConfirmMeasureChanges.Size = new System.Drawing.Size(105, 34);
            this.btnConfirmMeasureChanges.TabIndex = 18;
            this.btnConfirmMeasureChanges.Text = "Potvrdit změny";
            this.btnConfirmMeasureChanges.UseVisualStyleBackColor = true;
            this.btnConfirmMeasureChanges.Click += new System.EventHandler(this.btnConfirmMeasureChanges_Click);
            // 
            // btnDeleteSelectedMeasuresRow
            // 
            this.btnDeleteSelectedMeasuresRow.Location = new System.Drawing.Point(360, 52);
            this.btnDeleteSelectedMeasuresRow.Name = "btnDeleteSelectedMeasuresRow";
            this.btnDeleteSelectedMeasuresRow.Size = new System.Drawing.Size(105, 34);
            this.btnDeleteSelectedMeasuresRow.TabIndex = 17;
            this.btnDeleteSelectedMeasuresRow.Text = "Odebrat označené řádky";
            this.btnDeleteSelectedMeasuresRow.UseVisualStyleBackColor = true;
            this.btnDeleteSelectedMeasuresRow.Click += new System.EventHandler(this.btnDeleteSelectedMeasuresRow_Click);
            // 
            // btnNewMeasureRow
            // 
            this.btnNewMeasureRow.Location = new System.Drawing.Point(358, 12);
            this.btnNewMeasureRow.Name = "btnNewMeasureRow";
            this.btnNewMeasureRow.Size = new System.Drawing.Size(105, 34);
            this.btnNewMeasureRow.TabIndex = 16;
            this.btnNewMeasureRow.Text = "Přidat řádku";
            this.btnNewMeasureRow.UseVisualStyleBackColor = true;
            this.btnNewMeasureRow.Click += new System.EventHandler(this.btnNewMeasureRow_Click);
            // 
            // ManageMeasuresWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(477, 311);
            this.Controls.Add(this.btnReturnMeasure);
            this.Controls.Add(this.btnDiscardMeasureChanges);
            this.Controls.Add(this.btnConfirmMeasureChanges);
            this.Controls.Add(this.btnDeleteSelectedMeasuresRow);
            this.Controls.Add(this.btnNewMeasureRow);
            this.Controls.Add(this.dataGridViewManageMeasures);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ManageMeasuresWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Správa jednotek teplot";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewManageMeasures)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewManageMeasures;
        private System.Windows.Forms.Button btnReturnMeasure;
        private System.Windows.Forms.Button btnDiscardMeasureChanges;
        private System.Windows.Forms.Button btnConfirmMeasureChanges;
        private System.Windows.Forms.Button btnDeleteSelectedMeasuresRow;
        private System.Windows.Forms.Button btnNewMeasureRow;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnCityName;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnTag;
    }
}