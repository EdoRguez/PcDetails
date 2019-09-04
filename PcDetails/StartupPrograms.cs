using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace PcDetails
{
    class StartupPrograms
    {
        public StartupPrograms()
        {
            ManagementClass mc = new ManagementClass("Win32_StartupCommand");
            ManagementObjectCollection moc = mc.GetInstances();

            if (moc.Count > 0)
            {
                foreach (ManagementObject item in mc.GetInstances())
                {
                    Names.Add(item["Name"].ToString());
                    Locations.Add(item["Command"].ToString());
                }
            }
        }

        private List<string> Names = new List<string>();
        public List<string> NamesList { get { return Names; } }

        private List<string> Locations = new List<string>();
        public List<string> LocationList { get { return Locations; } }

    }
}
