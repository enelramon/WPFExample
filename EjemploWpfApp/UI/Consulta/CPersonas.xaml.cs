using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using EjemploWpfApp.BLL;
using EjemploWpfApp.Entidades;

namespace EjemploWpfApp.UI.Consulta
{
    /// <summary>
    /// Interaction logic for CPersonas.xaml
    /// </summary>
    public partial class CPersonas : Window
    {
        public CPersonas()
        {
            InitializeComponent();
        }

        private void ConsultarButton_Click(object sender, RoutedEventArgs e)
        {
            var Listado = new List<Personas>();
            if (CriterioTextBox.Text.Trim().Length > 0)
            {
                switch (FiltroComboBox.SelectedIndex)
                {
                    //Todo
                    case 0:
                        Listado = PersonasBLL.GetList(p => true);
                        break;
                    //ID
                    case 1:
                        int id = Convert.ToInt32(CriterioTextBox.Text);
                        Listado = PersonasBLL.GetList(p => p.PersonaId == id);
                        break;
                    //Nombre
                    case 2:
                        Listado = PersonasBLL.GetList(p => p.Nombres.Contains(CriterioTextBox.Text));
                        break;
                    //Cedula
                    case 3:
                        Listado = PersonasBLL.GetList(p => p.Cedula.Contains(CriterioTextBox.Text));
                        break;
                    //Direccion
                    case 4:
                        Listado = PersonasBLL.GetList(p => p.Direccion.Contains(CriterioTextBox.Text));
                        break;
                }

                Listado = Listado.Where(c => c.FechaNacimiento.Date >= DesdeDatePicker.SelectedDate && c.FechaNacimiento.Date <= HastaDatePicker.SelectedDate).ToList();
            }
            else
            {
                Listado = PersonasBLL.GetList(p => true);
            }

            ConsultaDataGrid.ItemsSource = null;
            ConsultaDataGrid.ItemsSource = Listado;
        }
    }
}
