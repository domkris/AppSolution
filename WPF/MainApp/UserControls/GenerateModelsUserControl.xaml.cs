using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using MainApp.Helpers;
using Microsoft.SqlServer.Management.Smo;
using System.IO;
using MainApp.Models;

namespace MainApp.UserControls
{
    /// <summary>
    /// Interaction logic for GenerateModelsUserControl.xaml
    /// </summary>
    public partial class GenerateModelsUserControl : UserControl
    {
        string modelNamespace;
        string selectedServer;
        string fileSaveLocation;

        string directory = Directory.GetParent("../../..").ToString();
        public GenerateModelsUserControl()
        {
            InitializeComponent();
            var servers = ListLocalSqlInstances();
            cbxServerList.ItemsSource = servers;
        }



        public static IEnumerable<string> ListLocalSqlInstances()
        {
            if (Environment.Is64BitOperatingSystem)
            {
                using (var hive = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64))
                {
                    foreach (string item in ListLocalSqlInstances(hive))
                    {
                        yield return item;
                    }
                }
                using (var hive = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32))
                {
                    foreach (string item in ListLocalSqlInstances(hive))
                    {
                        yield return item;
                    }
                }
            }
            else
            {
                foreach (string item in ListLocalSqlInstances(Registry.LocalMachine))
                {
                    yield return item;
                }
            }
        }

        private static IEnumerable<string> ListLocalSqlInstances(RegistryKey hive)
        {
            const string keyName = @"Software\Microsoft\Microsoft SQL Server";
            const string valueName = "InstalledInstances";
            const string defaultName = "MSSQLSERVER";

            using (var key = hive.OpenSubKey(keyName, false))
            {
                if (key == null) return Enumerable.Empty<string>();
                var value = key.GetValue(valueName) as string[];
                if (value == null) return Enumerable.Empty<string>();

                for (int index = 0; index < value.Length; index++)
                {
                    if (string.Equals(value[index], defaultName, StringComparison.OrdinalIgnoreCase))
                    {
                        value[index] = ".";
                    }
                    else
                    {
                        value[index] = @".\" + value[index];
                    }
                }
                return value;
            }

        }

        private void CbxServerList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedServer = (string)cbxServerList.SelectedItem;


            List<string> databases = new List<string>();
            databases = SqlServerHelper.GetDatabaseList(selectedServer);
            cbxDatabaseList.ItemsSource = databases;
        }

        private void CbxDatabaseList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selectedDatabase = (string)cbxDatabaseList.SelectedItem;

            switch (selectedDatabase)
            {
                case "AdminDB":
                    txtBoxModelNamespace.Text = "Models.Administration";
                    txtBoxSaveFolder.Text = directory + "\\Class Libraries\\Models\\" + "Administration\\";  
                    break;
                case "CoreDB":
                    txtBoxModelNamespace.Text = "Models.Core";
                    txtBoxSaveFolder.Text = directory + "\\Class Libraries\\Models\\" + "Core\\";
                    break;
                case "LoggingDB":
                    txtBoxModelNamespace.Text = "Models.Logging";
                    txtBoxSaveFolder.Text = directory + "\\Class Libraries\\Models\\" + "Logging\\";
                    break;
                default:
                    txtBoxModelNamespace.Text = "";
                    txtBoxSaveFolder.Text = "";
                    break;
            }

            List<Table> tables = SqlServerHelper.GetTableList(selectedServer, selectedDatabase);
            List<View> views = SqlServerHelper.GetViewlist(selectedServer, selectedDatabase);
            List<TableForExport> tablesForExport = new List<TableForExport>();
            List<ViewForExport> viewsForExport = new List<ViewForExport>();
            foreach (Table table in tables)
            {
                tablesForExport.Add(new TableForExport
                {
                    Table = table,
                    IsCheckedForExport = false
                });
            }
            dgTables.ItemsSource = tablesForExport;
   
            foreach (View view in views)
            {
                viewsForExport.Add(new ViewForExport
                {
                    View = view,
                    IsCheckedForExport = false
                });

            }
            dgViews.ItemsSource = viewsForExport;

        }

        

        private void BttnGenerate_Click(object sender, RoutedEventArgs e)
        {
            string fileName;
            modelNamespace = txtBoxModelNamespace.Text;
            fileSaveLocation = txtBoxSaveFolder.Text;

            List<TableForExport> tablesToGenerate = new List<TableForExport>();
            List<ViewForExport> viewsToGenerate = new List<ViewForExport>();

            foreach (TableForExport item in dgTables.Items)
            {
                if (item.IsCheckedForExport)
                {
                    tablesToGenerate.Add(item);
                }
            }
            foreach (ViewForExport item in dgViews.Items)
            {
                if (item.IsCheckedForExport)
                {
                    viewsToGenerate.Add(item);
                }
            }
            
            foreach (TableForExport item in tablesToGenerate)
            {
                
                string textToWrite;
                string className = item.Table.ToString().Replace("[dbo].", "").Replace("[", "").Replace("]", "");
                textToWrite = "namespace " + modelNamespace + "\n" +
                                  "{\n" +
                                  "\t" + "using System;\n" +
                                  "\t" + "using System.Collections.Generic;\n\n" +
                                  "\t" + "public partial class " + className + "\n" +
                                  "\t{\n";
                foreach (Column column in item.Table.Columns)
                {
                    textToWrite += "\t\t" + "public " + SqlServerHelper.GetDotNetType(column).ToString().Replace("System.", "") + " " + column.ToString().Replace("[", "").Replace("]", "") + " { get; set; }\n";

                    
                }
                textToWrite += "\t}\n}";
                fileName = className + ".cs";

                using (System.IO.StreamWriter file =
                new System.IO.StreamWriter(txtBoxSaveFolder.Text + fileName))
                {
                    file.Write(textToWrite);
                    if (File.Exists(txtBoxSaveFolder.Text + fileName))
                    {
                        MessageBox.Show("File " + fileName + " created succesfully!\n ");
                    }
                    else
                    {
                        MessageBox.Show("Error: File " + fileName + " not created!");
                    }
                }

            }
            foreach (ViewForExport item in viewsToGenerate)
            {
                string textToWrite;
                string className = item.View.ToString().Replace("[dbo].", "").Replace("[", "").Replace("]", "").Replace("Custom.", "");
                textToWrite = "namespace " + modelNamespace + "\n" +
                                  "{\n" +
                                  "\t" + "using System;\n" +
                                  "\t" + "using System.Collections.Generic;\n\n" +
                                  "\t" + "public partial class " + className + "\n" +
                                  "\t{\n";
                foreach (Column column in item.View.Columns)
                {
                    textToWrite += "\t\t" + "public " + SqlServerHelper.GetDotNetType(column).ToString().Replace("System.", "") + " " + column.ToString().Replace("[", "").Replace("]", "") + " { get; set; }\n";


                }
                textToWrite += "\t}\n}";
                fileName = className + ".cs";

                using (System.IO.StreamWriter file =
                new System.IO.StreamWriter(txtBoxSaveFolder.Text + fileName))
                {
                    file.Write(textToWrite);
                    if (File.Exists(txtBoxSaveFolder.Text + fileName))
                    {
                        MessageBox.Show("File " + fileName + " created succesfully!\n ");
                    }
                    else
                    {
                        MessageBox.Show("Error: File " + fileName + " not created!");
                    }
                }

            }
            
           

        }

        private void BttnBrowse_Click(object sender, RoutedEventArgs e)
        {

            System.Windows.Forms.FolderBrowserDialog dialog = new System.Windows.Forms.FolderBrowserDialog();
            dialog.SelectedPath = directory;
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtBoxSaveFolder.Text = dialog.SelectedPath;
            }
            
            
        }
    }
}
