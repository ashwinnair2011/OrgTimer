namespace OrgTimer
{
    partial class OrgTimerForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrgTimerForm));
            this.ActionButton = new System.Windows.Forms.Button();
            this.JobTimer = new System.Windows.Forms.Timer(this.components);
            this.OrgTimerNotify = new System.Windows.Forms.NotifyIcon(this.components);
            this.OrgTimerMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.restoreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.minimizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OrgTimerMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // ActionButton
            // 
            this.ActionButton.BackColor = System.Drawing.Color.SeaShell;
            this.ActionButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ActionButton.Location = new System.Drawing.Point(2, 1);
            this.ActionButton.Name = "ActionButton";
            this.ActionButton.Size = new System.Drawing.Size(245, 65);
            this.ActionButton.TabIndex = 0;
            this.ActionButton.Tag = "";
            this.ActionButton.Text = "Start";
            this.ActionButton.UseVisualStyleBackColor = false;
            this.ActionButton.Click += new System.EventHandler(this.ActionButton_Click);
            // 
            // JobTimer
            // 
            this.JobTimer.Interval = 1000;
            this.JobTimer.Tick += new System.EventHandler(this.JobTimer_Tick);
            // 
            // OrgTimerNotify
            // 
            this.OrgTimerNotify.ContextMenuStrip = this.OrgTimerMenu;
            this.OrgTimerNotify.Icon = ((System.Drawing.Icon)(resources.GetObject("OrgTimerNotify.Icon")));
            this.OrgTimerNotify.Text = "Org Timer";
            this.OrgTimerNotify.Visible = true;
            this.OrgTimerNotify.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.OrgTimerNotify_MouseDoubleClick);
            // 
            // OrgTimerMenu
            // 
            this.OrgTimerMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.restoreToolStripMenuItem,
            this.minimizeToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.OrgTimerMenu.Name = "OrgTimerMenu";
            this.OrgTimerMenu.Size = new System.Drawing.Size(153, 92);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // restoreToolStripMenuItem
            // 
            this.restoreToolStripMenuItem.Name = "restoreToolStripMenuItem";
            this.restoreToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.restoreToolStripMenuItem.Text = "Restore";
            this.restoreToolStripMenuItem.Click += new System.EventHandler(this.restoreToolStripMenuItem_Click);
            // 
            // minimizeToolStripMenuItem
            // 
            this.minimizeToolStripMenuItem.Name = "minimizeToolStripMenuItem";
            this.minimizeToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.minimizeToolStripMenuItem.Text = "Minimize";
            this.minimizeToolStripMenuItem.Click += new System.EventHandler(this.minimizeToolStripMenuItem_Click);
            // 
            // OrgTimerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(249, 68);
            this.Controls.Add(this.ActionButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "OrgTimerForm";
            this.Opacity = 0.75D;
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OrgTimerForm_FormClosing);
            this.OrgTimerMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ActionButton;
        private System.Windows.Forms.Timer JobTimer;
        private System.Windows.Forms.NotifyIcon OrgTimerNotify;
        private System.Windows.Forms.ContextMenuStrip OrgTimerMenu;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem restoreToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem minimizeToolStripMenuItem;
    }
}

