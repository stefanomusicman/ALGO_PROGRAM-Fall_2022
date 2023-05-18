using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prgConCsIntroduction
{
    internal class BasicOperators
    {
        static void Main(string[] args)
        {
            Single value1, value2;
            
            Console.WriteLine("     CALCULATOR");
            Console.WriteLine("     ----------");

            Console.Write("Enter value 1: ");
            value1 = Convert.ToSingle(Console.ReadLine());            
            Console.Write("Enter value 2: ");
            value2 = Convert.ToSingle(Console.ReadLine());

            Console.WriteLine("\n");
            Console.WriteLine("The addition of " + value1 + " and " + value2 + " is " + (value1 + value2));
            Console.WriteLine("The subtraction of " + value1 + " and " + value2 + " is " + (value1 - value2));
            Console.WriteLine("The multiplication of " + value1 + " and " + value2 + " is " + (value1 * value2));
            Console.WriteLine("The division of " + value1 + " and " + value2 + " is " + (value1 / value2));
            if(value1 >= value2)
            {
                Console.WriteLine("The remainder of " + value1 + " and " + value2 + " is " + (value1 % value2));
            } else
            {
                Console.WriteLine("Value1 is less than Value2 therefore cannot perform modulo");
            }

            Console.WriteLine("\n");
            Console.WriteLine("Is " + value1 + " the same as " + value2 + "?: " + (value1 == value2));
            Console.WriteLine("Is " + value1 + " different from " + value2 + "?: " + (value1 != value2));
            Console.WriteLine("Is " + value1 + " greater than or equal to " + value2 + "?: " + (value1 >= value2));
            Console.WriteLine("Is " + value1 + " less than or equal to " + value2 + "?: " + (value1 <= value2));
        }
    }
}
