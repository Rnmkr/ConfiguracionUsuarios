using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
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
        List<PermisoView> lvsource;
        public EdicionPermisosWindow(int idUsuario)
        {
            InitializeComponent();
            this._idUsuario = idUsuario;
            cbAplicaciones.ItemsSource = context.Aplicacion.Select(s => s.NombreAplicacion).ToList();

            //RevalidarPermisos();
        }

        private void RevalidarPermisos()
        {
            DBContext context = new DBContext();
            var listaPermisos = context.Permiso.Select(s => s);
            List<PermisoUsuario> listaPermisosUsuario = context.PermisoUsuario.Where(w => w.FK_IDUsuario == _idUsuario).Select(s => s).ToList();
            List<PermisoUsuario> listaNuevaPermisosUsuario = new List<PermisoUsuario>();
            foreach (var item in listaPermisos)
            {
                if (listaPermisosUsuario.Where(w => w.FK_IDPermiso == item.IDPermiso).Any())
                {

                }
                else
                {
                    listaNuevaPermisosUsuario.Add(new PermisoUsuario { FK_IDUsuario = _idUsuario, FK_IDPermiso = item.IDPermiso, EstadoPermiso = false });
                }

            }
            context.PermisoUsuario.AddRange(listaNuevaPermisosUsuario);
            context.SaveChanges();
            MessageBox.Show("Todo piola!");
            lvPermisos.ItemsSource = null;
            var _permisos = context.PermisoView.Where(w => w.FK_IDUsuario == _idUsuario).Select(s => s);
            lvPermisos.ItemsSource = _permisos.Where(w => w.NombreAplicacion == cbAplicaciones.SelectedValue.ToString()).ToList();
        }

        private void cbAplicaciones_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (cbAplicaciones.SelectedValue != null)
            {
                var _permisos = context.PermisoView.Where(w => w.FK_IDUsuario == _idUsuario).Select(s => s);
                lvsource = _permisos.Where(w => w.NombreAplicacion == cbAplicaciones.SelectedValue.ToString()).ToList();
                lvPermisos.ItemsSource = lvsource;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            //context.SaveChanges();
            MessageBox.Show("Todo piola!");
            Close();
        }

        //private void ChkSelectAll_Click(object sender, RoutedEventArgs e)
        //{
        //    CheckBox cbox = (CheckBox)sender;
        //    List<PermisoView> lpv = new List<PermisoView>();

        //    if (cbox.IsChecked == false)
        //    {
        //        foreach (var item in lvsource)
        //        {
        //             item.EstadoPermiso = false;
        //            lpv.Add(item);
        //        }
        //    }
        //    else
        //    {
        //        foreach (var item in lvsource)
        //        {
        //            item.EstadoPermiso = true;
        //        }
        //        lvsource = lpv;
        //        lvPermisos.ItemsSource = null;
        //        lvPermisos.ItemsSource = lvsource;
        //    }

        //}

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void chkSelectAll_Checked(object sender, RoutedEventArgs e)
        {

            foreach (PermisoView item in lvPermisos.ItemsSource)
            {
                item.EstadoPermiso = true;
            }
            
        }

        private void chkSelectAll_Unchecked(object sender, RoutedEventArgs e)
        {
            foreach (PermisoView item in lvPermisos.ItemsSource)
            {
                item.EstadoPermiso = false;
            }
        }
    }
}
