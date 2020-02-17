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

namespace WpfExample.UI.Registros
{
    /// <summary>
    /// Interaction logic for RegistroArticulos.xaml
    /// </summary>
    public partial class RegistroArticulos : Window
    {
        public RegistroArticulos()
        {
            InitializeComponent();
            ProductoIdTextBox.Text = "0";
        }

        private void Limpiar()
        {
            ProductoIdTextBox.Text = "0";
            DescripcionTextBox.Text = string.Empty;
            ExistenciaTextBox.Text = string.Empty;
            CostoTextBox.Text = string.Empty;
            ValorInventarioTextBox.Text = string.Empty;
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private Articulos LlenaClase()
        {
            Articulos articulo = new Articulos();
            articulo.ArticuloId = Convert.ToInt32(ProductoIdTextBox.Text);
            articulo.Descripcion = DescripcionTextBox.Text;
            articulo.Existencia = Convert.ToInt32(ExistenciaTextBox.Text);
            articulo.Costo = Convert.ToDecimal(CostoTextBox.Text);
            articulo.Ganancia = (articulo.Existencia * articulo.Costo);

            return articulo;
        }

        private void LlenaCampo(Articulos articulo)
        {
            ProductoIdTextBox.Text = Convert.ToString(articulo.ArticuloId);
            DescripcionTextBox.Text = articulo.Descripcion;
            ExistenciaTextBox.Text = Convert.ToString(articulo.Existencia);
            CostoTextBox.Text = Convert.ToString(articulo.Costo);
            ValorInventarioTextBox.Text = Convert.ToString(articulo.Ganancia);
        }

        private bool Validar()
        {
            bool paso = true;

            if (string.IsNullOrWhiteSpace(DescripcionTextBox.Text))
            {
                MessageBox.Show("No Puede dejar Campos Vacíos");
                DescripcionTextBox.Focus();
                paso = false;
            }

            if (string.IsNullOrWhiteSpace(ExistenciaTextBox.Text))
            {
                MessageBox.Show("No Puede dejar Campos Vacíos");
                ExistenciaTextBox.Focus();
                paso = false;
            }

            if (string.IsNullOrWhiteSpace(CostoTextBox.Text))
            {
                MessageBox.Show("No Puede dejar Campos Vacíos");
                CostoTextBox.Focus();
                paso = false;
            }

            return paso;
        }

        private bool ExisteEnLaBaseDeDatos()
        {
            Articulos articulo = ArticulosBLL.Buscar(Convert.ToInt32(ProductoIdTextBox.Text));

            return articulo != null;
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            Articulos articulo = new Articulos();
            bool paso = false;

            if (!Validar())
            {
                return;
            }
                
            articulo = LlenaClase();

            //determinar si es guardar o modificar
            if (ProductoIdTextBox.Text == "0")
            {
                paso = ArticulosBLL.Guardar(articulo);
            }
                
            else
            {
                if (!ExisteEnLaBaseDeDatos())
                {
                    MessageBox.Show("No se puede Modificar un Producto que no existe");
                    return;
                }

                paso = ArticulosBLL.Modificar(articulo);
            }

            //informar resultado
            if (paso)
            {
                Limpiar();
                MessageBox.Show("Guardado");
            }
            else
            {
                MessageBox.Show("No se pudo Guardar");
            }                
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            int id;
            int.TryParse(ProductoIdTextBox.Text, out id);

            Limpiar();

            if (ArticulosBLL.Eliminar(id))
            {
                MessageBox.Show("Eliminado Correctamente");
            }
            else
            {
                MessageBox.Show("No se Puede Eliminar un producto que no existe");
            }
                
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            int id;
            Articulos articulo = new Articulos();
            int.TryParse(ProductoIdTextBox.Text, out id);

            Limpiar();

            articulo = ArticulosBLL.Buscar(id);

            if (articulo != null)
            {
                MessageBox.Show("Encontrado");
                LlenaCampo(articulo);
            }
            else
            {
                MessageBox.Show("No existe");
            } 
        }

        private void ExistenciaTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(ExistenciaTextBox.Text) && !string.IsNullOrWhiteSpace(CostoTextBox.Text))
            {
                int valor1;
                decimal valor2;

                valor1 = Convert.ToInt32(ExistenciaTextBox.Text);
                valor2 = Convert.ToDecimal(CostoTextBox.Text);

                ValorInventarioTextBox.Text = Convert.ToString(valor1 * valor2);
            }
        }

        private void ValorInventarioTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(ExistenciaTextBox.Text) && !string.IsNullOrWhiteSpace(CostoTextBox.Text))
            {
                int valor1;
                decimal valor2;

                valor1 = Convert.ToInt32(ExistenciaTextBox.Text);
                valor2 = Convert.ToDecimal(CostoTextBox.Text);

                ValorInventarioTextBox.Text = Convert.ToString(valor1 * valor2);
            }
        }

        private void CostoTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(ExistenciaTextBox.Text) && !string.IsNullOrWhiteSpace(CostoTextBox.Text))
            {
                int valor1;
                decimal valor2;

                valor1 = Convert.ToInt32(ExistenciaTextBox.Text);
                valor2 = Convert.ToDecimal(CostoTextBox.Text);

                ValorInventarioTextBox.Text = Convert.ToString(valor1 * valor2);
            }
        }
    }
}
