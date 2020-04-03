﻿namespace PresentationLayer
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.label1 = new System.Windows.Forms.Label();
            this.cmbMeasure = new System.Windows.Forms.ComboBox();
            this.btnNewRecordRow = new System.Windows.Forms.Button();
            this.btnManageCities = new System.Windows.Forms.Button();
            this.dataGridViewComboBoxColumn1 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.dataGridViewDataset.AllowUserToAddRows = false;
            this.dataGridViewDataset.AllowUserToOrderColumns = true;
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
            this.dataGridViewDataset.Size = new System.Drawing.Size(863, 295);
            this.dataGridViewDataset.TabIndex = 2;
            this.dataGridViewDataset.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewDataset_CellClick);
            this.dataGridViewDataset.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewDataset_CellEndEdit);
            this.dataGridViewDataset.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dataGridViewDataset_CellValidating);
            // 
            // columnCity
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            this.columnCity.DefaultCellStyle = dataGridViewCellStyle1;
            this.columnCity.HeaderText = "Město";
            this.columnCity.MaxDropDownItems = 1;
            this.columnCity.Name = "columnCity";
            this.columnCity.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.columnCity.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // columnJanuary
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = null;
            this.columnJanuary.DefaultCellStyle = dataGridViewCellStyle2;
            this.columnJanuary.HeaderText = "Leden";
            this.columnJanuary.Name = "columnJanuary";
            this.columnJanuary.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.columnJanuary.Width = 60;
            // 
            // columnFebruary
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = null;
            this.columnFebruary.DefaultCellStyle = dataGridViewCellStyle3;
            this.columnFebruary.HeaderText = "Únor";
            this.columnFebruary.Name = "columnFebruary";
            this.columnFebruary.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.columnFebruary.Width = 60;
            // 
            // columnMarch
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = null;
            this.columnMarch.DefaultCellStyle = dataGridViewCellStyle4;
            this.columnMarch.HeaderText = "Březen";
            this.columnMarch.Name = "columnMarch";
            this.columnMarch.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.columnMarch.Width = 60;
            // 
            // columnApril
            // 
            this.columnApril.HeaderText = "Duben";
            this.columnApril.Name = "columnApril";
            this.columnApril.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.columnApril.Width = 60;
            // 
            // columnMay
            // 
            this.columnMay.HeaderText = "Květen";
            this.columnMay.Name = "columnMay";
            this.columnMay.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.columnMay.Width = 60;
            // 
            // columnJune
            // 
            this.columnJune.HeaderText = "Červen";
            this.columnJune.Name = "columnJune";
            this.columnJune.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.columnJune.Width = 60;
            // 
            // columnJuly
            // 
            this.columnJuly.HeaderText = "Červenec";
            this.columnJuly.Name = "columnJuly";
            this.columnJuly.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.columnJuly.Width = 60;
            // 
            // columnAugust
            // 
            this.columnAugust.HeaderText = "Srpen";
            this.columnAugust.Name = "columnAugust";
            this.columnAugust.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.columnAugust.Width = 60;
            // 
            // columnSeptember
            // 
            this.columnSeptember.HeaderText = "Září";
            this.columnSeptember.Name = "columnSeptember";
            this.columnSeptember.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.columnSeptember.Width = 60;
            // 
            // columnOctober
            // 
            this.columnOctober.HeaderText = "Říjen";
            this.columnOctober.Name = "columnOctober";
            this.columnOctober.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.columnOctober.Width = 60;
            // 
            // columnNovember
            // 
            this.columnNovember.HeaderText = "Listopad";
            this.columnNovember.Name = "columnNovember";
            this.columnNovember.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.columnNovember.Width = 60;
            // 
            // columnDecember
            // 
            this.columnDecember.HeaderText = "Prosinec";
            this.columnDecember.Name = "columnDecember";
            this.columnDecember.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.columnDecember.Width = 60;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Vybraná jednotka teploty:";
            // 
            // cmbMeasure
            // 
            this.cmbMeasure.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMeasure.FormattingEnabled = true;
            this.cmbMeasure.Location = new System.Drawing.Point(139, 55);
            this.cmbMeasure.Name = "cmbMeasure";
            this.cmbMeasure.Size = new System.Drawing.Size(204, 21);
            this.cmbMeasure.TabIndex = 4;
            this.cmbMeasure.SelectedIndexChanged += new System.EventHandler(this.cmbMeasure_SelectedIndexChanged);
            // 
            // btnNewRecordRow
            // 
            this.btnNewRecordRow.Location = new System.Drawing.Point(12, 103);
            this.btnNewRecordRow.Name = "btnNewRecordRow";
            this.btnNewRecordRow.Size = new System.Drawing.Size(105, 34);
            this.btnNewRecordRow.TabIndex = 5;
            this.btnNewRecordRow.Text = "Nová řádka";
            this.btnNewRecordRow.UseVisualStyleBackColor = true;
            this.btnNewRecordRow.Click += new System.EventHandler(this.btnNewRecordRow_Click);
            // 
            // btnManageCities
            // 
            this.btnManageCities.Location = new System.Drawing.Point(769, 103);
            this.btnManageCities.Name = "btnManageCities";
            this.btnManageCities.Size = new System.Drawing.Size(105, 34);
            this.btnManageCities.TabIndex = 6;
            this.btnManageCities.Text = "Správa měst";
            this.btnManageCities.UseVisualStyleBackColor = true;
            this.btnManageCities.Click += new System.EventHandler(this.btnManageCities_Click);
            // 
            // dataGridViewComboBoxColumn1
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            this.dataGridViewComboBoxColumn1.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewComboBoxColumn1.HeaderText = "Město";
            this.dataGridViewComboBoxColumn1.MaxDropDownItems = 1;
            this.dataGridViewComboBoxColumn1.Name = "dataGridViewComboBoxColumn1";
            this.dataGridViewComboBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewComboBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle6.Format = "N2";
            dataGridViewCellStyle6.NullValue = null;
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewTextBoxColumn1.HeaderText = "Leden";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn1.Width = 60;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle7.Format = "N2";
            dataGridViewCellStyle7.NullValue = null;
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridViewTextBoxColumn2.HeaderText = "Únor";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn2.Width = 60;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle8.Format = "N2";
            dataGridViewCellStyle8.NullValue = null;
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridViewTextBoxColumn3.HeaderText = "Březen";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn3.Width = 60;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Duben";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn4.Width = 60;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "Květen";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn5.Width = 60;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "Červen";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn6.Width = 60;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.HeaderText = "Červenec";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn7.Width = 60;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.HeaderText = "Srpen";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn8.Width = 60;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.HeaderText = "Září";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn9.Width = 60;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.HeaderText = "Říjen";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn10.Width = 60;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.HeaderText = "Listopad";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn11.Width = 60;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.HeaderText = "Prosinec";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn12.Width = 60;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(886, 450);
            this.Controls.Add(this.btnManageCities);
            this.Controls.Add(this.btnNewRecordRow);
            this.Controls.Add(this.cmbMeasure);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridViewDataset);
            this.Controls.Add(this.cmbDataset);
            this.Controls.Add(this.labelDataset);
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Zpracování naměřených teplot";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDataset)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelDataset;
        private System.Windows.Forms.ComboBox cmbDataset;
        private System.Windows.Forms.DataGridView dataGridViewDataset;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbMeasure;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
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
        private System.Windows.Forms.Button btnNewRecordRow;
        private System.Windows.Forms.Button btnManageCities;
        private System.Windows.Forms.DataGridViewComboBoxColumn dataGridViewComboBoxColumn1;
    }
}
