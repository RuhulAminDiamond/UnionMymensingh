using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HDMS.Windows.Forms.UI.Hospital
{
    public partial class ctrlDischargeCertificate : UserControl
    {
        public ctrlDischargeCertificate()
        {
            InitializeComponent();
        }

        public int EntryCompleted { get; internal set; }
    }
}
