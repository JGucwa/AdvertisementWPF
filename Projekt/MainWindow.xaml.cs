using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Projekt
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int UserId = -1;
        public int CompanyId = -1;
        Database DB = new Database();

        List<Offer> lst = new List<Offer>();
        public MainWindow()
        {
            InitializeComponent();

            /*Przykladowe dane
            DB.AddCategory(new Category() { Name = "IT" });
            DB.AddCategory(new Category() { Name = "Finanse" });
            DB.AddCategory(new Category() { Name = "Marketing" });
            DB.AddCategory(new Category() { Name = "Inżynieria" });
            DB.AddCategory(new Category() { Name = "Medycyna" });
            DB.AddCategory(new Category() { Name = "Edukacja" });
            DB.AddCategory(new Category() { Name = "Sztuka i Rozrywka" });
            DB.AddCategory(new Category() { Name = "Handel" });
            DB.AddCategory(new Category() { Name = "Prawo" });
            DB.AddCategory(new Category() { Name = "Nauki Społeczne" });
            DB.AddCategory(new Category() { Name = "Budownictwo" });
            DB.AddOffer(new Offer()
            {
                Description = "Zapraszamy do doświadczonego zespołu IT!",
                Title = "Architekt Systemów",
                Company_Id = 0,
                Position_name = "Cloud Solutions Architect",
                Position_level = "ekspert",
                Type_of_contract = "umowa o pracę na czas nieokreślony",
                Employment = "pełny etat",
                Type_of_Job = "praca zdalna",
                Salary = "9000-12000",
                Days = "poniedziałek-piątek",
                Hours = "9:00-17:30",
                Category = "IT",
                Duties = new List<string> { "Projektowanie i implementacja rozwiązań chmurowych", "Zarządzanie infrastrukturą chmurową", "Współpraca z klientami w zakresie architektury IT" },
                Requirements = new List<string> { "Doświadczenie w roli Architekta Systemów", "Znajomość platformy chmurowej AWS", "Certyfikat AWS Certified Solutions Architect" },
                Benefits = new List<string> { "Elastyczny czas pracy", "Premie za osiągnięcia", "Karta lunchowa", "Pakiet socjalny" },
                Application_Count = 0
            });
            DB.AddOffer(new Offer
            {
                Description = "Dynamiczna firma IT poszukuje programisty do zespołu!",
                Title = "Programista Java - Junior",
                Company_Id = 0,
                Position_name = "Java Developer",
                Position_level = "junior",
                Type_of_contract = "umowa o pracę na czas nieokreślony",
                Employment = "pełny etat",
                Type_of_Job = "praca stacjonarna",
                Salary = "5000-7000",
                Days = "poniedziałek-piątek",
                Hours = "8:00-16:00",
                Category = "IT",
                Duties = new List<string> { "Rozwój aplikacji w języku Java", "Testowanie i utrzymanie oprogramowania", "Współpraca z zespołem programistycznym" },
                Requirements = new List<string> { "Znajomość języka Java", "Podstawowa wiedza z zakresu programowania", "Chęć rozwoju w obszarze IT" },
                Benefits = new List<string> { "Dofinansowanie do kursów", "Elastyczne godziny pracy", "Opieka medyczna", "Integracje firmowe" },
                Application_Count = 0
            });

            DB.AddOffer(new Offer
            {
                Description = "Innowacyjna firma IT poszukuje specjalisty ds. baz danych!",
                Title = "Administrator baz danych - SQL",
                Company_Id = 0,
                Position_name = "Database Administrator",
                Position_level = "średniozaawansowany",
                Type_of_contract = "umowa o pracę na czas określony",
                Employment = "pełny etat",
                Type_of_Job = "praca hybrydowa",
                Salary = "6500-8500",
                Days = "poniedziałek-piątek",
                Hours = "9:00-17:30",
                Category = "IT",
                Duties = new List<string> { "Administrowanie bazami danych", "Optymalizacja i monitorowanie wydajności", "Wsparcie w zakresie problemów z bazą danych" },
                Requirements = new List<string> { "Doświadczenie w administrowaniu bazami danych SQL", "Znajomość języka SQL", "Dobra organizacja pracy" },
                Benefits = new List<string> { "Prywatna opieka zdrowotna", "Szkolenia branżowe", "Karta multisport", "Premie za wyniki" },
                Application_Count = 0
            });
            DB.AddOffer(new Offer
            {
                Description = "Międzynarodowy bank poszukuje doświadczonego analityka finansowego!",
                Title = "Analityk Finansowy",
                Company_Id = -1,
                Position_name = "Analityk Finansowy",
                Position_level = "średniozaawansowany",
                Type_of_contract = "umowa o pracę na czas nieokreślony",
                Employment = "pełny etat",
                Type_of_Job = "praca stacjonarna",
                Salary = "8000-10000",
                Days = "poniedziałek-piątek",
                Hours = "9:00-17:00",
                Category = "Finanse",
                Duties = new List<string> { "Analiza danych finansowych", "Przygotowywanie raportów i prognoz finansowych", "Współpraca z zespołem księgowym" },
                Requirements = new List<string> { "Doświadczenie w analizie finansowej", "Znajomość rachunkowości", "Dobra znajomość Excela" },
                Benefits = new List<string> { "Opieka medyczna", "Karta multisport", "Premie za wyniki", "Dofinansowanie do szkoleń" },
                Application_Count = 7
            });

            DB.AddOffer(new Offer
            {
                Description = "Dynamiczna agencja marketingowa poszukuje kreatywnego copywritera!",
                Title = "Copywriter",
                Company_Id = -1,
                Position_name = "Copywriter",
                Position_level = "junior",
                Type_of_contract = "umowa o pracę na czas określony",
                Employment = "pełny etat",
                Type_of_Job = "praca hybrydowa",
                Salary = "5500-7000",
                Days = "poniedziałek-piątek",
                Hours = "8:30-16:30",
                Category = "Marketing",
                Duties = new List<string> { "Tworzenie treści reklamowych i marketingowych", "Przygotowywanie tekstów na strony internetowe", "Współpraca z zespołem kreatywnym" },
                Requirements = new List<string> { "Znajomość technik copywritingu", "Kreatywność i zdolności redakcyjne", "Podstawowa wiedza z zakresu marketingu" },
                Benefits = new List<string> { "Elastyczne godziny pracy", "Home office", "Dofinansowanie do kursów językowych", "Integracje firmowe" },
                Application_Count = 4
            });

            DB.AddOffer(new Offer
            {
                Description = "Prężna szkoła językowa poszukuje nauczyciela angielskiego!",
                Title = "Nauczyciel Języka Angielskiego",
                Company_Id = -1,
                Position_name = "Nauczyciel",
                Position_level = "średniozaawansowany",
                Type_of_contract = "umowa o pracę na czas nieokreślony",
                Employment = "pełny etat",
                Type_of_Job = "praca stacjonarna",
                Salary = "6000-8000",
                Days = "poniedziałek-piątek",
                Hours = "10:00-18:00",
                Category = "Edukacja",
                Duties = new List<string> { "Nauczanie języka angielskiego", "Przygotowywanie lekcji i materiałów dydaktycznych", "Współpraca z uczniami i rodzicami" },
                Requirements = new List<string> { "Biegła znajomość języka angielskiego", "Doświadczenie w nauczaniu", "Dyplom pedagogiczny lub filologiczny" },
                Benefits = new List<string> { "Dofinansowanie do kursów językowych", "Pakiet socjalny", "Opieka medyczna", "Wakacje szkoleniowe" },
                Application_Count = 6
            });

            DB.AddCompany(new Company() { Name = "I&P",Password = "12345678" }); */

            OffertsCount.Content = DB.GetOffers().Count;

            List<Category> Categories = new Database().GetCategory();

            for (int i = 0; i < Categories.Count; i++)
            {
                ComboBoxItem comboBoxItem = new ComboBoxItem()
                {
                    FontSize = 20,
                    HorizontalContentAlignment = HorizontalAlignment.Center,
                    VerticalContentAlignment = VerticalAlignment.Center,
                    Content = Categories[i].Name,
                };

                Category.Items.Add(comboBoxItem);
            }

            createStartOffer(DB.GetOffers());
        }

        private void OpenAccount(object s,RoutedEventArgs e)
        {
            if(UserId == -1 && CompanyId == -1)
            {
                new Register(this).Show();
            }
            else
            {
                if(UserId != -1)
                {
                    new UserWindow(this).Show();
                }
                if (CompanyId != -1)
                {
                    new CompanyWindow(this).Show();
                }
            }
        }
        private void AddOfffer(object s, RoutedEventArgs e)
        {
            if(CompanyId != -1)
            {
                new AddOffer(this).Show();
            }
            else
            {
                MessageBox.Show("Zaloguj sie jako firma");
            }
        }
        private void Filter(object s,RoutedEventArgs e)
        {
            List<Offer> offers = DB.GetOffers();
            List<Offer> tmp = new List<Offer>();

            for(int i = 0; i < offers.Count;i++)
            {
                if(Category.Text != "Kategoria")
                {
                    if (offers[i].Category == Category.Text)
                    {
                        if(offers[i].Title.ToLower().Contains(KeyWord.Text.ToLower()))
                        {
                            tmp.Add(offers[i]);
                        }
                    }                   
                }
                else
                {
                    if (offers[i].Title.ToLower().Contains(KeyWord.Text.ToLower()))
                    {
                        tmp.Add(offers[i]);
                    }
                }
            }

            createStartOffer(tmp);
        }
        public void createStartOffer(List<Offer> OfferList)
        {
            Offers.Children.Clear();
            int icount = OfferList.Count/3;
            int count = 0;
            if(OfferList.Count > 0) 
            {
                for (int i = 0; i < icount + 1 && i < 10; i++)
                {
                    StackPanel panel0 = new StackPanel();
                    panel0.Orientation = Orientation.Horizontal;
                    for (int j = 0; j < 3; j++)
                    {
                        Border border = new Border();
                        border.Width = 400;
                        border.Height = 200;
                        border.BorderThickness = new Thickness(0.5);
                        border.CornerRadius = new CornerRadius(25);
                        border.BorderBrush = Brushes.DarkBlue;
                        border.Background = Brushes.White;
                        border.Margin = new Thickness(10);
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
                            Text = OfferList[count].Title,
                            TextWrapping = TextWrapping.WrapWithOverflow,
                            Margin = new Thickness(10, 10, 100, 0),
                            FontSize = 17,
                            FontWeight = FontWeights.SemiBold,
                        };
                        TextBlock salary = new TextBlock()
                        {
                            Text = OfferList[count].Salary + " zł",
                            TextWrapping = TextWrapping.WrapWithOverflow,
                            Margin = new Thickness(10, 10, 50, 0),
                            FontSize = 17,
                            Foreground = Brushes.Gray,
                            FontWeight = FontWeights.Thin,
                        };
                        StackPanel panel2 = new StackPanel();
                        Image image = new Image()
                        {
                            Width = 130,
                            Height = 90,
                            Margin = new Thickness(10),
                        };
                        TextBlock companyinfo = new TextBlock()
                        {
                            Text = OfferList[count].Description,
                            TextWrapping = TextWrapping.WrapWithOverflow,
                            Margin = new Thickness(10, 10, 50, 0),
                            Width = 230,
                            FontSize = 17,
                            FontWeight = FontWeights.Thin,
                        };
                        Button button = new Button()
                        {
                            Margin = new Thickness(0, -10, 0, 0),
                            Width = 140,
                            Height = 30,
                            Content = "Zobacz oferte",
                            Background = Brushes.DarkSlateBlue,
                            Foreground = Brushes.White,
                        };

                        Offer tmp = new Offer();
                        tmp = OfferList[count];

                        button.Click += (s, e) => { Ofer offer = new Ofer(tmp, this); offer.Show(); };
                        panel2.Orientation = Orientation.Horizontal;
                        panel2.Children.Add(image);
                        panel2.Children.Add(companyinfo);
                        panel.Children.Add(title);
                        panel.Children.Add(salary);
                        panel.Children.Add(panel2);
                        panel.Children.Add(button);
                        border.Child = panel;

                        panel0.Children.Add(border);

                        if (count == OfferList.Count - 1) { break; }
                        count++;

                    }
                    Offers.Children.Add(panel0);
                }
            }
            else
            {
                TextBlock error = new TextBlock()
                {
                    Text = "Przepraszamy brak ofert",
                    HorizontalAlignment = HorizontalAlignment.Center,
                    FontSize = 30,
                    FontWeight = FontWeights.SemiBold,
                };
                Offers.Children.Add(error);
            }
        }
    }
}

