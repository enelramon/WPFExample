using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfExample.BLL;
using WpfExample.Entidades;

namespace WpfExample.UI.Consulta
{
    /// <summary>
    /// Interaction logic for cArticulos.xaml
    /// </summary>
    public partial class cArticulos : Window
    {
        public cArticulos()
        {
            InitializeComponent();
        }

        private void ConsultarButton_Click(object sender, RoutedEventArgs e)
        {
            var Listado = new List<Articulos>();
            if (CriterioTextBox.Text.Trim().Length > 0)
            {
                switch (FiltroComboBox.SelectedIndex)
                {
                    //Todo
                    case 0:
                        Listado = ArticulosBLL.GetList(p => true);
                        break;
                    //ID
                    case 1:
                        int id = Convert.ToInt32(CriterioTextBox.Text);
                        Listado = ArticulosBLL.GetList(p => p.ArticuloId == id);
                        break;
                    //Descripcion
                    case 2:
                        Listado = ArticulosBLL.GetList(p => p.Descripcion.Contains(CriterioTextBox.Text));
                        break;
                    //costo
                    case 3:
                        decimal costo = Convert.ToDecimal(CriterioTextBox.Text);
                        Listado = ArticulosBLL.GetList(p => p.Costo == costo);
                        break;
                }
            }
            else
            {
                Listado = ArticulosBLL.GetList(p => true);
            }

            ConsultaDataGrid.ItemsSource = null;
            ConsultaDataGrid.ItemsSource = Listado;
        }
    }
}
