using MainApp.Helpers;
using MainApp.UserControls.AdministrateUserControls;
using Microsoft.SqlServer.Management.Smo;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Controls;
using System.Windows.Data;

namespace MainApp.UserControls
{
    /// <summary>
    /// Interaction logic for AdministrateUserRightsuserControl.xaml
    /// </summary>
    public partial class AdministrateUserRightsUserControl : UserControl
    {
        public AdministrateUserRightsUserControl()
        {
            InitializeComponent();
            listOfCategories.Items.Add("Applications");
            listOfCategories.Items.Add("Roles");
            listOfCategories.Items.Add("Authorizations");
            listOfCategories.Items.Add("Users");
            
           
        }

        private void ListOfCategories_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            string category = listOfCategories.SelectedItem.ToString();

            RemoveAdministrateUserControls();
            UserControl userControl = null;

            switch (category)
            {
                case "Applications":
                    userControl = new ApplicationsUserControl();
                    break;
                case "Roles":
                    userControl = new RolesUserControl();
                    break;
                case "Authorizations":
                    userControl = new AuthorizationsUserControl();
                    break;
                case "Users":
                    userControl = new UsersUserControl();
                    break;
                default:
                    break;
            }
            AdministrateUserControlsPanel.Children.Add(userControl);
    
        }
        private void RemoveAdministrateUserControls()
        {
            int indice = 0;
            int children = AdministrateUserControlsPanel.Children.Count;
            for (int i = 0; i < children; i++)
            {
                if (AdministrateUserControlsPanel.Children[indice] is UserControl uc)
                {
                    AdministrateUserControlsPanel.Children.Remove(uc);
                }
                else
                {
                    indice++;
                }
            }
        }
    }
}
