using System.Windows.Forms;

namespace Meal_Chooser_2
{
	partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.peoplelist = new System.Windows.Forms.ComboBox();
            this.subingrpanel = new System.Windows.Forms.FlowLayoutPanel();
            this.ingredientlistbox = new System.Windows.Forms.ListBox();
            this.tabcontrol = new System.Windows.Forms.TabControl();
            this.setpeople = new System.Windows.Forms.TabPage();
            this.newbutton = new System.Windows.Forms.Button();
            this.addingredienttabpage = new System.Windows.Forms.TabPage();
            this.Editcategories = new System.Windows.Forms.Button();
            this.deleteselectedbutton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.addingrbutton = new System.Windows.Forms.Button();
            this.editingrbox = new System.Windows.Forms.ListBox();
            this.editmealtab = new System.Windows.Forms.TabPage();
            this.Editmeal = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.addmealbutton = new System.Windows.Forms.Button();
            this.editmeallbox = new System.Windows.Forms.ListBox();
            this.comparetab = new System.Windows.Forms.TabPage();
            this.comparechart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel1 = new System.Windows.Forms.Panel();
            this.mealchecklist = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.peoplecheckbox = new System.Windows.Forms.CheckedListBox();
            this.comparebutton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.tabcontrol.SuspendLayout();
            this.setpeople.SuspendLayout();
            this.addingredienttabpage.SuspendLayout();
            this.editmealtab.SuspendLayout();
            this.comparetab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comparechart)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Silver;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(905, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // peoplelist
            // 
            this.peoplelist.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.peoplelist.FormattingEnabled = true;
            this.peoplelist.Location = new System.Drawing.Point(6, 6);
            this.peoplelist.Name = "peoplelist";
            this.peoplelist.Size = new System.Drawing.Size(225, 21);
            this.peoplelist.TabIndex = 2;
            this.peoplelist.SelectedIndexChanged += new System.EventHandler(this.peoplelist_SelectedIndexChanged);
            // 
            // subingrpanel
            // 
            this.subingrpanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.subingrpanel.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.subingrpanel.Location = new System.Drawing.Point(124, 33);
            this.subingrpanel.Name = "subingrpanel";
            this.subingrpanel.Size = new System.Drawing.Size(773, 368);
            this.subingrpanel.TabIndex = 3;
            // 
            // ingredientlistbox
            // 
            this.ingredientlistbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.ingredientlistbox.FormattingEnabled = true;
            this.ingredientlistbox.Location = new System.Drawing.Point(3, 33);
            this.ingredientlistbox.MultiColumn = true;
            this.ingredientlistbox.Name = "ingredientlistbox";
            this.ingredientlistbox.Size = new System.Drawing.Size(115, 368);
            this.ingredientlistbox.TabIndex = 4;
            this.ingredientlistbox.SelectedIndexChanged += new System.EventHandler(this.ingpedientlistbox_SelectedIndexChanged);
            // 
            // tabcontrol
            // 
            this.tabcontrol.Controls.Add(this.setpeople);
            this.tabcontrol.Controls.Add(this.addingredienttabpage);
            this.tabcontrol.Controls.Add(this.editmealtab);
            this.tabcontrol.Controls.Add(this.comparetab);
            this.tabcontrol.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabcontrol.Location = new System.Drawing.Point(0, 24);
            this.tabcontrol.Name = "tabcontrol";
            this.tabcontrol.SelectedIndex = 0;
            this.tabcontrol.Size = new System.Drawing.Size(905, 427);
            this.tabcontrol.TabIndex = 5;
            // 
            // setpeople
            // 
            this.setpeople.Controls.Add(this.newbutton);
            this.setpeople.Controls.Add(this.peoplelist);
            this.setpeople.Controls.Add(this.ingredientlistbox);
            this.setpeople.Controls.Add(this.subingrpanel);
            this.setpeople.Location = new System.Drawing.Point(4, 22);
            this.setpeople.Name = "setpeople";
            this.setpeople.Padding = new System.Windows.Forms.Padding(3);
            this.setpeople.Size = new System.Drawing.Size(897, 401);
            this.setpeople.TabIndex = 0;
            this.setpeople.Text = "Set People Taste Preferences";
            this.setpeople.UseVisualStyleBackColor = true;
            // 
            // newbutton
            // 
            this.newbutton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.newbutton.Location = new System.Drawing.Point(765, 4);
            this.newbutton.Name = "newbutton";
            this.newbutton.Size = new System.Drawing.Size(124, 23);
            this.newbutton.TabIndex = 7;
            this.newbutton.Text = "Create New Person";
            this.newbutton.UseVisualStyleBackColor = true;
            this.newbutton.Click += new System.EventHandler(this.newbutton_Click);
            // 
            // addingredienttabpage
            // 
            this.addingredienttabpage.Controls.Add(this.Editcategories);
            this.addingredienttabpage.Controls.Add(this.deleteselectedbutton);
            this.addingredienttabpage.Controls.Add(this.label3);
            this.addingredienttabpage.Controls.Add(this.addingrbutton);
            this.addingredienttabpage.Controls.Add(this.editingrbox);
            this.addingredienttabpage.Location = new System.Drawing.Point(4, 22);
            this.addingredienttabpage.Name = "addingredienttabpage";
            this.addingredienttabpage.Padding = new System.Windows.Forms.Padding(3);
            this.addingredienttabpage.Size = new System.Drawing.Size(897, 401);
            this.addingredienttabpage.TabIndex = 2;
            this.addingredienttabpage.Text = "Edit Ingredients";
            this.addingredienttabpage.UseVisualStyleBackColor = true;
            // 
            // Editcategories
            // 
            this.Editcategories.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Editcategories.Location = new System.Drawing.Point(11, 6);
            this.Editcategories.Name = "Editcategories";
            this.Editcategories.Size = new System.Drawing.Size(881, 23);
            this.Editcategories.TabIndex = 4;
            this.Editcategories.Text = "Edit Categories";
            this.Editcategories.UseVisualStyleBackColor = true;
            this.Editcategories.Click += new System.EventHandler(this.Editcategories_Click);
            // 
            // deleteselectedbutton
            // 
            this.deleteselectedbutton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.deleteselectedbutton.Location = new System.Drawing.Point(8, 367);
            this.deleteselectedbutton.Name = "deleteselectedbutton";
            this.deleteselectedbutton.Size = new System.Drawing.Size(881, 23);
            this.deleteselectedbutton.TabIndex = 3;
            this.deleteselectedbutton.Text = "Edit Ingredient Categories/ Remove Selected Ingredient";
            this.deleteselectedbutton.UseVisualStyleBackColor = true;
            this.deleteselectedbutton.Click += new System.EventHandler(this.deleteselectedbutton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(436, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "select single ingredient to edit name, or select one or more to have the possibil" +
    "ity of deletion";
            // 
            // addingrbutton
            // 
            this.addingrbutton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.addingrbutton.Location = new System.Drawing.Point(11, 35);
            this.addingrbutton.Name = "addingrbutton";
            this.addingrbutton.Size = new System.Drawing.Size(881, 23);
            this.addingrbutton.TabIndex = 1;
            this.addingrbutton.Text = "Add Ingredient";
            this.addingrbutton.UseVisualStyleBackColor = true;
            this.addingrbutton.Click += new System.EventHandler(this.addingrbutton_Click);
            // 
            // editingrbox
            // 
            this.editingrbox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.editingrbox.FormattingEnabled = true;
            this.editingrbox.Location = new System.Drawing.Point(8, 84);
            this.editingrbox.Name = "editingrbox";
            this.editingrbox.Size = new System.Drawing.Size(881, 277);
            this.editingrbox.TabIndex = 0;
            // 
            // editmealtab
            // 
            this.editmealtab.Controls.Add(this.Editmeal);
            this.editmealtab.Controls.Add(this.label4);
            this.editmealtab.Controls.Add(this.addmealbutton);
            this.editmealtab.Controls.Add(this.editmeallbox);
            this.editmealtab.Location = new System.Drawing.Point(4, 22);
            this.editmealtab.Name = "editmealtab";
            this.editmealtab.Padding = new System.Windows.Forms.Padding(3);
            this.editmealtab.Size = new System.Drawing.Size(897, 401);
            this.editmealtab.TabIndex = 3;
            this.editmealtab.Text = "Edit Meals";
            this.editmealtab.UseVisualStyleBackColor = true;
            // 
            // Editmeal
            // 
            this.Editmeal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Editmeal.Location = new System.Drawing.Point(8, 369);
            this.Editmeal.Name = "Editmeal";
            this.Editmeal.Size = new System.Drawing.Size(881, 23);
            this.Editmeal.TabIndex = 7;
            this.Editmeal.Text = "Edit Meal Ingredients/ Remove Selected Meal";
            this.Editmeal.UseVisualStyleBackColor = true;
            this.Editmeal.Click += new System.EventHandler(this.Editmeal_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(436, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "select single ingredient to edit name, or select one or more to have the possibil" +
    "ity of deletion";
            // 
            // addmealbutton
            // 
            this.addmealbutton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.addmealbutton.Location = new System.Drawing.Point(8, 8);
            this.addmealbutton.Name = "addmealbutton";
            this.addmealbutton.Size = new System.Drawing.Size(881, 23);
            this.addmealbutton.TabIndex = 5;
            this.addmealbutton.Text = "Add Meal";
            this.addmealbutton.UseVisualStyleBackColor = true;
            this.addmealbutton.Click += new System.EventHandler(this.addmealbutton_Click);
            // 
            // editmeallbox
            // 
            this.editmeallbox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.editmeallbox.FormattingEnabled = true;
            this.editmeallbox.Location = new System.Drawing.Point(8, 47);
            this.editmeallbox.Name = "editmeallbox";
            this.editmeallbox.Size = new System.Drawing.Size(881, 316);
            this.editmeallbox.TabIndex = 4;
            // 
            // comparetab
            // 
            this.comparetab.Controls.Add(this.comparechart);
            this.comparetab.Controls.Add(this.panel1);
            this.comparetab.Location = new System.Drawing.Point(4, 22);
            this.comparetab.Name = "comparetab";
            this.comparetab.Padding = new System.Windows.Forms.Padding(3);
            this.comparetab.Size = new System.Drawing.Size(897, 401);
            this.comparetab.TabIndex = 1;
            this.comparetab.Text = "Compare People";
            this.comparetab.UseVisualStyleBackColor = true;
            // 
            // comparechart
            // 
            chartArea1.AxisX.Interval = 1D;
            chartArea1.Name = "ChartArea1";
            this.comparechart.ChartAreas.Add(chartArea1);
            this.comparechart.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.comparechart.Legends.Add(legend1);
            this.comparechart.Location = new System.Drawing.Point(203, 3);
            this.comparechart.Name = "comparechart";
            this.comparechart.Size = new System.Drawing.Size(691, 395);
            this.comparechart.TabIndex = 0;
            this.comparechart.Text = "chart1";
            this.comparechart.MouseMove += new System.Windows.Forms.MouseEventHandler(this.comparechart_MouseMove);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.mealchecklist);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.splitter1);
            this.panel1.Controls.Add(this.peoplecheckbox);
            this.panel1.Controls.Add(this.comparebutton);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 395);
            this.panel1.TabIndex = 2;
            // 
            // mealchecklist
            // 
            this.mealchecklist.CheckOnClick = true;
            this.mealchecklist.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mealchecklist.FormattingEnabled = true;
            this.mealchecklist.Location = new System.Drawing.Point(0, 168);
            this.mealchecklist.Name = "mealchecklist";
            this.mealchecklist.Size = new System.Drawing.Size(200, 204);
            this.mealchecklist.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 155);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Select meal types to compare";
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Location = new System.Drawing.Point(0, 152);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(200, 3);
            this.splitter1.TabIndex = 3;
            this.splitter1.TabStop = false;
            // 
            // peoplecheckbox
            // 
            this.peoplecheckbox.CheckOnClick = true;
            this.peoplecheckbox.Dock = System.Windows.Forms.DockStyle.Top;
            this.peoplecheckbox.FormattingEnabled = true;
            this.peoplecheckbox.Location = new System.Drawing.Point(0, 13);
            this.peoplecheckbox.Name = "peoplecheckbox";
            this.peoplecheckbox.Size = new System.Drawing.Size(200, 139);
            this.peoplecheckbox.TabIndex = 1;
            // 
            // comparebutton
            // 
            this.comparebutton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.comparebutton.Location = new System.Drawing.Point(0, 372);
            this.comparebutton.Name = "comparebutton";
            this.comparebutton.Size = new System.Drawing.Size(200, 23);
            this.comparebutton.TabIndex = 2;
            this.comparebutton.Text = "Compare Selected People";
            this.comparebutton.UseVisualStyleBackColor = true;
            this.comparebutton.Click += new System.EventHandler(this.comparebutton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Select people to compare";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(905, 451);
            this.Controls.Add(this.tabcontrol);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabcontrol.ResumeLayout(false);
            this.setpeople.ResumeLayout(false);
            this.addingredienttabpage.ResumeLayout(false);
            this.addingredienttabpage.PerformLayout();
            this.editmealtab.ResumeLayout(false);
            this.editmealtab.PerformLayout();
            this.comparetab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.comparechart)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		public System.Windows.Forms.ComboBox peoplelist;
		public System.Windows.Forms.FlowLayoutPanel subingrpanel;
		public System.Windows.Forms.ListBox ingredientlistbox;
		private TabControl tabcontrol;
		private TabPage setpeople;
        private TabPage comparetab;
		private Panel panel1;
		private Button comparebutton;
		public CheckedListBox peoplecheckbox;
		public CheckedListBox mealchecklist;
		private Label label1;
		private Splitter splitter1;
		private Label label2;
		private Button newbutton;
		private TabPage addingredienttabpage;
		private Button deleteselectedbutton;
		private Label label3;
		private Button addingrbutton;
		public ListBox editingrbox;
		private TabPage editmealtab;
		private Button Editmeal;
		private Label label4;
		private Button addmealbutton;
		public ListBox editmeallbox;
        private Button Editcategories;
        private System.Windows.Forms.DataVisualization.Charting.Chart comparechart;
	}
}

