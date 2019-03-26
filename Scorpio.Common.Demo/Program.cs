using Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Scorpio.Common.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] aa = SortHelper.RandomSet(100, 99999);
            //int[] aa = SortHelper.OrderedSet(5000);
            Console.WriteLine("Array Length:" + aa.Length);
            SortHelper.RunTheMethod((Action<IList<int>>)SortHelper.SelectSort, aa.Clone() as int[]);
            SortHelper.RunTheMethod((Action<IList<int>>)SortHelper.BubbleSort, aa.Clone() as int[]);
            SortHelper.RunTheMethod((Action<IList<int>>)SortHelper.BubbleSortImprovedWithFlag, aa.Clone() as int[]);
            SortHelper.RunTheMethod((Action<IList<int>>)SortHelper.BubbleCocktailSort, aa.Clone() as int[]);
            SortHelper.RunTheMethod((Action<IList<int>>)SortHelper.InsertSort, aa.Clone() as int[]);
            SortHelper.RunTheMethod((Action<IList<int>>)SortHelper.InsertSortImprovedWithBinarySearch, aa.Clone() as int[]);
            SortHelper.RunTheMethod((Action<IList<int>>)SortHelper.QuickSortStrict, aa.Clone() as int[]);
            SortHelper.RunTheMethod((Action<IList<int>>)SortHelper.QuickSortRelax, aa.Clone() as int[]);
            SortHelper.RunTheMethod((Action<IList<int>>)SortHelper.QuickSortRelaxImproved, aa.Clone() as int[]);
            SortHelper.RunTheMethod((Func<IList<int>, IList<int>>)SortHelper.MergeSort, aa.Clone() as int[]);
            SortHelper.RunTheMethod((Action<IList<int>>)SortHelper.ShellSort, aa.Clone() as int[]);
            SortHelper.RunTheMethod((Func<IList<int>, IList<int>>)SortHelper.RadixSort, aa.Clone() as int[]);
            SortHelper.RunTheMethod((Action<IList<int>>)SortHelper.HeapSort, aa.Clone() as int[]);
            SortHelper.TestMicrosoft(aa.Clone() as int[]);
            Console.Read();
        }


    }
}
