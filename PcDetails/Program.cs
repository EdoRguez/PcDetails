﻿using System;
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
            var winOperatingSystemDetails = new Window("Operating System")
            {
                X = Pos.Right(winComputerDetails),
                Y = 1,
                Width = Dim.Fill(),
                Height = Dim.Percent(30)
            };
            var winProcessorDetails = new Window("Processor Details")
            {
                X = 0,
                Y = Pos.Bottom(winComputerDetails),
                Width = Dim.Percent(50),
                Height = Dim.Fill()
            };
            var winDiskDriveDetails = new Window("Disk Drive Details")
            {
                X = Pos.Right(winProcessorDetails),
                Y = Pos.Bottom(winOperatingSystemDetails),
                Width = Dim.Fill(),
                Height = Dim.Fill()
            };



            top.Add(winComputerDetails);
            top.Add(winDiskDriveDetails);
            top.Add(winProcessorDetails);
            top.Add(winOperatingSystemDetails);


            // Top menu bar
            var menu = new MenuBar(new MenuBarItem[] {
                new MenuBarItem ("_More Details", new MenuItem [] {
                    new MenuItem ("_Startup Programs", "", null),
                    new MenuItem ("_IP Details", "", null),
                    new MenuItem ("_CPU Temperature", "", null)
                })
            });
            top.Add(menu);

            // Computer system elements
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


            // Disk drive elements
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


            // Processor elements
            Processor processorDetails = new Processor();
            var processorPropertiesList = new ListView(processorDetails.ProcessorDetailsDictionary.Keys.ToArray())
            {
                X = 0,
                Y = 1,
                Width = Dim.Percent(50),
                Height = Dim.Fill()
            };
            var processorValuesList = new ListView(processorDetails.ProcessorDetailsDictionary.Values.ToArray()) { X = Pos.Right(processorPropertiesList), Y = 1, Width = Dim.Fill(), Height = Dim.Fill() };
            winProcessorDetails.Add(processorPropertiesList);
            winProcessorDetails.Add(processorValuesList);


            // Operating System Details
            OperatingSystem operatingSystemDetails = new OperatingSystem();
            var operatingSystemPropertiesList = new ListView(operatingSystemDetails.OperatingSystemDetailsDictionary.Keys.ToArray())
            {
                X = 0,
                Y = 1,
                Width = Dim.Percent(50),
                Height = Dim.Fill()
            };
            var operatingSystemValuesList = new ListView(operatingSystemDetails.OperatingSystemDetailsDictionary.Values.ToArray()) { X = Pos.Right(operatingSystemPropertiesList), Y = 1, Width = Dim.Fill(), Height = Dim.Fill() };
            winOperatingSystemDetails.Add(operatingSystemPropertiesList);
            winOperatingSystemDetails.Add(operatingSystemValuesList);

            Application.Run();
        }
    }
}
