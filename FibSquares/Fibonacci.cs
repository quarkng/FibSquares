using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FibSquares
{
    public static class Fibonacci
    {
        public static IEnumerable<int> Sequence()
        {
            int first = 1;
            int second = 1;

            yield return first;
            yield return second;

            // this enumerable sequence is bounded by the caller.
            while (true)
            {
                int current = first + second;
                yield return current;

                // wind up for next number if we're requesting one
                first = second;
                second = current;
            }
        }
    }
}
