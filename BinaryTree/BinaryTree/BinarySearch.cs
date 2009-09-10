using System;

namespace BinaryTree
{
    public class BinarySearch
    {
        public int Chop(int valueToFind, int[] dataToSearch)
        {
            if (dataToSearch.Length == 0) return -1;

            var index = -1;
            var lhs = 0;
            var rhs = dataToSearch.Length - 1;
            var completed = false;
            var offset = 0;

            while (!completed)
            {
                var mid = ((rhs - lhs) / 2) + offset;

                if (dataToSearch[mid] == valueToFind)
                {
                    index = mid;
                    break;
                }

                if (rhs - lhs == 0 || (lhs > rhs))
                {
                    completed = true;
                }

                if (valueToFind < dataToSearch[mid]) 
                {
                    lhs = offset;
                    rhs = mid - 1;
                } 
                else 
                {
                    offset = mid + 1;
                    lhs = mid + 1;
                    rhs = dataToSearch.Length - 1;
                }

            }

            return index;
        }
    }
}




