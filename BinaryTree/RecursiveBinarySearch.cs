using System;

namespace BinaryTree
{
    // why no generic type inference on new ArraySegment?


    public class RecursiveBinarySearch : IBinarySearch
    {
        public const int ItemNotFound = -1;

        public int Chop(int valueToFind, int[] dataToSearch)
        {
            var mid = dataToSearch.Length / 2;
            var offset = 0;
            var foundInPosition = ItemNotFound;

            if (dataToSearch.Length == 0) return ItemNotFound;
            if (dataToSearch.Length == 1 && dataToSearch[0] != valueToFind) return ItemNotFound;

            var midpointValue = dataToSearch[mid];

            if (valueToFind == midpointValue) return mid;
            
            if (valueToFind < midpointValue)
            {
                var newArray = GetArraySegment(new ArraySegment<int>(dataToSearch, 0, mid));
                foundInPosition = Chop(valueToFind, newArray);
            }

            if (valueToFind > midpointValue)
            {
                offset = mid + 1;
                var newArray = GetArraySegment(new ArraySegment<int>(dataToSearch, mid + 1, (dataToSearch.Length - mid - 1)));

                foundInPosition = Chop(valueToFind, newArray);
            }

            return foundInPosition > -1 ? foundInPosition + offset: foundInPosition;
        }

        private int[] GetArraySegment(ArraySegment<int> arraySegment)
        {
            var newArray = new int[arraySegment.Count];
            Array.Copy(arraySegment.Array, arraySegment.Offset, newArray, 0, arraySegment.Count);
            return newArray;
        }

    }
}