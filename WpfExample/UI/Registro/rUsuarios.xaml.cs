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
using WpfExample.Entidades;
using WpfExample.BLL;

namespace WpfExample.UI.Registro
{
    /// <summary>
    /// Interaction logic for rUsuarios.xaml
    /// </summary>
    public partial class rUsuarios : Window
    {
        Usuarios usuario = new Usuarios();
        public rUsuarios()
        {
            InitializeComponent();
            this.DataContext = usuario;
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            limpiar();
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            bool paso = false;

            if (usuario.UsuarioId == 0)
            {
                paso = UsuariosBLL.Guardar(usuario);
            }
            else
            {
                if (!ExisteEnLaBaseDeDatos())
                {
                    MessageBox.Show("No se puede Modificar un usuario que no existe");
                    return;
                }
                paso = UsuariosBLL.Modificar(usuario);
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
            Usuarios AnteriorUsuario = UsuariosBLL.Buscar(usuario.UsuarioId);

            if (AnteriorUsuario != null)
            {
                usuario = AnteriorUsuario;
                reCargar();
            }
            else
                MessageBox.Show("No existe");
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if (UsuariosBLL.Eliminar(usuario.UsuarioId))
            {
                limpiar();
                MessageBox.Show("Eliminado Correctamente");
            }
            else
                MessageBox.Show("No se Puede Eliminar un Usuario que no existe");
        }

        private void limpiar()
        {
            usuario = new Usuarios();
            reCargar();
        }

        private bool ExisteEnLaBaseDeDatos()
        {
            Usuarios AnteriorUsuario = UsuariosBLL.Buscar(usuario.UsuarioId);

            return (AnteriorUsuario != null);
        }

        private void reCargar()
        {
            this.DataContext = null;
            this.DataContext = usuario;
        }
    }
}
