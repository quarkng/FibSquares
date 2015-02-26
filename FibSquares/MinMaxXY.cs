using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FibSquares
{
    public class MinMaxXY
    {
        public float MinX { get; set; }
        public float MaxX { get; set; }
        public float MinY { get; set; }
        public float MaxY { get; set; }
        
        public MinMaxXY()
        {
            MinX = MaxX = MinY = MaxY = 0;
        }
    }
}
