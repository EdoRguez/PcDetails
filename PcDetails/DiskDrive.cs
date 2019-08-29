using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace PcDetails
{
    public class DiskDrive
    {
        public DiskDrive()
        {
            ManagementClass mc = new ManagementClass("Win32_DiskDrive");
            ManagementObjectCollection moc = mc.GetInstances();

            if (moc.Count > 0)
            {
                foreach (ManagementObject item in moc)
                {
                    _BytesPerSector = item["BytesPerSector"].ToString();
                    _CreationClassName = item["CreationClassName"].ToString();
                    //_Description = item["Description"].ToString();
                    _DeviceID = item["DeviceID"].ToString();
                    _FirmwareRevision = item["FirmwareRevision"].ToString();
                    _InterfaceType = item["InterfaceType"].ToString();
                    _Manufacturer = item["Manufacturer"].ToString();
                    _MediaType = item["MediaType"].ToString();
                    _Model = item["Model"].ToString();
                    _Partitions = item["Partitions"].ToString();
                    _PNPDeviceID = item["PNPDeviceID"].ToString();
                    _SerialNumber = item["SerialNumber"].ToString().Trim();
                    long longResult = long.Parse(item["Size"].ToString()) / 1000000000;
                    _Size = longResult.ToString() + " GB";
                    //_Status = item["Status"].ToString();
                    _SystemCreationClassName = item["SystemCreationClassName"].ToString();
                    _TotalCylinders = item["TotalCylinders"].ToString();
                    _TotalHeads = item["TotalHeads"].ToString();
                    _TotalSectors = item["TotalSectors"].ToString();
                    _TotalTracks = item["TotalTracks"].ToString();
                    _TracksPerCylinder = item["TracksPerCylinder"].ToString();
                }
            }

            _DiskDriveDetails = new Dictionary<string, string>
            {
                {"BytesPerSector", _BytesPerSector},
                {"CreationClassName", _CreationClassName},
                //{"Description", _Description},
                {"DeviceID", _DeviceID},
                {"FirmwareRevision", _FirmwareRevision},
                {"Manufacturer", _Manufacturer},
                {"MediaType", _MediaType},
                {"Model", _Model},
                {"Partitions", _Partitions},
                {"PNPDeviceID", _PNPDeviceID},
                {"SerialNumber", _SerialNumber},
                {"Size", _Size},
                //{"Status", _Status},
                {"SystemCreationClassName", _SystemCreationClassName},
                {"TotalCylinders", _TotalCylinders},
                {"TotalHeads", _TotalHeads},
                {"TotalSectors", _TotalSectors},
                {"TotalTracks", _TotalTracks},
                {"TracksPerCylinder", _TracksPerCylinder}
            };

        }

        private string _BytesPerSector;
        private string _CreationClassName;
        //private string _Description;
        private string _DeviceID;
        private string _FirmwareRevision;
        private string _InterfaceType;
        private string _Manufacturer;
        private string _MediaType;
        private string _Model;
        private string _Partitions;
        private string _PNPDeviceID;
        private string _SerialNumber;
        private string _Size;
        //private string _Status;
        private string _SystemCreationClassName;
        private string _TotalCylinders;
        private string _TotalHeads;
        private string _TotalSectors;
        private string _TotalTracks;
        private string _TracksPerCylinder;

        public string BytesPerSector { get { return _BytesPerSector; } }
        public string CreationClassName { get { return _CreationClassName; } }
        //public string Description { get { return _Description; } }
        public string DeviceID { get { return _DeviceID; } }
        public string FirmwareRevision { get { return _FirmwareRevision; } }
        public string InterfaceType { get { return _InterfaceType; } }
        public string Manufacturer { get { return _Manufacturer; } }
        public string MediaType { get { return _MediaType; } }
        public string Model { get { return _Model; } }
        public string Partitions { get { return _Partitions; } }
        public string PNPDeviceID { get { return _PNPDeviceID; } }
        public string SerialNumber { get { return _SerialNumber.Trim(); } }
        public string Size {
            get
            {
                long longResult = long.Parse(_Size) / 1000000000;
                return longResult.ToString() + " GB";
            }
        }
        //public string Status { get { return _Status; } }
        public string SystemCreationClassName { get { return _SystemCreationClassName; } }
        public string TotalCylinders { get { return _TotalCylinders; } }
        public string TotalHeads { get { return _TotalHeads; } }
        public string TotalSectors { get { return TotalSectors; } }
        public string TotalTracks { get { return TotalTracks; } }
        public string TracksPerCylinder { get { return _TracksPerCylinder; } }

        private Dictionary<string, string> _DiskDriveDetails = new Dictionary<string, string>();
        public Dictionary<string, string> DiskDriveDetailsDictionary { get { return _DiskDriveDetails; } }
    }
}
