namespace MyComander
{
    partial class textViewer
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
            this.text = new System.Windows.Forms.RichTextBox();
            this.menu = new System.Windows.Forms.MenuStrip();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.workWithFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.findOnecWordsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteSpacesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // text
            // 
            this.text.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.text.Location = new System.Drawing.Point(39, 22);
            this.text.Name = "text";
            this.text.Size = new System.Drawing.Size(206, 193);
            this.text.TabIndex = 0;
            this.text.Text = "This is text!";
            this.text.TextChanged += new System.EventHandler(this.text_TextChanged);
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.workWithFileToolStripMenuItem});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(284, 24);
            this.menu.TabIndex = 1;
            this.menu.Text = "menuStrip1";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem1,
            this.saveToolStripMenuItem,
            this.closeToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.openToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem1
            // 
            this.openToolStripMenuItem1.Name = "openToolStripMenuItem1";
            this.openToolStripMenuItem1.Size = new System.Drawing.Size(103, 22);
            this.openToolStripMenuItem1.Text = "Open";
            this.openToolStripMenuItem1.Click += new System.EventHandler(this.openToolStripMenuItem1_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // workWithFileToolStripMenuItem
            // 
            this.workWithFileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.findOnecWordsToolStripMenuItem,
            this.deleteSpacesToolStripMenuItem});
            this.workWithFileToolStripMenuItem.Name = "workWithFileToolStripMenuItem";
            this.workWithFileToolStripMenuItem.Size = new System.Drawing.Size(90, 20);
            this.workWithFileToolStripMenuItem.Text = "work with file";
            // 
            // findOnecWordsToolStripMenuItem
            // 
            this.findOnecWordsToolStripMenuItem.Name = "findOnecWordsToolStripMenuItem";
            this.findOnecWordsToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.findOnecWordsToolStripMenuItem.Text = "find onec words";
            this.findOnecWordsToolStripMenuItem.Click += new System.EventHandler(this.findOnecWordsToolStripMenuItem_Click);
            // 
            // deleteSpacesToolStripMenuItem
            // 
            this.deleteSpacesToolStripMenuItem.Name = "deleteSpacesToolStripMenuItem";
            this.deleteSpacesToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.deleteSpacesToolStripMenuItem.Text = "delete spaces";
            this.deleteSpacesToolStripMenuItem.Click += new System.EventHandler(this.deleteSpacesToolStripMenuItem_Click);
            // 
            // textViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 253);
            this.Controls.Add(this.text);
            this.Controls.Add(this.menu);
            this.MainMenuStrip = this.menu;
            this.Name = "textViewer";
            this.Text = "textViewer";
            this.Load += new System.EventHandler(this.textViewer_Load);
            this.SizeChanged += new System.EventHandler(this.textViewer_SizeChanged);
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox text;
        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem workWithFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem findOnecWordsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteSpacesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
    }
}