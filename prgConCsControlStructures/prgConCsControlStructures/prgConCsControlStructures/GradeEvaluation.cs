using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prgConCsControlStructures
{
    static class GradeEvaluation
    {
        public static void EvaluateStudent()
        {
            // Variable declarations
            String name, status;
            Char gender;
            Int16 birthYear, age;

            Console.WriteLine("\tLASALLE COLLEGE");
            Console.WriteLine("\t---------------");
            Console.Write("Enter your name: ");
            name = Console.ReadLine();
            Console.Write("Select gender (m/f): ");
            gender = Convert.ToChar(Console.ReadLine());
            Console.Write("Enter your year of birth: ");
            birthYear = Convert.ToInt16(Console.ReadLine());
            age = Convert.ToInt16(DateTime.Now.Year - birthYear);
            
            if(gender == 'M' || gender == 'm')
            {
                Console.WriteLine("Sir " + name + ",");
            } else
            {
                Console.WriteLine("Miss " + name + ",");
            }

            if(age >= 1 && age <= 12)
            {
                status = "child";
            }else if(age >= 13 && age <= 18)
            {
                status = "teenager";
            }else if(age >= 19 && age <= 70)
            {
                status = "adult";
            }else if(age >= 71 && age <= 100)
            {
                status = "senior";
            } else
            {
                status = "walking dead";
            }

            Console.WriteLine($"Born in {birthYear}, you are {age} years old");
            Console.WriteLine($"You are {status}");
        }

        public static void EvalNum2Alpha()
        {
            // Variable declaration
            String name;
            Int16 grade;

            Console.WriteLine("\tLASALLE COLLEGE");
            Console.WriteLine("\t---------------");
            Console.Write("Enter your name: ");
            name = Console.ReadLine();
            Console.Write("Enter your numeric grade: ");
            grade = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine($"Sir or Miss {name},");

            if (grade >= 90 && grade <= 100)
            {
                Console.WriteLine($"With {grade}, your Alpha is A");
                Console.WriteLine($"You Pass");
            }
            else if (grade >= 80 && grade <= 89)
            {
                Console.WriteLine($"With {grade}, your Alpha is B");
                Console.WriteLine($"You Pass");
            }
            else if (grade >= 70 && grade <= 79)
            {
                Console.WriteLine($"With {grade}, your Alpha is C");
                Console.WriteLine($"You Pass");
            }
            else if (grade >= 60 && grade <= 69)
            {
                Console.WriteLine($"With {grade}, your Alpha is D");
                Console.WriteLine($"You Pass");
            }
            else if (grade >= 0 && grade <= 59)
            {
                Console.WriteLine($"With {grade}, your Alpha is E");
                Console.WriteLine($"You Fail");
            }
            else
            {
                Console.WriteLine($"Your grade is invalid");
            }
        }

        public static void EvalAlphaNum2()
        {
            // Variable declaration
            String name, result, message;
            Char grade;

            Console.WriteLine("\tLASALLE COLLEGE");
            Console.WriteLine("\t---------------");
            Console.Write("Enter your name: ");
            name = Console.ReadLine();
            Console.Write("Enter your alpha grade: ");
            grade = Convert.ToChar(Console.ReadLine());

            Console.WriteLine($"Sir or Miss {name},");

            switch(grade)
            {
                case 'A':
                case 'a':
                    message = "your numeric grade is between 90 and 100";
                    result = "You Pass";
                    break;
               case 'B':
               case 'b':
                    message = "your numeric grade is between 80 and 90";
                    result = "You Pass";
                    break;               
               case 'C':
               case 'c':
                    message = "your numeric grade is between 70 and 80";
                    result = "You Pass";
                    break;               
               case 'D':
               case 'd':
                    message = "your numeric grade is between 60 and 70";
                    result = "You Pass";
                    break;               
               case 'E':
               case 'e':
                    message = "your numeric grade is between 0 and 59";
                    result = "You Fail";
                    break;
                default:
                    message = "your grade is invalid";
                    result = "Invalid";
                    break;
            }
            Console.WriteLine($"With {grade}, {message}");
            Console.WriteLine($"{result}");
        }
    }
}
