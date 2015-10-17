using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace MultiThreadForms
{
    public class UploadService
    {
        public void Upload(IProgress<int> progress)
        {
            for (int i = 0; i < 100; i++)
            {
                Thread.Sleep(1000);
                if (i % 5 == 0)
                {
                    progress.Report(i);
                }
            }
        }
    }
}
