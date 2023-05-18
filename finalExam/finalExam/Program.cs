using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace finalExam
{
    internal class Program
    {
        public struct Student
        {
            public String Id;
            public String Name;
            public String Program;
            public Int16 Grade;
        }

        static void ReadTextFile(Student[] array)
        {
            StreamReader studentList = new StreamReader("students.txt");
            Int16 index = 0;

            while (studentList.EndOfStream == false)
            {
                array[index].Id = studentList.ReadLine();
                array[index].Name = studentList.ReadLine();
                array[index].Program = studentList.ReadLine();
                array[index].Grade = Convert.ToInt16(studentList.ReadLine());
                index++;
            }
            studentList.Close();
        }

        static String PassOrFail(Int16 grade)
        {
            if(grade >= 60)
            {
                return "Pass";
            } else
            {
                return "Fail";
            }
        }

        static Int16 DetermineStartingStudents(Student[] array)
        {
            Int16 startingStuds = 0;

            for(Int16 i = 0; i < array.Length; i++)
            {
                if (array[i].Name == null)
                {
                    break;
                }
                else
                {
                    startingStuds++;
                }
            }
            return startingStuds;
        }

        static void DisplayTitle(String title)
        {
            Console.WriteLine($"\t{title}");
            Console.Write("\t");
            for (Int16 i = 0; i < title.Length; i++)
            {
                Console.Write("-");
            }
            Console.WriteLine();
        }

        static Int16 MenuSelection()
        {
            Int16 choice;
            DisplayTitle("LASALLE COLLEGE");

            Console.WriteLine("1 - DISPLAY ALL STUDENTS");
            Console.WriteLine("2 - ADD A NEW STUDENT AT THE END");
            Console.WriteLine("3 - FIND A STUDENT BY NUMBER");
            Console.WriteLine("4 - DISPLAY ALL STUDENTS BY REVERSE ORDER");
            Console.WriteLine("5 - QUIT THE PROGRAM");
            Console.Write("Enter your choice (1 - 5) : ");
            choice = Convert.ToInt16(Console.ReadLine());

            while (choice < 1 || choice > 5)
            {
                Console.Write("Invalid selection. Please make a valid selection (1 - 5) : ");
                choice = Convert.ToInt16(Console.ReadLine());
            }

            return choice;
        }

        static void DisplayAllStudents(Student[] arr, Int16 totalStuds)
        {
            Console.Clear();
            DisplayTitle("ALL STUDENTS IN ORDER");
            Console.WriteLine("Numbers\tNames\t\tPrograms\tGrades\tResults");

            for(Int16 i = 0; i < totalStuds; i++)
            {
                Console.WriteLine($"{arr[i].Id}\t{arr[i].Name}\t{arr[i].Program}\t\t{arr[i].Grade}\t{PassOrFail(arr[i].Grade)}");
            }

            Console.WriteLine();
            Console.Write("Click any key to return to main menu");
            Console.ReadKey();
            Console.Clear();
        }

        static Int16 AddNewStudent(Student[] arr, Int16 totalStuds)
        {
            String id, name, program;
            Int16 grade;

            Console.Clear();
            DisplayTitle("ADD A NEW STUDENT");

            if (totalStuds == arr.Length)
            {
                Console.WriteLine("Cannot add student, enrollment limit has been met.");
            } else
            {
                Console.WriteLine("Enter a new Student");
                Console.Write("\tNumber : ");
                id = Console.ReadLine();
                while(id.Length == 0)
                {
                    Console.Write("Please enter a student number : ");
                    id = Console.ReadLine();
                }                
                Console.Write("\tName : ");
                name = Console.ReadLine();
                while(name.Length == 0)
                {
                    Console.Write("Please enter a name : ");
                    name = Console.ReadLine();
                }                
                Console.Write("\tProgram : ");
                program = Console.ReadLine();
                while(program.Length == 0)
                {
                    Console.Write("Please enter a program : ");
                    program = Console.ReadLine();
                }                
                Console.Write("\tGrade : ");
                grade = Convert.ToInt16(Console.ReadLine());
                while(Convert.ToString(grade).Length == 0)
                {
                    Console.Write("Please enter a program : ");
                    grade = Convert.ToInt16(Console.ReadLine());
                }

                arr[totalStuds].Id = id;
                arr[totalStuds].Name = name;
                arr[totalStuds].Program = program;
                arr[totalStuds].Grade = grade;
                totalStuds++;
            }
            Console.WriteLine();
            Console.Write("Click any key to return to main menu");
            Console.ReadKey();
            Console.Clear();
            return totalStuds;
        }

        static void FindAStudent(Student[] arr, Int16 totalStuds)
        {
            Boolean found = false;
            String studentNum;

            Console.Clear();
            DisplayTitle("FIND AND DISPLAY STUDENT");
            Console.Write("Enter the Student Number : ");
            studentNum = Console.ReadLine();
            while (studentNum.Length == 0)
            {
                Console.Write("Please enter a student number : ");
                studentNum = Console.ReadLine();
            }

            for(Int16 i = 0; i < totalStuds; i++)
            {
                if (arr[i].Id.ToUpper() == studentNum.ToUpper())
                {
                    found = true;
                    Console.WriteLine($"{arr[i].Id}\t{arr[i].Name}\t{arr[i].Program}\t{arr[i].Grade}\t{PassOrFail(arr[i].Grade)}");
                    break;
                }
            }

            if(found == false)
            {
                Console.WriteLine("Student not found...");
            }

            Console.WriteLine();
            Console.Write("Click any key to return to main menu");
            Console.ReadKey();
            Console.Clear();
        }

        static void DisplayInReverseOrder(Student[] arr, Int16 totalStuds)
        {
            Console.Clear();
            DisplayTitle("ALL STUDENTS IN REVERSE");
            Console.WriteLine("Numbers\tNames\t\tPrograms\tGrades\tResults");

            for (Int16 i = Convert.ToInt16(totalStuds - 1); i >= 0; i--)
            {
                Console.WriteLine($"{arr[i].Id}\t{arr[i].Name}\t{arr[i].Program}\t\t{arr[i].Grade}\t{PassOrFail(arr[i].Grade)}");
            }

            Console.WriteLine();
            Console.Write("Click any key to return to main menu");
            Console.ReadKey();
            Console.Clear();
        }

        static void EndProgram(Student[] arr, Int16 totalStuds)
        {
            StreamWriter updatedStudentList = new StreamWriter("students.txt");
            for (Int16 i = 0; i < totalStuds; i++)
            {
                updatedStudentList.WriteLine(arr[i].Id);
                updatedStudentList.WriteLine(arr[i].Name);
                updatedStudentList.WriteLine(arr[i].Program);
                if (i == totalStuds - 1)
                {
                    updatedStudentList.Write(arr[i].Grade);
                }
                else
                {
                    updatedStudentList.WriteLine(arr[i].Grade);
                }
            }
            updatedStudentList.Close();
            Console.WriteLine();
            Console.WriteLine("Thank you, have a nice day!");
        }


        static void Main(string[] args)
        {
            Int16 choice, totalStudents;
            Student[] students = new Student[200];

            ReadTextFile(students);
            totalStudents = DetermineStartingStudents(students);

            do
            {
                // main menu
                choice = MenuSelection();

                switch(choice)
                {
                    // display all students
                    case 1:
                        DisplayAllStudents(students, totalStudents);
                        break;

                    // add a new student if possible
                    case 2:
                        totalStudents = AddNewStudent(students, totalStudents);
                        break;

                    // find a student by number
                    case 3:
                        FindAStudent(students, totalStudents);
                        break;

                    // display all students in reverse order
                    case 4:
                        DisplayInReverseOrder(students, totalStudents);
                        break;
                }
                EndProgram(students, totalStudents);
            } while (choice != 5);
        }
    }
}
