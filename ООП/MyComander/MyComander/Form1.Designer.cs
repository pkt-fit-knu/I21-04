namespace MyComander
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem("1");
            System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem("2");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abouteProgramToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listView1 = new System.Windows.Forms.ListView();
            this.Menu1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openItemMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.copyItemMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.cutItemMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteItemMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteItemMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.copyTxtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyHtmlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listView2 = new System.Windows.Forms.ListView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.treeView2 = new System.Windows.Forms.TreeView();
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.backButton1 = new System.Windows.Forms.ToolStripButton();
            this.newFolderButton1 = new System.Windows.Forms.ToolStripButton();
            this.newFileButton1 = new System.Windows.Forms.ToolStripButton();
            this.address1 = new System.Windows.Forms.ToolStripTextBox();
            this.refreshButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.backButton2 = new System.Windows.Forms.ToolStripButton();
            this.newFolderButton2 = new System.Windows.Forms.ToolStripButton();
            this.newFileButton2 = new System.Windows.Forms.ToolStripButton();
            this.address2 = new System.Windows.Forms.ToolStripTextBox();
            this.refreshButton2 = new System.Windows.Forms.ToolStripButton();
            this.label1 = new System.Windows.Forms.Label();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.Menu1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem,
            this.abouteProgramToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1099, 24);
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
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
            // 
            // abouteProgramToolStripMenuItem
            // 
            this.abouteProgramToolStripMenuItem.Name = "abouteProgramToolStripMenuItem";
            this.abouteProgramToolStripMenuItem.Size = new System.Drawing.Size(101, 20);
            this.abouteProgramToolStripMenuItem.Text = "About program";
            this.abouteProgramToolStripMenuItem.Click += new System.EventHandler(this.AbouteProgramToolStripMenuItem_Click);
            // 
            // listView1
            // 
            this.listView1.ContextMenuStrip = this.Menu1;
            this.listView1.ImeMode = System.Windows.Forms.ImeMode.AlphaFull;
            this.listView1.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem3,
            listViewItem4});
            this.listView1.Location = new System.Drawing.Point(212, 79);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(300, 450);
            this.listView1.TabIndex = 1;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.List;
            this.listView1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ListView1_MouseDoubleClick);
            // 
            // Menu1
            // 
            this.Menu1.AutoSize = false;
            this.Menu1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openItemMenu,
            this.copyItemMenu,
            this.cutItemMenu,
            this.deleteItemMenu,
            this.pasteItemMenu,
            this.copyTxtToolStripMenuItem,
            this.copyHtmlToolStripMenuItem});
            this.Menu1.Name = "Menu1";
            this.Menu1.Size = new System.Drawing.Size(153, 170);
            this.Menu1.Opening += new System.ComponentModel.CancelEventHandler(this.Menu1_Opening);
            // 
            // openItemMenu
            // 
            this.openItemMenu.Name = "openItemMenu";
            this.openItemMenu.Size = new System.Drawing.Size(131, 22);
            this.openItemMenu.Text = "відкрити";
            this.openItemMenu.Click += new System.EventHandler(this.OpenItemClick);
            // 
            // copyItemMenu
            // 
            this.copyItemMenu.Name = "copyItemMenu";
            this.copyItemMenu.Size = new System.Drawing.Size(131, 22);
            this.copyItemMenu.Text = "копіювати";
            this.copyItemMenu.Click += new System.EventHandler(this.CopyItemClick);
            // 
            // cutItemMenu
            // 
            this.cutItemMenu.Name = "cutItemMenu";
            this.cutItemMenu.Size = new System.Drawing.Size(131, 22);
            this.cutItemMenu.Text = "вирізати";
            this.cutItemMenu.Click += new System.EventHandler(this.CutItemClick);
            // 
            // deleteItemMenu
            // 
            this.deleteItemMenu.Name = "deleteItemMenu";
            this.deleteItemMenu.Size = new System.Drawing.Size(131, 22);
            this.deleteItemMenu.Text = "видалити";
            this.deleteItemMenu.Click += new System.EventHandler(this.DeleteItemClick);
            // 
            // pasteItemMenu
            // 
            this.pasteItemMenu.Name = "pasteItemMenu";
            this.pasteItemMenu.Size = new System.Drawing.Size(131, 22);
            this.pasteItemMenu.Text = "вставити";
            this.pasteItemMenu.Click += new System.EventHandler(this.PasteItemClick);
            // 
            // copyTxtToolStripMenuItem
            // 
            this.copyTxtToolStripMenuItem.Name = "copyTxtToolStripMenuItem";
            this.copyTxtToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.copyTxtToolStripMenuItem.Text = "copy txt";
            this.copyTxtToolStripMenuItem.Click += new System.EventHandler(this.copyTxtToolStripMenuItem_Click);
            // 
            // copyHtmlToolStripMenuItem
            // 
            this.copyHtmlToolStripMenuItem.Name = "copyHtmlToolStripMenuItem";
            this.copyHtmlToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.copyHtmlToolStripMenuItem.Text = "copy html";
            this.copyHtmlToolStripMenuItem.Click += new System.EventHandler(this.copyHtmlToolStripMenuItem_Click);
            // 
            // listView2
            // 
            this.listView2.ContextMenuStrip = this.Menu1;
            this.listView2.Location = new System.Drawing.Point(783, 79);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(300, 450);
            this.listView2.TabIndex = 2;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ListView2_MouseDoubleClick);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "directory.bmp");
            this.imageList1.Images.SetKeyName(1, "file.bmp");
            // 
            // treeView2
            // 
            this.treeView2.ImageIndex = 0;
            this.treeView2.ImageList = this.imageList2;
            this.treeView2.Location = new System.Drawing.Point(582, 79);
            this.treeView2.Name = "treeView2";
            this.treeView2.SelectedImageIndex = 0;
            this.treeView2.Size = new System.Drawing.Size(175, 450);
            this.treeView2.TabIndex = 3;
            // 
            // imageList2
            // 
            this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList2.Images.SetKeyName(0, "localdriver.png");
            this.imageList2.Images.SetKeyName(1, "directory_mini.bmp");
            // 
            // treeView1
            // 
            this.treeView1.ImageIndex = 0;
            this.treeView1.ImageList = this.imageList2;
            this.treeView1.Location = new System.Drawing.Point(12, 79);
            this.treeView1.Name = "treeView1";
            this.treeView1.SelectedImageIndex = 0;
            this.treeView1.Size = new System.Drawing.Size(175, 450);
            this.treeView1.TabIndex = 4;
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.backButton1,
            this.newFolderButton1,
            this.newFileButton1,
            this.address1,
            this.refreshButton1});
            this.toolStrip1.Location = new System.Drawing.Point(12, 42);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(500, 25);
            this.toolStrip1.TabIndex = 7;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // backButton1
            // 
            this.backButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.backButton1.Image = ((System.Drawing.Image)(resources.GetObject("backButton1.Image")));
            this.backButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.backButton1.Name = "backButton1";
            this.backButton1.Size = new System.Drawing.Size(23, 22);
            this.backButton1.Text = "toolStripButton1";
            this.backButton1.Click += new System.EventHandler(this.BackButton1Click);
            // 
            // newFolderButton1
            // 
            this.newFolderButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.newFolderButton1.Image = ((System.Drawing.Image)(resources.GetObject("newFolderButton1.Image")));
            this.newFolderButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newFolderButton1.Name = "newFolderButton1";
            this.newFolderButton1.Size = new System.Drawing.Size(23, 22);
            this.newFolderButton1.Text = "toolStripButton2";
            this.newFolderButton1.Click += new System.EventHandler(this.NewFolderButton1Click);
            // 
            // newFileButton1
            // 
            this.newFileButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.newFileButton1.Image = ((System.Drawing.Image)(resources.GetObject("newFileButton1.Image")));
            this.newFileButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newFileButton1.Name = "newFileButton1";
            this.newFileButton1.Size = new System.Drawing.Size(23, 22);
            this.newFileButton1.Text = "toolStripButton5";
            this.newFileButton1.Click += new System.EventHandler(this.NewFileButton1Click);
            // 
            // address1
            // 
            this.address1.Name = "address1";
            this.address1.Size = new System.Drawing.Size(380, 25);
            this.address1.Text = "address1";
            this.address1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Address1_KeyDown);
            // 
            // refreshButton1
            // 
            this.refreshButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.refreshButton1.Image = ((System.Drawing.Image)(resources.GetObject("refreshButton1.Image")));
            this.refreshButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.refreshButton1.Name = "refreshButton1";
            this.refreshButton1.Size = new System.Drawing.Size(23, 22);
            this.refreshButton1.Text = "toolStripButton6";
            this.refreshButton1.Click += new System.EventHandler(this.RefreshButton1Click);
            // 
            // toolStrip2
            // 
            this.toolStrip2.AutoSize = false;
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.backButton2,
            this.newFolderButton2,
            this.newFileButton2,
            this.address2,
            this.refreshButton2});
            this.toolStrip2.Location = new System.Drawing.Point(582, 42);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(500, 25);
            this.toolStrip2.TabIndex = 8;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // backButton2
            // 
            this.backButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.backButton2.Image = ((System.Drawing.Image)(resources.GetObject("backButton2.Image")));
            this.backButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.backButton2.Name = "backButton2";
            this.backButton2.Size = new System.Drawing.Size(23, 22);
            this.backButton2.Text = "toolStripButton1";
            this.backButton2.Click += new System.EventHandler(this.BackButton2Click);
            // 
            // newFolderButton2
            // 
            this.newFolderButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.newFolderButton2.Image = ((System.Drawing.Image)(resources.GetObject("newFolderButton2.Image")));
            this.newFolderButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newFolderButton2.Name = "newFolderButton2";
            this.newFolderButton2.Size = new System.Drawing.Size(23, 22);
            this.newFolderButton2.Text = "toolStripButton2";
            this.newFolderButton2.Click += new System.EventHandler(this.NewFolderButton2Click);
            // 
            // newFileButton2
            // 
            this.newFileButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.newFileButton2.Image = ((System.Drawing.Image)(resources.GetObject("newFileButton2.Image")));
            this.newFileButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newFileButton2.Name = "newFileButton2";
            this.newFileButton2.Size = new System.Drawing.Size(23, 22);
            this.newFileButton2.Text = "toolStripButton5";
            this.newFileButton2.Click += new System.EventHandler(this.NewFileButton2Click);
            // 
            // address2
            // 
            this.address2.Name = "address2";
            this.address2.Size = new System.Drawing.Size(380, 25);
            this.address2.Text = "address2";
            this.address2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Address2_KeyDown);
            // 
            // refreshButton2
            // 
            this.refreshButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.refreshButton2.Image = ((System.Drawing.Image)(resources.GetObject("refreshButton2.Image")));
            this.refreshButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.refreshButton2.Name = "refreshButton2";
            this.refreshButton2.Size = new System.Drawing.Size(23, 22);
            this.refreshButton2.Text = "toolStripButton6";
            this.refreshButton2.Click += new System.EventHandler(this.RefreshButton2Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(993, 538);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 17);
            this.label1.TabIndex = 9;
            this.label1.Text = "© Wsl_F 2013";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1099, 560);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.toolStrip2);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.treeView2);
            this.Controls.Add(this.listView2);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "File Manager";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.Menu1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem abouteProgramToolStripMenuItem;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.TreeView treeView2;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton backButton1;
        private System.Windows.Forms.ToolStripButton newFolderButton1;
        private System.Windows.Forms.ToolStripTextBox address1;
        private System.Windows.Forms.ContextMenuStrip Menu1;
        private System.Windows.Forms.ToolStripMenuItem openItemMenu;
        private System.Windows.Forms.ToolStripMenuItem copyItemMenu;
        private System.Windows.Forms.ToolStripMenuItem cutItemMenu;
        private System.Windows.Forms.ToolStripMenuItem deleteItemMenu;
        private System.Windows.Forms.ToolStripButton newFileButton1;
        private System.Windows.Forms.ToolStripButton refreshButton1;
        private System.Windows.Forms.ToolStripMenuItem pasteItemMenu;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton backButton2;
        private System.Windows.Forms.ToolStripButton newFolderButton2;
        private System.Windows.Forms.ToolStripButton newFileButton2;
        private System.Windows.Forms.ToolStripTextBox address2;
        private System.Windows.Forms.ToolStripButton refreshButton2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ImageList imageList2;
        private System.Windows.Forms.ToolStripMenuItem copyTxtToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyHtmlToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
    }
}

