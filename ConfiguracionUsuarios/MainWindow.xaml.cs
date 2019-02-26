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
using ConfiguracionUsuarios.DataAccessLayer;

namespace ConfiguracionUsuarios
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DBContext databaseContext = new DBContext();

        public MainWindow()
        {
            InitializeComponent();
            
            dgUsuarios.ItemsSource = databaseContext.UsuarioView.Select(s => s).ToList();
            
        }

        private void btnEditarPermisos_Click(object sender, RoutedEventArgs e)
        {
            UsuarioView si = (UsuarioView)dgUsuarios.SelectedItem;
            EdicionPermisosWindow epw = new EdicionPermisosWindow(si.IDUsuario);
            epw.Owner = this;
            epw.ShowDialog();
        }

        private void btnAsignarAccesos_Click(object sender, RoutedEventArgs e)
        {
            AsignacionAccesoWindow aw = new AsignacionAccesoWindow();
            aw.Owner = this;
            aw.ShowDialog();
        }
    }
}
