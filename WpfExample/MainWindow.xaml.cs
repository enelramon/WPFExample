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
using WpfExample.UI.MenuPrincipal;

namespace WpfExample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Usuarios usuario = new Usuarios();
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = usuario;
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            if (UsuariosBLL.Existe(usuario))
            {
                pMenu m = new pMenu();
                m.Owner = this;
                m.ShowDialog();
            }
            else
                MessageBox.Show("Usuario no existente");
        }
    }
}
