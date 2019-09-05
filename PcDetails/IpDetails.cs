using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PcDetails
{
    public class IpDetails
    {
        private string _IpDetails;

        public IpDetails()
        {
            string output = "";

            using (Process process = new Process())
            {
                process.StartInfo.FileName = "ipconfig.exe";
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardOutput = true;
                process.Start();

                // Synchronously read the standard output of the spawned process. 
                StreamReader reader = process.StandardOutput;
                output = reader.ReadToEnd();

                process.WaitForExit();
            }

            _IpDetails = output;
        }

        public string GetIpDetails()
        {
            return _IpDetails;
        }
    }
}
