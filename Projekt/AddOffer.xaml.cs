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
    /// Logika interakcji dla klasy AddOffer.xaml
    /// </summary>
    public partial class AddOffer : Window
    {
        
        MainWindow mainwindow;
        List<string> ReqList = new List<string>();
        List<TextBox> ReqListTB = new List<TextBox>();
        List<string> DutList = new List<string>();
        List<TextBox> DutListTB = new List<TextBox>();
        List<string> BenList = new List<string>();
        List<TextBox> BenListTB = new List<TextBox>();
        public AddOffer(MainWindow mainwindow)
        {
            this.mainwindow = mainwindow;
            InitializeComponent();

            ReqListTB.Add(req0);
            DutListTB.Add(dut0);
            BenListTB.Add(ben0);
            List<Category> Categories = new Database().GetCategory();

            for(int i = 0;i < Categories.Count; i++)
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

            ReqListTB.Add(req0);
            DutListTB.Add(dut0);
            BenListTB.Add(ben0);
        }
        public void RequirmentAdd(object s, RoutedEventArgs e)
        {
            TextBox reqtmp = new TextBox()
            {
                FontSize = 18,
                Width = 300,
                Height = 40,
                TextWrapping = TextWrapping.Wrap,
                AcceptsReturn = true,
                VerticalScrollBarVisibility = ScrollBarVisibility.Auto,
                HorizontalScrollBarVisibility = ScrollBarVisibility.Auto,
                VerticalContentAlignment = VerticalAlignment.Center,
                Margin = new Thickness(0, 5, 0, 0),
            };

            ReqListTB.Add(reqtmp);

            requirments.Children.Remove(addbtn0);
            requirments.Children.Add(reqtmp);
            requirments.Children.Add(addbtn0);
        }
        public void DutiesAdd(object s, RoutedEventArgs e)
        {
            TextBox duttmp = new TextBox()
            {
                FontSize = 18,
                Width = 300,
                Height = 40,
                TextWrapping = TextWrapping.Wrap,
                AcceptsReturn = true,
                VerticalScrollBarVisibility = ScrollBarVisibility.Auto,
                HorizontalScrollBarVisibility = ScrollBarVisibility.Auto,
                VerticalContentAlignment = VerticalAlignment.Center,
                Margin = new Thickness(0, 5, 0, 0),
            };

            DutListTB.Add(duttmp);

            duties.Children.Remove(addbtn1);
            duties.Children.Add(duttmp);
            duties.Children.Add(addbtn1);
        }
        public void BenefitsAdd(object s, RoutedEventArgs e)
        {
            TextBox bentmp = new TextBox()
            {
                FontSize = 18,
                Width = 300,
                Height = 40,
                TextWrapping = TextWrapping.Wrap,
                AcceptsReturn = true,
                VerticalScrollBarVisibility = ScrollBarVisibility.Auto,
                HorizontalScrollBarVisibility = ScrollBarVisibility.Auto,
                VerticalContentAlignment = VerticalAlignment.Center,
                Margin = new Thickness(0, 5, 0, 0),
            };

            BenListTB.Add(bentmp);

            benefits.Children.Remove(addbtn2);
            benefits.Children.Add(bentmp);
            benefits.Children.Add(addbtn2);
        }
        public async void SubmitOffer(object s, RoutedEventArgs e)
        {
            Offer oo = new Offer();

            if(!string.IsNullOrWhiteSpace(Category.Text) && !string.IsNullOrWhiteSpace(description.Text) && !string.IsNullOrWhiteSpace(TitleTextBox.Text) &&
               !string.IsNullOrWhiteSpace(Position_name.Text) && !string.IsNullOrWhiteSpace(Position_level.Text) && !string.IsNullOrWhiteSpace(TypeofContract.Text) &&
               !string.IsNullOrWhiteSpace(Employment.Text) && !string.IsNullOrWhiteSpace(TypeofJob.Text) && !string.IsNullOrWhiteSpace(myTimePickerFrom.Text) &&
               !string.IsNullOrWhiteSpace(myTimePickerTo.Text) && ReqListTB.Count > 0 && DutListTB.Count > 0 && BenListTB.Count > 0)
            {
                oo.Company_Id = mainwindow.CompanyId;
                oo.Category = Category.Text;
                oo.Description = description.Text;
                oo.Salary = SalaryFrom.Text + " - " + SalaryTo.Text;
                oo.Title = TitleTextBox.Text;
                oo.Position_name = Position_name.Text;
                oo.Position_level = Position_level.Text;
                oo.Type_of_contract = TypeofContract.Text;
                oo.Employment = Employment.Text;
                oo.Type_of_Job = TypeofJob.Text;
                if (Pn.IsChecked == true) oo.Days += "Pn,";
                if (Wt.IsChecked == true) oo.Days += "Wt,";
                if (Sr.IsChecked == true) oo.Days += "Sr,";
                if (Czw.IsChecked == true) oo.Days += "Czw,";
                if (Pt.IsChecked == true) oo.Days += "Pt,";
                if (Sob.IsChecked == true) oo.Days += "Sob,";
                oo.Hours = myTimePickerFrom.Text + " - " + myTimePickerTo.Text;
                oo.Expired = expired.SelectedDate ?? DateTime.MinValue;
                for (int i = 0; i < ReqListTB.Count; i++)
                {
                    ReqList.Add(ReqListTB[i].Text);
                }
                for (int i = 0; i < DutListTB.Count; i++)
                {
                    DutList.Add(DutListTB[i].Text);
                }
                for (int i = 0; i < BenListTB.Count; i++)
                {
                    BenList.Add(BenListTB[i].Text);
                }
                oo.Duties = DutList;
                oo.Requirements = ReqList;
                oo.Benefits = BenList;
                oo.Application_Count = 0;

                new Database().AddOffer(oo);

                mainwindow.createStartOffer(new Database().GetOffers());

                Close();
            }
            else
            {
                MessageBox.Show($"Błąd danych Prosimy o poprawienie");
            }
            
        }
    }
}
