namespace Diagrammer.Forms {
    partial class MainForm {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.mainMenu = new System.Windows.Forms.MainMenu(this.components);
            this.mainMenuRootItem = new System.Windows.Forms.MenuItem();
            this.menuItemSave = new System.Windows.Forms.MenuItem();
            this.menuItemSerialize = new System.Windows.Forms.MenuItem();
            this.menuItemLoad = new System.Windows.Forms.MenuItem();
            this.menuItemAbout = new System.Windows.Forms.MenuItem();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonRemove = new System.Windows.Forms.Button();
            this.listBoxCharts = new System.Windows.Forms.ListBox();
            this.mainFormBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainFormBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mainMenuRootItem});
            // 
            // mainMenuRootItem
            // 
            this.mainMenuRootItem.Index = 0;
            this.mainMenuRootItem.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemSave,
            this.menuItemSerialize,
            this.menuItemLoad,
            this.menuItemAbout});
            this.mainMenuRootItem.Text = "&File";
            // 
            // menuItemSave
            // 
            this.menuItemSave.Index = 0;
            this.menuItemSave.Text = "&Save as image (.png)";
            this.menuItemSave.Click += new System.EventHandler(this.menuItemSaveImg_Click);
            // 
            // menuItemSerialize
            // 
            this.menuItemSerialize.Index = 1;
            this.menuItemSerialize.Text = "&Save all as .bchrt";
            this.menuItemSerialize.Click += new System.EventHandler(this.menuItemSerialize_Click);
            // 
            // menuItemLoad
            // 
            this.menuItemLoad.Index = 2;
            this.menuItemLoad.Text = "&Load from .bchrt";
            this.menuItemLoad.Click += new System.EventHandler(this.menuItemLoad_Click);
            // 
            // menuItemAbout
            // 
            this.menuItemAbout.Index = 3;
            this.menuItemAbout.Text = "&About";
            this.menuItemAbout.Click += new System.EventHandler(this.menuItemAbout_Click);
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.tableLayoutPanel1);
            this.splitContainer.Panel1.Controls.Add(this.listBoxCharts);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.chartPanel_Paint);
            this.splitContainer.Panel2.Resize += new System.EventHandler(this.chartPanel_Resize);
            this.splitContainer.Size = new System.Drawing.Size(784, 414);
            this.splitContainer.SplitterDistance = 186;
            this.splitContainer.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.buttonAdd, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonRemove, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 386);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(186, 28);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // buttonAdd
            // 
            this.buttonAdd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonAdd.Location = new System.Drawing.Point(3, 3);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(87, 22);
            this.buttonAdd.TabIndex = 0;
            this.buttonAdd.Text = "+ &Add";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonRemove
            // 
            this.buttonRemove.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonRemove.Location = new System.Drawing.Point(96, 3);
            this.buttonRemove.Name = "buttonRemove";
            this.buttonRemove.Size = new System.Drawing.Size(87, 22);
            this.buttonRemove.TabIndex = 1;
            this.buttonRemove.Text = "- &Remove";
            this.buttonRemove.UseVisualStyleBackColor = true;
            this.buttonRemove.Click += new System.EventHandler(this.buttonRemove_Click);
            // 
            // listBoxCharts
            // 
            this.listBoxCharts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxCharts.FormattingEnabled = true;
            this.listBoxCharts.Location = new System.Drawing.Point(0, 0);
            this.listBoxCharts.Name = "listBoxCharts";
            this.listBoxCharts.Size = new System.Drawing.Size(186, 414);
            this.listBoxCharts.TabIndex = 5;
            this.listBoxCharts.SelectedIndexChanged += new System.EventHandler(this.listBoxCharts_SelectedIndexChanged);
            this.listBoxCharts.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBoxCharts_MouseDoubleClick);
            // 
            // mainFormBindingSource
            // 
            this.mainFormBindingSource.DataSource = typeof(Diagrammer.Forms.MainForm);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(784, 414);
            this.Controls.Add(this.splitContainer);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Menu = this.mainMenu;
            this.Name = "MainForm";
            this.Text = "Diagrammer GUI";
            this.splitContainer.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mainFormBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MainMenu mainMenu;
        private System.Windows.Forms.MenuItem mainMenuRootItem;
        private System.Windows.Forms.MenuItem menuItemSave;
        private System.Windows.Forms.MenuItem menuItemAbout;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.MenuItem menuItemLoad;
        private System.Windows.Forms.MenuItem menuItemSerialize;
        private System.Windows.Forms.ListBox listBoxCharts;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonRemove;
        private System.Windows.Forms.BindingSource mainFormBindingSource;
    }
}