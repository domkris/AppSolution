using MainApp.AES;
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
        Dictionary<int, string> usernamesDict;
        Dictionary<int, string> passwordsDict;
        SimpleAES AES;
        public UsersUserControl()
        {
            InitializeComponent();
            stackPanelNew.Visibility = Visibility.Hidden;
            txtBoxName.IsEnabled = false;
            passwordBox.IsEnabled = false;
            string category = selectedCategory.Text;
            txtAuto.TextChanged += new TextChangedEventHandler(TxtAuto_TextChanged);
            AES = new SimpleAES();
            FillData();   
        }


        private void FillData()
        {
            usernamesDict = new Dictionary<int, string>();
            passwordsDict = new Dictionary<int, string>();
            string selectStoredProcedure = "crud_selectFromUsers";
            txtBoxName.Text = "";
            passwordBox.Password = "";
            txtAuto.Text = "";


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
                    int userID = dataReader.GetInt32(dataReader.GetOrdinal("UserID"));
                    string username = dataReader.GetString(dataReader.GetOrdinal("Username"));
                    string password = dataReader.GetString(dataReader.GetOrdinal("PasswordHash"));
                    usernamesDict.Add(userID, username);
                    passwordsDict.Add(userID, password);
                }
            }
            else
            {
                Console.WriteLine("No rows found.");
            }
            dataReader.Close();
            
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            txtBoxName.IsEnabled = true;
            passwordBox.IsEnabled = true;

        }

        //private void ComboTitles_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    txtBoxName.IsEnabled = false;
        //    passwordBox.IsEnabled = false;
        //    string password = "";
        //    if (comboTitles.Items.Count > 0 && comboTitles.SelectedItem != null)
        //    {
        //        txtBoxName.Text = ((KeyValuePair<int, string>)comboTitles?.SelectedItem).Value;
        //        int key = ((KeyValuePair<int, string>)comboTitles?.SelectedItem).Key;
        //        if (passwordsDict.TryGetValue(key, out password))
        //        {
        //            passwordBox.Password = password;
        //        }
        //    }

        //}
        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            bool flag = false;
            foreach (var item in usernamesDict.Values)
            {
                if (txtBoxName.Text == item)
                    flag = true;
            }

            if (!flag)
            {
                string storedProcedure = "crud_UpdateUsers";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(storedProcedure, conn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Username", txtBoxName.Text);
                        cmd.Parameters.AddWithValue("@UserID", ((KeyValuePair<int, string>)lbSuggestions.SelectedItem).Key);
                        cmd.Parameters.AddWithValue("@PasswordHash", AES.Encrypt(passwordBox.Password));
                        cmd.Parameters.AddWithValue("@UserModified", "Admin");
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }
                }
                FillData();
            }
            else
            {
                MessageBox.Show("Username taken!");
                
            }
            
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            string storedProcedure = "crud_deleteUsers";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(storedProcedure, conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserID", ((KeyValuePair<int, string>)lbSuggestions.SelectedItem).Key);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            FillData();
        }

        private void BtnCreate_Click(object sender, RoutedEventArgs e)
        {
            bool flag = false;
            foreach (var item in usernamesDict.Values)
            {
                if (txtBoxNewUser.Text == item)
                    flag = true;
            }
            if (!flag)
            {
                stackPanelNew.Visibility = Visibility.Hidden;
                txtBlockCreateNew.Text = "+";
                if (txtBoxNewUser.Text != "" && passwordBoxNewUser.Password != "")
                {
                    string storedProcedure = "crud_InsertUsers";

                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        using (SqlCommand cmd = new SqlCommand(storedProcedure, conn))
                        {
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@Username", txtBoxNewUser.Text);
                            cmd.Parameters.AddWithValue("@PasswordHash", AES.Encrypt(passwordBoxNewUser.Password));
                            cmd.Parameters.AddWithValue("@UserCreated", "Admin");
                            cmd.ExecuteNonQuery();
                            conn.Close();
                        }
                    }
                    txtBoxNewUser.Text = "";
                    passwordBoxNewUser.Password = "";
                    FillData();
                }
                else
                {
                    MessageBox.Show("One field is empty!");
                }
            }
            else
            {
                MessageBox.Show("Username taken!");
            }
           
        }
        private void BtnCreateNew_Click(object sender, RoutedEventArgs e)
        {
            if (txtBlockCreateNew.Text == "-")
            {
                stackPanelNew.Visibility = Visibility.Hidden;
                txtBlockCreateNew.Text = "+";
            }
            else
            {
                stackPanelNew.Visibility = Visibility.Visible;
                txtBlockCreateNew.Text = "-";
            }
        }
        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            stackPanelNew.Visibility = Visibility.Hidden;
            txtBlockCreateNew.Text = "+";
        }

        private void LbSuggestions_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lbSuggestions.ItemsSource != null)
            {
                txtBoxName.IsEnabled = false;
                passwordBox.IsEnabled = false;
                string password = "";

                lbSuggestions.Visibility = Visibility.Collapsed;
                txtAuto.TextChanged -= new TextChangedEventHandler(TxtAuto_TextChanged);
                if (lbSuggestions.SelectedIndex != -1)
                {
                    txtAuto.Text = ((KeyValuePair<int, string>)lbSuggestions?.SelectedItem).Value;

                    txtBoxName.Text = txtAuto.Text;
                    int key = ((KeyValuePair<int, string>)lbSuggestions?.SelectedItem).Key;
                    if (passwordsDict.TryGetValue(key, out password))
                    {
                        passwordBox.Password = password;
                    }
                }
                txtAuto.TextChanged += new TextChangedEventHandler(TxtAuto_TextChanged);
            }
        }

        private void TxtAuto_TextChanged(object sender, TextChangedEventArgs e)
        {
            string typedString = txtAuto.Text;
            Dictionary<int, string> autoList = new Dictionary<int, string>();
            foreach (var item in usernamesDict)
            {
                if (!string.IsNullOrEmpty(txtAuto.Text))
                {
                    if (item.Value.StartsWith(typedString))
                    {
                        autoList.Add(item.Key, item.Value);
                    }
                }
            }
            if (autoList.Count > 0)
            {
                lbSuggestions.ItemsSource = autoList;
                lbSuggestions.Visibility = Visibility.Visible;
            }
            else if (txtAuto.Text == "")
            {
                lbSuggestions.Visibility = Visibility.Collapsed;
                lbSuggestions.ItemsSource = null;
            }
            else
            {
                lbSuggestions.Visibility = Visibility.Collapsed;
                lbSuggestions.ItemsSource = null;
            }
        }
    }
}
