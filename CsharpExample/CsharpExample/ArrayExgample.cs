using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpExample
{
    class ArrayExgample
    {
        public static int[] numbers =new int[5]{ 1, 2, 3, 4, 5 };//new定义+列表初始化
        public static string[] str = {"chen","cai" };//定义并通过列表进行初始化
        public static int[] tables=  { 1, 2, 3, 4, 5 };//数组
        public static string[,] names= { { "Mike", "Amy" }, { "Mary", "Albert" } };//多维数组
        public static int[,] numbers2 = new int[5,2] { { 1, 2 }, { 2, 9 }, { 3, 4 }, { 4, 10 }, { 5, 1000 } };//new定义+列表初始化       

        public static string[][] name1 = { new string[] { "aaaa","bbbbbb"}, new string[] { "aaaa", "bbbbbb" } };//数组的数组（交错的）
        public static byte[][] scores= { new byte[] {1,2 },new byte[] {1,100 } };//数组的数组（交错的）


        public static void ForeachShowArray2()
        {
            foreach (int i in numbers2)
            {
                Console.Write("{0} ", i);
            }
        }
    }
}
