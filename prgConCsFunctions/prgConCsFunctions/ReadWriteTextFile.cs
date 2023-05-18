using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace prgConCsFunctions
{
    public static class ReadWriteTextFile
    {
        public struct Friend
        {
            public Int16 Age;
            public String Name;
            public String Telephone;
        }

        public static void Start()
        {
            // OpenFileForWriting();
            //OpenFileForReading();
            FriendsBook();
        }

        public static void OpenFileForWriting()
        {
            // to work with files, we need to load the libraries that contains
            // objects that will manipulate files === System.IO

            // we will open a file for writing (SreamWriter)
            // if the file does not exist, it will be created
            StreamWriter myFile = new StreamWriter("friends.txt");

            // write in the file
            myFile.WriteLine("Barack Obama");
            myFile.WriteLine("(222)-345-5678");
            myFile.WriteLine("Bill Gates");
            myFile.WriteLine("(333)-675-5778");

            myFile.Close();
        }

        public static void OpenFileForReading()
        {
            // the same library System.IO contains the class StreamReader
            StreamReader myFile = new StreamReader("favoriteFoods.txt");

            // lets read
            // String allContent = myFile.ReadToEnd();

            // reading one line at a time
            String oneLine = "";
            while(myFile.EndOfStream == false)
            {
                oneLine = $"{oneLine} \n {myFile.ReadLine()}";
            }

            // lets write
            Console.WriteLine(oneLine);

            myFile.Close();
        }

        public static void FriendsBook()
        {
            Int16 choice, age;
            String name, telephone;
            Friend[] tabFriends = new Friend[25];

            Int16 nbFriend, i = 0;
            StreamReader myFile = new StreamReader("Book.txt");

            while(myFile.EndOfStream == false)
            {
                tabFriends[i].Name = myFile.ReadLine();
                tabFriends[i].Telephone = myFile.ReadLine();
                tabFriends[i].Age = Convert.ToInt16(myFile.ReadLine());
                i++;
            }
            nbFriend = i;
            myFile.Close();

            do
            {
                Console.WriteLine("1 - Display All");
                Console.WriteLine("2 - Add new Friend");
                Console.WriteLine("3 - Find a friend");
                Console.WriteLine("4 - Quit");
                do
                {
                    Console.Write("Make your choice (1-4) : ");
                    choice = Convert.ToInt16(Console.ReadLine());
                } while (choice < 1 || choice > 4);

                switch (choice)
                {
                    case 1:
                        // display all friends in array
                        Console.WriteLine("Friend Name\tTelephone\tAges");
                        for (i = 0; i < nbFriend; i++)
                        {
                            Console.WriteLine($"{tabFriends[i].Name}\t{tabFriends[i].Telephone}\t{tabFriends[i].Age}");
                        }
                        break;
                    case 2:
                        // add new friend

                        // get new friend's name
                        do
                        {
                            Console.Write("Please enter your friend's name : ");
                            name = Console.ReadLine();
                            tabFriends[nbFriend].Name = name;
                        } while (name.Length == 0);     
                        
                        // get new friend's telephone number
                        do
                        {
                            Console.Write("Please enter your telephone number : ");
                            telephone = Console.ReadLine();
                            tabFriends[nbFriend].Telephone = telephone;
                        } while (telephone.Length == 0);   
                        
                        // get new friend's age
                        do
                        {
                            Console.Write("Please enter your telephone age : ");
                            age = Convert.ToInt16(Console.ReadLine());
                            tabFriends[nbFriend].Age = age;
                        } while (telephone.Length == 0);

                        nbFriend++;
                        Console.Clear();
                        break;
                    case 3:
                        // checking it friend exists in the current list
                        Boolean verdict = false;
                        Console.Clear();
                        do
                        {
                            Console.Write("Please enter your friend's name : ");
                            name = Console.ReadLine();
                        } while (name.Length == 0);

                        for(i = 0; i < nbFriend; i++)
                        {
                            if (tabFriends[i].Name.ToLower() == name.ToLower())
                            {
                                verdict = true;
                                Console.WriteLine("Your friend was found!");
                                Console.WriteLine("Friend Name\tTelephone\tAges");
                                Console.WriteLine($"{tabFriends[i].Name}\t{tabFriends[i].Telephone}\t{tabFriends[i].Age}");
                                break;
                            }
                        }
                        if(verdict == false)
                        {
                            Console.WriteLine("Sorry, this person does not exist in our directory :(");
                        }
                        break;
                    case 4:
                        // rewrite the book.txt file with all updated information before ending the program
                        StreamWriter myNewFile = new StreamWriter("Book.txt");
                        for (i = 0; i < nbFriend; i++)
                        {
                            myNewFile.WriteLine(tabFriends[i].Name);
                            myNewFile.WriteLine(tabFriends[i].Telephone);
                            if(i == nbFriend - 1)
                            {
                                myNewFile.Write(tabFriends[i].Age);
                            }
                            else
                            {
                                myNewFile.WriteLine(tabFriends[i].Age);
                            }
                        }
                        myNewFile.Close();
                        Console.WriteLine("Bye Bye");
                        break;
                }

            } while (choice != 4);
        }
    }
}
