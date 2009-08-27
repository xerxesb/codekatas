using System;

/* Common Mistakes!!
 * 
 * order of operations when calculating the mid!! subtraction should happen before division, moron!
 * array index offsets (-1). when? where?
 * Middle of the segment needs to be determined based on the upper and lower bounds, NOT length of array
 * Dont need to set the upper/lower bound for each criteria - 
 *      only update the upper bound when number in lower segment
 *      only update the lower bound (and offset) when number in upper segment
 *      
 * When the number is in the lower segment, we want to update the upperbound to the mid - 1
 * WHen the number is in the upper segment, we want to update the lowerbound to the mid + 1
*/

namespace BinaryTree
{
    public class BinarySearch
    {
        private const int ItemNotFound = -1;

        public int Chop(int valueToFind, int[] dataToSearch)
        {
            var lowerBound = 0;
            var upperBound = dataToSearch.Length - 1;
            var positionInArray = ItemNotFound;
            var offset = 0;

            while (upperBound >= lowerBound && positionInArray == ItemNotFound)
            {
                var mid = ((upperBound - lowerBound) / 2) + offset;

                if (valueToFind < dataToSearch[mid])
                {
                    upperBound = mid - 1;
                }
                else if (valueToFind > dataToSearch[mid])
                {
                    lowerBound = offset = mid + 1;
                }
                else
                {
                    positionInArray = mid;
                }
            }

            return positionInArray;
        }
    }
}




