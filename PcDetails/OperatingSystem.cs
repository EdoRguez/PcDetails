using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace PcDetails
{
    class OperatingSystem
    {
        public OperatingSystem()
        {
            ManagementClass mc = new ManagementClass("Win32_OperatingSystem");
            ManagementObjectCollection moc = mc.GetInstances();

            if (moc.Count > 0)
            {
                foreach(var item in moc)
                {
                    _Caption = item["Caption"].ToString();
                    _Manufacturer = item["Manufacturer"].ToString();
                    _Version = item["Version"].ToString();
                    int freePhysical = int.Parse(item["FreePhysicalMemory"].ToString()) / 10000;
                    _FreePhysicalMemory = freePhysical.ToString() + " GB";
                    int freeVirtual = int.Parse(item["FreeVirtualMemory"].ToString()) / 10000;
                    _FreeVirtualMemory = freeVirtual.ToString() + " GB";
                }
            }

            _OperatingSystemDetails = new Dictionary<string, string>
            {
                { "Caption",  _Caption},
                { "Manufacturer",  _Manufacturer},
                { "Version",  _Version},
                { "FreePhysicalMemory",  _FreePhysicalMemory},
                { "FreeVirtualMemory",  _FreeVirtualMemory}
            };
        }

        private string _Caption;
        private string _Manufacturer;
        private string _Version;
        private string _FreePhysicalMemory;
        private string _FreeVirtualMemory;
        //private string _OSArchitecture;

        public string Caption { get { return _Caption; } }
        public string Manufacturer { get { return _Manufacturer; } }
        public string Version { get { return _Version; } }
        public string FreePhysicalMemory { get { return _FreePhysicalMemory; } }
        public string FreeVirtualMemory { get { return _FreeVirtualMemory; } }
        //public string OSArchitecture;

        private Dictionary<string, string> _OperatingSystemDetails = new Dictionary<string, string>();
        public Dictionary<string, string> OperatingSystemDetailsDictionary { get { return _OperatingSystemDetails; } }

    }
}
