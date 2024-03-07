using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace PivotPrint
{
    public partial class SelectFieldDialog : Form
    {
        public Excel.PivotField SelectedPivotField { get; private set; }
        private PivotField[] FieldArray { get; set; }
        public string folderPath {  get; set; }

        public SelectFieldDialog(PivotField[] fieldArray)
        {
            InitializeComponent();
            this.FieldArray = fieldArray;
            foreach (PivotField field in fieldArray)
            {
                fieldsBox.Items.Add(field.Name); // Add field name to the list
            }
        }

        private void selectBtn_Click(object sender, EventArgs e)
        {
            if (fieldsBox.SelectedIndex == -1 )
            {
                MessageBox.Show("Please select an item from the box");
                return;
            }
            if (FileSaveRadio.Checked == false && PrintRadio.Checked == false)
            {
                MessageBox.Show("Please select an output button");
                return;
            }
            if (FileSaveRadio.Checked == true && folderPath == null)
            {
                MessageBox.Show("Please select an output file");
                return;
            }



            // Retrieve the selected PivotField using the index from FieldArray
            SelectedPivotField = FieldArray[fieldsBox.SelectedIndex];
            DialogResult = DialogResult.OK;
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void selectFileBtn_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.SelectedPath = @"C:\";
            folderBrowserDialog.Description = "Select a folder to save to";
            DialogResult result = folderBrowserDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                folderPath = folderBrowserDialog.SelectedPath;
                textBox1.Text = folderBrowserDialog.SelectedPath;

            }
        }

        private void FileSaveRadio_CheckedChanged(object sender, EventArgs e)
        {
            selectFileBtn.Enabled = true;
        }

        private void PrintRadio_CheckedChanged(object sender, EventArgs e)
        {
            selectFileBtn.Enabled = false;
        }
    }
}

