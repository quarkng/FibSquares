using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace FibSquares
{
    public class SquareData
    {
        public int Left { get; set; }
        public int Top { get; set; }
        public int Size { get; set; } // Width & Height
        public Color Fill { get; set; }
    }
}
