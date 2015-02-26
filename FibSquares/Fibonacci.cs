using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FibSquares
{
    public class Fibonacci : IEnumerable<int>, IEnumerator<int>
    {
        private int first = 1;
        private int second = 1;
        private int walkCount = 0;



        public IEnumerator<int> GetEnumerator()
        {
            return new Fibonacci();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }



        public int Current
        {
            get 
            {
                if (walkCount >= 2)
                {
                    return first + second;
                }
                else
                {
                    return 1;
                }
            }
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
            walkCount++;
            if (walkCount >= 2)
            {
                int val = first + second;
                first = second;
                second = val;
            }
            return true;
        }

        public void Reset()
        {
            walkCount  = 0;
        }
    }
}
