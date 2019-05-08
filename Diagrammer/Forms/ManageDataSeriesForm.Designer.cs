namespace Diagrammer.Forms {
    partial class ManageDataSeriesForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManageDataSeriesForm));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.buttonRemoveSeries = new System.Windows.Forms.Button();
            this.buttonAddSeries = new System.Windows.Forms.Button();
            this.listBoxSeries = new System.Windows.Forms.ListBox();
            this.textBoxSeriesLabel = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonSeriesColor = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxSeriesData = new System.Windows.Forms.TextBox();
            this.textBoxChartTitle = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxChartType = new System.Windows.Forms.ComboBox();
            this.manageDataSeriesFormBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.manageDataSeriesFormBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 32);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.buttonRemoveSeries);
            this.splitContainer1.Panel1.Controls.Add(this.buttonAddSeries);
            this.splitContainer1.Panel1.Controls.Add(this.listBoxSeries);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.textBoxSeriesLabel);
            this.splitContainer1.Panel2.Controls.Add(this.label5);
            this.splitContainer1.Panel2.Controls.Add(this.buttonOK);
            this.splitContainer1.Panel2.Controls.Add(this.buttonCancel);
            this.splitContainer1.Panel2.Controls.Add(this.label3);
            this.splitContainer1.Panel2.Controls.Add(this.buttonSeriesColor);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.textBoxSeriesData);
            this.splitContainer1.Size = new System.Drawing.Size(600, 310);
            this.splitContainer1.SplitterDistance = 199;
            this.splitContainer1.TabIndex = 0;
            // 
            // buttonRemoveSeries
            // 
            this.buttonRemoveSeries.Location = new System.Drawing.Point(105, 284);
            this.buttonRemoveSeries.Name = "buttonRemoveSeries";
            this.buttonRemoveSeries.Size = new System.Drawing.Size(94, 23);
            this.buttonRemoveSeries.TabIndex = 2;
            this.buttonRemoveSeries.Text = "&Remove -";
            this.buttonRemoveSeries.UseVisualStyleBackColor = true;
            this.buttonRemoveSeries.Click += new System.EventHandler(this.buttonRemoveSeries_Click);
            // 
            // buttonAddSeries
            // 
            this.buttonAddSeries.Location = new System.Drawing.Point(0, 284);
            this.buttonAddSeries.Name = "buttonAddSeries";
            this.buttonAddSeries.Size = new System.Drawing.Size(95, 23);
            this.buttonAddSeries.TabIndex = 1;
            this.buttonAddSeries.Text = "&Add +";
            this.buttonAddSeries.UseVisualStyleBackColor = true;
            this.buttonAddSeries.Click += new System.EventHandler(this.buttonAddSeries_Click);
            // 
            // listBoxSeries
            // 
            this.listBoxSeries.FormattingEnabled = true;
            this.listBoxSeries.Location = new System.Drawing.Point(0, 0);
            this.listBoxSeries.Name = "listBoxSeries";
            this.listBoxSeries.Size = new System.Drawing.Size(199, 277);
            this.listBoxSeries.TabIndex = 0;
            this.listBoxSeries.SelectedIndexChanged += new System.EventHandler(this.listBoxSeries_SelectedIndexChanged);
            // 
            // textBoxSeriesLabel
            // 
            this.textBoxSeriesLabel.Location = new System.Drawing.Point(71, 8);
            this.textBoxSeriesLabel.Name = "textBoxSeriesLabel";
            this.textBoxSeriesLabel.Size = new System.Drawing.Size(220, 20);
            this.textBoxSeriesLabel.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Series label:";
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(238, 283);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 5;
            this.buttonOK.Text = "&OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(319, 283);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 4;
            this.buttonCancel.Text = "&Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(297, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Series color:";
            // 
            // buttonSeriesColor
            // 
            this.buttonSeriesColor.BackColor = System.Drawing.Color.White;
            this.buttonSeriesColor.Location = new System.Drawing.Point(368, 6);
            this.buttonSeriesColor.Name = "buttonSeriesColor";
            this.buttonSeriesColor.Size = new System.Drawing.Size(23, 23);
            this.buttonSeriesColor.TabIndex = 2;
            this.buttonSeriesColor.UseVisualStyleBackColor = false;
            this.buttonSeriesColor.Click += new System.EventHandler(this.buttonSeriesColor_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Data:";
            // 
            // textBoxSeriesData
            // 
            this.textBoxSeriesData.Location = new System.Drawing.Point(2, 48);
            this.textBoxSeriesData.Multiline = true;
            this.textBoxSeriesData.Name = "textBoxSeriesData";
            this.textBoxSeriesData.Size = new System.Drawing.Size(392, 229);
            this.textBoxSeriesData.TabIndex = 0;
            // 
            // textBoxChartTitle
            // 
            this.textBoxChartTitle.Location = new System.Drawing.Point(65, 6);
            this.textBoxChartTitle.Name = "textBoxChartTitle";
            this.textBoxChartTitle.Size = new System.Drawing.Size(237, 20);
            this.textBoxChartTitle.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Chart title:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(339, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Chart type:";
            // 
            // comboBoxChartType
            // 
            this.comboBoxChartType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxChartType.FormattingEnabled = true;
            this.comboBoxChartType.Location = new System.Drawing.Point(403, 6);
            this.comboBoxChartType.Name = "comboBoxChartType";
            this.comboBoxChartType.Size = new System.Drawing.Size(194, 21);
            this.comboBoxChartType.TabIndex = 2;
            // 
            // manageDataSeriesFormBindingSource
            // 
            this.manageDataSeriesFormBindingSource.DataSource = typeof(Diagrammer.Forms.ManageDataSeriesForm);
            // 
            // ManageDataSeriesForm
            // 
            this.AcceptButton = this.buttonAddSeries;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(599, 341);
            this.Controls.Add(this.textBoxChartTitle);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxChartType);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(615, 380);
            this.MinimumSize = new System.Drawing.Size(615, 380);
            this.Name = "ManageDataSeriesForm";
            this.Text = "Manage chart data";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.manageDataSeriesFormBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListBox listBoxSeries;
        private System.Windows.Forms.Button buttonSeriesColor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxSeriesData;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxChartType;
        private System.Windows.Forms.Button buttonRemoveSeries;
        private System.Windows.Forms.Button buttonAddSeries;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.TextBox textBoxChartTitle;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxSeriesLabel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.BindingSource manageDataSeriesFormBindingSource;
    }
}