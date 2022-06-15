namespace SPiApp
{
    partial class FormM1
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
            this.label1 = new System.Windows.Forms.Label();
            this.ctrlMapName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ctrlTemplates = new System.Windows.Forms.ComboBox();
            this.ctrlCreateMap = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Map name:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ctrlMapName
            // 
            this.ctrlMapName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrlMapName.Location = new System.Drawing.Point(88, 34);
            this.ctrlMapName.Name = "ctrlMapName";
            this.ctrlMapName.Size = new System.Drawing.Size(164, 20);
            this.ctrlMapName.TabIndex = 1;
            this.ctrlMapName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.QuickCreate);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "Template:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ctrlTemplates
            // 
            this.ctrlTemplates.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrlTemplates.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ctrlTemplates.FormattingEnabled = true;
            this.ctrlTemplates.Items.AddRange(new object[] {
            "<none>"});
            this.ctrlTemplates.Location = new System.Drawing.Point(88, 11);
            this.ctrlTemplates.Name = "ctrlTemplates";
            this.ctrlTemplates.Size = new System.Drawing.Size(164, 21);
            this.ctrlTemplates.TabIndex = 3;
            this.ctrlTemplates.SelectedIndexChanged += new System.EventHandler(this.SelectedTemplate);
            // 
            // ctrlCreateMap
            // 
            this.ctrlCreateMap.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrlCreateMap.Location = new System.Drawing.Point(152, 60);
            this.ctrlCreateMap.Name = "ctrlCreateMap";
            this.ctrlCreateMap.Size = new System.Drawing.Size(100, 23);
            this.ctrlCreateMap.TabIndex = 4;
            this.ctrlCreateMap.Text = "Create Map";
            this.ctrlCreateMap.UseVisualStyleBackColor = true;
            this.ctrlCreateMap.Click += new System.EventHandler(this.CreateMap);
            // 
            // FormM1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(259, 89);
            this.Controls.Add(this.ctrlCreateMap);
            this.Controls.Add(this.ctrlTemplates);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ctrlMapName);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(400, 128);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(275, 128);
            this.Name = "FormM1";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Create Map";
            this.Load += new System.EventHandler(this.InitializeTemplates);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ctrlMapName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox ctrlTemplates;
        private System.Windows.Forms.Button ctrlCreateMap;
    }
}