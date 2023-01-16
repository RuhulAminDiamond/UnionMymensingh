using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HDMS.Windows.Forms.UI
{
    public partial class ReportViewer : Form
    {
        string value;
        public ReportViewer()
        {
            InitializeComponent();
        }

        private void ReportViewer_Load(object sender, EventArgs e)
        {
          
        }

        private void crviewer_DoubleClickPage(object sender, CrystalDecisions.Windows.Forms.PageMouseEventArgs e)
        {
            if (e.ObjectInfo.Name == "vouCode") {
                MessageBox.Show(e.ObjectInfo.Text);
           }
        }

        private void crviewer_Click(object sender, EventArgs e)
        {
            MouseEventArgs testMouseEventArgs = (MouseEventArgs)e;
            if (value != null)
            {
               // MessageBox.Show(value + " - " + testMouseEventArgs.Button.ToString());
             
            }
            value = null;
        }

        private void crviewer_ClickPage(object sender, CrystalDecisions.Windows.Forms.PageMouseEventArgs e)
        {
            value = e.ObjectInfo.Text;
        }
    }
}
