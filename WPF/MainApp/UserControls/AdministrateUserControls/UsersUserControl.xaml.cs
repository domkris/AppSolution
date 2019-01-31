using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace MainApp.UserControls.AdministrateUserControls
{
    /// <summary>
    /// Interaction logic for UsersUserControl.xaml
    /// </summary>
    public partial class UsersUserControl : UserControl
    {

        string connectionString = ConfigurationManager.ConnectionStrings["AdminDBConnectionString"].ConnectionString;
        public UsersUserControl()
        {
            InitializeComponent();
            txtBoxName.IsEnabled = false;
            passwordBox.IsEnabled = false;
            string category = selectedCategory.Text;

            string selectStoredProcedure = "crud_selectFromUsers";

            List<string> titles = new List<string>();
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
                    titles.Add(dataReader.GetString(1));
                }
            }
            else
            {
                Console.WriteLine("No rows found.");
            }
            dataReader.Close();

            comboTitles.ItemsSource = titles;
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            txtBoxName.IsEnabled = true;
            passwordBox.IsEnabled = true;

        }

        private void ComboTitles_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            txtBoxName.IsEnabled = false;
            passwordBox.IsEnabled = false;
            txtBoxName.Text = comboTitles.SelectedItem.ToString();

        }
        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand($"UPDATE Roles SET RoleTitle = '{txtBoxName.Text}' " +
                                                       $"WHERE RoleTitle = '{comboTitles.SelectedItem}'"))
                {
                    cmd.Connection = conn;
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            //FillData();
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnCreate_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
