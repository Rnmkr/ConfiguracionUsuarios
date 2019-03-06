using System.Collections.Generic;
using System.Linq;
using System.Windows;
using ConfiguracionUsuarios.DataAccessLayer;

namespace ConfiguracionUsuarios
{
    /// <summary>
    /// Interaction logic for EdicionPermisosWindow.xaml
    /// </summary>
    public partial class EdicionPermisosWindow : Window
    {
        DBContext context = new DBContext();
        private int _idUsuario;

        public EdicionPermisosWindow(int idUsuario)
        {
            InitializeComponent();
            this._idUsuario = idUsuario;
            cbAplicaciones.ItemsSource = context.Aplicacion.Select(s => s.NombreAplicacion).ToList();
        }

        private void cbAplicaciones_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (cbAplicaciones.SelectedValue != null)
            {
                var _permisos = context.PermisoView.Where(w => w.FK_IDUsuario == _idUsuario).Select(s => s);
                lvPermisos.ItemsSource = _permisos.Where(w => w.NombreAplicacion == cbAplicaciones.SelectedValue.ToString()).ToList();

            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            //context.SaveChangesAsync();
            MessageBox.Show("Todo piola!");
        }

        private void ChkSelectAll_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
