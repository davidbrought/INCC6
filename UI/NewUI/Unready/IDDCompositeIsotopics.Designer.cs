﻿namespace NewUI
{
    partial class IDDCompositeIsotopics
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
        {
            if (disposing && (components != null))
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IDDCompositeIsotopics));
            this.OKBtn = new System.Windows.Forms.Button();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.HelpBtn = new System.Windows.Forms.Button();
            this.ReadBtn = new System.Windows.Forms.Button();
            this.WriteBtn = new System.Windows.Forms.Button();
            this.AddBtn = new System.Windows.Forms.Button();
            this.SaveBtn = new System.Windows.Forms.Button();
            this.EditBtn = new System.Windows.Forms.Button();
            this.DeleteBtn = new System.Windows.Forms.Button();
            this.InstructionsLabel = new System.Windows.Forms.Label();
            this.IsotopicsIdComboBox = new System.Windows.Forms.ComboBox();
            this.IsoSrcCodeComboBox = new System.Windows.Forms.ComboBox();
            this.IsotopicsIdLabel = new System.Windows.Forms.Label();
            this.ReferenceDateLabel = new System.Windows.Forms.Label();
            this.IsoSrcCodeLabel = new System.Windows.Forms.Label();
            this.CalculateBtn = new System.Windows.Forms.Button();
            this.ReferenceDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.IsoDataGrid = new System.Windows.Forms.DataGridView();
            this.PuMass = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pu238 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pu239 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pu240 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pu241 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pu242 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PuDate = new NewUI.CalendarColumn();
            this.Am241 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AmDate = new NewUI.CalendarColumn();
            ((System.ComponentModel.ISupportInitialize)(this.IsoDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // OKBtn
            // 
            this.OKBtn.Location = new System.Drawing.Point(682, 12);
            this.OKBtn.Name = "OKBtn";
            this.OKBtn.Size = new System.Drawing.Size(75, 23);
            this.OKBtn.TabIndex = 0;
            this.OKBtn.Text = "OK";
            this.OKBtn.UseVisualStyleBackColor = true;
            this.OKBtn.Click += new System.EventHandler(this.OKBtn_Click);
            // 
            // CancelBtn
            // 
            this.CancelBtn.Location = new System.Drawing.Point(682, 41);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(75, 23);
            this.CancelBtn.TabIndex = 1;
            this.CancelBtn.Text = "Cancel";
            this.CancelBtn.UseVisualStyleBackColor = true;
            this.CancelBtn.Click += new System.EventHandler(this.CancelBtn_Click);
            // 
            // HelpBtn
            // 
            this.HelpBtn.Location = new System.Drawing.Point(682, 70);
            this.HelpBtn.Name = "HelpBtn";
            this.HelpBtn.Size = new System.Drawing.Size(75, 23);
            this.HelpBtn.TabIndex = 2;
            this.HelpBtn.Text = "Help";
            this.HelpBtn.UseVisualStyleBackColor = true;
            this.HelpBtn.Click += new System.EventHandler(this.HelpBtn_Click);
            // 
            // ReadBtn
            // 
            this.ReadBtn.Location = new System.Drawing.Point(534, 99);
            this.ReadBtn.Name = "ReadBtn";
            this.ReadBtn.Size = new System.Drawing.Size(223, 23);
            this.ReadBtn.TabIndex = 3;
            this.ReadBtn.Text = "Read composite isotopics from file";
            this.toolTip1.SetToolTip(this.ReadBtn, "Clicking here brings up windows file selection dialog to select a composite isoto" +
        "pics file to import into INCC");
            this.ReadBtn.UseVisualStyleBackColor = true;
            this.ReadBtn.Click += new System.EventHandler(this.ReadBtn_Click);
            // 
            // WriteBtn
            // 
            this.WriteBtn.Location = new System.Drawing.Point(534, 128);
            this.WriteBtn.Name = "WriteBtn";
            this.WriteBtn.Size = new System.Drawing.Size(223, 23);
            this.WriteBtn.TabIndex = 4;
            this.WriteBtn.Text = "Write composite isotopics to file...";
            this.toolTip1.SetToolTip(this.WriteBtn, resources.GetString("WriteBtn.ToolTip"));
            this.WriteBtn.UseVisualStyleBackColor = true;
            this.WriteBtn.Click += new System.EventHandler(this.WriteBtn_Click);
            // 
            // AddBtn
            // 
            this.AddBtn.Location = new System.Drawing.Point(534, 157);
            this.AddBtn.Name = "AddBtn";
            this.AddBtn.Size = new System.Drawing.Size(223, 23);
            this.AddBtn.TabIndex = 5;
            this.AddBtn.Text = "Add new composite isotopics data set";
            this.toolTip1.SetToolTip(this.AddBtn, resources.GetString("AddBtn.ToolTip"));
            this.AddBtn.UseVisualStyleBackColor = true;
            this.AddBtn.Click += new System.EventHandler(this.AddBtn_Click);
            // 
            // SaveBtn
            // 
            this.SaveBtn.Location = new System.Drawing.Point(534, 186);
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Size = new System.Drawing.Size(223, 23);
            this.SaveBtn.TabIndex = 6;
            this.SaveBtn.Text = "Save composite isotopics data set";
            this.toolTip1.SetToolTip(this.SaveBtn, "Clicking here will save the currently displayed composite isotopics values for th" +
        "e currently displayed composite isotopics id");
            this.SaveBtn.UseVisualStyleBackColor = true;
            this.SaveBtn.Click += new System.EventHandler(this.SaveBtn_Click);
            // 
            // EditBtn
            // 
            this.EditBtn.Location = new System.Drawing.Point(534, 215);
            this.EditBtn.Name = "EditBtn";
            this.EditBtn.Size = new System.Drawing.Size(223, 23);
            this.EditBtn.TabIndex = 7;
            this.EditBtn.Text = "Edit composite isotopics id";
            this.toolTip1.SetToolTip(this.EditBtn, "Clicking here will bring up a dialog box prompting you to enter a new isotopics i" +
        "d for the currently displayed isotopics data set");
            this.EditBtn.UseVisualStyleBackColor = true;
            this.EditBtn.Click += new System.EventHandler(this.EditBtn_Click);
            // 
            // DeleteBtn
            // 
            this.DeleteBtn.Location = new System.Drawing.Point(534, 244);
            this.DeleteBtn.Name = "DeleteBtn";
            this.DeleteBtn.Size = new System.Drawing.Size(223, 23);
            this.DeleteBtn.TabIndex = 9;
            this.DeleteBtn.Text = "Delete composite isotopics data set";
            this.toolTip1.SetToolTip(this.DeleteBtn, "Clicking here will bring up a dialog box asking confirmation for deleting the cur" +
        "rently displayed composite isotopics data set ");
            this.DeleteBtn.UseVisualStyleBackColor = true;
            this.DeleteBtn.Click += new System.EventHandler(this.DeleteBtn_Click);
            // 
            // InstructionsLabel
            // 
            this.InstructionsLabel.AutoSize = true;
            this.InstructionsLabel.Location = new System.Drawing.Point(12, 9);
            this.InstructionsLabel.Name = "InstructionsLabel";
            this.InstructionsLabel.Size = new System.Drawing.Size(433, 13);
            this.InstructionsLabel.TabIndex = 10;
            this.InstructionsLabel.Text = "When all isotopic data sets are entered, click on the \'Calculate and Store Isotop" +
    "ics\' button.";
            // 
            // IsotopicsIdComboBox
            // 
            this.IsotopicsIdComboBox.FormattingEnabled = true;
            this.IsotopicsIdComboBox.Location = new System.Drawing.Point(127, 112);
            this.IsotopicsIdComboBox.Name = "IsotopicsIdComboBox";
            this.IsotopicsIdComboBox.Size = new System.Drawing.Size(200, 21);
            this.IsotopicsIdComboBox.TabIndex = 12;
            this.toolTip1.SetToolTip(this.IsotopicsIdComboBox, "Select the desired composite isotopics data set from the picklist");
            this.IsotopicsIdComboBox.SelectedIndexChanged += new System.EventHandler(this.IsotopicsIdComboBox_SelectedIndexChanged);
            // 
            // IsoSrcCodeComboBox
            // 
            this.IsoSrcCodeComboBox.FormattingEnabled = true;
            this.IsoSrcCodeComboBox.Location = new System.Drawing.Point(127, 179);
            this.IsoSrcCodeComboBox.Name = "IsoSrcCodeComboBox";
            this.IsoSrcCodeComboBox.Size = new System.Drawing.Size(200, 21);
            this.IsoSrcCodeComboBox.TabIndex = 13;
            this.toolTip1.SetToolTip(this.IsoSrcCodeComboBox, resources.GetString("IsoSrcCodeComboBox.ToolTip"));
            this.IsoSrcCodeComboBox.SelectedIndexChanged += new System.EventHandler(this.IsoSrcCodeComboBox_SelectedIndexChanged);
            // 
            // IsotopicsIdLabel
            // 
            this.IsotopicsIdLabel.AutoSize = true;
            this.IsotopicsIdLabel.Location = new System.Drawing.Point(10, 115);
            this.IsotopicsIdLabel.Name = "IsotopicsIdLabel";
            this.IsotopicsIdLabel.Size = new System.Drawing.Size(111, 13);
            this.IsotopicsIdLabel.TabIndex = 15;
            this.IsotopicsIdLabel.Text = "Composite isotopics id";
            // 
            // ReferenceDateLabel
            // 
            this.ReferenceDateLabel.AutoSize = true;
            this.ReferenceDateLabel.Location = new System.Drawing.Point(41, 148);
            this.ReferenceDateLabel.Name = "ReferenceDateLabel";
            this.ReferenceDateLabel.Size = new System.Drawing.Size(81, 13);
            this.ReferenceDateLabel.TabIndex = 16;
            this.ReferenceDateLabel.Text = "Reference date";
            // 
            // IsoSrcCodeLabel
            // 
            this.IsoSrcCodeLabel.AutoSize = true;
            this.IsoSrcCodeLabel.Location = new System.Drawing.Point(10, 182);
            this.IsoSrcCodeLabel.Name = "IsoSrcCodeLabel";
            this.IsoSrcCodeLabel.Size = new System.Drawing.Size(111, 13);
            this.IsoSrcCodeLabel.TabIndex = 17;
            this.IsoSrcCodeLabel.Text = "Isotopics source code";
            // 
            // CalculateBtn
            // 
            this.CalculateBtn.BackColor = System.Drawing.Color.Lime;
            this.CalculateBtn.Location = new System.Drawing.Point(127, 52);
            this.CalculateBtn.Name = "CalculateBtn";
            this.CalculateBtn.Size = new System.Drawing.Size(200, 23);
            this.CalculateBtn.TabIndex = 18;
            this.CalculateBtn.Text = "Calculate and Store Isotopics";
            this.toolTip1.SetToolTip(this.CalculateBtn, "Clicking here will cause a composite set of isotopics to be calculated and displa" +
        "yed. If you then click on OK, the composite isotopics will be stored in the isot" +
        "opics database");
            this.CalculateBtn.UseVisualStyleBackColor = false;
            this.CalculateBtn.Click += new System.EventHandler(this.CalculateBtn_Click);
            // 
            // ReferenceDateTimePicker
            // 
            this.ReferenceDateTimePicker.Location = new System.Drawing.Point(127, 146);
            this.ReferenceDateTimePicker.Name = "ReferenceDateTimePicker";
            this.ReferenceDateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.ReferenceDateTimePicker.TabIndex = 19;
            this.toolTip1.SetToolTip(this.ReferenceDateTimePicker, "The date the isotopics were determined");
            this.ReferenceDateTimePicker.ValueChanged += new System.EventHandler(this.ReferenceDateTimePicker_ValueChanged);
            // 
            // IsoDataGrid
            // 
            this.IsoDataGrid.AllowUserToDeleteRows = false;
            this.IsoDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.IsoDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PuMass,
            this.Pu238,
            this.Pu239,
            this.Pu240,
            this.Pu241,
            this.Pu242,
            this.PuDate,
            this.Am241,
            this.AmDate});
            this.IsoDataGrid.Location = new System.Drawing.Point(0, 282);
            this.IsoDataGrid.Name = "IsoDataGrid";
            this.IsoDataGrid.RowHeadersVisible = false;
            this.IsoDataGrid.Size = new System.Drawing.Size(769, 243);
            this.IsoDataGrid.TabIndex = 20;
            // 
            // PuMass
            // 
            this.PuMass.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.PuMass.HeaderText = "Pu Mass (g)";
            this.PuMass.Name = "PuMass";
            this.PuMass.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Pu238
            // 
            this.Pu238.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Pu238.HeaderText = "% Pu238";
            this.Pu238.Name = "Pu238";
            this.Pu238.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Pu239
            // 
            this.Pu239.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Pu239.HeaderText = "% Pu239";
            this.Pu239.Name = "Pu239";
            this.Pu239.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Pu240
            // 
            this.Pu240.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Pu240.HeaderText = "% Pu240";
            this.Pu240.Name = "Pu240";
            this.Pu240.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Pu241
            // 
            this.Pu241.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Pu241.HeaderText = "% Pu241";
            this.Pu241.Name = "Pu241";
            this.Pu241.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Pu242
            // 
            this.Pu242.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Pu242.HeaderText = "% Pu242";
            this.Pu242.Name = "Pu242";
            this.Pu242.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // PuDate
            // 
            this.PuDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.PuDate.HeaderText = "Pu Date";
            this.PuDate.Name = "PuDate";
            // 
            // Am241
            // 
            this.Am241.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Am241.HeaderText = "% Am241";
            this.Am241.Name = "Am241";
            this.Am241.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // AmDate
            // 
            this.AmDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.AmDate.HeaderText = "Am Date";
            this.AmDate.Name = "AmDate";
            // 
            // IDDCompositeIsotopics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(769, 517);
            this.Controls.Add(this.IsoDataGrid);
            this.Controls.Add(this.ReferenceDateTimePicker);
            this.Controls.Add(this.CalculateBtn);
            this.Controls.Add(this.IsoSrcCodeLabel);
            this.Controls.Add(this.ReferenceDateLabel);
            this.Controls.Add(this.IsotopicsIdLabel);
            this.Controls.Add(this.IsoSrcCodeComboBox);
            this.Controls.Add(this.IsotopicsIdComboBox);
            this.Controls.Add(this.InstructionsLabel);
            this.Controls.Add(this.DeleteBtn);
            this.Controls.Add(this.EditBtn);
            this.Controls.Add(this.SaveBtn);
            this.Controls.Add(this.AddBtn);
            this.Controls.Add(this.WriteBtn);
            this.Controls.Add(this.ReadBtn);
            this.Controls.Add(this.HelpBtn);
            this.Controls.Add(this.CancelBtn);
            this.Controls.Add(this.OKBtn);
            this.Name = "IDDCompositeIsotopics";
            this.Text = "Composite Isotopics";
            ((System.ComponentModel.ISupportInitialize)(this.IsoDataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button OKBtn;
        private System.Windows.Forms.Button CancelBtn;
        private System.Windows.Forms.Button HelpBtn;
        private System.Windows.Forms.Button ReadBtn;
        private System.Windows.Forms.Button WriteBtn;
        private System.Windows.Forms.Button AddBtn;
        private System.Windows.Forms.Button SaveBtn;
        private System.Windows.Forms.Button EditBtn;
        private System.Windows.Forms.Button DeleteBtn;
        private System.Windows.Forms.Label InstructionsLabel;
        private System.Windows.Forms.ComboBox IsotopicsIdComboBox;
        private System.Windows.Forms.ComboBox IsoSrcCodeComboBox;
        private System.Windows.Forms.Label IsotopicsIdLabel;
        private System.Windows.Forms.Label ReferenceDateLabel;
        private System.Windows.Forms.Label IsoSrcCodeLabel;
        private System.Windows.Forms.Button CalculateBtn;
        private System.Windows.Forms.DateTimePicker ReferenceDateTimePicker;
		private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.DataGridView IsoDataGrid;
        private CalendarColumn AmDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Am241;
        private CalendarColumn PuDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pu242;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pu241;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pu240;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pu239;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pu238;
        private System.Windows.Forms.DataGridViewTextBoxColumn PuMass;
    }
}