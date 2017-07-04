using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    /// <summary>
    /// The class helps to get diferrent info about array.
    /// </summary>
    public static class IntArraySearcher
    {
        /// <summary>
        /// The method searches the index of an element where the sum before 
        /// equals to the sum after the element in the array.
        /// </summary>
        /// <param name="arr">
        /// The one-dimensional int array where we search our element.
        /// </param>
        /// <returns>
        /// Index where the sum before equals to the sum after element.
        /// </returns>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        public static int GetIndexLRSumEquals(int[] arr)
        {
            if (arr == null)
                throw new ArgumentNullException();

            if (arr.Length < 3 || arr.Length >= 1000)
                throw new ArgumentException();

            int sum = arr.Sum();

            int i, currSum = 0;
            for (i = 0; i < arr.Length - 1; i++)
            {
                currSum += arr[i];
                if ((currSum * 2 + arr[i + 1]) == sum)
                    return i + 1;
            }

            return -1;
        }
    }


}
