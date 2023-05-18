using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ATMProject.Program;

namespace ATMProject
{
    internal class Program
    {
        public struct Client
        {
            public String ClientId;
            public String Name;
            public String Password;
            public Double TotalFunds;
        }

        static void DisplayTitle()
        {
            String name = "BANQUE ROYALE";
            String description = "Guichet Automatique Bancaire";

            Console.WriteLine($"\t{name}");
            Console.Write("\t");
            for (Int16 i = 0; i < name.Length; i++)
            {
                Console.Write("-");
            }
            Console.WriteLine();
            Console.WriteLine($" {description}");
            Console.Write(" ");
            for (Int16 i = 0; i < description.Length; i++)
            {
                Console.Write("-");
            }
            Console.WriteLine("\n");
        }

        static void ReadTextFile(Client[] array, Int16 index)
        {
            StreamReader myClientList = new StreamReader("ATMUsers.txt");

            while (myClientList.EndOfStream == false)
            {
                array[index].ClientId = myClientList.ReadLine();
                array[index].Name = myClientList.ReadLine();
                array[index].Password = myClientList.ReadLine();
                array[index].TotalFunds = Convert.ToDouble(myClientList.ReadLine());
                index++;
            }
            myClientList.Close();
        }

        static Int16 ValidateAccountNumber(Client[] array, Int16 index, Boolean validity)
        {
            String accountNum;
            Console.Write("Entrez votre numero de compte : ");
            accountNum = Console.ReadLine();

            for (index = 0; index < array.Length; index++)
            {
                if (array[index].ClientId == accountNum)
                {
                    validity = true;
                    break;
                }
            }

            while (validity == false)
            {
                Console.Write("Le numero de compte n'existe pas, entrez un numero valid : ");
                accountNum = Console.ReadLine();

                for (index = 0; index < array.Length; index++)
                {
                    if (array[index].ClientId == accountNum)
                    {
                        validity = true;
                        break;
                    }
                }
            }
            Console.WriteLine();
            return index;
        }

        static void ValidatePin(Client[] array, Int16 index, Boolean validity)
        {
            String password;
            Console.WriteLine($"\tBienvenue {array[index].Name}\n");

            validity = false;
            Console.Write("Entrez votre nip : ");
            password = Console.ReadLine();

            if (password == array[index].Password)
            {
                validity = true;
            }

            while (validity == false)
            {
                Console.Write("Le nip n'est pas valid, entrez un nip valid : ");
                password = Console.ReadLine();

                if (password == array[index].Password)
                {
                    validity = true;
                }
            }
            Console.WriteLine();
        }

        static Int16 MenuSelection()
        {
            Int16 choice;

            Console.WriteLine("Choisir votre Transaction");
            Console.WriteLine("\t1 - Pour Deposer");
            Console.WriteLine("\t2 - Pour Retirer");
            Console.WriteLine("\t3 - Pour Consulter");
            Console.Write("Entrez votre choix (1 - 3) : ");
            choice = Convert.ToInt16(Console.ReadLine());

            while (choice < 1 || choice > 3)
            {
                Console.Write("Selection Invalid. Entrez votre choix (1 - 3) : ");
                choice = Convert.ToInt16(Console.ReadLine());
            }

            return choice;
        }

        static void DepositFunds(Client[] array, Int16 index)
        {
            Double amount;

            Console.WriteLine();
            Console.Write("Entrez le montant a deposer $ : ");
            amount = Convert.ToDouble(Console.ReadLine());

            while (amount < 0)
            {
                Console.Write("Montant Invalid, Entrez le montant a deposer $ : ");
                amount = Convert.ToDouble(Console.ReadLine());
            }
            array[index].TotalFunds += amount;
            Console.WriteLine();
            Console.WriteLine("--- la transaction a reussi ---\n");

            Console.WriteLine("Les infos du compte");
            Console.WriteLine($"\tNumero : {array[index].ClientId}");
            Console.WriteLine($"\tClient : {array[index].Name}");
            Console.WriteLine($"\tNip : {array[index].Password}");
            Console.WriteLine($"\tSolde : {array[index].TotalFunds}");
        }

        static void WithdrawFunds(Client[] array, Int16 index)
        {
            Double amount;

            Console.WriteLine();
            Console.Write("Entrez le montant a retirer $ : ");
            amount = Convert.ToDouble(Console.ReadLine());

            while (amount < 0)
            {
                Console.Write("Montant Invalid, Entrez le montant a retirer $ : ");
                amount = Convert.ToDouble(Console.ReadLine());
            }
            array[index].TotalFunds -= amount;
            Console.WriteLine();
            Console.WriteLine("--- la transaction a reussi ---\n");

            Console.WriteLine("Les infos du compte");
            Console.WriteLine($"\tNumero : {array[index].ClientId}");
            Console.WriteLine($"\tClient : {array[index].Name}");
            Console.WriteLine($"\tNip : {array[index].Password}");
            Console.WriteLine($"\tSolde : {array[index].TotalFunds}");
        }

        static void VerifyAccount(Client[] array, Int16 index)
        {
            Console.WriteLine();
            Console.WriteLine("Les infos du compte");
            Console.WriteLine($"\tNumero : {array[index].ClientId}");
            Console.WriteLine($"\tClient : {array[index].Name}");
            Console.WriteLine($"\tNip : {array[index].Password}");
            Console.WriteLine($"\tSolde : {array[index].TotalFunds}");
        }

        static void EndProgram(Client[] array, Int16 index)
        {
            StreamWriter updatedClientList = new StreamWriter("ATMUsers.txt");
            for (index = 0; index < array.Length; index++)
            {
                updatedClientList.WriteLine(array[index].ClientId);
                updatedClientList.WriteLine(array[index].Name);
                updatedClientList.WriteLine(array[index].Password);
                if (index == array.Length - 1)
                {
                    updatedClientList.Write(array[index].TotalFunds);
                }
                else
                {
                    updatedClientList.WriteLine(array[index].TotalFunds);
                }
            }
            updatedClientList.Close();
            Console.WriteLine();
            Console.WriteLine("Merci d'avoir utiliser nos services");
        }

        static void Main(string[] args)
        {
            Int16 choice, i = 0;
            Boolean valid = false;
            Client[] clients = new Client[10];
         
            // reading text file
            ReadTextFile(clients, i);

            // beginning of program
            DisplayTitle();

            i = ValidateAccountNumber(clients, i, valid);

            ValidatePin(clients, i, valid);

            // Menu
            choice = MenuSelection();

            switch(choice)
            {
                // deposit money
                case 1:
                    DepositFunds(clients, i);
                    break;

                // withdraw money
                case 2:
                    WithdrawFunds(clients, i);
                    break;

                // verify account info
                case 3:
                    VerifyAccount(clients, i);
                    break;
            }

            // modify the text file
            EndProgram(clients, i);
        }
    }
}
