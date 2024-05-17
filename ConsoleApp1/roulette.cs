using System;

namespace Casino
{
    public class Roulette
    {
        public int StartRoulette(string name, int money)
        {
            Console.Clear();

            Console.WriteLine(@" 
                                   _______       __      _____  ___        __      _____  ___   ____  ____     
                                  |   _  '\     /''\    (\'   \|'  \      /''\    (\'   \|'  \ ('  _||_ ' |    
                                  (. |_)  :)   /    \   |.\\   \    |    /    \   |.\\   \    ||   (  ) : |    
                                  |:     \/   /' /\  \  |: \.   \\  |   /' /\  \  |: \.   \\  |(:  |  | . )    
                                  (|  _  \\  //  __'  \ |.  \    \. |  //  __'  \ |.  \    \. | \\ \__/ //     
                                  |: |_)  :)/   /  \\  \|    \    \ | /   /  \\  \|    \    \ | /\\ __ //\     
                                  (_______/(___/    \___)\___|\____\)(___/    \___)\___|\____\)(__________)    

                                        _______   ____  ____  ___       _______  ___________  _______          
                                       /'      \ ('  _||_ ' ||'  |     /'     '|('     _   ')/'     '|         
                                      |:        ||   (  ) : |||  |    (: ______) )__/  \\__/(: ______)         
                                      |_____/   )(:  |  | . )|:  |     \/    |      \\_ /    \/    |           
                                       //      /  \\ \__/ //  \  |___  // ___)_     |.  |    // ___)_          
                                      |:  __   \  /\\ __ //\ ( \_|:  \(:      '|    \:  |   (:      '|         
                                      |__|  \___)(__________) \_______)\_______)     \__|    \_______)         
          ");
            System.Threading.Thread.Sleep(1000);

            string word1 = "Press ";
            string word2 = "'ENTER' ";
            string word3 = "To ";
            string word4 = "Start...";

            foreach (char c in word1)
            {
                Console.Write(c); // Tiek izprintēts vārds pa burtiem "Press "
                System.Threading.Thread.Sleep(100);
            }
            System.Threading.Thread.Sleep(350);

            foreach (char c in word2)
            {
                Console.Write(c); // Tiek izprintēts vārds pa burtiem "'ENTER'"
                System.Threading.Thread.Sleep(100);
            }
            System.Threading.Thread.Sleep(350);

            foreach (char c in word3)
            {
                Console.Write(c); // Tiek izprintēts vārds pa burtiem "To "
                System.Threading.Thread.Sleep(100);
            }
            System.Threading.Thread.Sleep(350);

            foreach (char c in word4)
            {
                Console.Write(c); // Tiek izprintēts vārds pa burtiem "Start..."
                System.Threading.Thread.Sleep(100);
            }
            Console.ReadLine();
            Console.Clear();

            bool exit = false;

            while (!exit)
            {

                Console.WriteLine(@" 
                                   _______       __      _____  ___        __      _____  ___   ____  ____     
                                  |   _  '\     /''\    (\'   \|'  \      /''\    (\'   \|'  \ ('  _||_ ' |    
                                  (. |_)  :)   /    \   |.\\   \    |    /    \   |.\\   \    ||   (  ) : |    
                                  |:     \/   /' /\  \  |: \.   \\  |   /' /\  \  |: \.   \\  |(:  |  | . )    
                                  (|  _  \\  //  __'  \ |.  \    \. |  //  __'  \ |.  \    \. | \\ \__/ //     
                                  |: |_)  :)/   /  \\  \|    \    \ | /   /  \\  \|    \    \ | /\\ __ //\     
                                  (_______/(___/    \___)\___|\____\)(___/    \___)\___|\____\)(__________)    

                                        _______   ____  ____  ___       _______  ___________  _______          
                                       /'      \ ('  _||_ ' ||'  |     /'     '|('     _   ')/'     '|         
                                      |:        ||   (  ) : |||  |    (: ______) )__/  \\__/(: ______)         
                                      |_____/   )(:  |  | . )|:  |     \/    |      \\_ /    \/    |           
                                       //      /  \\ \__/ //  \  |___  // ___)_     |.  |    // ___)_          
                                      |:  __   \  /\\ __ //\ ( \_|:  \(:      '|    \:  |   (:      '|         
                                      |__|  \___)(__________) \_______)\_______)     \__|    \_______)         
              ");

                Console.WriteLine(@"
,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,
||=====================================||
||1. 1-18                              ||
||2. 19-36                             ||
||3. Even                              ||
||4. Odd                               ||
||5. Red                               ||
||6. Black                             ||
||7. 1st 12 (1-12)                     ||
||8. 2nd 12 (13-24)                    ||
||9. 3rd 12 (25-36)                    ||
||10. 0                                ||
||                                     ||
||(Place a bet by typing a number)     ||
||=====================================||
`````````````````````````````````````````"); //Lietotājam tiek prasīts ievadīt izveles numuru
                Console.Write(">>> ");

                int betChoice = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter your bet amount:");
                Console.Write(">>> ");
                int betAmount = Convert.ToInt32(Console.ReadLine());

                if (betAmount > money)
                {
                    Console.WriteLine("You don't have enough money to place this bet.");
                    System.Threading.Thread.Sleep(2000);
                    Console.Clear();
                    continue;
                }

                int randomNumber = new Random().Next(0, 37); // Ģenerē skaitli no 0 līdz 37 (neieskaitot)

                string color;
                if (randomNumber == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    color = "Green";
                }
                else if ((randomNumber >= 1 && randomNumber <= 10) || (randomNumber >= 19 && randomNumber <= 28))
                {
                    Console.ForegroundColor = (randomNumber % 2 == 0) ? ConsoleColor.Black : ConsoleColor.DarkRed;
                    color = (randomNumber % 2 == 0) ? "Black" : "Red";
                }
                else if ((randomNumber >= 11 && randomNumber <= 18) || (randomNumber >= 29 && randomNumber <= 36))
                {
                    Console.ForegroundColor = (randomNumber % 2 == 0) ? ConsoleColor.DarkRed : ConsoleColor.Black;
                    color = (randomNumber % 2 == 0) ? "Red" : "Black";
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    color = "Green";
                }

                Console.WriteLine("\nThe ball landed on " + randomNumber + " (" + color + ")");

                System.Threading.Thread.Sleep(1500); // Gaida 1,5 sekundes, lai redzētu rezultātu

                bool won = false;

                // Pārbauda, vai lietotājs ir uzvarējis
                switch (betChoice)
                {
                    case 1: // 1-18
                        won = (randomNumber >= 1 && randomNumber <= 18);
                        break;
                    case 2: // 19-36
                        won = (randomNumber >= 19 && randomNumber <= 36);
                        break;
                    case 3: // Even
                        won = (randomNumber % 2 == 0 && randomNumber != 0);
                        break;
                    case 4: // Odd
                        won = (randomNumber % 2 != 0);
                        break;
                    case 5: // Red
                        won = (randomNumber == 1 || randomNumber == 3 || randomNumber == 5 || randomNumber == 7 || randomNumber == 9 || randomNumber == 12 || randomNumber == 14 || randomNumber == 16 || randomNumber == 18 || randomNumber == 19 || randomNumber == 21 || randomNumber == 23 || randomNumber == 25 || randomNumber == 27 || randomNumber == 30 || randomNumber == 32 || randomNumber == 34 || randomNumber == 36);
                        break;
                    case 6: // Black
                        won = (randomNumber == 2 || randomNumber == 4 || randomNumber == 6 || randomNumber == 8 || randomNumber == 10 || randomNumber == 11 || randomNumber == 13 || randomNumber == 15 || randomNumber == 17 || randomNumber == 20 || randomNumber == 22 || randomNumber == 24 || randomNumber == 26 || randomNumber == 28 || randomNumber == 29 || randomNumber == 31 || randomNumber == 33 || randomNumber == 35);
                        break;
                    case 7: // 1st 12
                        won = (randomNumber >= 1 && randomNumber <= 12);
                        break;
                    case 8: // 2nd 12
                        won = (randomNumber >= 13 && randomNumber <= 24);
                        break;
                    case 9: // 3rd 12
                        won = (randomNumber >= 25 && randomNumber <= 36);
                        break;
                    case 10: // 0
                        won = (randomNumber == 0);
                        break;
                    default:
                        Console.WriteLine("Invalid bet choice.");
                        continue;
                }

                if (won)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("You win!");
                    money += betAmount;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You lose!");
                    money -= betAmount;
                }

                Console.WriteLine($"Your money: {money}$"); // Izdrukā pašreizējo naudas daudzumu uz ekrāna
                Console.WriteLine("\nVēlaties vēlvreiz spēlēt? (y/n)");
                string playAgain = Console.ReadLine();
                if (playAgain.ToLower() != "y")
                {
                    Console.ResetColor();
                    Console.Clear();
                    break; // Pārtrauc ciklu, iziet no spēles
                }
                Console.ResetColor();
                Console.Clear();
            }
            return money; // Atgriež atjaunināto naudas daudzumu
        }
    }
}
