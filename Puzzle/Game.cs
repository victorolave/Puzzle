using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Puzzle
{
    class Game
    {
        public string noimage = "pack://application:,,,/Puzzle;component/piezas/noimage.jpg";

        //Crea un puzzle desordenado

        public void newGame(Grid g)
        {
            //obtiene lista desordenada
            ArrayList list = generateGame();
            //obtiene los Image
            var pics = g.Children.OfType<Image>();
            int count = 0;
            //coloca imagenes
            foreach (Image i in pics)
            {
                BitmapImage img = new BitmapImage();
                img.BeginInit();
                img.UriSource = new Uri(@"pack://application:,,,/Puzzle;component/piezas/" + list[count] + ".jpg");
                img.EndInit();
                i.Source = img;
                count++;
            }
        }

    //Coloca la imagen "noimage" a un control Image 
        public void setNoneImage(Image i)
        {
            BitmapImage img = new BitmapImage();
            img.BeginInit();
            img.UriSource = new Uri(@"pack://application:,,,/Puzzle;component/piezas/noimage.jpg");
            img.EndInit();
            i.Source = img;
        }


        /*Retorna un arraylist con numeros del 1 al 24 desordenados
        que corresponde a cada una de las piezas del puzzle*/

        private ArrayList generateGame()
        {
            ArrayList ar = new ArrayList();
            for (int rr = 1; rr <= 24; rr++)
                ar.Add(rr);
            ArrayList arrDes = new ArrayList();
            Random randNum = new Random();
            while (ar.Count > 0)
            {
                int val = randNum.Next(0, ar.Count - 1);
                arrDes.Add(ar[val]);
                ar.RemoveAt(val);
            }
            return arrDes;
        }
    }
}