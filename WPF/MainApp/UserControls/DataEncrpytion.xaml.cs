using System.Windows.Controls;
using System.Security.Cryptography;
using System.Text;
using System;
using MainApp.AES;

namespace MainApp.UserControls
{
    /// <summary>
    /// Interaction logic for DataEncrpytion.xaml
    /// </summary>
    public partial class DataEncrpytion : UserControl
    {
        //AesCryptoServiceProvider aesCSP = new AesCryptoServiceProvider();
        //ICryptoTransform cryptoTransform;

        SimpleAES AES; 

        public DataEncrpytion()
        {
            InitializeComponent();
            AES = new SimpleAES();
        }

        private void BtnEncrypt_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            txtBoxResultEncrpyt.Text = AES.Encrypt(txtBoxValueEncrypt.Text);
        }

        private void BtnDecrypt_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            txtBoxResultDecrpyt.Text = AES.Decrpyt(txtBoxValueDecrypt.Text);
        }
    }
}
