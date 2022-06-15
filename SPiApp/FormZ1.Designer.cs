namespace SPiApp
{
    partial class FormZ1
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.tabMissing = new System.Windows.Forms.TabControl();
            this.tabMissingMain = new System.Windows.Forms.TabPage();
            this.ctrlMissingMainValue = new System.Windows.Forms.RichTextBox();
            this.tabMissingMod = new System.Windows.Forms.TabPage();
            this.ctrlMissingModValue = new System.Windows.Forms.RichTextBox();
            this.ctrlAssetsFile = new System.Windows.Forms.RichTextBox();
            this.ctrlClearMod = new System.Windows.Forms.CheckBox();
            this.ctrlClearMain = new System.Windows.Forms.CheckBox();
            this.ctrlSave = new System.Windows.Forms.Button();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.tabMissing.SuspendLayout();
            this.tabMissingMain.SuspendLayout();
            this.tabMissingMod.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.ctrlClearMod);
            this.splitContainer1.Panel2.Controls.Add(this.ctrlClearMain);
            this.splitContainer1.Panel2.Controls.Add(this.ctrlSave);
            this.splitContainer1.Size = new System.Drawing.Size(800, 450);
            this.splitContainer1.SplitterDistance = 400;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.tabMissing);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.ctrlAssetsFile);
            this.splitContainer2.Size = new System.Drawing.Size(800, 400);
            this.splitContainer2.SplitterDistance = 412;
            this.splitContainer2.TabIndex = 0;
            // 
            // tabMissing
            // 
            this.tabMissing.Controls.Add(this.tabMissingMain);
            this.tabMissing.Controls.Add(this.tabMissingMod);
            this.tabMissing.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMissing.Location = new System.Drawing.Point(0, 0);
            this.tabMissing.Name = "tabMissing";
            this.tabMissing.SelectedIndex = 0;
            this.tabMissing.Size = new System.Drawing.Size(412, 400);
            this.tabMissing.TabIndex = 0;
            this.tabMissing.Selected += new System.Windows.Forms.TabControlEventHandler(this.OnSwitchedTab);
            // 
            // tabMissingMain
            // 
            this.tabMissingMain.Controls.Add(this.ctrlMissingMainValue);
            this.tabMissingMain.Location = new System.Drawing.Point(4, 22);
            this.tabMissingMain.Name = "tabMissingMain";
            this.tabMissingMain.Padding = new System.Windows.Forms.Padding(3);
            this.tabMissingMain.Size = new System.Drawing.Size(404, 374);
            this.tabMissingMain.TabIndex = 0;
            this.tabMissingMain.Text = "main/missingasset.csv";
            this.tabMissingMain.UseVisualStyleBackColor = true;
            // 
            // ctrlMissingMainValue
            // 
            this.ctrlMissingMainValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlMissingMainValue.Location = new System.Drawing.Point(3, 3);
            this.ctrlMissingMainValue.Name = "ctrlMissingMainValue";
            this.ctrlMissingMainValue.Size = new System.Drawing.Size(398, 368);
            this.ctrlMissingMainValue.TabIndex = 0;
            this.ctrlMissingMainValue.Text = "";
            // 
            // tabMissingMod
            // 
            this.tabMissingMod.Controls.Add(this.ctrlMissingModValue);
            this.tabMissingMod.Location = new System.Drawing.Point(4, 22);
            this.tabMissingMod.Name = "tabMissingMod";
            this.tabMissingMod.Padding = new System.Windows.Forms.Padding(3);
            this.tabMissingMod.Size = new System.Drawing.Size(404, 374);
            this.tabMissingMod.TabIndex = 1;
            this.tabMissingMod.Text = "mod/missingasset.csv";
            this.tabMissingMod.UseVisualStyleBackColor = true;
            // 
            // ctrlMissingModValue
            // 
            this.ctrlMissingModValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlMissingModValue.Location = new System.Drawing.Point(3, 3);
            this.ctrlMissingModValue.Name = "ctrlMissingModValue";
            this.ctrlMissingModValue.Size = new System.Drawing.Size(398, 368);
            this.ctrlMissingModValue.TabIndex = 0;
            this.ctrlMissingModValue.Text = "";
            // 
            // ctrlAssetsFile
            // 
            this.ctrlAssetsFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlAssetsFile.Location = new System.Drawing.Point(0, 0);
            this.ctrlAssetsFile.Name = "ctrlAssetsFile";
            this.ctrlAssetsFile.Size = new System.Drawing.Size(384, 400);
            this.ctrlAssetsFile.TabIndex = 0;
            this.ctrlAssetsFile.Text = "";
            // 
            // ctrlClearMod
            // 
            this.ctrlClearMod.AutoSize = true;
            this.ctrlClearMod.Location = new System.Drawing.Point(218, 15);
            this.ctrlClearMod.Name = "ctrlClearMod";
            this.ctrlClearMod.Size = new System.Drawing.Size(198, 17);
            this.ctrlClearMod.TabIndex = 2;
            this.ctrlClearMod.Text = "Clear mod/missingasset.csv on save";
            this.ctrlClearMod.UseVisualStyleBackColor = true;
            this.ctrlClearMod.CheckedChanged += new System.EventHandler(this.OnClearChanged);
            // 
            // ctrlClearMain
            // 
            this.ctrlClearMain.AutoSize = true;
            this.ctrlClearMain.Location = new System.Drawing.Point(12, 15);
            this.ctrlClearMain.Name = "ctrlClearMain";
            this.ctrlClearMain.Size = new System.Drawing.Size(200, 17);
            this.ctrlClearMain.TabIndex = 1;
            this.ctrlClearMain.Text = "Clear main/missingasset.csv on save";
            this.ctrlClearMain.UseVisualStyleBackColor = true;
            this.ctrlClearMain.CheckedChanged += new System.EventHandler(this.OnClearChanged);
            // 
            // ctrlSave
            // 
            this.ctrlSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrlSave.Location = new System.Drawing.Point(713, 11);
            this.ctrlSave.Name = "ctrlSave";
            this.ctrlSave.Size = new System.Drawing.Size(75, 23);
            this.ctrlSave.TabIndex = 0;
            this.ctrlSave.Text = "Save";
            this.ctrlSave.UseVisualStyleBackColor = true;
            this.ctrlSave.Click += new System.EventHandler(this.PressSave);
            // 
            // FormZ1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "FormZ1";
            this.Text = "Update Map Zone File";
            this.Load += new System.EventHandler(this.LoadData);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            this.tabMissing.ResumeLayout(false);
            this.tabMissingMain.ResumeLayout(false);
            this.tabMissingMod.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.TabControl tabMissing;
        private System.Windows.Forms.TabPage tabMissingMain;
        private System.Windows.Forms.TabPage tabMissingMod;
        private System.Windows.Forms.RichTextBox ctrlAssetsFile;
        private System.Windows.Forms.RichTextBox ctrlMissingMainValue;
        private System.Windows.Forms.RichTextBox ctrlMissingModValue;
        private System.Windows.Forms.Button ctrlSave;
        private System.Windows.Forms.CheckBox ctrlClearMod;
        private System.Windows.Forms.CheckBox ctrlClearMain;
    }
}