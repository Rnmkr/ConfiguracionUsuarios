using ConfiguracionUsuarios.DataAccessLayer;
using System.Collections.Generic;
using System.Linq;
using System.Windows;


namespace ConfiguracionUsuarios
{
    /// <summary>
    /// Interaction logic for AsignacionAccesoWindow.xaml
    /// </summary>
    public partial class NuevoUsuarioWindow : Window
    {
        internal Usuario nuevoUsuario;
        internal UsuarioView nuevoUsuarioView;
        internal UsuarioView editarUsuarioView;

        public NuevoUsuarioWindow(UsuarioView _editarUsuarioView)
        {
            InitializeComponent();
            editarUsuarioView = _editarUsuarioView;

            if (editarUsuarioView != null)
            {
                tbLegajo.Text = editarUsuarioView.LegajoUsuario;
                tbNombre.Text = editarUsuarioView.NombreUsuario;
                tbApellido.Text = editarUsuarioView.ApellidoUsuario;
                tbRFID.Password = editarUsuarioView.HashedRFID;
            }
        }

        private void btnNuevoUsuario_Click(object sender, RoutedEventArgs e)
        {
            if (editarUsuarioView != null)
            {
                EditarUsuario();
            }
            else
            {
                NuevoUsuario();
            }

        }
        private void EditarUsuario()
        {
            DBContext context = new DBContext();
            var user = context.Usuario.Where(w => w.IDUsuario == editarUsuarioView.IDUsuario).Select(s => s).SingleOrDefault();
            user.LegajoUsuario = tbLegajo.Text;
            user.NombreUsuario = tbNombre.Text;
            user.ApellidoUsuario = tbApellido.Text;
            user.Password.HashedRFID = tbRFID.Password;
            context.SaveChangesAsync();
            MessageBox.Show("Usuario Guardado Correctamente lince!");
        }

        private void NuevoUsuario()
        {
            //retorno de un metodo de comprobacion de datos de usuario
            bool dataIsValid = true;
            if (dataIsValid)
            {
                DBContext context = new DBContext();
                nuevoUsuario = new Usuario { LegajoUsuario = tbLegajo.Text, NombreUsuario = tbNombre.Text, ApellidoUsuario = tbApellido.Text };
                context.Usuario.Add(nuevoUsuario);

                Password nuevaContraseña = new Password { FK_IDUsuario = nuevoUsuario.IDUsuario, HashedPassword = null, HashedRFID = null };
                context.Password.Add(nuevaContraseña);

                var listaPermisos = context.Permiso.Select(s => s);
                List<PermisoUsuario> listaPermisosUsuario = new List<PermisoUsuario>();

                foreach (var item in listaPermisos)
                {
                    listaPermisosUsuario.Add(new PermisoUsuario { FK_IDUsuario = nuevoUsuario.IDUsuario, FK_IDPermiso = item.IDPermiso, EstadoPermiso = false });
                }

                context.PermisoUsuario.AddRange(listaPermisosUsuario);

                try
                {
                    context.SaveChanges();
                    MessageBox.Show("Usuario Guardado Correctamente lince!");
                    nuevoUsuarioView = context.UsuarioView.Where(w => w.IDUsuario == nuevoUsuario.IDUsuario).Select(s => s).SingleOrDefault();
                    Close();
                }
                catch (System.Data.Entity.Infrastructure.DbUpdateException)
                {
                    MessageBox.Show("El legajo ya esta registrado en la base de datos lince!");
                }


            }
        }
    }
}
