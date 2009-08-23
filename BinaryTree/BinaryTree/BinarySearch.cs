using System;

/* Common Mistakes!!
 * 
 * order of operations when calculating the mid!! subtraction should happen before division, moron!
 * array index offsets (-1). when? where?
*/

namespace BinaryTree
{
    public class BinarySearch
    {
        public int Chop(int valueToFind, int[] dataToSearch)
        {
            var lowerBound = 0;
            var upperBound = dataToSearch.Length - 1;
            var valuePosition = -1;
            var itemOffset = 0;

            if (dataToSearch.Length == 0) return -1;

            do
            {
                var mid = ((upperBound - lowerBound) / 2) + itemOffset;

                if (valueToFind == dataToSearch[mid]) valuePosition = mid;

                if (valueToFind < dataToSearch[mid])
                {
                    lowerBound = itemOffset;
                    upperBound = mid - 1;
                }
                else if (valueToFind > dataToSearch[mid])
                {
                    itemOffset = mid + 1;
                    lowerBound = mid + 1;
                    upperBound = dataToSearch.Length - 1;
                }

            } while (valuePosition == -1 && lowerBound <= upperBound);

            return valuePosition;
        }
    }
}




