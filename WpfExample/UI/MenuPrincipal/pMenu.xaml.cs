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
using WpfExample.UI.Registro;
using WpfExample.UI.Consulta;

namespace WpfExample.UI.MenuPrincipal
{
    /// <summary>
    /// Interaction logic for pMenu.xaml
    /// </summary>
    public partial class pMenu : Window
    {
        public pMenu()
        {
            InitializeComponent();
        }

        private void RegistroArticuloMenuItem_Click(object sender, RoutedEventArgs e)
        {
            rArticulos ra = new rArticulos();
            ra.Owner = this;
            ra.ShowDialog();
        }

        private void RegistroPersonaMenuItem_Click(object sender, RoutedEventArgs e)
        {
            rPersonas rp = new rPersonas();
            rp.Owner = this;
            rp.ShowDialog();
        }

        private void RegistroUsuarioMenuItem_Click(object sender, RoutedEventArgs e)
        {
            rUsuarios ru = new rUsuarios();
            ru.Owner = this;
            ru.ShowDialog();
        }

        private void ConsultaArticulosMenuItem_Click(object sender, RoutedEventArgs e)
        {
            cArticulos ca = new cArticulos();
            ca.Owner = this;
            ca.ShowDialog();
        }

        private void ConsultaPersonasMenuItem_Click(object sender, RoutedEventArgs e)
        {
            cPersonas cp = new cPersonas();
            cp.Owner = this;
            cp.ShowDialog();
        }

        private void ConsultaUsuariosMenuItem_Click(object sender, RoutedEventArgs e)
        {
            cUsuarios cu = new cUsuarios();
            cu.Owner = this;
            cu.ShowDialog();
        }
    }
}
