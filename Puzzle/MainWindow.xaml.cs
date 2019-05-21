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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Puzzle
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        private Game game = new Game();
        private Image origen;

        public Window1()
        {
            InitializeComponent();
        }

        private void btnPlay_Click(object sender, RoutedEventArgs e)
        {
            game.newGame(gridMatriz);
            game.setNoneImage(pzaLibre);
        }

        private void pza_Drop(object sender, DragEventArgs e)
        {
            Image img = e.Source as Image;

            //Si control origen es diferente al destino
            if (img != origen)
            {
                //Si control destino no esta ocupado
                if (String.Compare(img.Source + "", game.noimage) == 0)
                {
                    //obtiene el valor de data (source de la imagen) y asigna a la Image destino
                    img.Source = (BitmapSource)e.Data.GetData(DataFormats.Text);
                    //a la Image fuente, se le coloca una imagen en blanco
                    game.setNoneImage(origen);
                }
            }

        }

        private void pza_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Image img = e.Source as Image;
            origen = img;
            //Coloca el Source de la imagen en data de tipo DataObject que permite la transferencia de datos
            DataObject data = new DataObject(DataFormats.Text, img.Source);
            //Inicia una operación de arrastrar y colocar donde
            //e.Source = Una referencia al objeto de dependencia que es el origen de datos que se arrastran.
            //data = variable que contiene los datos que se arrastran
            //DragDropEffects = Especifica la operacion de arrastrar y colocar, en este caso es un COPY
            DragDrop.DoDragDrop((DependencyObject)e.Source, data, DragDropEffects.Copy);
        }
    }
}