using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminal.Gui;
using System.Management;
using System.Collections;

namespace PcDetails
{
    class Program
    {
        static void Main(string[] args)
        {
            Application.Init();
            var top = Application.Top;

            var winComputerDetails = new Window("Computer Details")
            {
                X = 0,
                Y = 1,
                Width = Dim.Percent(50),
                Height = Dim.Percent(50)
            };
            var winDiskDriveDetails = new Window("Disk Drive Details")
            {
                X = Pos.Right(winComputerDetails),
                Y = 1,
                Width = Dim.Fill(),
                Height = Dim.Percent(75)
            };

            var win3 = new Window("MyApp3")
            {
                X = 0,
                Y = Pos.Bottom(winComputerDetails),
                Width = Dim.Percent(50),
                Height = Dim.Fill()
            };

            var win4 = new Window("MyApp4")
            {
                X = Pos.Right(win3),
                Y = Pos.Bottom(winDiskDriveDetails),
                Width = Dim.Fill(),
                Height = Dim.Fill()
            };


            top.Add(winComputerDetails);
            top.Add(winDiskDriveDetails);
            top.Add(win3);
            top.Add(win4);

            var menu = new MenuBar(new MenuBarItem[] {
                new MenuBarItem ("_File", new MenuItem [] {
                    new MenuItem ("_New", "Creates new file", null),
                    new MenuItem ("_Close", "", null),
                    new MenuItem ("_Quit", "", null)
                })
            });
            top.Add(menu);


            ComputerSystem computerDetails = new ComputerSystem();
            var computerPropertiesList = new ListView(computerDetails.ComputerDetailsDictionary.Keys.ToArray())
            {
                X = 0,
                Y = 1,
                Width = Dim.Percent(50),
                Height = Dim.Fill()
            };
            var computerValuesList = new ListView(computerDetails.ComputerDetailsDictionary.Values.ToArray()) { X = Pos.Right(computerPropertiesList), Y = 1, Width = Dim.Fill(), Height = Dim.Fill() };
            winComputerDetails.Add(computerPropertiesList);
            winComputerDetails.Add(computerValuesList);



            DiskDrive diskDriveDetails = new DiskDrive();
            var diskPropertiesList = new ListView(diskDriveDetails.DiskDriveDetailsDictionary.Keys.ToArray())
            {
                X = 0,
                Y = 1,
                Width = Dim.Percent(50),
                Height = Dim.Fill()
            };
            var diskValuesList = new ListView(diskDriveDetails.DiskDriveDetailsDictionary.Values.ToArray()) { X = Pos.Right(diskPropertiesList), Y = 1, Width = Dim.Fill(), Height = Dim.Fill() };

            winDiskDriveDetails.Add(diskPropertiesList);
            winDiskDriveDetails.Add(diskValuesList);

            Application.Run();
        }
    }
}
