using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PivotPrint
{
    public partial class loadingForm : Form
    {
        public loadingForm(int max)
        {
            InitializeComponent();
            progressBar1.Maximum = max;
            progressBar1.Value = 0;
        }

        public void UpdateProgress(int progValue)
        {
            progressBar1.Value = progValue;
        }

        public void CloseMessageBox()
        {
            this.Close();
        }
    }
}
