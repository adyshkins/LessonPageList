using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LessonPageList
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Entities context = new Entities();
        
        ObservableCollection<Person> listPerson = new ObservableCollection<Person>();

        List<string> countPeopleList = new List<string>();

        private int countPeople;

        int _numberPage = 0;

        private void GetList()
        {
            listPerson.Clear();
            for (int i = _numberPage * countPeople; i < _numberPage * countPeople + countPeople; i++)
            {
                if (i <= context.Person.Count())
                {
                    listPerson.Add(context.Person.ToList()[i]);
                    LVPerson.ItemsSource = listPerson;
                    txtNumberPage.Text = (_numberPage + 1).ToString();
                }
               
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            
            GetList();

            countPeopleList.Add("Все");
            countPeopleList.Add("20");
            countPeopleList.Add("50");
            countPeopleList.Add("100");
            cmbCountPeople.SelectedIndex = 0;
            cmbCountPeople.ItemsSource = countPeopleList;

            countPeople = context.Person.Count();

        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            _numberPage--;
            if (_numberPage < 0)
            {
                _numberPage = 0;
            }
            GetList();
        }

        private void btnNaxt_Click(object sender, RoutedEventArgs e)
        {
            if ((_numberPage + 1) * countPeople < context.Person.Count())
            {
                _numberPage++;
                GetList();
            }
           
        }

        private void cmbCountPeople_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            switch (cmbCountPeople.SelectedIndex)
            {
                case 0:
                    countPeople = context.Person.Count();
                    break;

                case 1:
                    countPeople = 20;
                    break;

                case 2:
                    countPeople = 50;
                    break;

                case 3:
                    countPeople = 100;
                    break;


                default:
                    countPeople = context.Person.Count();

                    break;
            }
            GetList();
        }
    }
}
