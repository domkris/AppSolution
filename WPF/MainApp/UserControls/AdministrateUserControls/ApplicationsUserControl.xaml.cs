using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Models.Administration;

namespace MainApp.UserControls.AdministrateUserControls
{
    /// <summary>
    /// Interaction logic for ApplicationsUserControl.xaml
    /// </summary>
    public partial class ApplicationsUserControl : UserControl
    {
        string connectionString = ConfigurationManager.ConnectionStrings["AdminDBConnectionString"].ConnectionString;

        public ApplicationsUserControl()
        {
            InitializeComponent();
            txtBoxName.IsEnabled = false;
            string category = selectedCategory.Text;
            FillData();
        }

        private void FillData()
        {
            string selectStoredProcedure = "crud_selectFromApplications";
            txtBoxName.Text = "";
            Dictionary<int, string> titlesDict = new Dictionary<int, string>();
            SqlDataReader dataReader;
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            SqlCommand cmd = new SqlCommand
            {
                CommandType = System.Data.CommandType.StoredProcedure,
                CommandText = selectStoredProcedure,
                Connection = conn

            };
            dataReader = cmd.ExecuteReader();

            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    int appID = dataReader.GetInt32(dataReader.GetOrdinal("ApplicationID"));
                    string appTitle = dataReader.GetString(dataReader.GetOrdinal("ApplicationTitle"));
                    titlesDict.Add(appID, appTitle);
                }
            }
            else
            {
                Console.WriteLine("No rows found.");
            }
            dataReader.Close();

            comboTitles.ItemsSource = titlesDict;
        }

        private void BtnEdit_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            txtBoxName.IsEnabled = true;

        }

        private void ComboTitles_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            txtBoxName.IsEnabled = false;
            
            if (comboTitles.Items.Count > 0 && comboTitles.SelectedItem != null)
            {
                txtBoxName.Text = ((KeyValuePair<int, string>)comboTitles?.SelectedItem).Value;
            }
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            string storedProcedure = "crud_UpdateApplications";
      
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(storedProcedure, conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ApplicationTitle",txtBoxName.Text);
                    cmd.Parameters.AddWithValue("@ApplicationID", ((KeyValuePair<int, string>)comboTitles.SelectedItem).Key);
                    cmd.Parameters.AddWithValue("@UserModified", "Admin");
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            FillData();
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            string storedProcedure = "crud_deleteApplications";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(storedProcedure, conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ApplicationID", ((KeyValuePair<int, string>)comboTitles.SelectedItem).Key);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            FillData();
        }

        private void BtnCreate_Click(object sender, RoutedEventArgs e)
        {
            if (txtBoxNewApplication.Text != "")
            {
                string storedProcedure = "crud_InsertApplications";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(storedProcedure, conn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ApplicationTitle", txtBoxNewApplication.Text);
                        cmd.Parameters.AddWithValue("@UserCreated", "Admin");
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }
                }
                txtBoxNewApplication.Text = "";
                FillData();
            }
            else
            {
                MessageBox.Show("Title field is empty!");
            }
        }
    }
}
