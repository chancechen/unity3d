//foreach 语句是循环访问数组元素的方便方法。如果集合类已实现 System.Collections.IEnumerator 
//和 System.Collections.IEnumerable 接口，它还可以枚举该集合的元素。

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpExample
{
    class ForeachClass : IEnumerable
    {
        private string[] elements;

        ForeachClass(string source, char[] delimiters)
        {
            // Parse the string into tokens:
            elements = source.Split(delimiters);
        }

        public IEnumerator GetEnumerator()
        {
            return new TokenEnumerator(this);
        }

        // Inner class implements IEnumerator interface:
        private class TokenEnumerator : IEnumerator
        {
            private int position = -1;
            private ForeachClass t;

            public TokenEnumerator(ForeachClass t)
            {
                this.t = t;
            }

            // Declare the MoveNext method required by IEnumerator:
            public bool MoveNext()
            {
                if (position < t.elements.Length - 1)
                {
                    position++;
                    return true;
                }
                else
                {
                    return false;
                }
            }

            // Declare the Reset method required by IEnumerator:
            public void Reset()
            {
                position = -1;
            }

            // Declare the Current property required by IEnumerator:
            public object Current
            {
                get
                {
                    return t.elements[position];
                }
            }
        }
        
        private static ForeachClass instance;

        public static ForeachClass GetInstance()
        {
            return instance == null ? instance = new ForeachClass("This is a well-done program.",new char[] { ' ', '-' }) : instance;
        }

        public void Show()
        {
            Console.WriteLine("example for foreach class:");
            foreach (string item in instance)
            {
                Console.WriteLine(item );
            }
            Console.WriteLine();
        }
    }
}
