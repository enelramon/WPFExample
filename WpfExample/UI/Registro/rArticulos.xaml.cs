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
using WpfExample.Entidades;
using WpfExample.BLL;

namespace WpfExample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class rArticulos : Window
    {
        Articulos articulo = new Articulos();

        public rArticulos()
        {
            InitializeComponent();
            this.DataContext = articulo;
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            limpiar();
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            bool paso = false;

            if (articulo.ArticuloId == 0)
            {
                paso = ArticulosBLL.Guardar(articulo);
            }
            else
            {
                if (!ExisteEnLaBaseDeDatos())
                {
                    MessageBox.Show("No se puede Modificar un articulo que no existe");
                    return;
                }
                paso = ArticulosBLL.Modificar(articulo);
            }

            if (paso)
            {
                limpiar();
                MessageBox.Show("Guardado");
            }
            else
            {
                MessageBox.Show("No se pudo guardar");
            }

        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            Articulos AnteriorArticulo = ArticulosBLL.Buscar(articulo.ArticuloId);

            if (AnteriorArticulo != null)
            {
                articulo = AnteriorArticulo;
                reCargar();
            }
            else
                MessageBox.Show("No existe");
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if (ArticulosBLL.Eliminar(articulo.ArticuloId))
            {
                limpiar();
                MessageBox.Show("Eliminado Correctamente");
            }
            else
                MessageBox.Show("No se Puede Eliminar un Articulo que no existe");
        }

        private void limpiar()
        {
            articulo = new Articulos();
            reCargar();
        }

        private bool ExisteEnLaBaseDeDatos()
        {
            Articulos AnteriorArticulo = ArticulosBLL.Buscar(articulo.ArticuloId);

            return (AnteriorArticulo != null);
        }

        private void reCargar()
        {
            this.DataContext = null;
            this.DataContext = articulo;
        }
    }
}
