using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using Office = Microsoft.Office.Core;
using Excel = Microsoft.Office.Interop.Excel;
using System.Diagnostics;
using Microsoft.Office.Tools.Excel;
using static System.Collections.Specialized.BitVector32;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PivotPrint
{
    [ComVisible(true)]
    public class Ribbon1 : Office.IRibbonExtensibility
    {
        private Office.IRibbonUI ribbon;

        public Ribbon1()
        {
        }

        public void CustomButton_Click(Office.IRibbonControl control)
        {

            try
            {
                // Get the Excel application instance
                Excel.Application excelApp = control.Context as Excel.Application;
                Excel.Application excelApp2 = Globals.ThisAddIn.Application;

                // Get the active worksheet
                Excel.Worksheet activeSheet = Globals.ThisAddIn.Application.ActiveSheet;

                // Check if the active sheet is a worksheet
                if (activeSheet != null && activeSheet is Excel.Worksheet)
                {
                    Excel.Worksheet worksheet = activeSheet as Excel.Worksheet;

                    // Get the selection (which should be the pivot table)
                    Excel.Range selection = excelApp2.Selection as Excel.Range;

                    // Check if the selection is a pivot table
                    if (selection != null && selection.PivotTable != null)
                    {
                        Excel.PivotTable pivotTable = selection.PivotTable;

                        // Initialize the pivotFields variable
                        Excel.PivotFields pivotFields = pivotTable.PivotFields();


                        //count of pageFields
                        int pageCount = 0;

                        foreach (Excel.PivotField field in pivotFields)
                        {
                            // Check if the pivot field is a page field
                            if (field.Orientation == Excel.XlPivotFieldOrientation.xlPageField)
                            {
                                pageCount += 1;
                            }
                        }

                        //get fields array
                        PivotField[] fields = new PivotField[pageCount];
                        int i = 0;
                        foreach (Excel.PivotField field in pivotFields)
                        {
                            // Check if the pivot field is a page field
                            if (field.Orientation == Excel.XlPivotFieldOrientation.xlPageField)
                            {
                                fields[i] = field;
                                i += 1;
                            }
                        }

                        //Dialog
                        PivotField selectedField = null;
                        String folderPath = null;
                        



                        SelectFieldDialog selectFieldDialog = new SelectFieldDialog(fields);
                        DialogResult result = selectFieldDialog.ShowDialog();
                        if (result == DialogResult.OK) { selectedField = selectFieldDialog.SelectedPivotField; folderPath = selectFieldDialog.folderPath; }
                        else { return; }


                        loadingForm loadingForm = new loadingForm((selectedField.PivotItems() as PivotItems).Count);
                        loadingForm.Show();
                        i = 0;
                        foreach (Excel.PivotItem item in selectedField.PivotItems())
                        {
                            pivotTable.PivotFields(selectedField.Name).CurrentPage = item.Name;

                            if (folderPath != null)
                            {
                                String filepath = folderPath + "/" + worksheet.Name + "_" + selectedField.Name + "_" + item.Name + "_" + DateTime.Now.ToShortDateString().Replace('/', '-');
                                Debug.WriteLine(filepath);
                                worksheet.ExportAsFixedFormat(Excel.XlFixedFormatType.xlTypePDF, filepath);
                            }
                            else
                            {
                                worksheet.PrintOutEx(Preview: true);
                            }
                            i++;
                            loadingForm.UpdateProgress(i);
                        }
                        loadingForm.CloseMessageBox();
                        MessageBox.Show("Finished!");




                        Debug.WriteLine(selectedField.Name);
                        Debug.WriteLine("Number of Page Fields: " + pivotFields.Count); // Output the count of page fields
                    }
                    else
                    {
                        Debug.WriteLine("Selection is not a pivot table.");
                    }
                }
                else
                {
                    MessageBox.Show("Please navigate to a worksheet with a pivot table before clicking the button.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        #region IRibbonExtensibility Members

        public string GetCustomUI(string ribbonID)
        {
            return GetResourceText("PivotPrint.Ribbon1.xml");
        }

        #endregion

        #region Ribbon Callbacks
        //Create callback methods here. For more information about adding callback methods, visit https://go.microsoft.com/fwlink/?LinkID=271226

        public void Ribbon_Load(Office.IRibbonUI ribbonUI)
        {
            this.ribbon = ribbonUI;
        }

        #endregion

        #region Helpers

        private static string GetResourceText(string resourceName)
        {
            Assembly asm = Assembly.GetExecutingAssembly();
            string[] resourceNames = asm.GetManifestResourceNames();
            for (int i = 0; i < resourceNames.Length; ++i)
            {
                if (string.Compare(resourceName, resourceNames[i], StringComparison.OrdinalIgnoreCase) == 0)
                {
                    using (StreamReader resourceReader = new StreamReader(asm.GetManifestResourceStream(resourceNames[i])))
                    {
                        if (resourceReader != null)
                        {
                            return resourceReader.ReadToEnd();
                        }
                    }
                }
            }
            return null;
        }

        #endregion
    }
}
