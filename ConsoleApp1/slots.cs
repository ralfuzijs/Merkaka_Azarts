using System;

namespace Casino
{
    public class Slots
    {
        private const int SpinCost = 10;
        private const int BigWinAmount = 1000;
        private const int SmallWinAmount = 100;

        public int SlotsGame(string playerName, int money)
        {
            bool gameRunning = true;

            Console.Clear();
            Console.WriteLine("Press enter to spin:");

            int spins = 0;
            int wins = 0;
            int s1 = 0;
            int s2 = 0;
            int s3 = 0;

            Random rnd = new Random();

            while (gameRunning && money >= SpinCost) // Cikls, kas turpinās, kamēr spēle ir aktīva un ir naudas pietiekami daudz
            {
                int i = 0;

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "":
                        money -= SpinCost;
                        spins++;
                        s1 = rnd.Next(9);
                        s2 = rnd.Next(9);
                        s3 = rnd.Next(9);

                        for (int c = 0; c < 9; c++)
                        {
                            int ss1 = rnd.Next(9);
                            Console.Clear();
                            Console.Write($"{ss1}00");
                            System.Threading.Thread.Sleep(75);
                        }

                        for (int c = 0; c < 9; c++)
                        {
                            int ss2 = rnd.Next(9);
                            Console.Clear();
                            Console.Write($"{s1}{ss2}0");
                            System.Threading.Thread.Sleep(75);
                        }

                        for (int c = 0; c < 9; c++)
                        {
                            int ss3 = rnd.Next(9);
                            Console.Clear();
                            Console.Write($"{s1}{s2}{ss3}");
                            System.Threading.Thread.Sleep(75);
                        }

                        Console.Clear();
                        Console.Write($"{s1}{s2}{s3}");

                        if (s1 == s2 && s2 == s3) // Pārbauda, vai ir uzvarēja un iedod naudas daudzumu atkarībā no uzvaras
                        {
                            wins++;
                            money += BigWinAmount;
                            i = 1;
                            Console.WriteLine("\n\nBig win!");
                            Console.WriteLine("\n\nPress 'enter' to spin\nType 'quit' to quit slots");
                            Console.Write("\n>>> ");
                        }

                        else if (s1 == s2 || s1 == s3 || s2 == s3)
                        {
                            if (i != 1)
                            {
                                wins++;
                                money += SmallWinAmount;
                                Console.WriteLine("\n\nSmall win!");
                                Console.WriteLine("\n\nPress 'enter' to spin\nType 'quit' to quit slots");
                                Console.Write("\n>>> ");
                            }
                        }
                        else
                        {
                            Console.WriteLine("\n\nPress 'enter' to spin\nType 'quit' to quit slots");
                            Console.Write("\n>>> ");
                        }
                        break;

                    case "quit":
                        Console.Clear();
                        gameRunning = false;
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("Invalid choice\n\nPress 'enter' to spin\nType 'quit' to quit slots");
                        Console.Write("\n>>> ");
                        break;
                }
            }

            Console.WriteLine($"You have played {spins} spins\nWon {wins} times");
            Console.WriteLine($"\nYour final balance is {money} money.");

            return money; // Atgriež atlikumu pēc spēles
        }
    }
}
