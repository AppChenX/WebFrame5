namespace CH.CodeGenerator
{
    partial class frmMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_open = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_new = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_save = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_saveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_close = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_exit = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_settings = new System.Windows.Forms.ToolStripMenuItem();
            this.panel4 = new System.Windows.Forms.Panel();
            this.fileTabs = new System.Windows.Forms.TabControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chklstbx_Tables = new System.Windows.Forms.CheckedListBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.ToolStripMenuItem_Generator = new System.Windows.Forms.ToolStripMenuItem();
            this.loadDataBaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_execute = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.ToolStripMenuItem_Generator});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(785, 25);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem_open,
            this.ToolStripMenuItem_new,
            this.ToolStripMenuItem_save,
            this.ToolStripMenuItem_saveAs,
            this.ToolStripMenuItem_close,
            this.ToolStripMenuItem_exit});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(39, 21);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // ToolStripMenuItem_open
            // 
            this.ToolStripMenuItem_open.Name = "ToolStripMenuItem_open";
            this.ToolStripMenuItem_open.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.ToolStripMenuItem_open.Size = new System.Drawing.Size(185, 22);
            this.ToolStripMenuItem_open.Text = "&Open";
            this.ToolStripMenuItem_open.Click += new System.EventHandler(this.ToolStripMenuItem_open_Click);
            // 
            // ToolStripMenuItem_new
            // 
            this.ToolStripMenuItem_new.Name = "ToolStripMenuItem_new";
            this.ToolStripMenuItem_new.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.ToolStripMenuItem_new.Size = new System.Drawing.Size(185, 22);
            this.ToolStripMenuItem_new.Text = "&New";
            // 
            // ToolStripMenuItem_save
            // 
            this.ToolStripMenuItem_save.Name = "ToolStripMenuItem_save";
            this.ToolStripMenuItem_save.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.ToolStripMenuItem_save.Size = new System.Drawing.Size(185, 22);
            this.ToolStripMenuItem_save.Text = "&Save";
            this.ToolStripMenuItem_save.Click += new System.EventHandler(this.ToolStripMenuItem_save_Click);
            // 
            // ToolStripMenuItem_saveAs
            // 
            this.ToolStripMenuItem_saveAs.Name = "ToolStripMenuItem_saveAs";
            this.ToolStripMenuItem_saveAs.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.S)));
            this.ToolStripMenuItem_saveAs.Size = new System.Drawing.Size(185, 22);
            this.ToolStripMenuItem_saveAs.Text = "&SaveAs";
            this.ToolStripMenuItem_saveAs.Click += new System.EventHandler(this.ToolStripMenuItem_saveAs_Click);
            // 
            // ToolStripMenuItem_close
            // 
            this.ToolStripMenuItem_close.Name = "ToolStripMenuItem_close";
            this.ToolStripMenuItem_close.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.W)));
            this.ToolStripMenuItem_close.Size = new System.Drawing.Size(185, 22);
            this.ToolStripMenuItem_close.Text = "&Close";
            this.ToolStripMenuItem_close.Click += new System.EventHandler(this.ToolStripMenuItem_close_Click);
            // 
            // ToolStripMenuItem_exit
            // 
            this.ToolStripMenuItem_exit.Name = "ToolStripMenuItem_exit";
            this.ToolStripMenuItem_exit.ShortcutKeys = System.Windows.Forms.Keys.F4;
            this.ToolStripMenuItem_exit.Size = new System.Drawing.Size(185, 22);
            this.ToolStripMenuItem_exit.Text = "&Exit";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem_settings});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(66, 21);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // ToolStripMenuItem_settings
            // 
            this.ToolStripMenuItem_settings.Name = "ToolStripMenuItem_settings";
            this.ToolStripMenuItem_settings.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.S)));
            this.ToolStripMenuItem_settings.Size = new System.Drawing.Size(161, 22);
            this.ToolStripMenuItem_settings.Text = "&Settings";
            this.ToolStripMenuItem_settings.Click += new System.EventHandler(this.ToolStripMenuItem_settings_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.fileTabs);
            this.panel4.Controls.Add(this.panel1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 25);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(785, 399);
            this.panel4.TabIndex = 3;
            // 
            // fileTabs
            // 
            this.fileTabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fileTabs.Location = new System.Drawing.Point(232, 0);
            this.fileTabs.Name = "fileTabs";
            this.fileTabs.SelectedIndex = 0;
            this.fileTabs.Size = new System.Drawing.Size(553, 399);
            this.fileTabs.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.chklstbx_Tables);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(232, 399);
            this.panel1.TabIndex = 2;
            // 
            // chklstbx_Tables
            // 
            this.chklstbx_Tables.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chklstbx_Tables.FormattingEnabled = true;
            this.chklstbx_Tables.Items.AddRange(new object[] {
            "1212",
            "12121"});
            this.chklstbx_Tables.Location = new System.Drawing.Point(0, 46);
            this.chklstbx_Tables.Name = "chklstbx_Tables";
            this.chklstbx_Tables.Size = new System.Drawing.Size(232, 353);
            this.chklstbx_Tables.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.txtFilter);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(232, 46);
            this.panel3.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "Filter(*)";
            // 
            // txtFilter
            // 
            this.txtFilter.Location = new System.Drawing.Point(68, 12);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(158, 21);
            this.txtFilter.TabIndex = 1;
            // 
            // ToolStripMenuItem_Generator
            // 
            this.ToolStripMenuItem_Generator.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadDataBaseToolStripMenuItem,
            this.ToolStripMenuItem_execute});
            this.ToolStripMenuItem_Generator.Name = "ToolStripMenuItem_Generator";
            this.ToolStripMenuItem_Generator.Size = new System.Drawing.Size(79, 21);
            this.ToolStripMenuItem_Generator.Text = "Generator";
            // 
            // loadDataBaseToolStripMenuItem
            // 
            this.loadDataBaseToolStripMenuItem.Name = "loadDataBaseToolStripMenuItem";
            this.loadDataBaseToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.loadDataBaseToolStripMenuItem.Text = "LoadDataBase";
            this.loadDataBaseToolStripMenuItem.Click += new System.EventHandler(this.loadDataBaseToolStripMenuItem_Click);
            // 
            // ToolStripMenuItem_execute
            // 
            this.ToolStripMenuItem_execute.Name = "ToolStripMenuItem_execute";
            this.ToolStripMenuItem_execute.ShortcutKeys = System.Windows.Forms.Keys.F8;
            this.ToolStripMenuItem_execute.Size = new System.Drawing.Size(160, 22);
            this.ToolStripMenuItem_execute.Text = "&Execute";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(785, 424);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " ";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_open;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_new;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_save;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_saveAs;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_close;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_exit;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_settings;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckedListBox chklstbx_Tables;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFilter;
        private System.Windows.Forms.TabControl fileTabs;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Generator;
        private System.Windows.Forms.ToolStripMenuItem loadDataBaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_execute;
    }
}

