using System;
using System.IO;
using Casino;


class Program
{
    static void Main(string[] args)
    {
        string filePath = "accounts.csv"; //Šī koda daļa pārbauda, vai fails accounts.csv eksistē, un, ja nē, tad to izveido

        if (!File.Exists(filePath))
        {
            File.Create(filePath).Close();
        }

        while (true) //Šis cikls palaiž programmu un turpina to darbību, kamēr lietotājs neizvēlas iziet no programmas
        {
            Console.WriteLine(@" 
                       _                                            ___      ___   _______   _______   __   ___       __       __   ___       __            _
                      //\                                          |'  \    /'  | /'     '| /'      \ |/'| /  ')     /''\     |/'| /  ')     /''\          //\
                      V  \                                          \   \  //   |(: ______)|:        |(: |/   /     /    \    (: |/   /     /    \         V  \
                       \  \_                                        /\\  \/.    | \/    |  |_____/   )|    __/     /' /\  \   |    __/     /' /\  \         \  \_
                        \,'.`-.                                    |: \.        | // ___)_  //      / (// _  \    //  __'  \  (// _  \    //  __'  \         \,'.`-.
                         |\ `. `.                                  |.  \    /:  |(:      '||:  __   \ |: | \  \  /   /  \\  \ |: | \  \  /   /  \\  \         |\ `. `.
                         ( \  `. `-.                       _,.:\   |___|\__/|___| \_______)|__|  \___)(__|  \__)(___/    \___)(__|__\__)(___/    \___)        ( \  `. `-.                       _,.:\
                          \ \   `.  `-._            __..--' ,';/                                                                 /_/                           \ \   `.  `-._            __..--' ,';/
                           \ `.   `-.   `-..__..---'   _.--','/             __     ________        __        _______  ___________  ________                     \ `.   `-.   `-..__..---'   _.--','/
                            `. `.    `-._       __..--'   ,'/              /''\   ('      '\      /''\      /'      \('     _   ')/'       )                     `. `.    `-._       __..--'   ,'/
                              `-_ `-.___       __,--'   ,'                /    \   \___/   :)    /    \    |:        |)__/  \\__/(:   \___/                        `-_ `-.___       __,--'   ,'
                                 `-.__  `---'''    __.-'                 /' /\  \    /  ___/    /' /\  \   |_____/   )   \\_ /    \___  \                             `-.__  `---'''    __.-'
                                      `--..___..--'                     //  __'  \  //  \__    //  __'  \   //      /    |.  |     __/  \\                                 `--..___..--' 
                                                                       /   /  \\  \(:   / '\  /   /  \\  \ |:  __   \    \:  |    /' \   :)
                                                                      (___/    \___)\_______)(___/    \___)|__|  \___)    \__|   (_______/
                    ");

            Console.WriteLine(",,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,\n||=====================================||\n||1. Register                          ||\n||2. Login                             ||\n||3. Scoreboard                        ||\n||4. Exit                              ||\n||                                     ||\n||(Choose command by typing a number)  ||\n||=====================================||\n`````````````````````````````````````````"); //Lietotājam tiek prasīts ievadīt izveles numuru
            Console.Write(">>> ");

            int choice;

            if (!int.TryParse(Console.ReadLine(), out choice))  //Programma pārbauda, vai ievadītā vērtība ir skaitlis
            {
                Console.WriteLine("Invalid choice. Please enter a number.");
                continue;
            }

            string word5 = "Exiting...";

            switch (choice)
            {
                case 1:
                    Registration.Register(filePath);
                    break;
                case 2:
                    Registration.Login(filePath);
                    break;
                case 3:
                    Scoreboard.Show(filePath);
                    break;
                case 4:
                    Console.Clear();
                    foreach (char c in word5)
                    {
                        Console.Write(c); // Tiek izprintēts vārds pa burtiem "Press "
                        System.Threading.Thread.Sleep(100);
                    }
                    System.Threading.Thread.Sleep(350);
                    return;
                default:
                    Console.Clear();
                    Console.WriteLine("Invalid choice. Please enter a number between 1 and 4\n");
                    break;
            }
        }
    }
}
