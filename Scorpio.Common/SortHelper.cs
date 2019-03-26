using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class SortHelper
    {
        //int[] arr = {6, 5, 3, 1, 8, 7, 2, 4};

        public void BubbleSortSort(int[] arr)
        {
            //外层循环控制排序趟数
            for (int i = 0; i < arr.Length - 1; i++)
            {
                //内层循环控制每一趟排序多少次
                for (int j = 0; j < arr.Length - 1 - i; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }
        }
    }

}
