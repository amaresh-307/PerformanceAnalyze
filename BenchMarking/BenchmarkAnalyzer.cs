using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenchMarking
{
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
        public void AnalyzeBubbleSort()
        {
            SortManager.BubbleSort(InputArray, InputArray.Length);
        }
        [Benchmark]
        public void AnalyzeInsertionSort()
        {
            SortManager.InsertionSort(InputArray, InputArray.Length);
        }
        [Benchmark]
        public void AnalyzeSelectionSort()
        {
            SortManager.SelectionSort(InputArray, InputArray.Length);
        }
        [Benchmark]
        public void AnalyzeMergeSort()
        {
            SortManager.MergeSort(InputArray, 0, InputArray.Length - 1);
        }
        [Benchmark]
        public void AnalyzeQuickSortWithLomutoPartition()
        {
            SortManager.QuickSortWithLomutoPartition(InputArray, 0, InputArray.Length - 1);
        }
    }
}
