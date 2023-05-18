using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prgConCsArrays
{
    public static class StructureExercises 
    { 
        struct Student
        {
            public String Name;
            public Char Gender;
            public Single Average;
        }

        struct Date
        {
            public Int16 Month;
            public Int16 Year;
        }

        struct Employee
        {
            public String Name;
            public Date BirthDate;
            public Char Gender;
        }


        public static void Introduction()
        {
            Console.WriteLine("\tTHE STRUCTURE");
            Console.WriteLine("\t-------------");

            Student stud1;

            Console.Write("Enter student name: ");
            stud1.Name = Console.ReadLine();            
            Console.Write("Enter student grade: ");
            stud1.Average = Convert.ToSingle(Console.ReadLine());
            
            Console.WriteLine($"{stud1.Name} has an average of {stud1.Average}");
        }

        public static void BankManyArraysV2()
        {
            // variable declaration
            Int16 numEmployees, birthYear, oldest = Convert.ToInt16(DateTime.Now.Year);
            String name;
            Char gender;

            // array declaration
            Employee[] companyEmployees = new Employee[255];

            Console.WriteLine("\t    TORONTO DOMINION");
            Console.WriteLine("\tEmployee Management System");
            Console.WriteLine("\t--------------------------\n");

            do
            {
                Console.Write("Enter the number of employees (Max 200) : ");
                numEmployees = Convert.ToInt16(Console.ReadLine());
            } while (numEmployees < 0 || numEmployees > 200);

            // pushing info to the arrays
            for (Int16 i = 0; i < numEmployees; i++)
            {
                Console.WriteLine($"Employee {i + 1}");

                // loop for getting name
                do
                {
                    Console.Write("  Name: ");
                    name = Console.ReadLine();
                    companyEmployees[i].Name = name;
                } while (name == "");

                // loop for getting gender
                do
                {
                    Console.Write("  Gender: ");
                    gender = Convert.ToChar(Console.ReadLine());
                    companyEmployees[i].Gender = gender;
                } while (gender != 'm' && gender != 'M' && gender != 'f' && gender != 'F');

                // loop for getting year of birth
                do
                {
                    Console.Write("  Year of birth: ");
                    birthYear = Convert.ToInt16(Console.ReadLine());
                    companyEmployees[i].BirthDate.Year = birthYear;
                } while (birthYear < 0 || birthYear > DateTime.Now.Year);
            }

            Console.WriteLine();
            Console.WriteLine("The Company Employees\n");
            Console.WriteLine("Employee Names\tBirth Years\tAges\n");

            // loop for displaying all employees and their information
            for (Int16 i = 0; i < numEmployees; i++)
            {
                Console.WriteLine($"{companyEmployees[i].Name}\t\t{companyEmployees[i].BirthDate.Year}\t\t{DateTime.Now.Year - companyEmployees[i].BirthDate.Year}");

                // determining the oldest age based on birth year
                if (companyEmployees[i].BirthDate.Year < oldest)
                {
                    oldest = companyEmployees[i].BirthDate.Year;
                }
            }

            Console.WriteLine();
            Console.WriteLine("The oldest Employee(s)\n");

            // loop for displaying all employees who have the same age as the oldest age defined in previous loop
            for (Int16 i = 0; i < numEmployees; i++)
            {
                if (companyEmployees[i].BirthDate.Year == oldest)
                {
                    if (companyEmployees[i].Gender == 'm' || companyEmployees[i].Gender == 'm')
                    {
                        Console.WriteLine($"Sir {companyEmployees[i].Name}\t{companyEmployees[i].BirthDate.Year}\t\t{DateTime.Now.Year - companyEmployees[i].BirthDate.Year}");
                    }
                    else
                    {
                        Console.WriteLine($"Miss {companyEmployees[i].Name}\t{companyEmployees[i].BirthDate.Year}\t\t{DateTime.Now.Year - companyEmployees[i].BirthDate.Year}");
                    }
                }
            }
        }

        public static void BankManyArraysV3()
        {
            // variable declaration
            Int16 numEmployees, birthYear, oldest = Convert.ToInt16(DateTime.Now.Year);
            String name;
            Char gender;

            Console.WriteLine("\t    TORONTO DOMINION");
            Console.WriteLine("\tEmployee Management System");
            Console.WriteLine("\t--------------------------\n");

            Console.Write("Enter the number of employees : ");
            numEmployees = Convert.ToInt16(Console.ReadLine());

            // loop for getting the right number of empoloyees
            while(numEmployees < 1)
            {
                Console.Write("Enter the number (Min 1) : ");
                numEmployees = Convert.ToInt16(Console.ReadLine());
            }

            // dynamic array declaration
            Employee[] companyEmployees = new Employee[numEmployees];

            // pushing info to the arrays
            for (Int16 i = 0; i < companyEmployees.Length; i++)
            {
                Console.WriteLine($"Employee {i + 1}");

                // loop for getting name
                do
                {
                    Console.Write("  Name: ");
                    name = Console.ReadLine();
                    companyEmployees[i].Name = name;
                } while (name.Trim().Length == 0);

                Console.Write("  Gender: ");
                gender = Convert.ToChar(Console.ReadLine());
                companyEmployees[i].Gender = gender;

                // loop for getting gender
                while (gender != 'm' && gender != 'M' && gender != 'f' && gender != 'F')
                {
                    Console.Write("  Gender (M/F): ");
                    gender = Convert.ToChar(Console.ReadLine());
                    companyEmployees[i].Gender = gender;
                }

                // loop for getting year of birth
                do
                {
                    Console.Write("  Year of birth: ");
                    birthYear = Convert.ToInt16(Console.ReadLine());
                    companyEmployees[i].BirthDate.Year = birthYear;
                } while (birthYear < 0 || birthYear > DateTime.Now.Year);
            }

            Console.WriteLine();
            Console.WriteLine("The Company Employees\n");
            Console.WriteLine("Employee Names\tBirth Years\tAges\n");

            // loop for displaying all employees and their information
            for (Int16 i = 0; i < companyEmployees.Length; i++)
            {
                Console.WriteLine($"{companyEmployees[i].Name}\t\t{companyEmployees[i].BirthDate.Year}\t\t{DateTime.Now.Year - companyEmployees[i].BirthDate.Year}");

                // determining the oldest age based on birth year
                if (companyEmployees[i].BirthDate.Year < oldest)
                {
                    oldest = companyEmployees[i].BirthDate.Year;
                }
            }

            Console.WriteLine();
            Console.WriteLine("The oldest Employee(s)\n");

            // loop for displaying all employees who have the same age as the oldest age defined in previous loop
            for (Int16 i = 0; i < companyEmployees.Length; i++)
            {
                String title = (companyEmployees[i].Gender == 'm' || companyEmployees[i].Gender == 'M') ? "Sir" : "Miss";
                if (companyEmployees[i].BirthDate.Year == oldest)
                {
                    Console.WriteLine($"{title} {companyEmployees[i].Name}\t{companyEmployees[i].BirthDate.Year}\t\t{DateTime.Now.Year - companyEmployees[i].BirthDate.Year}");
                }
            }
        }
    }
}
