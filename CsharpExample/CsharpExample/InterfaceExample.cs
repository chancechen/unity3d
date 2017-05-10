
//实现接口的类可以显式实现该接口的成员。当显式实现某成员时，[[不能通过类实例访问该成员，而只能通过该接口的实例访问该成员]]。

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpExample
{
    interface IDimensions
    {
        float Length();
        float Width();
    }

    // Declare the metric units interface:
    interface IMetricDimensions
    {
        float Length();
        float Width();
    }

    class Box : IDimensions, IMetricDimensions
    {
        float lengthInches;
        float widthInches;

        public Box(float length, float width)
        {
            lengthInches = length;
            widthInches = width;
        }
        // Explicit interface member implementation: 
        float IDimensions.Length()
        {
            return lengthInches;
        }
        // Explicit interface member implementation:
        float IDimensions.Width()
        {
            return widthInches;
        }
        // Explicitly implement the members of IMetricDimensions:
        float IMetricDimensions.Length()
        {
            return lengthInches * 2.54f;
        }
        float IMetricDimensions.Width()
        {
            return widthInches * 2.54f;
        }
    }

    class InterfaceExample:Instance<InterfaceExample>
    {
        public override void Show()
        {
            // Declare a class instance "myBox":
            Box myBox = new Box(30.0f, 20.0f);
            
            // Declare an interface instance "myDimensions":
            IDimensions myDimensions = (IDimensions)myBox;
            IMetricDimensions mIMetricDimensions = (IMetricDimensions)myBox;
            // Print out the dimensions of the box:
            /* The following commented lines would produce compilation 
               errors because they try to access an explicitly implemented
               interface member from a class instance:                   */
            //System.Console.WriteLine("Length: {0}", myBox.Length());
            //System.Console.WriteLine("Width: {0}", myBox.Width());
            /* Print out the dimensions of the box by calling the methods 
               from an instance of the interface:                         */
            System.Console.WriteLine("Length: {0}", myDimensions.Length());
            System.Console.WriteLine("Width: {0}", myDimensions.Width());

            System.Console.WriteLine("Length: {0}", mIMetricDimensions.Length());
            System.Console.WriteLine("Width: {0}", mIMetricDimensions.Width());
        }
    }
}
