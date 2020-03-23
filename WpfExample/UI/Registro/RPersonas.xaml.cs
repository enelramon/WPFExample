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
using Microsoft.EntityFrameworkCore;
using WpfExample.Entidades;
using WpfExample.BLL;
using WpfExample.UI.Consulta;

namespace WpfExample.UI.Registro
{
    /// <summary>
    /// Interaction logic for RPersonas.xaml
    /// </summary>
    public partial class rPersonas : Window
    {
        Personas persona = new Personas();
        public rPersonas()
        {
            InitializeComponent();
            this.DataContext = persona;
        }

        private void ConsultarButton_Click(object sender, RoutedEventArgs e)
        {
            cPersonas cp = new cPersonas();
            cp.Show();
        }

        private void Limpiar()
        {
            persona = new Personas();
            reCargar();
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private bool ExisteEnLaBaseDeDatos()
        {
            Personas AnteriorPersona = PersonasBLL.Buscar(persona.PersonaId);

            return (AnteriorPersona != null);
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            bool paso = false;

            //determinar si es guardar o modificar
            if (persona.PersonaId == 0)
                paso = PersonasBLL.Guardar(persona);
            else
            {
                if (!ExisteEnLaBaseDeDatos())
                {
                    MessageBox.Show("No se puede Modificar una persona que no existe");
                    return;
                }
                paso = PersonasBLL.Modificar(persona);
            }

            //informar resultado
            if (paso)
            {
                Limpiar();
                MessageBox.Show("Guardado");
            }
            else
                MessageBox.Show("No se pudo Guardar");
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if (PersonasBLL.Eliminar(persona.PersonaId))
            {
                Limpiar();
                MessageBox.Show("Eliminado Correctamente");
            }
            else
                MessageBox.Show("No se Puede Eliminar una perona que no existe");
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            Personas AnteriorPersona = PersonasBLL.Buscar(persona.PersonaId);

            if (AnteriorPersona != null)
            {
                persona = AnteriorPersona;
                reCargar();
            }
            else
                MessageBox.Show("No existe");
        }

        private void reCargar()
        {
            this.DataContext = null;
            this.DataContext = persona;
        }
    }
}
