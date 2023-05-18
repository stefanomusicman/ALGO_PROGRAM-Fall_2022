using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prgConCsArrays
{
    internal class ArrayExercises
    {
        public static void LasalleOneArray()
        {
            // variable declaration
            Int16 nbStud;
            Single[] tabGrades = new Single[25];
            Single sum = 0, avg, max, min;

            // Display title
            Console.WriteLine("\tLASALLE COLLEGE");
            Console.WriteLine("\t---------------\n");

            // read the number of students
            do
            {
                Console.Write("Enter the number of students (2-25) : ");
                nbStud = Convert.ToInt16(Console.ReadLine());
            } while (nbStud < 2 || nbStud > 25);

            // loop to read all grades into our array
            for(Int16 i = 0; i < nbStud; i++)
            {
                do
                {
                    Console.Write($"Enter grade {i + 1} : ");
                    tabGrades[i] = Convert.ToSingle(Console.ReadLine());
                } while (tabGrades[i] < 0 || tabGrades[i] > 100);

                sum += tabGrades[i];
            }

            max = min = tabGrades[0];

            // loop to display the contents of the array
            Console.WriteLine("\n#\t Grades");
            for(Int16 i = 0; i < nbStud; i++)
            {
                Console.WriteLine($"{i + 1} \t {tabGrades[i]}");

                // find max and min
                if (tabGrades[i] > max) { max = tabGrades[i]; };
                if (tabGrades[i] < min) { min = tabGrades[i]; };

            }

            avg = sum / nbStud;

            Console.WriteLine($"\nThe class average is {avg}");
            Console.WriteLine($"\nThe best grade is {max}");
            Console.WriteLine($"\nThe best worst is {min}");
        }

        public static void BankManyArrays()
        {
            // variable declaration
            Int16 numEmployees, birthYear, oldest = Convert.ToInt16(DateTime.Now.Year);
            String name;
            Char gender;

            String[] names = new String[200];
            Char[] genders = new Char[200];
            Int16[] birthYears = new Int16[200];

            Console.WriteLine("\t    TORONTO DOMINION");
            Console.WriteLine("\tEmployee Management System");
            Console.WriteLine("\t--------------------------\n");
            do
            {
                Console.Write("Enter the number of employees (Max 200) : ");
                numEmployees = Convert.ToInt16(Console.ReadLine());
            } while (numEmployees < 0 || numEmployees > 200);

            // pushing info to the arrays
            for(Int16 i = 0; i < numEmployees; i++)
            {
                Console.WriteLine($"Employee {i + 1}");

                // loop for getting name
                do
                {
                    Console.Write("  Name: ");
                    name = Console.ReadLine();
                    names[i] = name;
                } while (name == "");                
                
                // loop for getting gender
                do
                {
                    Console.Write("  Gender: ");
                    gender = Convert.ToChar(Console.ReadLine());
                    genders[i] = gender;
                } while (gender != 'm' && gender != 'M' && gender != 'f' && gender != 'F');               
                
                // loop for getting year of birth
                do
                {
                    Console.Write("  Year of birth: ");
                    birthYear = Convert.ToInt16(Console.ReadLine());
                    birthYears[i] = birthYear;
                } while (birthYear < 0 || birthYear > DateTime.Now.Year);

            }
            Console.WriteLine();
            Console.WriteLine("The Company Employees\n");
            Console.WriteLine("Employee Names\tBirth Years\tAges\n");

            // loop for displaying all employees and their information
            for(Int16 i = 0; i < numEmployees; i++)
            {
                Console.WriteLine($"{names[i]}\t\t{birthYears[i]}\t\t{DateTime.Now.Year - birthYears[i]}");

                // determining the oldest age based on birth year
                if (birthYears[i] < oldest)
                {
                    oldest = birthYears[i];
                }
            }
            Console.WriteLine();
            Console.WriteLine("The oldest Employee(s)\n");

            // loop for displaying all employees who have the same age as the oldest age defined in previous loop
            for(Int16 i = 0; i < numEmployees; i++)
            {
                if (birthYears[i] == oldest)
                {
                    if (genders[i] == 'm' || genders[i] == 'm')
                    {
                        Console.WriteLine($"Sir {names[i]}\t{birthYears[i]}\t\t{DateTime.Now.Year - birthYears[i]}");
                    } else
                    {
                        Console.WriteLine($"Miss {names[i]}\t{birthYears[i]}\t\t{DateTime.Now.Year - birthYears[i]}");
                    }
                }
            }
        }
    }
}
