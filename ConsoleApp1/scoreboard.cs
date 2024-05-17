using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Casino
{
    public static class Scoreboard
    {
        public static void Show(string filePath) // Šī metode ļauj parādīt rezultātu tabulu ar visiem spēlētājiem un viņu naudas daudzumu
        {
            bool i = true;
            while (i)
            {
                Console.Clear();
                Console.WriteLine(@"
                  ________  ______    ______     _______    _______  _______     ______      __        _______   ________   
                 /`       )/` _  `\  /    ` \   /`      \  /`     `||   _  `\   /    ` \    /``\      /`      \ |`      `\  
                (:   \___/(: ( \___)// ____  \ |:        |(: ______)(. |_)  :) // ____  \  /    \    |:        |(.  ___  :) 
                 \___  \   \/ \    /  /    ) :)|_____/   ) \/    |  |:     \/ /  /    ) :)/' /\  \   |_____/   )|: \   ) || 
                  __/  \\  //  \ _(: (____/ //  //      /  // ___)_ (|  _  \\(: (____/ ////  __'  \   //      / (| (___\ || 
                 /` \   :)(:   _) \\        /  |:  __   \ (:      `||: |_)  :)\        //   /  \\  \ |:  __   \ |:       :) 
                (_______/  \_______)\`_____/   |__|  \___) \_______)(_______/  \`_____/(___/    \___)|__|  \___)(________/  
");
                Console.WriteLine("1. Search player.");
                Console.WriteLine("2. Sort by name (alphabetically)");
                Console.WriteLine("3. Sort by money (descending)");
                Console.WriteLine("4. Exit");
                Console.Write("\n>>> ");

                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        SearchPlayer(filePath);
                        break;
                    case "2":
                        ShowScoreboardSortedByName(filePath);
                        break;
                    case "3":
                        ShowScoreboardSortedByMoney(filePath);
                        break;
                    case "4":
                        Console.Clear();
                        return;
                    default:
                        Console.Clear();
                        Console.WriteLine("Invalid choice");
                        System.Threading.Thread.Sleep(2000);
                        break;
                }
            }
        }


        private static void ShowScoreboardSortedByName(string filePath)  // Šī metode ļauj parādīt rezultātu tabulu, sakārtojot to pēc spēlētāju vārdiem.
        {
            Console.Clear();
            Console.WriteLine("Scoreboard (Sorted by Name):");

            List<string> lines = File.ReadAllLines(filePath).ToList();
            lines.Sort((x, y) => string.Compare(x.Split(',')[0], y.Split(',')[0], StringComparison.OrdinalIgnoreCase));

            int place = 1;

            Console.WriteLine("=========================================");

            foreach (string line in lines)
            {
                string[] parts = line.Split(',');
                Console.WriteLine($"{place}. {parts[0]} - {parts[2]} money");
                place++;
            }

            Console.WriteLine("=========================================");
            Console.WriteLine("Press 'ESC' to go back.");

            var keyInfo = Console.ReadKey(true);
            if (keyInfo.Key == ConsoleKey.Escape)
            {
                Console.Clear();
                return;
            }
        }

        private static void ShowScoreboardSortedByMoney(string filePath)  // Šī metode ļauj parādīt rezultātu tabulu, sakārtojot to pēc spēlētāju naudas daudzuma.
        {
            Console.Clear();
            Console.WriteLine("Scoreboard (Sorted by Money):");

            List<string> lines = File.ReadAllLines(filePath).ToList();
            lines.Sort((x, y) => int.Parse(y.Split(',')[2]).CompareTo(int.Parse(x.Split(',')[2])));

            int place = 1;

            Console.WriteLine("=========================================");

            foreach (string line in lines)
            {
                string[] parts = line.Split(',');
                Console.WriteLine($"{place}. {parts[0]} - {parts[2]} money");
                place++;
            }

            Console.WriteLine("=========================================");
            Console.WriteLine("Press 'ESC' to go back.");

            var keyInfo = Console.ReadKey(true);
            if (keyInfo.Key == ConsoleKey.Escape)
            {
                Console.Clear();
                return;
            }
        }


        private static void SearchPlayer(string filePath)  // Šī metode ļauj meklēt spēlētāju pēc viņa lietotājvārda
        {
            Console.Clear();
            Console.WriteLine("Enter the username to search:");
            Console.Write("\n>>> ");

            string username = Console.ReadLine();
            string[] lines = File.ReadAllLines(filePath); // Nolasa visas līnijas no faila
            string player = lines.FirstOrDefault(line => line.Split(',')[0].Equals(username, StringComparison.OrdinalIgnoreCase)); // Atrod pirmo līniju, kas atbilst lietotājvārdam

            if (player != null) // Ja spēlētājs ir atrasts
            {
                string[] parts = player.Split(',');
                Console.Clear();
                Console.WriteLine("Player found:");
                Console.WriteLine("=========================================");
                Console.WriteLine($"Username: {parts[0]}");
                Console.WriteLine($"Money: {parts[2]}");
                Console.WriteLine("=========================================");
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Player not found.");
            }

            Console.WriteLine("Press 'ESC' to go back.");

            var keyInfo = Console.ReadKey(true);
            if (keyInfo.Key == ConsoleKey.Escape)
            {
                Console.Clear();
                return;
            }
        }
    }
}
