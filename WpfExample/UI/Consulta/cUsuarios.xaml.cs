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
    /// Interaction logic for cUsuarios.xaml
    /// </summary>
    public partial class cUsuarios : Window
    {
        public cUsuarios()
        {
            InitializeComponent();
        }

        private void ConsultarButton_Click(object sender, RoutedEventArgs e)
        {
            var Listado = new List<Usuarios>();
            if (CriterioTextBox.Text.Trim().Length > 0)
            {
                switch (FiltroComboBox.SelectedIndex)
                {
                    //Todo
                    case 0:
                        Listado = UsuariosBLL.GetList(p => true);
                        break;
                    //ID
                    case 1:
                        int id = Convert.ToInt32(CriterioTextBox.Text);
                        Listado = UsuariosBLL.GetList(p => p.UsuarioId == id);
                        break;
                    //Nombre
                    case 2:
                        Listado = UsuariosBLL.GetList(p => p.Nombre.Contains(CriterioTextBox.Text));
                        break;
                    //Clave
                    case 3:
                        Listado = UsuariosBLL.GetList(p => p.Clave.Contains(CriterioTextBox.Text));
                        break;
                }
            }
            else
            {
                Listado = UsuariosBLL.GetList(p => true);
            }

            ConsultaDataGrid.ItemsSource = null;
            ConsultaDataGrid.ItemsSource = Listado;
        }
    }
}
