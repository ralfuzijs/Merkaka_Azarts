using System;
using System.IO;
using System.Linq;

namespace Casino
{
    public static class Admin
    {
        // Šī metode parāda administratora izvēlni
        public static void ShowAdminMenu(string filePath)
        {
            bool adminMenu = true;

            while (adminMenu)
            {
                Console.Clear();
                Console.WriteLine("1. Delete a player");
                Console.WriteLine("2. Change amount of money for a player");
                Console.WriteLine("3. Logout");
                Console.Write("\n>>> ");

                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        DeletePlayer(filePath); // Izsauc dzēšanas metodi
                        break;
                    case 2:
                        moneyChange(filePath); // Izsauc naudas maiņas metodi
                        break;
                    case 3:
                        adminMenu = false; // Iziet no izvēlnes
                        Console.Clear();
                        break;
                    default:
                        Console.WriteLine("Invalid choice!");
                        System.Threading.Thread.Sleep(2000);
                        break;
                }
            }
        }

        // Šī metode dzēš spēlētāju
        private static void DeletePlayer(string filePath)
        {
            Console.Clear();
            Console.WriteLine("Enter the name of the player to delete:");
            Console.Write("\n>>> ");

            string playerName = Console.ReadLine();
            string[] lines = File.ReadAllLines(filePath);

            // Filtrē ārā līnijas, kas sākas ar spēlētāja vārdu
            lines = lines.Where(line => !line.StartsWith(playerName + ",")).ToArray();
            File.WriteAllLines(filePath, lines);
            Console.Clear();

            Console.WriteLine("Player deleted successfully!");
            System.Threading.Thread.Sleep(2000);
        }

        // Šī metode maina spēlētāja naudas daudzumu
        private static void moneyChange(string filePath)
        {
            Console.Clear();
            Console.WriteLine("Enter the name of the player to change amount of money: ");
            Console.Write("\n>>> ");

            string playerName = Console.ReadLine();
            string[] lines = File.ReadAllLines(filePath); // Nolasa visus faila rindas
            string playerAccount = lines.FirstOrDefault(line => line.StartsWith(playerName + ",")); // Atrod spēlētāja kontu pēc vārda

            if (playerAccount == null)
            {
                Console.Clear();
                Console.WriteLine("Player not found.");
                System.Threading.Thread.Sleep(2000);
                return;
            }

            Console.Clear();
            Console.WriteLine("Enter the new amount of money:");
            Console.Write("\n>>> ");

            if (int.TryParse(Console.ReadLine(), out int newMoney)) // Pārbauda, vai ievadītā vērtība ir derīgs skaitlis
            {
                string[] parts = playerAccount.Split(','); 

                parts[2] = newMoney.ToString(); // Maina naudas daudzumu

                lines = lines.Select(line => line.StartsWith(playerName + ",") ? string.Join(",", parts) : line).ToArray(); // Atjaunina spēlētāja kontu failā
                File.WriteAllLines(filePath, lines); // Pieraksta izmainīto saturu atpakaļ failā

                Console.Clear();
                Console.WriteLine("Player amount of money changed successfully!");
                System.Threading.Thread.Sleep(2000);
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Invalid amount.");
                System.Threading.Thread.Sleep(2000);
            }
        }
    }
}
