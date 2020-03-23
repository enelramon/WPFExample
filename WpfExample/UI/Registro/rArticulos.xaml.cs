using System;
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

namespace WpfExample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class rArticulos : Window
    {
        Entidades.Articulos Articulo = new Entidades.Articulos();

        public rArticulos()
        {
            this.DataContext = Articulo;
            InitializeComponent();
        }



        private async void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            //esto es un prueba rapida para ver que todo esta bien.
            DAL.Contexto contexto = new DAL.Contexto();

            contexto.Articulos.Add(this.Articulo);

            await contexto.SaveChangesAsync();



        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            DAL.Contexto contexto = new DAL.Contexto();
            var art = contexto.Articulos.Find(int.Parse( this.ArticuloIdTextBox.Text));

            if (art != null)
                this.Articulo = art;
        }
    }
}
