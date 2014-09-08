using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1DV402.S1.L03C
{
    static class MyExtensions
    {
        public static int Dispersion(this int[] source)
        {
            return source.Max() - source.Min();
        }

        public static int Median(this int[] source)
        {
            var query = from number in source orderby number select number;
            int[] sortedSource = query.ToArray();
            if (sortedSource.Length % 2 > 0)
            {
                return sortedSource[(sortedSource.Length / 2)];
            }
            else
            {
                return (sortedSource[sortedSource.Length / 2 - 1] +
                    sortedSource[sortedSource.Length / 2]) / 2;
            }
        }
    }
}