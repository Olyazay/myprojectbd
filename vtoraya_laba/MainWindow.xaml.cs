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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace vtoraya_laba
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            DataContext = new BindingViewModel();
            
            InitializeComponent();
            //UpDawn mycontrol = new UpDawn();
            //mycontrol.SetValue(Grid.RowProperty, 4);
            //mycontrol.SetValue(Grid.ColumnProperty, 3);
                 
            //CharIph.Children.Add(mycontrol);
        }
    }
}
