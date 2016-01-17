namespace DudDuRu
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器
        /// 修改這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.button_scan = new System.Windows.Forms.Button();
            this.textBox_folder = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.actionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moveToToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.languageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.defaultToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.visitProjectSiteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.listBox_overview = new System.Windows.Forms.ListBox();
            this.textBox_filePath = new System.Windows.Forms.TextBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.listBox_details = new System.Windows.Forms.ListBox();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.selectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deselectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backgroundWorker_scan = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker_remove = new System.ComponentModel.BackgroundWorker();
            this.panel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button_scan);
            this.panel1.Controls.Add(this.textBox_folder);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // button_scan
            // 
            resources.ApplyResources(this.button_scan, "button_scan");
            this.button_scan.Name = "button_scan";
            this.button_scan.UseVisualStyleBackColor = true;
            this.button_scan.Click += new System.EventHandler(this.button_scan_Click);
            // 
            // textBox_folder
            // 
            this.textBox_folder.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.textBox_folder, "textBox_folder");
            this.textBox_folder.Name = "textBox_folder";
            this.textBox_folder.ReadOnly = true;
            this.textBox_folder.Click += new System.EventHandler(this.textBox_dir_Click);
            this.textBox_folder.TextChanged += new System.EventHandler(this.textBox_folder_TextChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.actionToolStripMenuItem,
            this.languageToolStripMenuItem,
            this.helpToolStripMenuItem});
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Name = "menuStrip1";
            // 
            // actionToolStripMenuItem
            // 
            resources.ApplyResources(this.actionToolStripMenuItem, "actionToolStripMenuItem");
            this.actionToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.actionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removeToolStripMenuItem,
            this.moveToToolStripMenuItem});
            this.actionToolStripMenuItem.Name = "actionToolStripMenuItem";
            // 
            // removeToolStripMenuItem
            // 
            this.removeToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            resources.ApplyResources(this.removeToolStripMenuItem, "removeToolStripMenuItem");
            this.removeToolStripMenuItem.Click += new System.EventHandler(this.removeToolStripMenuItem_Click);
            // 
            // moveToToolStripMenuItem
            // 
            this.moveToToolStripMenuItem.Name = "moveToToolStripMenuItem";
            resources.ApplyResources(this.moveToToolStripMenuItem, "moveToToolStripMenuItem");
            this.moveToToolStripMenuItem.Click += new System.EventHandler(this.moveToToolStripMenuItem_Click);
            // 
            // languageToolStripMenuItem
            // 
            this.languageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.defaultToolStripMenuItem});
            this.languageToolStripMenuItem.Name = "languageToolStripMenuItem";
            resources.ApplyResources(this.languageToolStripMenuItem, "languageToolStripMenuItem");
            // 
            // defaultToolStripMenuItem
            // 
            this.defaultToolStripMenuItem.Checked = true;
            this.defaultToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.defaultToolStripMenuItem.Name = "defaultToolStripMenuItem";
            resources.ApplyResources(this.defaultToolStripMenuItem, "defaultToolStripMenuItem");
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.visitProjectSiteToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            resources.ApplyResources(this.helpToolStripMenuItem, "helpToolStripMenuItem");
            // 
            // visitProjectSiteToolStripMenuItem
            // 
            this.visitProjectSiteToolStripMenuItem.Name = "visitProjectSiteToolStripMenuItem";
            resources.ApplyResources(this.visitProjectSiteToolStripMenuItem, "visitProjectSiteToolStripMenuItem");
            this.visitProjectSiteToolStripMenuItem.Click += new System.EventHandler(this.visitProjectSiteToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar1,
            this.toolStripStatusLabel1});
            resources.ApplyResources(this.statusStrip1, "statusStrip1");
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.SizingGrip = false;
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            resources.ApplyResources(this.toolStripProgressBar1, "toolStripProgressBar1");
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            resources.ApplyResources(this.toolStripStatusLabel1, "toolStripStatusLabel1");
            // 
            // listBox_overview
            // 
            this.listBox_overview.BackColor = System.Drawing.SystemColors.Window;
            resources.ApplyResources(this.listBox_overview, "listBox_overview");
            this.listBox_overview.FormattingEnabled = true;
            this.listBox_overview.Name = "listBox_overview";
            this.listBox_overview.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listBox_MouseClick);
            this.listBox_overview.SelectedIndexChanged += new System.EventHandler(this.listBox_overview_SelectedIndexChanged);
            // 
            // textBox_filePath
            // 
            this.textBox_filePath.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.textBox_filePath, "textBox_filePath");
            this.textBox_filePath.Name = "textBox_filePath";
            this.textBox_filePath.ReadOnly = true;
            // 
            // splitContainer2
            // 
            resources.ApplyResources(this.splitContainer2, "splitContainer2");
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.listBox_overview);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.listBox_details);
            this.splitContainer2.Panel2.Controls.Add(this.textBox_filePath);
            // 
            // listBox_details
            // 
            this.listBox_details.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.listBox_details.FormattingEnabled = true;
            resources.ApplyResources(this.listBox_details, "listBox_details");
            this.listBox_details.Name = "listBox_details";
            this.listBox_details.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBox_details.SelectedIndexChanged += new System.EventHandler(this.listBox_details_SelectedIndexChanged);
            this.listBox_details.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listBox_details_MouseDown);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectToolStripMenuItem,
            this.deselectToolStripMenuItem,
            this.openToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.ShowImageMargin = false;
            resources.ApplyResources(this.contextMenuStrip1, "contextMenuStrip1");
            // 
            // selectToolStripMenuItem
            // 
            this.selectToolStripMenuItem.Name = "selectToolStripMenuItem";
            resources.ApplyResources(this.selectToolStripMenuItem, "selectToolStripMenuItem");
            this.selectToolStripMenuItem.Click += new System.EventHandler(this.ToolStripMenuItem_Click_keep);
            // 
            // deselectToolStripMenuItem
            // 
            this.deselectToolStripMenuItem.Name = "deselectToolStripMenuItem";
            resources.ApplyResources(this.deselectToolStripMenuItem, "deselectToolStripMenuItem");
            this.deselectToolStripMenuItem.Click += new System.EventHandler(this.ToolStripMenuItem_Click_remove);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            resources.ApplyResources(this.openToolStripMenuItem, "openToolStripMenuItem");
            this.openToolStripMenuItem.Click += new System.EventHandler(this.ToolStripMenuItem_Click_open);
            // 
            // backgroundWorker_scan
            // 
            this.backgroundWorker_scan.WorkerReportsProgress = true;
            this.backgroundWorker_scan.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_scan_DoWork);
            this.backgroundWorker_scan.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker_scan_ProgressChanged);
            this.backgroundWorker_scan.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_scan_RunWorkerCompleted);
            // 
            // backgroundWorker_remove
            // 
            this.backgroundWorker_remove.WorkerReportsProgress = true;
            this.backgroundWorker_remove.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_remove_DoWork);
            this.backgroundWorker_remove.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker_remove_ProgressChanged);
            this.backgroundWorker_remove.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_remove_RunWorkerCompleted);
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer2);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button_scan;
        private System.Windows.Forms.TextBox textBox_folder;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem languageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem defaultToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ListBox listBox_overview;
        private System.Windows.Forms.TextBox textBox_filePath;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.ToolStripMenuItem selectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ListBox listBox_details;
        private System.Windows.Forms.ToolStripMenuItem deselectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem actionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.ComponentModel.BackgroundWorker backgroundWorker_scan;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem visitProjectSiteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moveToToolStripMenuItem;
        private System.ComponentModel.BackgroundWorker backgroundWorker_remove;
    }
}

