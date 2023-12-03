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