using System;

namespace BinaryTree
{
    public class BinarySearch
    {
        const int ItemNotFoundIndex = -1;

        public int Chop(int valueToFind, int[] dataToSearch)
        {
            var currentPosition = 1;

            if (dataToSearch.Length == 0) return ItemNotFoundIndex; // Possibly redundant

            if (dataToSearch.Length == 1)
            {
                return dataToSearch[0] != valueToFind ? ItemNotFoundIndex : 0;
            }

            if (dataToSearch.Length % 2 == 0) // even number of elements
            {
                var lhs = new int[dataToSearch.Length/2];
                Array.Copy(dataToSearch, 0, lhs, 0, dataToSearch.Length/2);

                var rhs = new int[dataToSearch.Length/2];
                Array.Copy(dataToSearch, dataToSearch.Length/2, rhs, 0, dataToSearch.Length/2);

                if (lhs[lhs.Length - 1] == valueToFind)
                {
                    currentPosition += lhs[lhs.Length - 1];
                }
                else if (lhs[lhs.Length - 1] < valueToFind) // value we want is in LHS 
                {
                    var pos = Chop(valueToFind, lhs);
                    if (pos != ItemNotFoundIndex) currentPosition += pos;
                }
                else
                {
                    var pos = Chop(valueToFind, rhs);
                    if (pos != ItemNotFoundIndex) currentPosition -= pos;
                }
            }
            else // odd number of elements
            {
                var lhs = new int[dataToSearch.Length/2 + 1];
                Array.Copy(dataToSearch, 0, lhs, 0, dataToSearch.Length/2 + 1);

                var rhs = new int[dataToSearch.Length/2];
                Array.Copy(dataToSearch, dataToSearch.Length/2, rhs, 0, dataToSearch.Length/2);

                if (lhs[lhs.Length - 1] == valueToFind) {
                    currentPosition += lhs[lhs.Length - 1];
                } 
                else if (lhs[lhs.Length - 1] < valueToFind) // value we want is in LHS 
                {
                    var pos = Chop(valueToFind, rhs);
                    if (pos != ItemNotFoundIndex) currentPosition += pos;
                }
                else
                {
                    var pos = Chop(valueToFind, lhs);
                    if (pos != ItemNotFoundIndex) currentPosition += pos;
                }
            }

            return currentPosition;
        }
    }
}