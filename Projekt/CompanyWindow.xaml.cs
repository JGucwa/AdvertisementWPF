using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Projekt
{
    /// <summary>
    /// Logika interakcji dla klasy CompanyWindow.xaml
    /// </summary>
    public partial class CompanyWindow : Window
    {
        MainWindow mainwindow;
        Company company;
        public CompanyWindow(MainWindow mainwindow)
        {
            InitializeComponent();

            this.mainwindow = mainwindow;
            
            for(int i = 0; i < new Database().GetCompanies().Count; i++)
            {
                if(mainwindow.CompanyId == new Database().GetCompanies()[i].Company_id)
                {
                    company = new Database().GetCompanies()[i];
                    CompanyContent.DataContext = company;
                }
            }
            for (int i = 0; i < new Database().GetOffers().Count; i++)
            {
                if (mainwindow.CompanyId == new Database().GetOffers()[i].Company_Id)
                {
                    StackPanel panel0 = new StackPanel();
                    panel0.Orientation = Orientation.Horizontal;

                    Border border = new Border()
                    {
                        Width = 800,
                        Height = 100,
                        BorderThickness = new Thickness(0.5),
                        CornerRadius = new CornerRadius(25),
                        BorderBrush = Brushes.DarkBlue,
                        Background = Brushes.White,
                        Margin = new Thickness(10),
                    };
                    DropShadowEffect dropShadowEffect = new DropShadowEffect()
                    {
                        ShadowDepth = 7,
                        Direction = 330,
                        BlurRadius = 4,
                        Opacity = 0.5,
                    };
                    border.Effect = dropShadowEffect;
                    StackPanel panel = new StackPanel();

                    TextBlock title = new TextBlock()
                    {
                        Text = new Database().GetOffers()[i].Title,
                        TextWrapping = TextWrapping.WrapWithOverflow,
                        Margin = new Thickness(10, 10, 100, 0),
                        FontSize = 17,
                        FontWeight = FontWeights.SemiBold,
                    };
                    Button button = new Button()
                    {
                        Margin = new Thickness(300, -30, 0, 0),
                        Width = 140,
                        Height = 30,
                        Content = "Zobacz oferte",
                        Background = Brushes.DarkSlateBlue,
                        Foreground = Brushes.White,
                    };
                    Button delete = new Button()
                    {
                        Margin = new Thickness(300, 10, 0, 0),
                        Width = 140,
                        Height = 30,
                        Content = "Usuń oferte",
                        Background = Brushes.Red,
                        Foreground = Brushes.White,
                    };

                    Offer tmp = new Offer();
                    tmp = new Database().GetOffers()[i];

                    button.Click += (s, e) => { Ofer offer = new Ofer(tmp, mainwindow); offer.Show(); };
                    delete.Click += (s, e) => { new Database().DeleteOffer(tmp); mainwindow.createStartOffer(new Database().GetOffers()); };

                    panel.Children.Add(title);
                    panel.Children.Add(button);
                    panel.Children.Add(delete);
                    border.Child = panel;

                    panel0.Children.Add(border);

                    Offers.Children.Add(panel0);

                }
            }
        }

        private void ChangePass(object s, RoutedEventArgs e)
        {
            new PasswordChange(company).Show();
        }
        private void Logout(object s, RoutedEventArgs e)
        {
            mainwindow.CompanyId = -1;
            MessageBox.Show($"Zostałeś wylogowany");
            Close();
        }

        public async void Change(object s, RoutedEventArgs e)
        {

            if (!string.IsNullOrWhiteSpace(name.Text) && !string.IsNullOrWhiteSpace(localization.Text) && !string.IsNullOrWhiteSpace(description.Text))
            {
                company.Name = name.Text;
                company.Localization = localization.Text;
                company.Description = description.Text;

                new Database().EditCompany(company);

                Close();
            }
            else
            {
                MessageBox.Show($"Błąd danych Prosimy o poprawienie");
            }

        }
    }
}