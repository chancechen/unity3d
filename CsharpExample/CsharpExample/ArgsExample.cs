using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpExample
{
    class ArgsExample
    {
        public static void ForeachShowArgs( string[] args)
        {
            Console.WriteLine("Number of command line parameters = {0}", args.Length);

            foreach (var param in args)
            {
                Console.WriteLine(param );
            }
        }

        public static void ForShowArgs(string[] args)
        {
            Console.WriteLine("Number of command line parameters = {0}", args.Length);

            for (int i = 0; i < args.Length; i++)
            {
                Console.WriteLine("Arg[{0}] = [{1}]", i, args[i]);
            }
        }
    }
}
