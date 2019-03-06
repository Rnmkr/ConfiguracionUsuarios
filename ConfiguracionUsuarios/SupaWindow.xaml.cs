using System.Windows;
using ConfiguracionUsuarios.IngresoPedidos;


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
            ListaPedidos mw = new ListaPedidos();
            contentControl.Content = mw;
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ListaUsuarios lu = new ListaUsuarios();
            contentControl.Content = lu;
        }
    }
}
