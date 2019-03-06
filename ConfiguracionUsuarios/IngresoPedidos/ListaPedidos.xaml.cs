using ConfiguracionUsuarios.DataAccessLayer;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace ConfiguracionUsuarios.IngresoPedidos
{
    /// <summary>
    /// Interaction logic for ListaPedidos.xaml
    /// </summary>
    public partial class ListaPedidos : UserControl
    {
        DBContext databaseContext = new DBContext();

        public ListaPedidos()
        {
            InitializeComponent();
            dgUsuarios.ItemsSource = databaseContext.Aplicacion.Select(s => s).ToList();
        }

        private void btnEditarPermisos_Click(object sender, RoutedEventArgs e)
        {
            EditarPermisos(null);
        }

        private void ctxmnuEditarusuario_Click(object sender, RoutedEventArgs e)
        {
            NuevoUsuarioWindow aw = new NuevoUsuarioWindow((UsuarioView)dgUsuarios.SelectedItem);
            aw.Owner = Window.GetWindow(this.Parent);
            if (aw.ShowDialog() != null)
            {
                dgUsuarios.ItemsSource = null;
                dgUsuarios.ItemsSource = databaseContext.UsuarioView.Select(s => s).ToList();
                //dgUsuarios.SelectedIndex = dgUsuarios.Items.Count - 1;
                //dgUsuarios.SelectedItem = dgUsuarios.SelectedIndex;
                //dgUsuarios.ScrollIntoView(dgUsuarios.SelectedItem);
                //EditarPermisos((UsuarioView)dgUsuarios.SelectedItem);
            }
        }

        private void EditarPermisos(UsuarioView usuario)
        {
            UsuarioView si = usuario; ;

            if (usuario == null)
            {
                si = (UsuarioView)dgUsuarios.SelectedItem;
            }

            EdicionPermisosWindow epw = new EdicionPermisosWindow(si.IDUsuario);
            epw.Owner = Window.GetWindow(this.Parent);
            mainGrid.IsEnabled = false;
            epw.ShowDialog();
            mainGrid.IsEnabled = true;
        }

        private void btnNuevoUsuario_Click(object sender, RoutedEventArgs e)
        {

            NuevoUsuarioWindow aw = new NuevoUsuarioWindow(null);
            aw.Owner = Window.GetWindow(this.Parent);
            if (aw.ShowDialog() != null)
            {
                dgUsuarios.ItemsSource = null;
                dgUsuarios.ItemsSource = databaseContext.UsuarioView.Select(s => s).ToList();
                dgUsuarios.SelectedIndex = dgUsuarios.Items.Count - 1;
                dgUsuarios.SelectedItem = dgUsuarios.SelectedIndex;
                dgUsuarios.ScrollIntoView(dgUsuarios.SelectedItem);
                //EditarPermisos((UsuarioView)dgUsuarios.SelectedItem);
            }


        }

        private void BtnEliminarUsuario_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult mbr = MessageBox.Show("Desea Eliminar este usuario?", "Eliminar Usuario", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
            if (mbr == MessageBoxResult.Yes)
            {
                DBContext context = new DBContext();

                var usuarioSeleccionado = (UsuarioView)dgUsuarios.SelectedItem;
                var usuarioEliminado = context.Usuario.Where(w => w.IDUsuario == usuarioSeleccionado.IDUsuario).Select(s => s).SingleOrDefault();
                var contrseñaEliminada = context.Password.Where(w => w.FK_IDUsuario == usuarioEliminado.IDUsuario).SingleOrDefault();
                context.Usuario.Remove(usuarioEliminado);
                context.Password.Remove(context.Password.Where(w => w.FK_IDUsuario == usuarioEliminado.IDUsuario).SingleOrDefault());
                var listaPermisosUsuarioEliminado = context.PermisoUsuario.Where(w => w.FK_IDUsuario == usuarioEliminado.IDUsuario).Select(s => s).ToList();
                foreach (var item in listaPermisosUsuarioEliminado)
                {
                    context.PermisoUsuario.Remove(item);
                }
                context.SaveChanges();
                MessageBox.Show("Usuario Eliminado Correctamente");
                dgUsuarios.ItemsSource = null;
                dgUsuarios.ItemsSource = databaseContext.UsuarioView.Select(s => s).ToList();
            }

        }

        private void ctxmnuResetPassword_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult mbr = MessageBox.Show("Desea reiniciar el password?", "Reset Password", MessageBoxButton.OKCancel, MessageBoxImage.Question, MessageBoxResult.Cancel);
            if (mbr == MessageBoxResult.OK)
            {
                var seleccion = (UsuarioView)dgUsuarios.SelectedItem;
                int idseleccion = seleccion.IDUsuario;
                DBContext context = new DBContext();
                Password passwordusuario = context.Password.Where(w => w.FK_IDUsuario == idseleccion).Select(s => s).SingleOrDefault();
                passwordusuario.HashedPassword = null;
                context.SaveChangesAsync();
                MessageBox.Show("Password reiniciado", "Reset Password", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void ctxmnuResetRFID_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult mbr = MessageBox.Show("Desea reiniciar el RFID?", "Reset RFID", MessageBoxButton.OKCancel, MessageBoxImage.Question, MessageBoxResult.Cancel);
            if (mbr == MessageBoxResult.OK)
            {
                var seleccion = (UsuarioView)dgUsuarios.SelectedItem;
                int idseleccion = seleccion.IDUsuario;
                DBContext context = new DBContext();
                Password passwordusuario = context.Password.Where(w => w.FK_IDUsuario == idseleccion).Select(s => s).SingleOrDefault();
                passwordusuario.HashedRFID = null;
                context.SaveChangesAsync();
                MessageBox.Show("RFID reiniciado", "Reset Password", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
