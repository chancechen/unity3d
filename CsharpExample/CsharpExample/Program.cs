using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpExample
{
    class Program
    {
        
        static void Main(string[] args)
        {
            //ArgsExample.ForeachShowArgs(args);
            //ArgsExample.ForShowArgs(args);

            //ArrayExgample.ForeachShowArray2();

            //PropertyExample.GetInstance().Age = 100;
            //PropertyExample.GetInstance().Name = "Chen Chaozhong";
            //PropertyExample.GetInstance().Show();
            //ClassVersion.GetInstance().Show();
            //ForeachClass.GetInstance().Show();
            //StrcutExample.GetInstance().Show();
            //Indexer.GetInstance().Show();
            //IndexerProperty.GetInstance().Show();
            //RomanNumerial.GetInstance().Show();
            //OperatorExample.GetInstance().Show();
            //DelegateExample.GetInstance().Show();
            //EventExample.GetInstance().Show();
            //InterfaceExample.GetInstance().Show();
            //ConditionalExample.GetInstance().Show();

            Dictionary<int, int> map = new Dictionary<int, int>()
            {
                {10,10 },
                {50,10 },
                {70,10 },
                {40,10 },
                {20,10 },
                {60,10 },
                {30,10 }
            };

            List<KeyValuePair<int, int>> list=new List<KeyValuePair<int, int>>(map);
            list.Sort((a,b)=> {
                return a.Key > b.Key?1:-1;
            });


            foreach (KeyValuePair<int,int> it in list)
            {
                Console.WriteLine(it.Key);
            }
            List<int> alist = new List<int>() { 1,9,8,6,7,4,2,3};
            alist.Sort((a,b)=> { return a < b?1:-1; });
            foreach (int it in alist)
            {
                Console.WriteLine(it);
            }
        }
    }
}
