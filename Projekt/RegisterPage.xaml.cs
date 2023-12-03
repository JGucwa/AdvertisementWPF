using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Logika interakcji dla klasy RegisterPage.xaml
    /// </summary>
    public partial class RegisterPage : Window
    {
        MainWindow mainwindow;
        int mode = -1;
        public RegisterPage(MainWindow mainwindow,int mode)
        {
            this.mainwindow = mainwindow;
            this.mode = mode;

            InitializeComponent();

            if (mode == 0)
            {
                name.Content = "Email";
            }
            else
            {
                name.Content = "Nazwa Firmy";
            }
        }
        public void Register(object s, RoutedEventArgs e)
        {
            if(mode == 1)
            {
                List<Company> list = new Database().GetCompanies();

                if (!string.IsNullOrWhiteSpace(txtUsername.Text) && !string.IsNullOrWhiteSpace(pwdPassword.Password) && !string.IsNullOrWhiteSpace(pwdPassword2.Password) && pwdPassword2.Password == pwdPassword.Password && pwdPassword.Password.Length > 7)
                {
                    for (int i = 0; i < list.Count; i++)
                    {
                        if (txtUsername.Text == list[i].Name)
                        {
                            MessageBox.Show("Konto istnieje");
                        }
                    }
                    new Database().AddCompany(new Company() { Name = txtUsername.Text, Password = pwdPassword.Password });

                    MessageBox.Show("Konto utworzone");


                    list = new Database().GetCompanies();

                    mainwindow.CompanyId = list[list.Count - 1].Company_id;

                    Close();
                }
                else
                {
                    MessageBox.Show("Uzupełnij poprawnie dane");
                }
            }
            else
            {
                string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

                List<User> list = new Database().GetUsers();

                if (!string.IsNullOrWhiteSpace(txtUsername.Text) && !string.IsNullOrWhiteSpace(pwdPassword.Password) && !string.IsNullOrWhiteSpace(pwdPassword2.Password) && pwdPassword2.Password == pwdPassword.Password && pwdPassword.Password.Length > 7 && Regex.IsMatch(txtUsername.Text, pattern))
                {
                    for (int i = 0; i < list.Count; i++)
                    {
                        if (txtUsername.Text == list[i].Email && pwdPassword.Password == list[i].Password)
                        {
                            MessageBox.Show("Konto istnieje");
                        }
                    }
                    new Database().AddUser(new User() { Email = txtUsername.Text, Password = pwdPassword.Password });

                    MessageBox.Show("Konto utworzone");


                    list = new Database().GetUsers();

                    mainwindow.UserId = list[list.Count - 1].User_id;

                    Close();
                }
                else
                {
                    MessageBox.Show("Uzupełnij poprawnie dane");
                }
            }
            
        }
    }
}
