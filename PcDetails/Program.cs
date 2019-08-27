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

            // Creates the top-level window to show
            var winComputerDetails = new Window("Computer Details")
            {
                X = 0,
                Y = 1, // Leave one row for the toplevel menu

                // By using Dim.Fill(), it will automatically resize without manual intervention
                Width = Dim.Percent(50),
                Height = Dim.Percent(50)
            };
            var win2 = new Window("MyApp2")
            {
                X = Pos.Right(winComputerDetails),
                Y = 1, // Leave one row for the toplevel menu

                // By using Dim.Fill(), it will automatically resize without manual intervention
                Width = Dim.Fill(),
                Height = Dim.Percent(50)
            };

            var win3 = new Window("MyApp3")
            {
                X = 0,
                Y = Pos.Bottom(winComputerDetails), // Leave one row for the toplevel menu

                // By using Dim.Fill(), it will automatically resize without manual intervention
                Width = Dim.Percent(50),
                Height = Dim.Fill()
            };

            var win4 = new Window("MyApp4")
            {
                X = Pos.Right(win3),
                Y = Pos.Bottom(win2), // Leave one row for the toplevel menu

                // By using Dim.Fill(), it will automatically resize without manual intervention
                Width = Dim.Fill(),
                Height = Dim.Fill()
            };


            top.Add(winComputerDetails);
            top.Add(win2);
            top.Add(win3);
            top.Add(win4);


            // Creates a menubar, the item "New" has a help menu.
            var menu = new MenuBar(new MenuBarItem[] {
                new MenuBarItem ("_File", new MenuItem [] {
                    new MenuItem ("_New", "Creates new file", null),
                    new MenuItem ("_Close", "", null),
                    new MenuItem ("_Quit", "", null)
                })
            });
            top.Add(menu);


            var computerDetails = GetComputerDetails();

            var computerPropertiesList = new ListView(computerDetails.Keys.ToArray())
            {
                X = 0, // Leave one row for the toplevel menu
                Y = 1,
                // By using Dim.Fill(), it will automatically resize without manual intervention
                Width = Dim.Percent(50),
                Height = Dim.Fill()
            };
            var computerValuesList = new ListView(computerDetails.Values.ToArray()) { X = Pos.Right(computerPropertiesList), Y = 1, Width = Dim.Fill(), Height = Dim.Fill() };


            winComputerDetails.Add(computerPropertiesList);
            winComputerDetails.Add(computerValuesList);




            var listView1 = new ListView(new String[] { "Hola", "Como", "Estas" })
            {
                X = 0, // Leave one row for the toplevel menu

                // By using Dim.Fill(), it will automatically resize without manual intervention
                Width = Dim.Percent(50),
            };
            var listView2 = new ListView(new String[] { "Bien", "Y", "Tu" }) { X = Pos.Right(listView1), Width = Dim.Fill() };

            win2.Add(listView1);
            win2.Add(listView2);

            var hola = GetComputerDetails();

            Application.Run();
        }

        public static Dictionary<string, string> GetComputerDetails()
        {
            Dictionary<string, string> computerDetails = new Dictionary<string, string>();

            ManagementClass mc = new ManagementClass("win32_computersystem");
            ManagementObjectCollection moc = mc.GetInstances();

            if (moc.Count > 0)
            {
                foreach (ManagementObject item in mc.GetInstances())
                {
                    computerDetails.Add("Caption", item["Caption"].ToString());
                    computerDetails.Add("Manufacturer", item["Manufacturer"].ToString());
                    computerDetails.Add("Model", item["Model"].ToString());
                    computerDetails.Add("SystemType", item["SystemType"].ToString());
                    computerDetails.Add("DNSHostName", item["DNSHostName"].ToString());
                    computerDetails.Add("UserName", item["UserName"].ToString());
                }
            }

            return computerDetails;
        }
    }
}
