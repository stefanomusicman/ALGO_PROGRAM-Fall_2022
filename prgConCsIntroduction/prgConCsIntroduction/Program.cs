using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prgConCsIntroduction
{
    internal class Program
    {
        static void MainProgram(string[] args)
        {
            String name;
            Int16 birthYear;
            Int16 age;
            Console.Write("\tLASALLE COLLEGE\n");
            Console.Write("\t---------------\n");
            Console.Write("Enter your name: ");
            name = Console.ReadLine();
            Console.Write("Enter your year of birth: ");
            birthYear = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine("Hello Sir or Miss " + name + ",");
            age = Convert.ToInt16(DateTime.Now.Year - birthYear);
            Console.WriteLine("Born in " + birthYear + ", your age is " + age);
        }
    }
}
