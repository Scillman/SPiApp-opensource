namespace SPiApp
{
    partial class FormZ2
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
            this.ctrlMissingFile = new System.Windows.Forms.RichTextBox();
            this.ctrlAssetsFile = new System.Windows.Forms.RichTextBox();
            this.ctrlClearMissing = new System.Windows.Forms.CheckBox();
            this.ctrlSave = new System.Windows.Forms.Button();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
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
            this.splitContainer1.Panel2.Controls.Add(this.ctrlClearMissing);
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
            this.splitContainer2.Panel1.Controls.Add(this.ctrlMissingFile);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.ctrlAssetsFile);
            this.splitContainer2.Size = new System.Drawing.Size(800, 400);
            this.splitContainer2.SplitterDistance = 412;
            this.splitContainer2.TabIndex = 0;
            // 
            // ctrlMissingFile
            // 
            this.ctrlMissingFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlMissingFile.Location = new System.Drawing.Point(0, 0);
            this.ctrlMissingFile.Name = "ctrlMissingFile";
            this.ctrlMissingFile.Size = new System.Drawing.Size(412, 400);
            this.ctrlMissingFile.TabIndex = 1;
            this.ctrlMissingFile.Text = "";
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
            // ctrlClearMissing
            // 
            this.ctrlClearMissing.AutoSize = true;
            this.ctrlClearMissing.Location = new System.Drawing.Point(12, 15);
            this.ctrlClearMissing.Name = "ctrlClearMissing";
            this.ctrlClearMissing.Size = new System.Drawing.Size(173, 17);
            this.ctrlClearMissing.TabIndex = 1;
            this.ctrlClearMissing.Text = "Clear missingasset.csv on save";
            this.ctrlClearMissing.UseVisualStyleBackColor = true;
            this.ctrlClearMissing.CheckedChanged += new System.EventHandler(this.OnClearChanged);
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
            // FormZ2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "FormZ2";
            this.Text = "Update Mod Zone File";
            this.Load += new System.EventHandler(this.LoadData);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.RichTextBox ctrlAssetsFile;
        private System.Windows.Forms.Button ctrlSave;
        private System.Windows.Forms.CheckBox ctrlClearMissing;
        private System.Windows.Forms.RichTextBox ctrlMissingFile;
    }
}