using System.Windows.Controls;
using System.Security.Cryptography;
using System.Text;
using System;

namespace MainApp.UserControls
{
    /// <summary>
    /// Interaction logic for DataEncrpytion.xaml
    /// </summary>
    public partial class DataEncrpytion : UserControl
    {
        AesCryptoServiceProvider aesCSP = new AesCryptoServiceProvider();
        ICryptoTransform cryptoTransform;

        public DataEncrpytion()
        {
            InitializeComponent();
        }

        private void BtnEncrypt_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            cryptoTransform = aesCSP.CreateEncryptor();
            byte[] bytes = Encoding.Unicode.GetBytes(txtBoxValueEncrypt.Text);
            byte[] encryptedBytes = cryptoTransform.TransformFinalBlock(bytes,0, bytes.Length);

            txtBoxResultEncrpyt.Text = BitConverter.ToString(encryptedBytes).Replace("-","");
        }

        private void BtnDecrypt_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            cryptoTransform = aesCSP.CreateDecryptor();
            byte[] raw = new byte[txtBoxValueDecrypt.Text.Length / 2];

            for (var i = 0; i < raw.Length; i++)
            {
                raw[i] = Convert.ToByte(txtBoxValueDecrypt.Text.Substring(i * 2, 2), 16);
            }
            byte[] decryptedBytes = cryptoTransform.TransformFinalBlock(raw, 0, raw.Length);

            txtBoxResultDecrpyt.Text = Encoding.Unicode.GetString(decryptedBytes);
        }
    }
}
