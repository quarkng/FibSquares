using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace FibSquares
{
    class ColorsGen : IEnumerable<Color>, IEnumerator<Color>
    {
        private Color currentColor;
        private int counter;

        private static Color[] colorArray = { Colors.Red, Colors.Blue, Colors.Yellow, Colors.Green, Colors.Maroon, 
                                                Colors.LightSkyBlue, Colors.MediumPurple, Colors.Navy, Colors.NavajoWhite, Colors.MistyRose };



        public ColorsGen()
        {
            counter = 0;
            MoveNext();
        }

        //======= IEnumerable

        public IEnumerator<Color> GetEnumerator()
        {
            return new ColorsGen();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        //======== IEnumerator

        public Color Current
        {
            get { return currentColor; }
        }

        public void Dispose()
        {
        }

        object System.Collections.IEnumerator.Current
        {
            get { return this.Current; }
        }



        public bool MoveNext()
        {
            counter++;

            if (counter >= colorArray.Length)
            {
                counter = 0;
            }
            currentColor = colorArray[counter];

            return true;
        }

        public void Reset()
        {
            counter = 0;
            MoveNext();
        }
    }
}
