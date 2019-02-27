﻿using System;
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
            EditarPermisos(null);
        }

        private void EditarPermisos(UsuarioView usuario)
        {
            UsuarioView si = usuario; ;

            if (usuario == null)
            {
                si = (UsuarioView)dgUsuarios.SelectedItem;
            }

            EdicionPermisosWindow epw = new EdicionPermisosWindow(si.IDUsuario);
            epw.Owner = this;
            mainGrid.IsEnabled = false;
            epw.ShowDialog();
            mainGrid.IsEnabled = true;
        }

        private void btnNuevoUsuario_Click(object sender, RoutedEventArgs e)
        {

            NuevoUsuarioWindow aw = new NuevoUsuarioWindow();
            aw.Owner = this;
            if (aw.ShowDialog() != null)
            {
                dgUsuarios.ItemsSource = null;
                dgUsuarios.ItemsSource = databaseContext.UsuarioView.Select(s => s).ToList();
                dgUsuarios.SelectedIndex = dgUsuarios.Items.Count - 1;
                dgUsuarios.SelectedItem = dgUsuarios.SelectedIndex;
                dgUsuarios.ScrollIntoView(dgUsuarios.SelectedItem);
                EditarPermisos((UsuarioView)dgUsuarios.SelectedItem);
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
    }
}
