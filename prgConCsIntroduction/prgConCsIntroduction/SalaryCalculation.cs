using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prgConCsIntroduction
{
    internal class SalaryCalculation
    {
        static void MainProgram(string[] args)
        {
            String name;
            Single hourlyRate, normalHours, overtimeHours, normalSalary, overtimeSalary, total;

            Console.WriteLine("     GAME-STORE INC");
            Console.WriteLine("Employee Salary Calculation");
            Console.WriteLine("---------------------------");
            Console.Write("Enter your Name: ");
            name = Console.ReadLine();
            Console.Write("Enter your hourly salary: ");
            hourlyRate = Convert.ToSingle(Console.ReadLine());
            Console.Write("Enter your number of hours worked: ");
            normalHours = Convert.ToSingle(Console.ReadLine());
            Console.Write("Enter your overtime hours worked: ");
            overtimeHours = Convert.ToSingle(Console.ReadLine());

            normalSalary = hourlyRate * normalHours;
            overtimeSalary = Convert.ToSingle(hourlyRate * 1.5) * overtimeHours;
            total = normalSalary + overtimeSalary;

            Console.WriteLine("\n");
            Console.WriteLine("Thank you,");
            Console.WriteLine("Sir or Miss " + name);
            Console.WriteLine("Your weekly salaray is " + normalSalary + "$");
            Console.WriteLine("Your overtime salary is " + overtimeSalary + "$");
            Console.WriteLine("Your total revenue is " + total + "$");
        }
    }
}
