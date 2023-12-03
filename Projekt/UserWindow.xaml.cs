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
    /// Logika interakcji dla klasy UserWindow.xaml
    /// </summary>
    public partial class UserWindow : Window
    {
        MainWindow mainwindow;
        User user;
        List<string> ExpList = new List<string>();
        List<TextBox> ExpListTB = new List<TextBox>();
        List<string> EduList = new List<string>();
        List<TextBox> EduListTB = new List<TextBox>();
        List<string> LanList = new List<string>();
        List<TextBox> LanListTB = new List<TextBox>();
        List<string> SklList = new List<string>();
        List<TextBox> SklListTB = new List<TextBox>();
        List<string> CurList = new List<string>();
        List<TextBox> CurListTB = new List<TextBox>();
        List<string> LnkList = new List<string>();
        List<TextBox> LnkListTB = new List<TextBox>();
        public UserWindow(MainWindow mainwindow)
        {
            InitializeComponent();

            this.mainwindow = mainwindow;
            for (int i = 0; i < new Database().GetUsers().Count; i++)
            {
                if(mainwindow.UserId == new Database().GetUsers()[i].User_id)
                {
                    user = new Database().GetUsers()[i];
                    UserContent.DataContext = user; 
                }
            }
            if (user.Experience == null) { user.Experience = new List<string>(); } else { ExpListTB.Add(exp0); }
            if (user.Education == null){ user.Education = new List<string>();} else { EduListTB.Add(edu0); }
            if (user.Languages == null){ user.Languages = new List<string>();} else { LanListTB.Add(lan0); }
            if (user.Skills == null){ user.Skills = new List<string>();} else { SklListTB.Add(skl0); }
            if (user.Courses == null){ user.Courses = new List<string>();} else { CurListTB.Add(cur0); }
            if (user.Links == null){ user.Links = new List<string>();} else { LnkListTB.Add(lnk0); }
            if (user.Experience.Count > 0)
            {
                experience.Children.Remove(exp0);
            }
            for (int i = 0; i < user.Experience.Count; i++)
            {
                TextBox exptmp = new TextBox()
                {
                    Text = user.Experience[i],
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

                ExpListTB.Add(exptmp);

                experience.Children.Remove(addbtn0);
                experience.Children.Add(exptmp);
                experience.Children.Add(addbtn0);
            }
            if (user.Education.Count > 0)
            {
                education.Children.Remove(edu0);
            }
            for (int i = 0; i < user.Education.Count; i++)
            {
                TextBox edutmp = new TextBox()
                {
                    Text = user.Education[i],
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

                ExpListTB.Add(edutmp);

                education.Children.Remove(addbtn1);
                education.Children.Add(edutmp);
                education.Children.Add(addbtn1);
            }
            if (user.Languages.Count > 0)
            {
                languages.Children.Remove(lan0);
            }
            for (int i = 0; i < user.Languages.Count; i++)
            {
                TextBox lantmp = new TextBox()
                {
                    Text = user.Languages[i],
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

                ExpListTB.Add(lantmp);

                languages.Children.Remove(addbtn2);
                languages.Children.Add(lantmp);
                languages.Children.Add(addbtn2);
            }
            if (user.Skills.Count > 0)
            {
                skills.Children.Remove(skl0);
            }
            for (int i = 0; i < user.Skills.Count; i++)
            {
                TextBox skltmp = new TextBox()
                {
                    Text = user.Skills[i],
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

                SklListTB.Add(skltmp);

                skills.Children.Remove(addbtn3);
                skills.Children.Add(skltmp);
                skills.Children.Add(addbtn3);
            }
            if (user.Courses.Count > 0)
            {
                courses.Children.Remove(cur0);
            }
            for (int i = 0; i < user.Courses.Count; i++)
            {
                TextBox curtmp = new TextBox()
                {
                    Text = user.Courses[i],
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

                CurListTB.Add(curtmp);

                courses.Children.Remove(addbtn4);
                courses.Children.Add(curtmp);
                courses.Children.Add(addbtn4);
            }
            if (user.Links.Count > 0)
            {
                links.Children.Remove(lnk0);
            }
            for (int i = 0; i < user.Links.Count; i++)
            {
                TextBox lnktmp = new TextBox()
                {
                    Text = user.Links[i],
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

                LnkListTB.Add(lnktmp);

                links.Children.Remove(addbtn5);
                links.Children.Add(lnktmp);
                links.Children.Add(addbtn5);
            }
        }
        public void ExperienceAdd(object s, RoutedEventArgs e)
        {
            ListAdd(experience, addbtn0, EduListTB);
        }
        public void EducationAdd(object s, RoutedEventArgs e)
        {
            ListAdd(education, addbtn1, EduListTB);
        }
        public void LanguagesAdd(object s, RoutedEventArgs e)
        {
            ListAdd(languages, addbtn2, LanListTB);
        }
        public void SkillsAdd(object s, RoutedEventArgs e)
        {
            ListAdd(skills, addbtn3, SklListTB);
        }
        public void CoursesAdd(object s, RoutedEventArgs e)
        {
            ListAdd(courses, addbtn4, CurListTB);
        }
        public void LinksAdd(object s, RoutedEventArgs e)
        {
            ListAdd(links, addbtn5, LnkListTB);
        }

        private void ChangePass(object s, RoutedEventArgs e)
        {
            new PasswordChange(user).Show();
        }
        private void Logout(object s, RoutedEventArgs e)
        {
            mainwindow.UserId = -1;
            MessageBox.Show($"Zostałeś wylogowany");
            Close();
        }

        private void ListAdd(StackPanel sp,Button btn,List<TextBox> tb)
        {
            TextBox tmp = new TextBox()
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

            tb.Add(tmp);

            sp.Children.Remove(btn);
            sp.Children.Add(tmp);
            sp.Children.Add(btn);
        }
        public async void Change(object s, RoutedEventArgs e)
        {

            if (!string.IsNullOrWhiteSpace(firstname.Text) && !string.IsNullOrWhiteSpace(surname.Text) && !string.IsNullOrWhiteSpace(email.Text) &&
               !string.IsNullOrWhiteSpace(number.Text) && !string.IsNullOrWhiteSpace(address.Text) && !string.IsNullOrWhiteSpace(actual_position.Text) &&
               !string.IsNullOrWhiteSpace(position_description.Text))
            {
                user.Firstname = firstname.Text;
                user.Surname = surname.Text;
                user.Birth_Date = birthdate.SelectedDate.Value;
                user.Email = email.Text;
                user.Number = int.Parse(number.Text);
                user.Address = address.Text;
                user.Actual_position = actual_position.Text;
                user.Position_description = position_description.Text;
                for (int i = 0; i < ExpListTB.Count; i++)
                {
                    ExpList.Add(ExpListTB[i].Text);
                }
                for (int i = 0; i < EduListTB.Count; i++)
                {
                    EduList.Add(EduListTB[i].Text);
                }
                for (int i = 0; i < LanListTB.Count; i++)
                {
                    LanList.Add(LanListTB[i].Text);
                }
                for (int i = 0; i < SklListTB.Count; i++)
                {
                    SklList.Add(SklListTB[i].Text);
                }
                for (int i = 0; i < CurListTB.Count; i++)
                {
                    CurList.Add(CurListTB[i].Text);
                }
                for (int i = 0; i < LnkListTB.Count; i++)
                {
                    LnkList.Add(LnkListTB[i].Text);
                }
                user.Experience = ExpList;
                user.Education = EduList;
                user.Languages = LanList;
                user.Skills = SklList;
                user.Courses = CurList;
                user.Links = LnkList;
                new Database().EditUser(user);

                Close();
            }
            else
            {
                MessageBox.Show($"Błąd danych Prosimy o poprawienie");
            }

        }
    }
}