/*
 * <Border Width="400" Height="200" BorderBrush="DarkBlue" BorderThickness="0.5" CornerRadius="25" Background="White">
                    <StackPanel>
                        <TextBlock Text="Sprzedawca - kASJER i wITA Stwosza 48 (Mokotów)" TextWrapping="WrapWithOverflow" Margin="10,10,100,0" FontSize="17" FontWeight="SemiBold" Foreground="DarkBlue"/>
                        <TextBlock Text="4 400-4 700 zł brutto /mies" TextWrapping="WrapWithOverflow" Margin="10,0,50,0" FontSize="17" FontWeight="Thin" Foreground="Gray"/>
                        <StackPanel Orientation="Horizontal">
                            <Image Width="130" Height="90" Margin="10"/>
                            <TextBlock Text="Jeronimo Martins takie pierdolenie o nawei firmy wystawiajcej ogloszenie" TextWrapping="WrapWithOverflow" Margin="10,10,50,0" Width="230" FontSize="17" FontWeight="Thin" Foreground="Gray"/>
                        </StackPanel>
                    </StackPanel>
                    
                    <Border.Effect>
                        <DropShadowEffect ShadowDepth="7" Direction="330" Color="WhiteSmoke" BlurRadius="4" Opacity="0.5"/>
                    </Border.Effect>
                </Border>
*/