using GameOfThrones;
using Gecko;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Forms.Integration;
using System.IO;
using System.Net;
using Newtonsoft.Json;
using System.Windows.Forms;
using System.Windows.Controls;

namespace GeckoWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string _url;
        private List<Person> _people;

        public MainWindow()
        {
            _url = "https://api.got.show/api/show/characters";
            InitializeComponent();

            GetPeople();

            foreach (var person in _people)
            {
                peopleListBox.Items.Add(person.Name);
            }
            
            Gecko.Xpcom.Initialize("Firefox");
        }
        

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            WindowsFormsHost host = new WindowsFormsHost();
            GeckoWebBrowser browser = new GeckoWebBrowser();
            host.Child = browser;
            GridWeb.Children.Add(host);
            browser.Navigate("http://viewers-guide.hbo.com/game-of-thrones/season-6/episode-10/map/location/77/bay-of-dragons");
        }
        
        public void GetPeople()
        {
            string json = "";
            WebClient client = new WebClient();
            using (Stream stream = client.OpenRead(_url))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    string line = "";
                    while ((line = reader.ReadLine()) != null)
                    {
                        json += line;
                    }
                }
            }

            _people = JsonConvert.DeserializeObject<List<Person>>(json);
        }

        private void findTextBoxDataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            foreach (var item in peopleListBox.Items)
            {
                peopleListBox.Items.Remove(item);
            }

            foreach (var person in _people)
            {
                if (person.Name.Contains(findTextBox.Text) && person.Name.Length <= findTextBox.Text.Length)
                {
                    peopleListBox.Items.Add(person);
                }
            }
        }

        private void findTextBoxTextChanged(object sender, TextChangedEventArgs e)
        {
            peopleListBox.Items.Clear();

            foreach (var person in _people)
            {
                if (person.Name.Contains(textBox.Text))
                {
                    peopleListBox.Items.Add(person);
                }
            }
        }

        private void peopleListBoxMouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            //System.Windows.MessageBox.Show(peopleListBox.Items[peopleListBox.SelectedIndex].ToString());
            PersonInfo personInfo = new PersonInfo();
            personInfo.Show();
        }
    }
}