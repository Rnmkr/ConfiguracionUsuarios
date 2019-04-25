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
    /// Interaction logic for ProdModFall.xaml
    /// </summary>
    public partial class ProdModFall : UserControl
    {
        public ProdModFall()
        {
            InitializeComponent();
            DBContext context = new DBContext();
            Proli.ItemsSource = context.Producto.Select(s => s.NombreProducto).ToList();
            Moli.ItemsSource = context.Modelo.Select(s => s.NombreModelo).ToList();
            Cali.ItemsSource = context.Categoria.Select(s => s.NombreCategoria).ToList();
            Fall.ItemsSource = context.Falla.Select(s => s.DescripcionFalla).ToList();
        }
    }
}
