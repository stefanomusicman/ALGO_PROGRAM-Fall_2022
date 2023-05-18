using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prgConCsRepetitiveStructures
{
    public class LoopsExercises
    {
        // function for exo 1
        public static void Exo1()
        {
            // variable declaration
            String name, title;
            Char gender;
            Single total = 0, grade, lowestGrade = 101, bestGrade = -1;

            Console.WriteLine("\tLASALLE COLLEGE");
            Console.WriteLine("\t---------------");

            // do-while loop for getting name
            do
            {
                Console.Write("Enter your name: ");
                name = Console.ReadLine();
            } while (name == "");

            Console.Write("Select your gender: ");
            gender = Convert.ToChar(Console.ReadLine());

            // while loop for getting gender
            while(gender != 'M' && gender != 'm' && gender != 'F' && gender != 'f')
            {
                Console.Write("Please select m/f: ");
                gender = Convert.ToChar(Console.ReadLine());
            }

            // determining the title
            title = (gender == 'm' || gender == 'M') ? "Sir" : "Miss";

            Console.WriteLine("Now let's read your 4 grades,");

            // for loop for reading the 4 grades
            for(Int16 number = 1; number <= 4; number++)
            {
                // do-while loop for getting individual grade
                do
                {
                    Console.Write($"\tEnter grade {number}: ");
                    grade = Convert.ToSingle(Console.ReadLine());
                } while (grade < 0 || grade > 100);

                // adding grade to total
                total += grade;

                // check for highest grade
                if(grade > bestGrade)
                {
                    bestGrade = grade;
                }

                // check for lowest grade
                if(grade < lowestGrade)
                {
                    lowestGrade = grade;
                }
            }

            // final section of program
            Console.WriteLine($"{title} {name},");
            Console.Write($"Your average is {total / 4}");
            if((total / 4) >= 60)
            {
                Console.WriteLine("(You pass)");
            } else
            {
                Console.WriteLine("(You fail)");
            }

            Console.WriteLine($"Your best grade is {bestGrade}");
            Console.WriteLine($"Your worst grade is {lowestGrade}");

        }

        public static void Exo2()
        {
            // variable declaration
            String course;
            Single numStudents, total = 0, bestGrade = -1, worstGrade = 101, grade;

            Console.WriteLine("\t  LASALLE COLLEGE");
            Console.WriteLine("\tStudents Evaluation");
            Console.WriteLine("\t-------------------");

            // do-while loop for getting the course name
            do
            {
                Console.Write("Enter the course: ");
                course = Console.ReadLine();
            } while (course == "");

            // do-while loop for getting the number of students
            do
            {
                Console.Write("Enter the number of students (Max 25): ");
                numStudents = Convert.ToSingle(Console.ReadLine());
            } while (numStudents <= 1 || numStudents > 25);

            // for-loop for getting every grade
            for(Int16 number = 1; number <= numStudents; number++)
            {
                do
                {
                    Console.Write($"Grade {number}: ");
                    grade = Convert.ToSingle(Console.ReadLine());
                } while (grade < 0 || grade > 100);

                total += grade;

                // keep track of lowest grade
                if(grade < worstGrade)
                {
                    worstGrade = grade;
                }

                // keep track of highest grade
                if(grade > bestGrade)
                {
                    bestGrade = grade;
                }
            }

            // final section of program
            Console.WriteLine($"The class average is {total / numStudents}");
            Console.WriteLine($"The best grade is {bestGrade}");
            Console.WriteLine($"The worst grade is {worstGrade}");
        }

        public static void Exo3()
        {
            // variable declaration
            String name, title;
            Char gender, maritalStatus;
            Int16 numChildren;
            Single salary, deductions = 0, benefits = 0, total = 0;

            Console.WriteLine("\tREVENU-QUEBEC");
            Console.WriteLine("\t-------------");

            // do-while loop to get name
            do
            {
                Console.Write("Enter your name: ");
                name = Console.ReadLine();
            } while (name == "");

            // do-while loop to get salary
            do
            {
                Console.Write("Enter your annual salary: ");
                salary = Convert.ToSingle(Console.ReadLine());
            } while (salary < 0);            
            
            // do-while loop to get gender
            do
            {
                Console.Write("Select your gender (m/f): ");
                gender = Convert.ToChar(Console.ReadLine());
            } while (gender != 'f' && gender != 'F' && gender != 'm' && gender != 'M');  
            
            // determining title
            if(gender == 'f' || gender == 'F')
            {
                title = "Miss";
            } else
            {
                title = "Sir";
            }
            
            // do-while loop to get marital status
            do
            {
                Console.Write("Are you married (y/n): ");
                maritalStatus = Convert.ToChar(Console.ReadLine());
            } while (maritalStatus != 'n' && maritalStatus != 'N' && maritalStatus != 'y' && maritalStatus != 'Y');            
            
            // do-while loop to get number of children
            do
            {
                Console.Write("How many children do you have: ");
                numChildren = Convert.ToInt16(Console.ReadLine());
            } while (numChildren < 0);

            // checking if number of children is > 10
            if(numChildren > 10)
            {
                numChildren = 10;
            }

            // calculating deductions/benefits
            if((title == "Sir") && (maritalStatus == 'y' || maritalStatus == 'y'))
            {
                deductions = 40;
            } else if((title == "Sir") && (maritalStatus == 'n' || maritalStatus == 'N'))
            {
                deductions = 50;
            } else if ((title == "Miss") && (maritalStatus == 'y' || maritalStatus == 'Y'))
            {
                deductions = 30;
                benefits = numChildren * 5000;
            } else if ((title == "Miss") && (maritalStatus == 'n' || maritalStatus == 'N'))
            {
                deductions = 40;
                benefits = numChildren * 5000;
            }

            // calculating total
            total = (salary - ((salary * deductions) / 100)) + benefits;

            // final section of program
            Console.WriteLine("Thanks,");
            Console.WriteLine($"{title} {name},");
            Console.WriteLine($"\tYour salary is {salary}");
            Console.WriteLine($"\tYour deductions are {(salary * deductions) / 100}");
            Console.WriteLine($"\tYour benefits are {benefits}");
            Console.WriteLine($"\tYour net income is {total}");

        }
    }
}
