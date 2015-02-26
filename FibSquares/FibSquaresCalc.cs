using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace FibSquares
{
    public class FibSquaresCalc
    {
        public List<SquareData> Calculate(float limitX, float limitY)
        {
            List<SquareData> result = new List<SquareData>();
            Fibonacci fib = new Fibonacci();
            ColorsGen colGen = new ColorsGen();

            MinMaxXY mmNew;
            MinMaxXY mm = new MinMaxXY();

            // Start by generating squares around (0,0)
            for(int i=0; ; i++)
            {
                int size = fib.Current;
                fib.MoveNext();

                SquareData sd = MakeSquare( i % 4, size, mm);

                sd.Fill = colGen.Current;
                colGen.MoveNext();


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

            sd.Size = size;
            
            switch( direction )
            {
                case 0: // up
                    sd.Left = mmxy.MinX;
                    sd.Top = mmxy.MinY - size;
                    sd.Fill = Colors.Green;
                    break;

                case 1: // left
                    sd.Left = mmxy.MinX - size;
                    sd.Top = mmxy.MinY;
                    sd.Fill = Colors.Red;
                    break;

                case 2: // down
                    sd.Left = mmxy.MinX;
                    sd.Top = mmxy.MaxY;
                    sd.Fill = Colors.Blue;
                    break;

                case 3: // right
                    sd.Left = mmxy.MaxX;
                    sd.Top = mmxy.MinY;
                    sd.Fill = Colors.Yellow;
                    break;

                default:
                    throw new Exception("Unknown direction value");
            }


            return sd;
        }

    }
}
