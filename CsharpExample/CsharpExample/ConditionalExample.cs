using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpExample
{
    public class Trace
    {
        [Conditional("AAAAA")]
        public static void Message(string traceMessage)
        {
            Console.WriteLine("[TRACE] - " + traceMessage);
        }
    }

    class ConditionalExample:Instance<ConditionalExample>
    {
        public override void Show()
        {
            Trace.Message("Main Starting");

            Console.WriteLine("call ConditionalExample");

            Trace.Message("Main Ending");
        }
    }
}
