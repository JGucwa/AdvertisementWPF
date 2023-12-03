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
    /// Logika interakcji dla klasy Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        MainWindow mainwindow;
        public Register(MainWindow mainwindow)
        {
            InitializeComponent();

            this.mainwindow = mainwindow;
        }
        public void CompanyLogin(object s,RoutedEventArgs e)
        {
            List<Company> list = new Database().GetCompanies();

            if (!string.IsNullOrWhiteSpace(txtCompanyUsername.Text) && !string.IsNullOrWhiteSpace(pwdCompanyPassword.Password))
            {
                
                for (int i=0;i < list.Count;i++)
                {
                    if(txtCompanyUsername.Text.ToLower() == list[i].Name.ToLower() && pwdCompanyPassword.Password == list[i].Password)
                    {
                        mainwindow.CompanyId = list[i].Company_id;
                        break;
                    }
                }

                if(mainwindow.CompanyId == -1)
                {
                    MessageBox.Show("Konto nie istnieje");
                }
                else
                {
                    Close();
                }
            }
            else
            {
                MessageBox.Show("Uzupełnij dane");
            }
        }
        public void CompanyRegister(object s, RoutedEventArgs e)
        {
            new RegisterPage(mainwindow,1).Show();

            this.Close();
        }
        public void UserLogin(object s, RoutedEventArgs e)
        {
            List<User> list = new Database().GetUsers();

            if (!string.IsNullOrWhiteSpace(txtUserUsername.Text) && !string.IsNullOrWhiteSpace(pwdUserPassword.Password))
            {

                for (int i = 0; i < list.Count; i++)
                {
                    if (txtUserUsername.Text.ToLower() == list[i].Email && pwdUserPassword.Password.ToLower() == list[i].Password)
                    {
                        mainwindow.UserId = list[i].User_id;
                        break;
                    }
                }
                if (mainwindow.UserId == -1)
                {
                    MessageBox.Show("Konto nie istnieje");
                }
                else
                {
                    Close();
                }
            }
            else
            {
                MessageBox.Show("Uzupełnij dane");
            }
        }
        public void UserRegister(object s, RoutedEventArgs e)
        {
            new RegisterPage(mainwindow,0).Show();

            this.Close();
        }
    }
}
