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
    /// Interaction logic for Componentes.xaml
    /// </summary>
    public partial class ComponentesUserControl : UserControl
    {
        public ComponentesUserControl()
        {
            InitializeComponent();
            DBContext context = new DBContext();
            dgComponentes.ItemsSource = context.ComponentesView.Select(s => s).ToList();
        }
    }
}
