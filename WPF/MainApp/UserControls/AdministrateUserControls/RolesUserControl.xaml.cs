using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace MainApp.UserControls.AdministrateUserControls
{
    /// <summary>
    /// Interaction logic for RolesUserControl.xaml
    /// </summary>
    public partial class RolesUserControl : UserControl
    {

        string connectionString = ConfigurationManager.ConnectionStrings["AdminDBConnectionString"].ConnectionString;
        public RolesUserControl()
        {
            InitializeComponent();
            txtBoxName.IsEnabled = false;
            string category = selectedCategory.Text;
            FillData();
        }

        private void FillData()
        {
            string selectStoredProcedure = "crud_selectFromRoles";
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
                    int roleID = dataReader.GetInt32(dataReader.GetOrdinal("RoleID"));
                    string roleTitle = dataReader.GetString(dataReader.GetOrdinal("RoleTitle"));
                    titlesDict.Add(roleID, roleTitle);
                }
            }
            else
            {
                Console.WriteLine("No rows found.");
            }
            dataReader.Close();

            comboTitles.ItemsSource = titlesDict;
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
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
        private void BtnSave_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            string storedProcedure = "crud_UpdateRoles";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(storedProcedure, conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@RoleTitle", txtBoxName.Text);
                    cmd.Parameters.AddWithValue("@RoleID", ((KeyValuePair<int, string>)comboTitles.SelectedItem).Key);
                    cmd.Parameters.AddWithValue("@UserModified", "Admin");
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            FillData();
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            string storedProcedure = "crud_deleteRoles";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(storedProcedure, conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@RoleID", ((KeyValuePair<int, string>)comboTitles.SelectedItem).Key);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            FillData();
        }

        private void BtnCreate_Click(object sender, RoutedEventArgs e)
        {
            if (txtBoxNewRole.Text != "")
            {
                string storedProcedure = "crud_InsertApplications";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(storedProcedure, conn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@RoleTitle", txtBoxNewRole.Text);
                        cmd.Parameters.AddWithValue("@UserCreated", "Admin");
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }
                }
                txtBoxNewRole.Text = "";
                FillData();
            }
            else
            {
                MessageBox.Show("Title field is empty!");
            }
        }
    }
}
