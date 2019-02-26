using ConfiguracionUsuarios.DataAccessLayer;
using System.Linq;
using System.Windows;


namespace ConfiguracionUsuarios
{
    /// <summary>
    /// Interaction logic for AsignacionAccesoWindow.xaml
    /// </summary>
    public partial class AsignacionAccesoWindow : Window
    {
        public AsignacionAccesoWindow()
        {
            InitializeComponent();
            DBContext context = new DBContext();
            dgAccesos.ItemsSource = context.Aplicacion.Select(s => s).ToList();

        }
    }
}
