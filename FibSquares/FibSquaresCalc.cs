using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FibSquares
{
    public class FibSquares
    {
        public List<SquareData> Calculate(float limitX, float limitY)
        {
            List<SquareData> result = new List<SquareData>();
            MinMaxXY mmNew;
            MinMaxXY mm = new MinMaxXY();

            // Start by generating squares around (0,0)
            for(int i=0; ; i++)
            {
                int size = 0;
                SquareData sd = MakeSquare( i % 4, size, mm);

                mmNew = UpdateMinMax(sd, mm);
                if( (mmNew.MaxX - mmNew.MinX > limitX) || (mmNew.MaxY - mmNew.MinY > limitY) )
                {
                    break; // We've already reached the limit.  Quit.
                }
                else
                {
                    mm = mmNew;
                    result.Add(sd);
                }
            }

            // Now shift everything so that no negative values exist
            float shiftX = (mm.MinX < 0) ? -mm.MinX : 0;
            float shiftY = (mm.MinY < 0) ? -mm.MinY : 0;
            foreach( var sd in result )
            {
                sd.Left += shiftX;
                sd.Top += shiftY;
            }
            
            return result;
        }

        private MinMaxXY UpdateMinMax( SquareData sd, MinMaxXY old )
        {
            MinMaxXY neu = new MinMaxXY();

            neu.MinX = (sd.Left < old.MinX) ? sd.Left : old.MinX;
            neu.MaxX = (sd.Left + sd.Size > old.MaxX) ? (sd.Left + sd.Size) : old.MaxX;

            neu.MinY = (sd.Top < old.MinY) ? sd.Top : old.MinY;
            neu.MaxY = (sd.Top + sd.Size > old.MaxY) ? (sd.Top + sd.Size) : old.MaxY;

            return neu;
        }

        private SquareData MakeSquare( int direction, int size, MinMaxXY mmxy)
        {
            SquareData sd = new SquareData();


            return sd;
        }

    }
}
