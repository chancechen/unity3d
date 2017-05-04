
//在 C# 中，默认情况下方法不是虚拟的。若要使方法成为虚拟方法，必须在基类的方法声明中使用 virtual 修饰符。
//然后，派生类可以使用 override 关键字重写基虚拟方法，或使用 new 关键字隐藏基类中的虚拟方法。
//如果 override 关键字和 new 关键字均未指定，编译器将发出警告，并且派生类中的方法将隐藏基类中的方法。

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpExample
{
    class ClassVersion
    {
        public virtual string Meth1()
        {
            return "MyBase-Meth1";
        }
        public virtual string Meth2()
        {
            return "MyBase-Meth2";
        }
        public virtual string Meth3()
        {
            return "MyBase-Meth3";
        }


        private static Version1 instance;

        public static Version1 GetInstance()
        {
            return instance == null ? instance = new Version1() : instance;
        }

        public void Show()
        {

            ClassVersion child = (ClassVersion)instance;

            Console.WriteLine(child.Meth1());
            Console.WriteLine(child.Meth2());
            Console.WriteLine(child.Meth3());
        }
    }

    class Version1 : ClassVersion
    {
        // Overrides the virtual method Meth1 using the override keyword:
        public override string Meth1()
        {
            return "MyDerived-Meth1";
        }
        // Explicitly hide the virtual method Meth2 using the new
        // keyword:
        public new string Meth2()
        {
            return "MyDerived-Meth2";
        }

    }    
}
