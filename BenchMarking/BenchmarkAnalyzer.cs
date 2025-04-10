using BenchmarkDotNet.Attributes;

namespace BenchMarking
{
    [ShortRunJob]
    //[Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [MemoryDiagnoser]
    public class BenchmarkAnalyzer
    {
        //[ParamsSource(nameof(GetDynamicData))]
        public int[] InputArray;
        [Params(100)] // update the params in order to test for different numbers of elements
        public int ArraySize;

        [GlobalSetup]
        public void Setup()
        {
            InputArray = Enumerable.Range(1, ArraySize).ToArray();
            Console.WriteLine($"InputArray Length: {InputArray?.Length ?? 0}");
        }

        [Benchmark]
        public void BubbleSort()
        {
            SortManager.BubbleSort(InputArray, InputArray.Length);
        }

        [Benchmark]
        public void InsertionSort()
        {
            SortManager.InsertionSort(InputArray, InputArray.Length);
        }

        //[Benchmark(Baseline =true)]
        [Benchmark]
        public void SelectionSort()
        {
            SortManager.SelectionSort(InputArray, InputArray.Length);
        }

        [Benchmark]
        public void MergeSort()
        {
            SortManager.MergeSort(InputArray, 0, InputArray.Length - 1);
        }

        [Benchmark]
        public void QuickSort_LomutoPartition()
        {
            SortManager.QuickSortWithLomutoPartition(InputArray, 0, InputArray.Length - 1);
        }

        [Benchmark]
        public void QuickSort_HoarePartition()
        {
            SortManager.QuickSortWithHoarePartition(InputArray, 0, InputArray.Length - 1);
        }

        [Benchmark]
        public void CycleSort()
        {
            SortManager.CycleSort(InputArray, InputArray.Length);
        }
    }
}
