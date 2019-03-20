using IngresoPedidos.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Windows.Media;
using System.Linq;
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
        IEnumerable<Button> listaBotones;

        public SupaWindow()
        {
            InitializeComponent();
            //listaBotones = spAppMenu.Children.OfType<Button>();
            //MainLogin ml = new MainLogin();
            //contentControl.Content = ml;

            //if (listaBotones.Count() == 1)
            //{
            //    CargarUsuarios(null);
            //}
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CargarUsuarios(sender);

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            CargarPedidos(sender);
        }

        private void CargarUsuarios(object sender)
        {
            if (sender != null)
            {
                SelectUnselectButtons(sender);
            }

            //ListaUsuarios lu = new ListaUsuarios();
            //contentControl.Content = lu;
        }

        private void CargarPedidos(object sender)
        {
            SelectUnselectButtons(sender);

            if (IngresoPedidos.Helpers.ConnectionCheck.Success(IngresoPedidos.Helpers.StaticData.ServerHostName))
            {

                IngresoPedidos.Helpers.LoginValidation userValidation = new IngresoPedidos.Helpers.LoginValidation();

                if (userValidation.CanLogin("925", "123456", "LOGIN"))
                {
                    IngresoPedidos.ListaPedidos iplp = new IngresoPedidos.ListaPedidos();
                    //contentControl.Content = iplp;
                }
            }
        }

        private void SelectUnselectButtons(object clickedButton)
        {
            //foreach (Button button in spAppMenu.Children.OfType<Button>())
            //{
            //    if (button == clickedButton)
            //    {
            //        button.IsEnabled = false;
            //    }
            //    else
            //    {
            //        button.IsEnabled = true;
            //    }
            //}
        }

        private void btnShowCaption(object sender, System.Windows.Input.MouseEventArgs e)
        {
            //var btnName = sender as Button;
            //lblCaption.Foreground = Brushes.LightCyan;
            //switch (btnName.Name)
            //{
            //    case "btnUSUARIOS":
            //        lblCaption.Content = "USUARIOS";
            //        break;
            //    case "btnPEDIDOS":
            //        lblCaption.Content = "PEDIDOS";
            //        break;
            //    case "btnPRODUCCION":
            //        lblCaption.Content = "PRODUCCION";
            //        break;
            //    case "btnINFORMES":
            //        lblCaption.Content = "INFORMES";
            //        break;
            //    case "btnFALLAS":
            //        lblCaption.Content = "FALLAS";
            //        break;
            //    case "btnPIEZAS":
            //        lblCaption.Content = "PIEZAS";
            //        break;
            //    case "btnPRODUCTOS":
            //        lblCaption.Content = "PRODUCTOS";
            //        break;
            //    case "btnMODELOS":
            //        lblCaption.Content = "MODELOS";
            //        break;
            //    case "btnADMIN":
            //        lblCaption.Content = "ADMIN";
            //        break;

            //    default:
            //        break;
            //}
        }

        private void btnShowSelected(object sender, System.Windows.Input.MouseEventArgs e)
        {
            //lblCaption.Foreground = Brushes.White;
            //foreach (Button button in spAppMenu.Children.OfType<Button>())
            //{
            //    if (button.IsEnabled == false)
            //    {
            //        switch (button.Name)
            //        {
            //            case "btnUSUARIOS":
            //                lblCaption.Content = "USUARIOS";
            //                break;
            //            case "btnPEDIDOS":
            //                lblCaption.Content = "PEDIDOS";
            //                break;
            //            case "btnPRODUCCION":
            //                lblCaption.Content = "PRODUCCION";
            //                break;
            //            case "btnINFORMES":
            //                lblCaption.Content = "INFORMES";
            //                break;
            //            case "btnFALLAS":
            //                lblCaption.Content = "FALLAS";
            //                break;
            //            case "btnPIEZAS":
            //                lblCaption.Content = "PIEZAS";
            //                break;
            //            case "btnPRODUCTOS":
            //                lblCaption.Content = "PRODUCTOS";
            //                break;
            //            case "btnMODELOS":
            //                lblCaption.Content = "MODELOS";
            //                break;
            //            case "btnADMIN":
            //                lblCaption.Content = "ADMIN";
            //                break;

            //            default:
            //                break;
            //        }
            //    }
            //}
        }

        private void btnADMIN_Click(object sender, RoutedEventArgs e)
        {
            //SelectUnselectButtons(sender);
            //MainLogin ml = new MainLogin();
            //contentControl.Content = ml;
        }

        private void BtnSUGERENCIAS_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonAx_Click(object sender, RoutedEventArgs e)
        {
            //if (rect.Visibility == System.Windows.Visibility.Collapsed)
            //{
            //    rect.Visibility = System.Windows.Visibility.Visible;
            //    (sender as Button).Content = "<";
            //}
            //else
            //{
            //    rect.Visibility = System.Windows.Visibility.Collapsed;
            //    (sender as Button).Content = ">";
            //}
        }




        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Visible;
            ButtonOpenMenu.Visibility = Visibility.Collapsed;
        }

        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
            ButtonOpenMenu.Visibility = Visibility.Visible;
        }

        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UserControl usc = null;
            GridMain.Children.Clear();

            switch (((ListViewItem)((ListView)sender).SelectedItem).Name)
            {
                case "ItemHome":
                    usc = new ListaUsuarios();
                    GridMain.Children.Add(usc);
                    break;
                case "ItemCreate":
                    usc = new IngresoPedidos.ListaPedidos();
                    GridMain.Children.Add(usc);
                    break;
                default:
                    break;
            }
        }
    }
}
