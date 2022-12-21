using System;
using System.Collections.Generic;


namespace InsertionSort
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = new List<int>(){ 3, 18, 7, 2, 7, 4, 1, 9, 6, 11, 10 };
            Console.WriteLine("Nums before Sorting:");
            foreach (int i in nums) Console.Write(i + " ");

            Console.WriteLine();
            Console.WriteLine("----------------------");

            InsertionSort(nums);

            Console.WriteLine("Nums After Sorting:");
            foreach (int i in nums) Console.Write(i + " ");

        }

        static void InsertionSort(List<int> nums)
        {
            int val = 0;
            for (int i = 1; i < nums.Count; i++)
            {
                val = nums[i];
                for (int j = i - 1; j >= 0; j--)
                {
                    if (nums[j] > val)
                    {
                        nums[j + 1] = nums[j];
                        nums[j] = val;
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }

    }


}
