using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpExample
{

    struct RomanNumeral1
    {
        public RomanNumeral1(int value)
        {
            this.value = value;
        }
        // Declare a conversion from an int to a RomanNumeral. Note the
        // the use of the operator keyword. This is a conversion 
        // operator named RomanNumeral:
        static public implicit operator RomanNumeral1(int value)
        {
            // Note that because RomanNumeral is declared as a struct, 
            // calling new on the struct merely calls the constructor 
            // rather than allocating an object on the heap:
            return new RomanNumeral1(value);
        }
        // Declare an explicit conversion from a RomanNumeral to an int:
        static public explicit operator int(RomanNumeral1 roman)
        {
            return roman.value;
        }
        // Declare an implicit conversion from a RomanNumeral to 
        // a string:
        static public implicit operator string(RomanNumeral1 roman)
        {
            return ("Conversion not yet implemented");
        }

        static public implicit operator RomanNumeral1(BinaryNumeral binary)
        {
            return new RomanNumeral1((int)binary);
        }
        
        private int value;
    }

    struct BinaryNumeral
    {
        public BinaryNumeral(int value)
        {
            this.value = value;
        }
        static public implicit operator BinaryNumeral(int value)
        {
            return new BinaryNumeral(value);
        }
        static public implicit operator string(BinaryNumeral binary)
        {
            return ("Conversion not yet implemented");
        }
        static public explicit operator int(BinaryNumeral binary)
        {
            return (binary.value);
        }
        static public explicit operator RomanNumeral1(BinaryNumeral binary)
        {
            return new RomanNumeral1(binary.value);
        }
        private int value;
    }

    class RomanNumerial:Instance<RomanNumerial>
    {
        public override void Show() {
            RomanNumeral1 numeral;

            numeral = 10;

            // Call the explicit conversion from numeral to int. Because it is
            // an explicit conversion, a cast must be used:
            Console.WriteLine((int)numeral);

            // Call the implicit conversion to string. Because there is no
            // cast, the implicit conversion to string is the only
            // conversion that is considered:
            Console.WriteLine(numeral);

            // Call the explicit conversion from numeral to int and 
            // then the explicit conversion from int to short:
            short s = (short)numeral;
            Console.WriteLine(s);


            RomanNumeral1 roman;
            roman = 10;
            BinaryNumeral binary;
            // Perform a conversion from a RomanNumeral to a
            // BinaryNumeral:
            binary = (BinaryNumeral)(int)roman;
            // Performs a conversion from a BinaryNumeral to a RomanNumeral.
            // No cast is required:
            roman = binary;
            Console.WriteLine((int)binary);
            Console.WriteLine(binary);
        }
    }
}
