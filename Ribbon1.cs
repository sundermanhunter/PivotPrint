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

                        foreach (Excel.PivotField field in pivotTable.PivotFields())
                        {
                            Debug.WriteLine($"Name: {field.Name}");
                            Debug.WriteLine($"Caption: {field.Caption}");
                            Debug.WriteLine($"Data Type: {field.DataType}");
                            Debug.WriteLine($"Orientation: {field.Orientation}"); ///////////////this one!!!!!!!!!!!!!
                            Debug.WriteLine($"Is Calculated: {field.IsCalculated}");
                            //Debug.WriteLine($"Hidden: {field.Hidden}");
                            Debug.WriteLine($"Drag To Column: {field.DragToColumn}");
                            Debug.WriteLine($"Drag To Data: {field.DragToData}");
                            Debug.WriteLine($"Drag To Hide: {field.DragToHide}");
                            Debug.WriteLine($"Drag To Page: {field.DragToPage}");
                            Debug.WriteLine($"Drag To Row: {field.DragToRow}");
                            Debug.WriteLine($"Repeat Labels: {field.RepeatLabels}");
                            Debug.WriteLine($"Show All Items: {field.ShowAllItems}");
                            //Debug.WriteLine($"Show Detail: {field.ShowDetail}");



                        }
                    }
                    else
                    {
                        MessageBox.Show("Please right-click on a pivot table.");
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
