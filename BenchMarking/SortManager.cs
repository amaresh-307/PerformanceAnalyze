
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
                while (j >= 0 && nums[j] > key)
                {
                    nums[j + 1] = nums[j];
                    j--;
                }
                nums[j + 1] = key;
            }
            return nums;
        }

        #region Merge Sort
        public static int[] MergeSort(int[] nums, int left, int right)
        {
            if(left < right)
            {
                int mid = (right + left) / 2;
                MergeSort(nums, left, mid);
                MergeSort(nums, mid+1, right);
                Merge(nums, left, mid, right);
            }
            return nums;
        }
        public static void Merge(int[] nums, int left, int mid, int right)
        {
            int[] leftArr = new int[mid - left + 1];
            int[] rightArr = new int[right - mid];
            for (int i = 0; i < leftArr.Length; i++)
            {
                leftArr[i] = nums[left+i];
            }
            for (int j = 0; j < rightArr.Length; j++)
            {
                rightArr[j] = nums[leftArr.Length + j];
            }
            int m = 0; int n = 0;int k = 0;
            while(m < leftArr.Length && n < rightArr.Length)
            {
                if (leftArr[m] <= rightArr[n])
                {
                    nums[k++] = leftArr[m++];
                }
                else
                {
                    nums[k++] = rightArr[n++];
                }
            }
            while(m < leftArr.Length)
            {
                nums[k++] = nums[m++];
            }
            while (m < rightArr.Length)
            {
                nums[k++] = nums[n++];
            }
        }

        #endregion Merge sort

        #region Quick Sort
        public static void QuickSortWithLomutoPartition(int[] nums, int low, int high) 
        {
            if(low < high)
            {
               int pivotPosition = LomutoPartition(nums, low, high);
                QuickSortWithLomutoPartition(nums, low, pivotPosition - 1);
                QuickSortWithLomutoPartition(nums, pivotPosition + 1, high);
            }
        }

        public static void QuickSortWithHoarePartition(int[] nums, int low, int high)
        {
            if (low < high)
            {
                int middle = HoarePartition(nums, low, high); //does not return the pivot position
                QuickSortWithHoarePartition(nums, low, middle);
                QuickSortWithHoarePartition(nums, middle + 1, high);
            }
        }

        //461,3,4,1,45,2,53
        public static int LomutoPartition(int[] nums, int low, int high) {
            int i = low - 1;
            int pivot = nums[high];

            for(int j = low;j <= high-1;j++)
            {
                if (nums[j] < pivot)
                {
                    i++; // If a smaller element is found then increase the size of smaller elements' window and swap.
                    (nums[i], nums[j]) = (nums[j], nums[i]);
                }
            }
            (nums[i+1], nums[high]) = (nums[high], nums[i+1]); // put the pivot in correct place i.e, after the smaller elements.
            return i+1;
        }

        //5,461,3,4,1,45,2,53
        public static int HoarePartition(int[] nums, int low, int high)
        {
            int i = low - 1;int j = high + 1;
            int pivot = nums[low];

            while(true)
            {
                do
                {
                    i++;
                } while (nums[i] < pivot);
                do
                {
                    j--;
                } while (nums[j] > pivot);
                if (i >= j) return j;
                (nums[i], nums[j]) = (nums[j], nums[i]);
            }
        }

        #endregion Quick Sort

        #region Cycle Sort

        public static int[] CycleSort(int[] nums, int n)
        {
            for (int cstart = 0; cstart < n - 1; cstart++)
            {
                int item = nums[cstart];
                int pos = cstart;
                for (int i = cstart + 1; i < n; i++)
                {
                    if (nums[i] < item)
                    {
                        pos++;
                    }
                }

                if (pos == cstart) continue;

                while (nums[pos] == item)
                {
                    pos++;
                }

                if(pos != cstart)
                {
                    (item, nums[pos]) = (nums[pos], item);
                }

                while(pos != cstart)
                {
                    pos =cstart;

                    for(int i = cstart + 1;i < n;i++)
                    {
                        if (nums[i] < item) { 
                            pos++;
                        }
                    }
                    while (nums[pos] == item)
                    {
                        pos++;
                    }

                    if(item != nums[pos])
                    {
                        (item, nums[pos]) = (nums[pos], item);
                    }
                }

            }
            return nums;
        }
        #endregion

        #region Heap sort

        public static int[] HeapSort(int[] nums, int n)
        {
            BuildHeap(nums, n);
            for(int i = n - 1; i >= 1; i--)
            {
                (nums[0], nums[i]) = (nums[i], nums[0]);
                MaxHeapify(nums, i, 0);
            }
            return nums;
        } 

        public static void BuildHeap(int[] nums, int n)
        {
            for(int i = (n - 2) / 2; i >= 0; i--)
            {
                MaxHeapify(nums, n, i);
            }
        }

        public static void MaxHeapify(int[] nums, int n, int i)
        {
            int left = (2 * i) + 1;
            int right = (2 * i) + 2;
            int largest = i;
            if (left < n && nums[left] > nums[i])
            {
                largest = left;
            }
            if (right < n && nums[right] > nums[largest])
            {
                largest = right;
            }
            if (largest != i) {
                (nums[largest], nums[i]) = (nums[i], nums[largest]);
                MaxHeapify(nums,n, largest);
            }
        }

        #endregion Heap sort
    }
}
