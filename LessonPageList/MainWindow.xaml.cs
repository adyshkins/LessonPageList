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

        int _numberPage = 0;

        private void GetList()
        {
            listPerson.Clear();
            for (int i = _numberPage * 50; i < _numberPage * 50 + 50; i++)
            {
                if (i < context.Person.Count())
                {
                    listPerson.Add(context.Person.ToList()[i]);
                    LVPerson.ItemsSource = listPerson;
                }
               
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            
            GetList();
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
            if ((_numberPage + 1) * 50 < context.Person.Count())
            {
                _numberPage++;
                GetList();
            }
           
        }
    }
}
