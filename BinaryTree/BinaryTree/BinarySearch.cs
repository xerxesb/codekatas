using System;

/* Common Mistakes!!
 * 
 * order of operations when calculating the mid!! subtraction should happen before division, moron!
 * array index offsets (-1). when? where?
 * Middle of the segment needs to be determined based on the upper and lower bounds, NOT length of array
 * Dont need to set the upper/lower bound for each criteria - 
 *      only update the upper bound when number in lower segment
 *      only update the lower bound (and offset) when number in upper segment
*/

namespace BinaryTree
{
    public class BinarySearch
    {
        private const int ItemNotFound = -1;

        public int Chop(int valueToFind, int[] dataToSearch)
        {
            var positionInArray = ItemNotFound;
            var lowerBound = 0;
            var upperBound = dataToSearch.Length - 1;
            var offset = 0;

            while (positionInArray == -1 && lowerBound <= upperBound)
            {
                var mid = ((upperBound - lowerBound) / 2) + offset;

                if (valueToFind == dataToSearch[mid]) positionInArray = mid;

                if (valueToFind < dataToSearch[mid])
                {
                    upperBound = mid - 1;
                }
                else if (valueToFind > dataToSearch[mid])
                {
                    offset = lowerBound = mid + 1;
                }
            }

            return positionInArray;
        }
    }
}




