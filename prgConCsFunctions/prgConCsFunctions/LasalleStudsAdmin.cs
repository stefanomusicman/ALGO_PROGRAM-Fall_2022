using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace prgConCsFunctions
{
    internal class LasalleStudsAdmin
    {
        struct MyDate
        {
            public Int16 Day;
            public Int16 Month;
            public Int16 Year;
        }

        struct Student
        {
            public String StudNum;
            public String Name;
            public MyDate BDay;
        }

        // function to display title
        static void DisplayTitle(String anyTitle)
        {
            Console.WriteLine($"\t{anyTitle.ToUpper()}");
            Console.Write("\t");
            for(Int16 i = 0; i < anyTitle.Length; i++)
            {
                Console.Write("-");
            }
            Console.WriteLine();
        }

        // function to get the number of students
        static Int16 GetNumStuds(Int16 min, Int16 max)
        {
            Int16 numStuds;

            do
            {
                Console.Write($"Enter the number of students ({min} - {max}): ");
                numStuds = Convert.ToInt16(Console.ReadLine());
            } while (numStuds < min || numStuds > max);

            return numStuds;
        }

        // function to add the students to the array
        static void ReadAllStudents(Student[] array)
        {
            for(Int16 i = 0; i < array.Length; i++)
            {
                ReadOneStudent(i, array);
            }
        }

        static void ReadOneStudent(Int16 index, Student[] array)
        {
            Console.WriteLine($"Student {index + 1}");
            Console.Write($"\tNumber: ");
            array[index].StudNum = ReadStudentNum();
            Console.Write($"\tName: ");
            array[index].Name = ReadStudentName();
            Console.WriteLine("\tBirth date");
            array[index].BDay = ReadStudentBDay(); 
        }

        // function for reading student number
        static String ReadStudentNum()
        {
            String studNum;
            do
            {
                studNum = Console.ReadLine();
            } while (studNum.Trim().Length == 0);
            
            return studNum;
        }        
        
        // function for reading student name
        static String ReadStudentName()
        {
            String studName;
            do
            {
                studName = Console.ReadLine();
            } while (studName.Trim().Length == 0);

            return studName;
        }        
        
        // function for reading student bday
        static MyDate ReadStudentBDay()
        {
            MyDate bdate;

            do
            {
                Console.Write($"\t\tDay: ");
                bdate.Day = Convert.ToInt16(Console.ReadLine());
            } while (bdate.Day < 1 || bdate.Day > 31);

            do
            {
                Console.Write($"\t\tMonth: ");
                bdate.Month = Convert.ToInt16(Console.ReadLine());
            } while (bdate.Month < 1 || bdate.Month > 12);

            do
            {
                Console.Write($"\t\tYear: ");
                bdate.Year = Convert.ToInt16(Console.ReadLine());
            } while (bdate.Year > DateTime.Now.Year || bdate.Year < 0);

            return bdate;
        }

        // function for determing the oldest student based on year
        static Int16 DetermineOldest(Student[] array)
        {
            Int16 oldest = Convert.ToInt16(DateTime.Now.Year);

            for(Int16 i = 0; i < array.Length; i++)
            {
                if(array[i].BDay.Year < oldest)
                {
                    oldest = array[i].BDay.Year;
                }
            }

            return oldest;
        }

        // function for determing the youngest student based on year
        static Int16 DetermineYoungest(Student[] array)
        {
            Int16 youngest = 0;

            for (Int16 i = 0; i < array.Length; i++)
            {
                if (array[i].BDay.Year > youngest)
                {
                    youngest = array[i].BDay.Year;
                }
            }

            return youngest;
        }

        // function for converting birth year to appropriate age in years
        static Int16 ConvertToAge(Int16 year)
        {
            return Convert.ToInt16(DateTime.Now.Year - year);
        }

        // displaying oldest students
        static void DisplayOldest(Student[] array, Int16 oldest)
        {
            Console.WriteLine("The oldest students");
            Console.WriteLine($"Student Number\tName\tAge");
            for(Int16 i = 0; i < array.Length; i++)
            {
                if(array[i].BDay.Year == oldest)
                {
                    Console.WriteLine($"{array[i].StudNum}\t\t{array[i].Name}\t{ConvertToAge(array[i].BDay.Year)}");
                }
            }
        }

        // displaying youngest students
        static void DisplayYoungest(Student[] array, Int16 youngest)
        {
            Console.WriteLine("The youngest students");
            Console.WriteLine($"Student Number\tName\tAge");
            for (Int16 i = 0; i < array.Length; i++)
            {
                if (array[i].BDay.Year == youngest)
                {
                    Console.WriteLine($"{array[i].StudNum}\t\t{array[i].Name}\t{ConvertToAge(array[i].BDay.Year)}");
                }
            }
        }

        public static void Start()
        {
            Student[] students;
            Int16 oldest, youngest;

            DisplayTitle("lasalle college");
            students = new Student[GetNumStuds(min: 0, max: 10)];
            ReadAllStudents(students);
            oldest = DetermineOldest(students);
            youngest = DetermineYoungest(students);
            Console.WriteLine();
            DisplayOldest(students, oldest);
            Console.WriteLine();
            DisplayYoungest(students, youngest);
        }
    }
}
