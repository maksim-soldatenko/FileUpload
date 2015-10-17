using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UploadProgressUnit
{
    public partial class UploadPanel: UserControl
    {
        public int ProgressValue
        {
            get { return this.progressBar1.Value; }
            set { this.progressBar1.Value = value; }
        }


        public UploadPanel(string caption)
        {
            InitializeComponent();

            this.label1.Text = caption;
        }

        private void btnPause_Click(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            
        }
    }
}
