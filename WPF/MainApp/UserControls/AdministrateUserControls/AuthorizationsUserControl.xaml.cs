using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace MainApp.UserControls.AdministrateUserControls
{
    /// <summary>
    /// Interaction logic for AuthorizationsUserControl.xaml
    /// </summary>
    public partial class AuthorizationsUserControl : UserControl
    {
        string connectionString = ConfigurationManager.ConnectionStrings["AdminDBConnectionString"].ConnectionString;

        public AuthorizationsUserControl()
        {
            InitializeComponent();
            txtBoxName.IsEnabled = false;
            string category = selectedCategory.Text;
            FillData();
 
        }

        private void FillData()
        {
            string selectStoredProcedure = "crud_selectFromAuthorizations";
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
                    int authID = dataReader.GetInt32(dataReader.GetOrdinal("AuthorizationID"));
                    string authTitle = dataReader.GetString(dataReader.GetOrdinal("AuthorizationTitle"));
                    titlesDict.Add(authID, authTitle);
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
            string storedProcedure = "crud_UpdateAuthorizations";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(storedProcedure, conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@AuthorizationTitle", txtBoxName.Text);
                    cmd.Parameters.AddWithValue("@AuthorizationID", ((KeyValuePair<int, string>)comboTitles.SelectedItem).Key);
                    cmd.Parameters.AddWithValue("@UserModified", "Admin");
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            FillData();
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            string storedProcedure = "crud_deleteAuthorizations";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(storedProcedure, conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@AuthorizationID", ((KeyValuePair<int, string>)comboTitles.SelectedItem).Key);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            FillData();
        }

        private void BtnCreate_Click(object sender, RoutedEventArgs e)
        {
            if (txtBoxNewAuthorization.Text != "")
            {
                string storedProcedure = "crud_InsertApplications";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(storedProcedure, conn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@AuthorizationTitle", txtBoxNewAuthorization.Text);
                        cmd.Parameters.AddWithValue("@UserCreated", "Admin");
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }
                }
                txtBoxNewAuthorization.Text = "";
                FillData();
            }
            else
            {
                MessageBox.Show("Title field is empty!");
            }
        }
    }
}
