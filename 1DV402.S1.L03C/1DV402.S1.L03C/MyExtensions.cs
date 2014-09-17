using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1DV402.S1.L03C
{
    static class MyExtensions
    {
        /// <summary>
        /// Counts the dispersion of the given values
        /// </summary>
        /// <param name="source">An array of int values</param>
        /// <returns>The dispersion of the values as an int</returns>
        public static int Dispersion(this int[] source)
        {
            return source.Max() - source.Min();
        }

        /// <summary>
        /// Counts the median of the given values
        /// </summary>
        /// <param name="source">An array of int values </param>
        /// <returns>The median of the values as an int</returns>
        public static int Median(this int[] source)
        {
            var query = from number in source orderby number select number;
            int[] sortedSource = query.ToArray();
            if (sortedSource.Length % 2 > 0) //if the array contains an uneven number of values
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