using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Stefano Proietti - 2012831
namespace prgConCsCalculatorProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // variable declaration
            Int16 selection, numOfDigits;
            Single num1, num2, total, num;
            Char verdict;

            // primary do-while loop responsible for running and exiting the program
            do
            {
                // main menu
                Console.WriteLine("\t    NUMERIC CALCULATOR");
                Console.WriteLine("\tMain Menu Operators Choice");
                Console.WriteLine("\t--------------------------\n");

                Console.WriteLine("1 - ADDITION");
                Console.WriteLine("2 - DIVISION");
                Console.WriteLine("3 - MULTIPLICATION");
                Console.WriteLine("4 - SUBTRACTION");
                Console.WriteLine("5 - QUIT\n");

                Console.Write("Make your choice (1 - 5) : ");
                selection = Convert.ToInt16(Console.ReadLine());
                Console.Clear();

                // switch function to carry out logic for different cases
                switch(selection)
                {
                    case 1:
                        // addition

                        total = 0;
                        // loop to carry out actions and navigation
                        do
                        {
                            Console.WriteLine("\tADDITION OPERATION");
                            Console.WriteLine("\t------------------\n");

                            Console.Write("Enter the number of values to add : ");
                            numOfDigits = Convert.ToInt16(Console.ReadLine());

                            // validate numOfDigits
                            while(numOfDigits < 2 || numOfDigits > 20) 
                            {
                                Console.Write("Please enter a valid entry (2 - 20) : ");
                                numOfDigits = Convert.ToInt16(Console.ReadLine());
                            }

                            // collecting individual numbers
                            for(Int16 i = 1; i <= numOfDigits; i++)
                            {
                                Console.Write($"   Enter value {i} : ");
                                num = Convert.ToSingle(Console.ReadLine());
                                total += num;
                            }

                            Console.WriteLine("\t\t------");
                            Console.WriteLine($"   The result is   {total}\n");

                            Console.Write("Do you want to do another addition ? (y/n): ");
                            verdict = Convert.ToChar(Console.ReadLine());

                            // loop to ensure a valid selection was made
                            while(verdict != 'n' && verdict != 'N' && verdict != 'y' && verdict != 'Y')
                            {
                                Console.Write("Please enter a valid selection (y/n): ");
                                verdict = Convert.ToChar(Console.ReadLine());
                            }
                            total = 0;
                            Console.Clear();

                        } while (verdict != 'n' && verdict != 'N');
                        break;
                    case 2: 
                        // division

                        // loop to carry out actions and navigation
                        do
                        {
                            Console.WriteLine("\tDIVISION OPERATION");
                            Console.WriteLine("\t------------------\n");

                            Console.Write("Enter the value to divide : ");
                            num1 = Convert.ToSingle(Console.ReadLine());
                            Console.Write("Enter the divider (not 0) : ");
                            num2 = Convert.ToSingle(Console.ReadLine());

                            // validating the second number
                            while (num2 == 0)
                            {
                                Console.Write("Please enter a divider that is not 0 : ");
                                num2 = Convert.ToSingle(Console.ReadLine());
                            }

                            Console.WriteLine($"\t\t\t------");
                            Console.WriteLine($"\t    The Result is   {num1 / num2}\n");

                            Console.Write("Do you want to do another addition ? (y/n): ");
                            verdict = Convert.ToChar(Console.ReadLine());
                            // loop to ensure a valid selection was made
                            while (verdict != 'n' && verdict != 'N' && verdict != 'y' && verdict != 'Y')
                            {
                                Console.Write("Please enter a valid selection (y/n): ");
                                verdict = Convert.ToChar(Console.ReadLine());
                            }
                            Console.Clear();
                        } while (verdict != 'n' && verdict != 'N');
                        break;
                    case 3:
                        // multiplication
                        total = 1;

                        // loop to carry out actions and navigation
                        do
                        {
                            Console.WriteLine("\tMULTIPLICATION OPERATION");
                            Console.WriteLine("\t------------------------\n");

                            Console.Write("Enter the number of values to multiply : ");
                            numOfDigits = Convert.ToInt16(Console.ReadLine());

                            // validating the numOfDigits
                            while (numOfDigits < 2 || numOfDigits > 20) 
                            {
                                Console.Write("Please enter a valid entry (2 - 20) : ");
                                numOfDigits = Convert.ToInt16(Console.ReadLine());
                            }

                            // collecting individual numbers
                            for (Int16 i = 1; i <= numOfDigits; i++)
                            {
                                Console.Write($"   Enter value {i} : ");
                                num = Convert.ToSingle(Console.ReadLine());
                                total *= num;
                            }

                            Console.WriteLine("\t\t------");
                            Console.WriteLine($"   The result is   {total}\n");

                            Console.Write("Do you want to do another addition ? (y/n): ");
                            verdict = Convert.ToChar(Console.ReadLine());
                            // loop to ensure a valid selection was made
                            while (verdict != 'n' && verdict != 'N' && verdict != 'y' && verdict != 'Y')
                            {
                                Console.Write("Please enter a valid selection (y/n): ");
                                verdict = Convert.ToChar(Console.ReadLine());
                            }
                            total = 1;
                            Console.Clear();

                        } while (verdict != 'n' && verdict != 'N');
                        break;
                    case 4:
                        // subtraction

                        // loop to carry out actions and navigation
                        do
                        {
                            Console.WriteLine("\tSUBTRACTION OPERATION");
                            Console.WriteLine("\t---------------------\n");

                            Console.Write("Enter the first value  : ");
                            num1 = Convert.ToSingle(Console.ReadLine());  
                            Console.Write("Enter value to subtract: ");
                            num2 = Convert.ToSingle(Console.ReadLine());
                            Console.WriteLine("\t\t     ------");
                            Console.WriteLine($"\tThe Result is   {num1 - num2}\n");

                            Console.Write("Do you want to do another addition ? (y/n): ");
                            verdict = Convert.ToChar(Console.ReadLine());
                            // loop to ensure a valid selection was made
                            while (verdict != 'n' && verdict != 'N' && verdict != 'y' && verdict != 'Y')
                            {
                                Console.Write("Please enter a valid selection (y/n): ");
                                verdict = Convert.ToChar(Console.ReadLine());
                            }
                            Console.Clear();

                        } while (verdict != 'n' && verdict != 'N');
                        break;
                }

            } while (selection != 5);
        }
    }
}
