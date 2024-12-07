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
        [Params(100)]
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
    }
}
