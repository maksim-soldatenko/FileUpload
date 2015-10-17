using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UploadProgressUnit;
using System.Diagnostics;

namespace MultiThreadForms
{
    public partial class MainForm : Form
    {
        private static Random random = new Random((int)DateTime.Now.Ticks);

        public MainForm()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var fileName = RandomString(5);
            ProcessFile(fileName);
            //var uploadUnit = new UploadPanel(fileName);
            //pnlProgress.Controls.Add(uploadUnit);

            //var uploader = new UploadService();
            //var progress = new Progress<int>();
            //uploader.Upload(progress);
            //progress.ProgressChanged += (obj, i) => { throw new NullReferenceException(); };
        }

        private void ProcessFile(string fileName)
        {
            var uploadUnit = new UploadPanel(fileName);
            pnlProgress.Controls.Add(uploadUnit);

            var task = Task.Run(() =>
            {
                var uploader = new UploadService();
                var progress = new Progress<int>();
                progress.ProgressChanged += (obj, i) => { uploadUnit.SetPropertyThreadSafe(() => uploadUnit.ProgressValue, i); };

                uploader.Upload(progress);                
            });

            task.ContinueWith(res => pnlProgress.Controls.Remove(uploadUnit));
        }


        private string RandomString(int size)
        {
            StringBuilder builder = new StringBuilder();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }

            return builder.ToString();
        }

    }
}
