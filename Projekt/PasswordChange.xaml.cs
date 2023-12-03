using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Projekt
{
    /// <summary>
    /// Logika interakcji dla klasy PasswordChange.xaml
    /// </summary>
    public partial class PasswordChange : Window
    {
        User user;
        Company company;
        public PasswordChange(User user)
        {
            this.user = user;
            InitializeComponent();
        }
        public PasswordChange(Company company)
        {
            this.company = company;
            InitializeComponent();
        }
        public void ChangePassword_Click(object sender, RoutedEventArgs e)
        {
            if(user != null)
            {
                if (user.Password == currentPasswordBox.Password && newPasswordBox.Password.Length > 7)
                {
                    user.Password = newPasswordBox.Password;
                    new Database().EditUser(user);

                    MessageBox.Show($"Hasło zostało zmienione");

                    Close();
                }
                else
                {
                    MessageBox.Show($"Dane się nie zgadzają");

                    currentPasswordBox.Password = newPasswordBox.Password = String.Empty;
                }
            }
            else
            {
                if (company.Password == currentPasswordBox.Password && newPasswordBox.Password.Length > 7)
                {
                    company.Password = newPasswordBox.Password;
                    new Database().EditCompany(company);

                    MessageBox.Show($"Hasło zostało zmienione");

                    Close();
                }
                else
                {
                    MessageBox.Show($"Dane się nie zgadzają");

                    currentPasswordBox.Password = newPasswordBox.Password = String.Empty;
                }
            }
            
        }
    }
}
