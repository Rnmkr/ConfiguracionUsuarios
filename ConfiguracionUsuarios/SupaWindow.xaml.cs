using IngresoPedidos.DataAccessLayer;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

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
            SelectUnselectButtons(sender);

            ListaUsuarios lu = new ListaUsuarios();
            contentControl.Content = lu;

        }

        private void SelectUnselectButtons(object clickedButton)
        {
            
            foreach (Button tb in spAppMenu.Children)
            {
                if (tb == clickedButton)
                {
                    tb.IsEnabled = false;
                }
                else
                {
                    tb.IsEnabled = true;
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {


            SelectUnselectButtons(sender);

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
