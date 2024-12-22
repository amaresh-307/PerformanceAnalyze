
using BenchmarkDotNet.Running;
using System.Diagnostics;

namespace BenchMarking
{
    internal class PerformanceAnalyzer(int[] input)
    {
        //IMP: Make sure to create new instance of input array and pass to the corresponding methods to avoid passing a previously sorted array
        public void Analyze()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            //Cyclet sort
            Stopwatch cycleSortTimer = new();
            var arrayToCycleSort = (int[])input.Clone();
            cycleSortTimer.Start();
            SortManager.CycleSort(arrayToCycleSort, input.Length);
            cycleSortTimer.Stop();
            Console.WriteLine($"Mechanism: 🚲 Sort | Time taken: {cycleSortTimer.ElapsedMilliseconds}ms \n");


            //Quick sort with Hoare partition
            Stopwatch hoareQuickSortTimer = new();
            var arrayToHoareQuickSort = (int[])input.Clone();
            hoareQuickSortTimer.Start();
            SortManager.QuickSortWithHoarePartition(arrayToHoareQuickSort, 0, input.Length - 1);
            hoareQuickSortTimer.Stop();
            Console.WriteLine($"Mechanism: {nameof(SortManager.QuickSortWithHoarePartition)} | Time taken: {hoareQuickSortTimer.ElapsedMilliseconds}ms \n");


            //Quick sort with Lomuto partition
            Stopwatch lomutoQuickSortTimer = new();
            var arrayToQuickSort = (int[])input.Clone();
            lomutoQuickSortTimer.Start();
            SortManager.QuickSortWithLomutoPartition(arrayToQuickSort, 0, input.Length - 1);
            lomutoQuickSortTimer.Stop();
            Console.WriteLine($"Mechanism: {nameof(SortManager.QuickSortWithLomutoPartition)} | Time taken: {lomutoQuickSortTimer.ElapsedMilliseconds}ms \n");


            //Merge sort
            Stopwatch mergeSortTimer = new();
            var arrayToMergeSort = (int[])input.Clone();
            mergeSortTimer.Start();
            SortManager.MergeSort(arrayToMergeSort,0, input.Length - 1);
            mergeSortTimer.Stop();
            Console.WriteLine($"Mechanism: {nameof(SortManager.MergeSort)} | Time taken: {mergeSortTimer.ElapsedMilliseconds}ms \n");

            //Selection sort
            Stopwatch insertionSortTimer = new();
            var arrayToSort = (int[])input.Clone();
            insertionSortTimer.Start();
            SortManager.InsertionSort(arrayToSort, input.Length);
            insertionSortTimer.Stop();
            Console.WriteLine($"Mechanism: {nameof(SortManager.InsertionSort)} | Time taken: {insertionSortTimer.ElapsedMilliseconds}ms \n");

            //Selection sort
            Stopwatch selectionSortTimer = new();
            var arrayToSelSort = (int[])input.Clone();
            selectionSortTimer.Start();
            SortManager.SelectionSort(arrayToSelSort, input.Length);
            selectionSortTimer.Stop();
            Console.WriteLine($"Mechanism: {nameof(SortManager.SelectionSort)} | Time taken: {selectionSortTimer.ElapsedMilliseconds}ms \n");

            //Bubble sort
            Stopwatch bubbleSortTimer = new();
            var arrayToBubbleSort = (int[])input.Clone();
            bubbleSortTimer.Start();
            SortManager.BubbleSort(arrayToBubbleSort, input.Length);
            bubbleSortTimer.Stop();
            Console.WriteLine($"Mechanism: {nameof(SortManager.BubbleSort)} | Time taken: {bubbleSortTimer.ElapsedMilliseconds}ms \n");

            Console.ForegroundColor = ConsoleColor.White;
        }

    }
}
