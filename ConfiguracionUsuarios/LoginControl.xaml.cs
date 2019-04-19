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

namespace ConfiguracionUsuarios
{
    /// <summary>
    /// Interaction logic for LoginControl.xaml
    /// </summary>
    public partial class LoginControl : UserControl
    {
        public LoginControl()
        {
            InitializeComponent();
        }

        private void BtnAceptar_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            string buttonContent = button.Content as string;
            if (buttonContent == "SALIR")
            {
                tblTitulo.Text = "Sistema Manager de Producción";
                tbLegajo.Visibility = Visibility.Visible;
                pbPassword.Visibility = Visibility.Visible;
                btnAceptar.Content = "INGRESAR";
            }
            else
            {
                tblTitulo.Text = "Bienvenido Schneider Nicolas";
                tbLegajo.Visibility = Visibility.Collapsed;
                pbPassword.Visibility = Visibility.Collapsed;
                btnAceptar.Content = "SALIR";
            }
        }
    }
}
