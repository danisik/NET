namespace PresentationLayer.Window
{
    partial class ManageCitiesWindow
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
            this.dataGridViewManageCities = new System.Windows.Forms.DataGridView();
            this.columnCityName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnConfirmChanges = new System.Windows.Forms.Button();
            this.btnDiscardChanges = new System.Windows.Forms.Button();
            this.btnReturn = new System.Windows.Forms.Button();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnNewCityRow = new System.Windows.Forms.Button();
            this.btnDeleteSelectedCityRow = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewManageCities)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewManageCities
            // 
            this.dataGridViewManageCities.AllowUserToAddRows = false;
            this.dataGridViewManageCities.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewManageCities.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.columnCityName});
            this.dataGridViewManageCities.Location = new System.Drawing.Point(12, 12);
            this.dataGridViewManageCities.Name = "dataGridViewManageCities";
            this.dataGridViewManageCities.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dataGridViewManageCities.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewManageCities.Size = new System.Drawing.Size(243, 287);
            this.dataGridViewManageCities.TabIndex = 0;
            // 
            // columnCityName
            // 
            this.columnCityName.FillWeight = 200F;
            this.columnCityName.HeaderText = "Město";
            this.columnCityName.Name = "columnCityName";
            this.columnCityName.Width = 200;
            // 
            // btnConfirmChanges
            // 
            this.btnConfirmChanges.Location = new System.Drawing.Point(261, 185);
            this.btnConfirmChanges.Name = "btnConfirmChanges";
            this.btnConfirmChanges.Size = new System.Drawing.Size(105, 34);
            this.btnConfirmChanges.TabIndex = 6;
            this.btnConfirmChanges.Text = "Potvrdit změny";
            this.btnConfirmChanges.UseVisualStyleBackColor = true;
            this.btnConfirmChanges.Click += new System.EventHandler(this.btnConfirmChanges_Click);
            // 
            // btnDiscardChanges
            // 
            this.btnDiscardChanges.Location = new System.Drawing.Point(260, 225);
            this.btnDiscardChanges.Name = "btnDiscardChanges";
            this.btnDiscardChanges.Size = new System.Drawing.Size(105, 34);
            this.btnDiscardChanges.TabIndex = 7;
            this.btnDiscardChanges.Text = "Zrušit změny";
            this.btnDiscardChanges.UseVisualStyleBackColor = true;
            this.btnDiscardChanges.Click += new System.EventHandler(this.btnDiscardChanges_Click);
            // 
            // btnReturn
            // 
            this.btnReturn.Location = new System.Drawing.Point(261, 265);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(105, 34);
            this.btnReturn.TabIndex = 8;
            this.btnReturn.Text = "Zavřít";
            this.btnReturn.UseVisualStyleBackColor = true;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.FillWeight = 200F;
            this.dataGridViewTextBoxColumn1.HeaderText = "Město";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 200;
            // 
            // btnNewCityRow
            // 
            this.btnNewCityRow.Location = new System.Drawing.Point(261, 12);
            this.btnNewCityRow.Name = "btnNewCityRow";
            this.btnNewCityRow.Size = new System.Drawing.Size(105, 34);
            this.btnNewCityRow.TabIndex = 9;
            this.btnNewCityRow.Text = "Přidat řádku";
            this.btnNewCityRow.UseVisualStyleBackColor = true;
            this.btnNewCityRow.Click += new System.EventHandler(this.btnNewCityRow_Click);
            // 
            // btnDeleteSelectedCityRow
            // 
            this.btnDeleteSelectedCityRow.Location = new System.Drawing.Point(261, 52);
            this.btnDeleteSelectedCityRow.Name = "btnDeleteSelectedCityRow";
            this.btnDeleteSelectedCityRow.Size = new System.Drawing.Size(105, 34);
            this.btnDeleteSelectedCityRow.TabIndex = 10;
            this.btnDeleteSelectedCityRow.Text = "Odebrat označené řádky";
            this.btnDeleteSelectedCityRow.UseVisualStyleBackColor = true;
            this.btnDeleteSelectedCityRow.Click += new System.EventHandler(this.btnDeleteSelectedCityRow_Click);
            // 
            // ManageCitiesWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(377, 311);
            this.Controls.Add(this.btnDeleteSelectedCityRow);
            this.Controls.Add(this.btnNewCityRow);
            this.Controls.Add(this.btnReturn);
            this.Controls.Add(this.btnDiscardChanges);
            this.Controls.Add(this.btnConfirmChanges);
            this.Controls.Add(this.dataGridViewManageCities);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ManageCitiesWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Správa měst";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewManageCities)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewManageCities;
        private System.Windows.Forms.Button btnConfirmChanges;
        private System.Windows.Forms.Button btnDiscardChanges;
        private System.Windows.Forms.Button btnReturn;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnCityName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.Button btnNewCityRow;
        private System.Windows.Forms.Button btnDeleteSelectedCityRow;
    }
}