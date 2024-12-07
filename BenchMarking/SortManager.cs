
using BenchmarkDotNet.Attributes;

namespace BenchMarking
{
    internal class SortManager
    {
        public static int[] BubbleSort(int[] nums, int n)
        {
            if (n < 2) return nums;

            for (int i = 0; i < n; i++)
            {
                bool swapped = false;
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (nums[j] > nums[j + 1])
                    {
                        //swap
                        (nums[j], nums[j + 1]) = (nums[j + 1], nums[j]);
                        swapped = true;
                    }
                }
                if (!swapped) return nums;
            }
            return nums;
        }

        public static int[] SelectionSort(int[] nums, int n)
        {
            if (n < 2) return nums;

            for (int i = 0; i < n - 1; i++)
            {
                int min = i;
                for (int j = i + 1; j < n; j++)
                {
                    if (nums[j] < nums[min])
                    {
                        min = j;
                    }
                }
                //swap
                (nums[min], nums[i]) = (nums[i], nums[min]);
            }
            return nums;
        }

        //46,3,4,1,45,2,53
        public static int[] InsertionSort(int[] nums, int n)
        {
            if (n < 2) return nums;

            for (int i = 1; i < n - 1; i++)
            {
                int key = nums[i];
                int j = i - 1;
                while(j >= 0 && nums[j] > key)
                {
                    nums[j + 1] = nums[j];
                    j--;
                }
                nums[j+1] = key;
            }
            return nums;
        }
    }
}
