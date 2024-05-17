using System;
using System.IO;
using System.Linq;

namespace Casino
{
    public static class Registration
    {
        private static readonly string AdminUsername = "admin";
        private static readonly string AdminPassword = "admin123";

        public static void Register(string filePath, bool isAdmin = false) // Reģistrācijas metode
        {
            Console.Clear();
            Console.WriteLine("Enter your name (or press 'ESC' to exit):");
            Console.Write("\n>>> ");

            var keyInfo = Console.ReadKey(true);
            if (keyInfo.Key == ConsoleKey.Escape)
            {
                Console.Clear();
                return;
            }

            string name = Console.ReadLine();

            string[] lines = File.ReadAllLines(filePath);
            if (lines.Any(line => line.StartsWith(name + ",")))
            {
                Console.WriteLine("This name is already registered. Please choose a different name.");
                System.Threading.Thread.Sleep(3000);
                Console.Clear();
                return;
            }

            Console.Clear();
            Console.WriteLine("Enter password:");
            Console.Write("\n>>> ");

            string password = Console.ReadLine();
            if (isAdmin)
            {
                using (StreamWriter sw = File.AppendText(filePath)) // Pievieno jaunu administratoru failam
                {
                    sw.WriteLine($"ADMIN,{name},{password}");
                }

                Console.Clear();
                Console.WriteLine("Admin registration successful.");
                System.Threading.Thread.Sleep(2000);
                return;
            }

            bool regMonCheck = false;

            while (!regMonCheck)
            {
                Console.Clear();
                Console.WriteLine("Enter the amount of money to deposit:");
                Console.Write("\n>>> ");

                if (int.TryParse(Console.ReadLine(), out int money))
                {
                    using (StreamWriter sw = File.AppendText(filePath))
                    {
                        sw.WriteLine($"{name},{password},{money}");
                    }

                    Console.Clear();
                    Console.WriteLine("Registration successful.");
                    System.Threading.Thread.Sleep(2000);
                    Console.Clear();
                    regMonCheck = true; // Exit loop
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Invalid amount. Please enter a number.");
                    System.Threading.Thread.Sleep(2000);
                }
            }
        }

        public static void Login(string filePath)
        {
            bool acclogin = true;

            while (acclogin)
            {
                Console.Clear();
                Console.WriteLine("Enter your name (or press 'ESC' to exit):");
                Console.Write("\n>>> ");

                var keyInfo = Console.ReadKey(true);
                if (keyInfo.Key == ConsoleKey.Escape)
                {
                    Console.Clear();
                    return;
                }

                string name = Console.ReadLine();

                Console.Clear();
                Console.WriteLine("Enter password:");
                Console.Write("\n>>> ");

                string password = Console.ReadLine();
                Console.Clear();

                if (name == AdminUsername && password == AdminPassword) // Pārbauda, vai ievadīts administrators
                {
                    Console.WriteLine("Welcome Admin!");
                    Admin.ShowAdminMenu(filePath); // Parāda administratora izvēlni
                    return;
                }

                string[] lines = File.ReadAllLines(filePath); // Nolasa visas līnijas no faila
                string account = lines.FirstOrDefault(line => line.StartsWith(name + "," + password)); // Atrod lietotāju pēc vārda un paroles

                if (account != null) // Ja konts atrasts
                {
                    if (account.StartsWith("ADMIN,"))
                    {
                        Console.WriteLine("Welcome Admin!");
                        Admin.ShowAdminMenu(filePath); // Parāda administratora izvēlni
                    }
                    else
                    {
                        int money = int.Parse(account.Split(',')[2]); // Nolasa naudas summu
                        Console.WriteLine($"Welcome back, {name}. Your balance is {money} b$\n");
                        Console.WriteLine(@"
                              ______   __    __    ______     ______   ________ _______           __            _______      __      ___      ___  _______     
                             /' _  '\ /' |  | '\  /     '\   /    ' \ /'       )'     '|         /''\          /' _   '|    /''\    |'  \    /'  |/'     '|    
                            (: ( \___|:  (__)  :)// ____  \ // ____  (:   \___(: ______)        /    \        (: ( \___)   /    \    \   \  //   (: ______)    
                             \/ \     \/      \//  /    ) :)  /    ) :)___  \  \/    |         /' /\  \        \/ \       /' /\  \   /\\  \/.    |\/    |      
                             //  \ _  //  __  \(: (____/ /(: (____/ // __/  \\ // ___)_       //  __'  \       //  \ ___ //  __'  \ |: \.        |// ___)_     
                            (:   _) \(:  (  )  :)        / \        / /' \   :|:      '|     /   /  \\  \     (:   _(  _/   /  \\  \|.  \    /:  (:      '|    
                             \_______)\__|  |__/ \'_____/   \'_____/ (_______/ \_______)    (___/    \___)     \_______|___/    \___)___|\__/|___|\_______)    



.------.     .------..------..------..------..------.
|1.--. |     |S.--. ||L.--. ||O.--. ||T.--. ||S.--. |
| :/\: |     | :/\: || :/\: || :/\: || :/\: || :/\: |
| (__) |     | :\/: || (__) || :\/: || :\/: || (__) |
| '--'1|     | '--'S|| '--'L|| '--'O|| '--'T|| '--'S|
`------'     `------'`------'`------'`------'`------'

.------.     .------..------..------..------..------..------..------..------.
|2.--. |     |R.--. ||O.--. ||U.--. ||L.--. ||E.--. ||T.--. ||T.--. ||E.--. |
| (\/) |     | :(): || :/\: || (\/) || :/\: || (\/) || :/\: || :/\: || (\/) |
| :\/: |     | ()() || :\/: || :\/: || (__) || :\/: || (__) || (__) || :\/: |
| '--'2|     | '--'R|| '--'O|| '--'U|| '--'L|| '--'E|| '--'T|| '--'T|| '--'E|
`------'     `------'`------'`------'`------'`------'`------'`------'`------'

                        ");
                        Console.WriteLine("Choose game by typing a number (or press ESC to exit)");
                        Console.Write("\n>>> ");

                        keyInfo = Console.ReadKey(true);

                        if (keyInfo.Key == ConsoleKey.Escape)
                        {
                            Console.Clear();
                            return;
                        }

                        int gameChoice = Convert.ToInt32(Console.ReadLine());

                        switch (gameChoice)
                        {
                            case 1:
                                Slots slotsGame = new Slots();
                                money = slotsGame.SlotsGame(name, money);
                                break;
                            case 2:
                                Roulette rouletteGame = new Roulette();
                                money = rouletteGame.StartRoulette(name, money);
                                break;
                            default:
                                Console.WriteLine("Invalid choice!");
                                break;
                        }


                        UpdateBalance(filePath, name, password, money);

                        Console.WriteLine("Logging out...");
                        System.Threading.Thread.Sleep(2000);
                        Console.Clear();
                        acclogin = false;
                    }
                }
                else
                {
                    Console.WriteLine("Account not found.");
                    System.Threading.Thread.Sleep(2000);
                }
            }
        }

        private static void UpdateBalance(string filePath, string name, string password, int money)
        {
            string[] lines = File.ReadAllLines(filePath);

            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].StartsWith(name + ","))
                {
                    lines[i] = $"{name},{password},{money}";
                    break;
                }
            }
            File.WriteAllLines(filePath, lines);
        }
    }
}
