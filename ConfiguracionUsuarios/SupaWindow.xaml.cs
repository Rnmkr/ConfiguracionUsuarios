using IngresoPedidos.DataAccessLayer;
using System.Windows;


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
            contentControl.Content = lu;

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (IngresoPedidos.Helpers.ConnectionCheck.Success(IngresoPedidos.Helpers.StaticData.ServerHostName))
            {

                IngresoPedidos.Helpers.LoginValidation userValidation = new IngresoPedidos.Helpers.LoginValidation();

                if (userValidation.CanLogin("925", "123456", "LOGIN"))
                {
                    IngresoPedidos.ListaPedidos iplp = new IngresoPedidos.ListaPedidos();
                    contentControl.Content = iplp;
                }
            }

        }
    }
}
