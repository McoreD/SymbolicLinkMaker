namespace SymbolicLinkMaker
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.groupLink = new System.Windows.Forms.GroupBox();
            this.panelLink = new System.Windows.Forms.Panel();
            this.checkLink = new System.Windows.Forms.CheckBox();
            this.btnClearLinkName = new System.Windows.Forms.Button();
            this.txtLinkName = new System.Windows.Forms.TextBox();
            this.btnBrowseLinkDir = new System.Windows.Forms.Button();
            this.txtLinkDir = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupTarget = new System.Windows.Forms.GroupBox();
            this.panelTarget = new System.Windows.Forms.Panel();
            this.btnBrowseTargetDir = new System.Windows.Forms.Button();
            this.txtTargetDir = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnCreate = new System.Windows.Forms.Button();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupLink.SuspendLayout();
            this.panelLink.SuspendLayout();
            this.groupTarget.SuspendLayout();
            this.panelTarget.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupLink
            // 
            this.groupLink.Controls.Add(this.panelLink);
            this.groupLink.Location = new System.Drawing.Point(12, 27);
            this.groupLink.Name = "groupLink";
            this.groupLink.Size = new System.Drawing.Size(501, 122);
            this.groupLink.TabIndex = 1;
            this.groupLink.TabStop = false;
            this.groupLink.Text = "Link";
            // 
            // panelLink
            // 
            this.panelLink.AllowDrop = true;
            this.panelLink.Controls.Add(this.checkLink);
            this.panelLink.Controls.Add(this.btnClearLinkName);
            this.panelLink.Controls.Add(this.txtLinkName);
            this.panelLink.Controls.Add(this.btnBrowseLinkDir);
            this.panelLink.Controls.Add(this.txtLinkDir);
            this.panelLink.Controls.Add(this.label2);
            this.panelLink.Controls.Add(this.label1);
            this.panelLink.Location = new System.Drawing.Point(6, 11);
            this.panelLink.Name = "panelLink";
            this.panelLink.Size = new System.Drawing.Size(493, 105);
            this.panelLink.TabIndex = 6;
            this.panelLink.DragDrop += new System.Windows.Forms.DragEventHandler(this.panelLink_DragDrop);
            this.panelLink.DragEnter += new System.Windows.Forms.DragEventHandler(this.panelLink_DragEnter);
            // 
            // checkLink
            // 
            this.checkLink.AutoSize = true;
            this.checkLink.Location = new System.Drawing.Point(3, 17);
            this.checkLink.Name = "checkLink";
            this.checkLink.Size = new System.Drawing.Size(207, 17);
            this.checkLink.TabIndex = 1;
            this.checkLink.Text = "Convert the folder into a Symbolic Link";
            this.checkLink.UseVisualStyleBackColor = true;
            this.checkLink.CheckedChanged += new System.EventHandler(this.checkLink_CheckedChanged);
            // 
            // btnClearLinkName
            // 
            this.btnClearLinkName.Location = new System.Drawing.Point(411, 79);
            this.btnClearLinkName.Name = "btnClearLinkName";
            this.btnClearLinkName.Size = new System.Drawing.Size(75, 23);
            this.btnClearLinkName.TabIndex = 5;
            this.btnClearLinkName.Text = "C&lear";
            this.btnClearLinkName.UseVisualStyleBackColor = true;
            this.btnClearLinkName.Click += new System.EventHandler(this.btnClearLinkName_Click);
            // 
            // txtLinkName
            // 
            this.txtLinkName.Location = new System.Drawing.Point(109, 81);
            this.txtLinkName.Name = "txtLinkName";
            this.txtLinkName.Size = new System.Drawing.Size(296, 20);
            this.txtLinkName.TabIndex = 4;
            // 
            // btnBrowseLinkDir
            // 
            this.btnBrowseLinkDir.Location = new System.Drawing.Point(411, 50);
            this.btnBrowseLinkDir.Name = "btnBrowseLinkDir";
            this.btnBrowseLinkDir.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseLinkDir.TabIndex = 3;
            this.btnBrowseLinkDir.Text = "&Browse";
            this.btnBrowseLinkDir.UseVisualStyleBackColor = true;
            this.btnBrowseLinkDir.Click += new System.EventHandler(this.btnBrowseLinkDir_Click);
            // 
            // txtLinkDir
            // 
            this.txtLinkDir.Location = new System.Drawing.Point(109, 52);
            this.txtLinkDir.Name = "txtLinkDir";
            this.txtLinkDir.Size = new System.Drawing.Size(296, 20);
            this.txtLinkDir.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(0, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Symbolic Link Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Parent Directory";
            // 
            // groupTarget
            // 
            this.groupTarget.Controls.Add(this.panelTarget);
            this.groupTarget.Location = new System.Drawing.Point(12, 155);
            this.groupTarget.Name = "groupTarget";
            this.groupTarget.Size = new System.Drawing.Size(501, 61);
            this.groupTarget.TabIndex = 2;
            this.groupTarget.TabStop = false;
            this.groupTarget.Text = "Target";
            // 
            // panelTarget
            // 
            this.panelTarget.AllowDrop = true;
            this.panelTarget.Controls.Add(this.btnBrowseTargetDir);
            this.panelTarget.Controls.Add(this.txtTargetDir);
            this.panelTarget.Controls.Add(this.label3);
            this.panelTarget.Location = new System.Drawing.Point(6, 16);
            this.panelTarget.Name = "panelTarget";
            this.panelTarget.Size = new System.Drawing.Size(492, 39);
            this.panelTarget.TabIndex = 7;
            this.panelTarget.DragDrop += new System.Windows.Forms.DragEventHandler(this.panelTarget_DragDrop);
            this.panelTarget.DragEnter += new System.Windows.Forms.DragEventHandler(this.panelTarget_DragEnter);
            // 
            // btnBrowseTargetDir
            // 
            this.btnBrowseTargetDir.Location = new System.Drawing.Point(411, 13);
            this.btnBrowseTargetDir.Name = "btnBrowseTargetDir";
            this.btnBrowseTargetDir.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseTargetDir.TabIndex = 7;
            this.btnBrowseTargetDir.Text = "B&rowse";
            this.btnBrowseTargetDir.UseVisualStyleBackColor = true;
            this.btnBrowseTargetDir.Click += new System.EventHandler(this.btnBrowseTargetDir_Click);
            // 
            // txtTargetDir
            // 
            this.txtTargetDir.Location = new System.Drawing.Point(109, 15);
            this.txtTargetDir.Name = "txtTargetDir";
            this.txtTargetDir.Size = new System.Drawing.Size(296, 20);
            this.txtTargetDir.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(0, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Directory";
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(429, 222);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(75, 23);
            this.btnCreate.TabIndex = 8;
            this.btnCreate.Text = "&Create";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(527, 24);
            this.menuStrip1.TabIndex = 9;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "&Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "&About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AcceptButton = this.btnCreate;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(527, 259);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.groupTarget);
            this.Controls.Add(this.groupLink);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Symbolic Link Maker 0.1.0.0";
            this.groupLink.ResumeLayout(false);
            this.panelLink.ResumeLayout(false);
            this.panelLink.PerformLayout();
            this.groupTarget.ResumeLayout(false);
            this.panelTarget.ResumeLayout(false);
            this.panelTarget.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupLink;
        private System.Windows.Forms.GroupBox groupTarget;
        private System.Windows.Forms.Button btnBrowseTargetDir;
        private System.Windows.Forms.TextBox txtTargetDir;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.Panel panelLink;
        private System.Windows.Forms.Button btnBrowseLinkDir;
        private System.Windows.Forms.TextBox txtLinkDir;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelTarget;
        private System.Windows.Forms.CheckBox checkLink;
        private System.Windows.Forms.Button btnClearLinkName;
        private System.Windows.Forms.TextBox txtLinkName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
    }
}

