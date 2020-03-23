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
        public rPersonas()
        {
            InitializeComponent();
            PersonaIdTextBox.Text = "0";
            FechaNacimientoDatePicker.SelectedDate = DateTime.Now;
        }

        private void ConsultarButton_Click(object sender, RoutedEventArgs e)
        {
            cPersonas cp = new cPersonas();
            cp.Show();
        }

        private void Limpiar()
        {
            PersonaIdTextBox.Text = "0";
            NombresTextBox.Text = string.Empty;
            TelefonoTextBox.Text = string.Empty;
            CedulaTextBox.Text = string.Empty;
            DireccionTextBox.Text = string.Empty;
            FechaNacimientoDatePicker.SelectedDate = DateTime.Now;
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private Personas LlenaClase()
        {
            Personas persona = new Personas();

            persona.PersonaId = Convert.ToInt32(PersonaIdTextBox.Text);
            persona.Nombres = NombresTextBox.Text;
            persona.Telefono = TelefonoTextBox.Text;
            persona.Cedula = CedulaTextBox.Text;
            persona.Direccion = DireccionTextBox.Text;
            persona.FechaNacimiento = Convert.ToDateTime(FechaNacimientoDatePicker.SelectedDate);

            return persona;
        }

        private void LlenaCampo(Personas persona)
        {
            PersonaIdTextBox.Text = Convert.ToString(persona.PersonaId);
            NombresTextBox.Text = persona.Nombres;
            TelefonoTextBox.Text = persona.Telefono;
            CedulaTextBox.Text = persona.Cedula;
            DireccionTextBox.Text = persona.Direccion;
            FechaNacimientoDatePicker.SelectedDate = persona.FechaNacimiento;
        }

        private bool Validar()
        {
            bool paso = true;

            if(string.IsNullOrWhiteSpace(NombresTextBox.Text))
            {
                MessageBox.Show("El Campo Nombres no puede estar Vacío");
                NombresTextBox.Focus();
                paso = false;
            }

            if (string.IsNullOrWhiteSpace(TelefonoTextBox.Text))
            {
                MessageBox.Show("El Campo Telefono no puede estar Vacío");
                TelefonoTextBox.Focus();
                paso = false;
            }

            if (string.IsNullOrWhiteSpace(CedulaTextBox.Text.Replace("-", "")))
            {
                MessageBox.Show("El Campo Cedula no puede estar Vacío");
                CedulaTextBox.Focus();
                paso = false;
            }

            if (string.IsNullOrWhiteSpace(DireccionTextBox.Text))
            {
                MessageBox.Show("El Campo Dirección no puede estar Vacío");
                DireccionTextBox.Focus();
                paso = false;
            }

            return paso;
        }

        private bool ExisteEnLaBaseDeDatos()
        {
            Personas persona = PersonasBLL.Buscar(Convert.ToInt32(PersonaIdTextBox.Text));

            return (persona != null);
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            Personas persona = new Personas();
            bool paso = false;

            if (!Validar())
                return;

            persona = LlenaClase();

            //determinar si es guardar o modificar
            if (PersonaIdTextBox.Text == "0")
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
            int id;
            int.TryParse(PersonaIdTextBox.Text, out id);

            Limpiar();

            if (PersonasBLL.Eliminar(id))
            {
                MessageBox.Show("Eliminado Correctamente");
            }
            else
                MessageBox.Show("No se Puede Eliminar una perona que no existe");
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            int id;
            Personas persona = new Personas();
            int.TryParse(PersonaIdTextBox.Text, out id);

            Limpiar();

            persona = PersonasBLL.Buscar(id);

            if (persona != null)
            {
                MessageBox.Show("Encontrado");
                LlenaCampo(persona);
            }
            else
                MessageBox.Show("No existe");
        }
    }
}
