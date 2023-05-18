using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prgConCsFunctions
{
    public static class TheComparator
    {
        static void DisplayTitle()
        {
            Console.WriteLine("\tTHE COMPARATOR");
            Console.WriteLine("\t--------------\n");
        }

        static Int16 ReadValue(Int16 number)
        {
            Int16 value;
            Console.Write($"Enter value {number}: ");
            value = Convert.ToInt16(Console.ReadLine());
            return value;
        }

        static Int16 FindMax(Int16 value1, Int16 value2)
        {
            return (value1 > value2) ? value1 : value2;
        }

        static void DisplayResult(Int16 value)
        {
            Console.WriteLine($"The maximum is {value}");
        }

        public static void Start()
        {
            // long version

            //// variable declaration for main function
            //Int16 val1, val2, max;

            //// call function to display title
            //DisplayTitle();

            //// call function to read value
            //val1 = ReadValue(1);
            //val2 = ReadValue(2);

            //// call function to determine max
            //max = FindMax(val1, val2);

            //// call function to display result
            //DisplayResult(max);

            // the shorter version
            DisplayTitle();
            DisplayResult(FindMax(ReadValue(1), ReadValue(2)));
        }
    }
}
