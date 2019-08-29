using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace PcDetails
{
    public class Processor
    {
        public Processor()
        {
            ManagementClass mc = new ManagementClass("Win32_Processor");
            ManagementObjectCollection moc = mc.GetInstances();

            if (moc.Count > 0)
            {
                foreach(var item in moc)
                {
                    //_CreationClassName = item["CreationClassName"].ToString();
                    float speed = float.Parse(item["CurrentClockSpeed"].ToString()) / 1000;
                    _CurrentClockSpeed = speed.ToString() + " Ghz";
                    //_CurrentVoltage = item["CurrentVoltage"].ToString();
                    _DataWidth = item["DataWidth"].ToString();
                    _Description = item["Description"].ToString();
                    float l2Size = float.Parse(item["L2CacheSize"].ToString()) / 1000;
                    _L2CacheSize = l2Size.ToString() + " Mb";
                    float l3Size = float.Parse(item["L3CacheSize"].ToString()) / 1000;
                    _L3CacheSize = l3Size.ToString();
                    //_Level = item["Level"].ToString() + " Mb";
                    //_LoadPercentage = item["LoadPercentage"].ToString() + " %";
                    _Manufacturer = item["Manufacturer"].ToString();
                    float maxSpeed = float.Parse(item["MaxClockSpeed"].ToString()) / 1000;
                    _MaxClockSpeed = maxSpeed.ToString() + " Ghz";
                    _Name = item["Name"].ToString();
                    _NumberOfCores = item["NumberOfCores"].ToString();
                    _NumberOfLogicalProcessors = item["NumberOfLogicalProcessors"].ToString();
                    _ProcessorId = item["ProcessorId"].ToString();
                }
            }

            _ProcessorDetails = new Dictionary<string, string>()
            {
                //{"CreationClassName", _CreationClassName},
                {"CurrentClockSpeed", _CurrentClockSpeed},
                //{"CurrentVoltage", _CurrentVoltage},
                {"DataWidth", _DataWidth},
                {"Description", _Description},
                {"L2CacheSize", _L2CacheSize},
                {"L3CacheSize", _L3CacheSize},
                //{"Level", _Level},
                //{"LoadPercentage", _LoadPercentage},
                {"Manufacturer", _Manufacturer},
                {"MaxClockSpeed", _MaxClockSpeed},
                {"Name", _Name},
                {"NumberOfCores", _NumberOfCores},
                {"NumberOfLogicalProcessors", _NumberOfLogicalProcessors},
                {"ProcessorId", _ProcessorId},
            };
        }

        //private string _CreationClassName;
        private string _CurrentClockSpeed;
        //private string _CurrentVoltage;
        private string _DataWidth;
        private string _Description;
        private string _L2CacheSize;
        private string _L3CacheSize;
        //private string _Level;
        //private string _LoadPercentage;
        private string _Manufacturer;
        private string _MaxClockSpeed;
        private string _Name;
        private string _NumberOfCores;
        private string _NumberOfLogicalProcessors;
        private string _ProcessorId;

        //public string CreationClassName { get { return _CreationClassName; } }
        public string CurrentClockSpeed
        {
            get
            {
                float speed = float.Parse(_CurrentClockSpeed) / 1000;
                return speed.ToString() + " Ghz";
            }
        }
        //public string CurrentVoltage { get { return _CurrentVoltage; } }
        public string DataWidth { get { return _DataWidth; } }
        public string Description { get { return _Description; } }
        public string L2CacheSize
        {
            get
            {
                float l2Size = float.Parse(_L2CacheSize) / 1000;
                return l2Size.ToString() + " Mb";
            }
        }
        public string L3CacheSize
        {
            get
            {
                float l3Size = float.Parse(_L3CacheSize) / 1000;
                return l3Size.ToString() + " Mb";
            }
        }
        //public string Level { get { return _Level; } }
        //public string LoadPercentage { get { return _LoadPercentage; } }
        public string Manufacturer { get { return _Manufacturer; } }
        public string MaxClockSpeed
        {
            get
            {
                float maxSpeed = float.Parse(_MaxClockSpeed) / 1000;
                return maxSpeed + " Ghz";
            }
        }
        public string Name { get { return _Name; } }
        public string NumberOfCores { get { return _NumberOfCores; } }
        public string NumberOfLogicalProcessors { get { return _NumberOfLogicalProcessors; } }
        public string ProcessorId { get { return _ProcessorId; } }


        private Dictionary<string, string> _ProcessorDetails = new Dictionary<string, string>();
        public Dictionary<string, string> ProcessorDetailsDictionary { get { return _ProcessorDetails; } }


    }
}
