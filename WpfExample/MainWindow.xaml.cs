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
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

     

        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //esto es un prueba rapida para ver que todo esta bien.
            DAL.Contexto contexto = new DAL.Contexto();

            contexto.Articulos.Add(
                new Entidades.Articulos 
                { ArticuloId = 0 ,
                Descripcion="Pandora",
                Existencia=2,
                Costo=50,
                Ganancia=10,
                Precio= 55});

            await contexto.SaveChangesAsync();

            var articulo= contexto.Articulos.Find(1);

        }
    }
}
