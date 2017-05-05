// 结构可以声明构造函数，但它们必须带参数。声明结构的默认（无参数）构造函数是错误的
// 对于结构，不像类那样存在继承。一个结构不能从另一个结构或类继承，而且不能作为一个类的基。
// 但是，结构从基类对象继承

//可以使用 StructLayout(LayoutKind.Explicit) 和 FieldOffset 属性创建在 C/C++ 中称为联合的布局方式。

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace CsharpExample
{
    interface IBase
    {
        void Add();
    }
    struct StrcutData: IBase
    {

        private int age;
        private string name;

        public void Add()
        {
            throw new NotImplementedException();
        }
        void StructData()
        {
        }
    }

    [StructLayout(LayoutKind.Explicit)]
    struct TestUnion
    {
        [FieldOffset(0)]
        public uint value;
        [FieldOffset(0)]
        public byte p1;
        [FieldOffset(1)]
        public byte p2;
        [FieldOffset(2)]
        public byte p3;
        [FieldOffset(3)]
        public byte p4;
    }

    class StrcutExample : Instance<StrcutExample>
    {
        override public void Show()
        {
            TestUnion data;

            data.value = 0;
            data.p1 = 1;
            data.p2 = 1;
            data.p3 = 1;
            data.p4 = 1;

            Console.WriteLine("value={0},[{1}][{2}][{3}][{4}]",data.value,data.p1, data.p3, data.p2, data.p4);
        }
    }
}
