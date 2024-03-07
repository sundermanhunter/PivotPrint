namespace PivotPrint
{
    partial class SelectFieldDialog
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
            this.fieldsBox = new System.Windows.Forms.ListBox();
            this.selectBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.FileSaveRadio = new System.Windows.Forms.RadioButton();
            this.PrintRadio = new System.Windows.Forms.RadioButton();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.selectFileBtn = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // fieldsBox
            // 
            this.fieldsBox.FormattingEnabled = true;
            this.fieldsBox.Location = new System.Drawing.Point(13, 13);
            this.fieldsBox.Name = "fieldsBox";
            this.fieldsBox.Size = new System.Drawing.Size(205, 56);
            this.fieldsBox.TabIndex = 0;
            // 
            // selectBtn
            // 
            this.selectBtn.Location = new System.Drawing.Point(38, 136);
            this.selectBtn.Name = "selectBtn";
            this.selectBtn.Size = new System.Drawing.Size(75, 23);
            this.selectBtn.TabIndex = 1;
            this.selectBtn.Text = "Confirm";
            this.selectBtn.UseVisualStyleBackColor = true;
            this.selectBtn.Click += new System.EventHandler(this.selectBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(119, 136);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 2;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // FileSaveRadio
            // 
            this.FileSaveRadio.AutoSize = true;
            this.FileSaveRadio.Checked = true;
            this.FileSaveRadio.Location = new System.Drawing.Point(28, 75);
            this.FileSaveRadio.Name = "FileSaveRadio";
            this.FileSaveRadio.Size = new System.Drawing.Size(85, 17);
            this.FileSaveRadio.TabIndex = 3;
            this.FileSaveRadio.TabStop = true;
            this.FileSaveRadio.Text = "Save To File";
            this.FileSaveRadio.UseVisualStyleBackColor = true;
            this.FileSaveRadio.CheckedChanged += new System.EventHandler(this.FileSaveRadio_CheckedChanged);
            // 
            // PrintRadio
            // 
            this.PrintRadio.AutoSize = true;
            this.PrintRadio.Location = new System.Drawing.Point(144, 75);
            this.PrintRadio.Name = "PrintRadio";
            this.PrintRadio.Size = new System.Drawing.Size(46, 17);
            this.PrintRadio.TabIndex = 4;
            this.PrintRadio.TabStop = true;
            this.PrintRadio.Text = "Print";
            this.PrintRadio.UseVisualStyleBackColor = true;
            this.PrintRadio.CheckedChanged += new System.EventHandler(this.PrintRadio_CheckedChanged);
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(13, 101);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(124, 20);
            this.textBox1.TabIndex = 5;
            // 
            // selectFileBtn
            // 
            this.selectFileBtn.Location = new System.Drawing.Point(143, 98);
            this.selectFileBtn.Name = "selectFileBtn";
            this.selectFileBtn.Size = new System.Drawing.Size(75, 23);
            this.selectFileBtn.TabIndex = 6;
            this.selectFileBtn.Text = "Select File";
            this.selectFileBtn.UseVisualStyleBackColor = true;
            this.selectFileBtn.Click += new System.EventHandler(this.selectFileBtn_Click);
            // 
            // SelectFieldDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(230, 176);
            this.Controls.Add(this.selectFileBtn);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.PrintRadio);
            this.Controls.Add(this.FileSaveRadio);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.selectBtn);
            this.Controls.Add(this.fieldsBox);
            this.Name = "SelectFieldDialog";
            this.Text = "SelectFieldDialog";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox fieldsBox;
        private System.Windows.Forms.Button selectBtn;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.RadioButton FileSaveRadio;
        private System.Windows.Forms.RadioButton PrintRadio;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button selectFileBtn;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    }
}