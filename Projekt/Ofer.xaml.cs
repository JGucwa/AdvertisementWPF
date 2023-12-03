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
    /// Logika interakcji dla klasy Ofer.xaml
    /// </summary>
    public partial class Ofer : Window
    {
        MainWindow mainwindow;

        Offer offer;
        public Ofer(Offer offer, MainWindow mainwindow)
        {
            InitializeComponent();

            this.mainwindow = mainwindow;
            this.offer = offer;
            /*
            Offer oo = new Offer();

            oo.Description = "Jeronimo Martins takie pierdolenie o nawei firmy wystawiajcej ogloszenie";
            oo.Salary = "4 400-4 700 zł brutto /mies";
            oo.Title = "Sprzedawca - kASJER i wITA Stwosza 48 (Mokotów)";
            oo.Company_Id = 0;
            oo.Position_name = "Programista";
            oo.Position_level = "specjalista";
            oo.Type_of_contract = "umowa o prace";
            oo.Employment = "pelny etat";
            oo.Type_of_Job = "praca mobilna";
            oo.Salary = "5000-10000";
            oo.Days = "pn-pt";
            oo.Hours = "7:00-15:30";
            //oo.Expired = "wazna 6 dni";
            oo.Duties = new List<string>() {"Praca od 6:00-23:00","Brak","Praca za miskę ryżu","Skłonności saddystyczne" };
            oo.Requirements = new List<string>() { "Biały odcień skóry", ">180cm", "20cm", "Wkład własny 3 morgi bawełny", "Prawo jazdy kategorii S P I E R D A L A J", "Wkład własny 3 morgi bawełny" };
            oo.Benefits = new List<string>() { "Owocowe czwartki", "3 dni w gułagu", "Transport \"Furmanką\"", "3 niewolnikow","300gram Marichuany miesięcznie" };
            oo.Application_Count = 10;

            Company company = new Company();
            company.Name = "CD PROJECT BLACK";
            company.Localization = "Warszawa";

            */

            List<Company> list = new Database().GetCompanies();

            for(int i = 0;i < list.Count;i++)
            {
                if(offer.Company_Id == list[i].Company_id)
                {
                    Logo.DataContext = list[i].Company_id;
                    CompanyName.DataContext = list[i].Company_id;
                }
            }
            Offer.DataContext = offer;

            ShowLists(offer);
        }
        private void Apply(object s,RoutedEventArgs e)
        {
            if(mainwindow.UserId != -1)
            {
                bool sendOffer = false;
                for(int i = 0; i < offer.Applications.Count;i++)
                {
                    if (offer.Applications[i] == mainwindow.UserId)
                    {
                        MessageBox.Show("Twoje zgłoszenie już zostało wysłane wcześniej");
                        sendOffer = true;
                    }
                }
                if(!sendOffer)
                {
                    List<Offer> tmp = new Database().GetOffers();

                    for (int i = 0; i < tmp.Count; i++)
                    {
                        if (tmp[i].Offer_id == offer.Offer_id)
                        {
                            if (tmp[i].Applications == null) tmp[i].Applications = new List<int>();
                            tmp[i].Applications.Add(mainwindow.UserId);
                            tmp[i].Application_Count = tmp[i].Applications.Count;

                            new Database().UpdateOffer(tmp[i]);

                            MessageBox.Show("Twoje zgłoszenie zostało wysłane");

                            mainwindow.createStartOffer(new Database().GetOffers());

                            Close();

                            break;
                        }
                    }
                }
                
                
            }
            else
            {
                MessageBox.Show("Najpierw się zaloguj");
            }
            
        }
        private void ShowLists(Offer offer)
        {
            StackPanel req = new StackPanel();
            for (int i = 0; i < offer.Requirements.Count;i++)
            {
                StackPanel sp = new StackPanel();
                sp.Margin = new Thickness(0, 20, 0, 0);
                sp.Orientation = Orientation.Horizontal;

                Image image = new Image()
                {
                    Width = 30,
                    Height = 30,
                };

                TextBlock textBlock = new TextBlock()
                {
                    Text = "> " + offer.Requirements[i],
                    FontSize = 15,
                };

                sp.Children.Add(image);
                sp.Children.Add(textBlock);
                req.Children.Add(sp);
            }
            Requierments.Child = req;
            StackPanel dut = new StackPanel();
            for (int i = 0; i < offer.Duties.Count; i++)
            {
                StackPanel sp = new StackPanel();
                sp.Margin = new Thickness(0, 20, 0, 0);
                sp.Orientation = Orientation.Horizontal;

                Image image = new Image()
                {
                    Width = 30,
                    Height = 30,
                };

                TextBlock textBlock = new TextBlock()
                {
                    Text = "> " + offer.Duties[i],
                    FontSize = 15,
                };

                sp.Children.Add(image);
                sp.Children.Add(textBlock);
                dut.Children.Add(sp);
            }
            Duties.Child = dut;
            StackPanel ben = new StackPanel();
            for (int i = 0; i < offer.Benefits.Count; i++)
            {
                StackPanel sp = new StackPanel();
                sp.Margin = new Thickness(0, 20, 0, 0);
                sp.Orientation = Orientation.Horizontal;

                Image image = new Image()
                {
                    Width = 30,
                    Height = 30,
                };

                TextBlock textBlock = new TextBlock()
                {
                    Text = "> " + offer.Benefits[i],
                    FontSize = 15,
                };

                sp.Children.Add(image);
                sp.Children.Add(textBlock);
                ben.Children.Add(sp);
            }
            Benefits.Child = ben;
        }
    }
}
