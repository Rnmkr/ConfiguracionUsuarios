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
using IngresoPedidos.DataAccessLayer;
using IngresoPedidos.Helpers;


namespace ConfiguracionUsuarios
{
    /// <summary>
    /// Interaction logic for MainLogin.xaml
    /// </summary>
    public partial class MainLogin : UserControl
    {
        public MainLogin()
        {
            InitializeComponent();
        }

        //private void btnLogin_Click(object sender, RoutedEventArgs e)
        //{
        //    btnLogin.IsEnabled = false;
        //    using (new WaitCursor())
        //    {
        //        var _legajo = tbLegajo.Text;
        //        var _password = pbContraseña.Password;
        //        TryLoginAsync(_legajo, _password);

        //        //mal todo mal eh, aprende de una vez que tenes que hacer la ventanita...
        //    }

        //    btnLogin.IsEnabled = true;
        //}

        //private void TryLoginAsync(string legajo, string password)
        //{



        //    if (string.IsNullOrWhiteSpace(legajo) || string.IsNullOrWhiteSpace(password))
        //    {
        //        return;
        //    }

        //    if (legajo == "LEGAJO" || password == "--------")
        //    {
        //        return;
        //    }

        //    if (ConnectionCheck.Success(StaticData.ServerHostName))
        //    {
        //        StaticData.DataBaseContext = new DBContext();
        //        LoginValidation userValidation = new LoginValidation();

        //        if (userValidation.CanLogin(legajo, password, "LOGIN"))
        //        {
        //            MainWindow mainWindow = new MainWindow();
        //            mainWindow.Show();
        //            //Close();
        //        }
        //    }

        //}

        //private void TbLegajo_GotFocus(object sender, RoutedEventArgs e)
        //{
        //    tbLegajo.SelectAll();
        //}

        //private void PbContraseña_GotFocus(object sender, RoutedEventArgs e)
        //{
        //    pbContraseña.SelectAll();
        //}

        //private void Window_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        //{
        //    if (e.Key == System.Windows.Input.Key.Enter)
        //    {
        //        return;
        //    }

        //    if (e.Key == System.Windows.Input.Key.Escape)
        //    {
        //        //Close();
        //    }
        //}


    }
}
