using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace PcDetails
{
    class ComputerSystem
    {
        public ComputerSystem()
        {
            ManagementClass mc = new ManagementClass("win32_computersystem");
            ManagementObjectCollection moc = mc.GetInstances();

            if (moc.Count > 0)
            {
                foreach (ManagementObject item in mc.GetInstances())
                {
                    _DNSHostName = item["DNSHostName"].ToString();
                    _Domain =  item["Domain"].ToString();
                    _Manufacturer = item["Manufacturer"].ToString();
                    _Model = item["Model"].ToString();
                    _Name = item["Name"].ToString();
                    _PrimaryOwnerName = item["PrimaryOwnerName"].ToString();
                    _SystemFamily = item["SystemFamily"].ToString();
                    _SystemSKUNumber = item["SystemSKUNumber"].ToString();
                    _SystemType = item["SystemType"].ToString();
                    _ThermalState = item["ThermalState"].ToString();
                    _UserName = item["UserName"].ToString();
                    _Workgroup = item["WorkGroup"].ToString();
                }

                _ComputerDetails = new Dictionary<string, string>()
                {
                    {"DNSHostName", _DNSHostName},
                    {"Domain", _Domain},
                    {"Manufacturer", _Manufacturer},
                    {"Model", _Model},
                    {"Name", _Name},
                    {"PrimaryOwnerName", _PrimaryOwnerName},
                    {"SystemFamily", _SystemFamily},
                    {"SystemSKUNumber", _SystemSKUNumber},
                    {"SystemType", _SystemType},
                    {"ThermalState", _ThermalState},
                    {"UserName", _UserName},
                    {"WorkGroup", _Workgroup},
                };
            }
        }

        private string _DNSHostName;
        private string _Domain;
        private string _Manufacturer;
        private string _Model;
        private string _Name;
        private string _PrimaryOwnerName;
        private string _SystemFamily;
        private string _SystemSKUNumber;
        private string _SystemType;
        private string _ThermalState;
        private string _UserName;
        private string _Workgroup;

        public string DNSHostName { get { return _DNSHostName; } }
        public string Domain{ get { return _Domain; } }
        public string Manufacturer { get { return _Manufacturer; } }
        public string Model { get { return _Model; } }
        public string Name { get { return _Name; } }
        public string PrimaryOwnerName { get { return _PrimaryOwnerName; } }
        public string SystemFamily { get { return _SystemFamily; } }
        public string SystemSKUNumber { get { return _SystemSKUNumber; } }
        public string SystemType { get { return _SystemType; } }
        public string ThermalState { get { return _ThermalState; } }
        public string UserName { get { return _UserName; } }
        public string WorkGroup { get { return _Workgroup; } }

        private Dictionary<string, string> _ComputerDetails = new Dictionary<string, string>();
        public Dictionary<string, string> ComputerDetailsDictionary { get { return _ComputerDetails; } }

    }
}
