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
            ArgsExample.ForeachShowArgs(args);
            ArgsExample.ForShowArgs(args);

            ArrayExgample.ForeachShowArray2();

            PropertyExample.GetInstance().Age = 100;
            PropertyExample.GetInstance().Name = "Chen Chaozhong";

            PropertyExample.GetInstance().Show();
            ClassVersion.GetInstance().Show();
            ForeachClass.GetInstance().Show();
            StrcutExample.GetInstance().Show();
            Indexer.GetInstance().Show();
            IndexerProperty.GetInstance().Show();
            RomanNumerial.GetInstance().Show();
            OperatorExample.GetInstance().Show();
            DelegateExample.GetInstance().Show();
        }
    }
}
