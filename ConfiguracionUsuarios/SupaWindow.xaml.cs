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

namespace ConfiguracionUsuarios
{
    /// <summary>
    /// Interaction logic for SupaWindow.xaml
    /// </summary>
    public partial class SupaWindow : Window
    {
        public SupaWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ListaUsuarios lu = new ListaUsuarios();
            //MainWindow mw = new MainWindow();
            contentControl.Content = lu;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
