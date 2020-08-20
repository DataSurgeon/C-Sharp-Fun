using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2 {
    class Program {
        static int Main(string[] args) {
            // App Info
            String appName = "Guess That Number, in Ten Tries!";
            String appVersion = "1.0";
            String appAuthor = "Norberto Limon Jr AKA DataSurgeon369";

            // Display Header and reset Text Color
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("{0}:\nVersion {1}\nBrought to you by: {2}\n", appName, appVersion, appAuthor);
            Console.ResetColor();

            // Get user input
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Welcome to Guess that Number in Ten Tries! What is your name?");
            String input = Console.ReadLine();
            Console.WriteLine("Great! Hello " + input + ". Lets play a game!");
            Console.ResetColor();

            // Game Loop
            bool letsgo = true;
            while (letsgo) {
                // New game: set preliminaries
                Random random = new Random();
                int correctNumber = random.Next(1, 1000);
                int guess;
                int proceed;
                int remainingGuesses = 10;

                // Intro: get user's guess and compare it to the correct value
                do {
                    Console.WriteLine("Guess a number between 1 and 1000. You get " + remainingGuesses + " more guesses!");
                    // Verify that it is a number
                    input = Console.ReadLine();
                    if (!int.TryParse(input, out guess))
                    {
                        break;
                    }
                    // If number, Check number relative to correct answer
                    proceed = print_result(guess, correctNumber);
                    // If Win, break inner loop
                    if (proceed == 0)
                    {
                        break;
                    }
                    remainingGuesses--;
                    Console.ResetColor();
                } while ((guess >= 1 && guess <= 1000) && remainingGuesses > 0);
                // Game Over: Feedback
                if (guess == correctNumber)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("Just in time too!");
                    Console.ResetColor();
                }
                else if (guess > 1000 || guess < 1) {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Pay attention next time. 1 through 1000 only. You lose!! >:D");
                    Console.ResetColor();
                }
                else {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Sorry Chump. End of the Road. You Lose!! >:D");
                    Console.ResetColor();
                }
                // Try Again?
                Console.WriteLine("Would you like to play again? Y or N");
                String tryAgain = Console.ReadLine();
                if (tryAgain.ToUpper() == "Y") {
                    Console.WriteLine("Awesome! Here we go again!");
                    letsgo = true;
                }
                else if (tryAgain.ToUpper() == "N") {
                    Console.WriteLine("Thanks for Playing! Goodbye.");
                    letsgo = false;
                }
                else {
                    Console.WriteLine("Sorry, invalid response. Goodbye!");
                    letsgo = false;
                }
            }
            return 0;
        }
        // Guess Comparison Logic
        static int print_result(int guess, int correctNumber)
        {
            if (guess > correctNumber)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(guess + " is Too High!");
                Console.ResetColor();
                return 1;
            }
            else if (guess < correctNumber)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(guess + " is Too Low!");
                Console.ResetColor();
                return 1;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Correct! You got it! You Win!! :D");
                // break to get out of te inner loop and allow for continue
                Console.ResetColor();
                return 0;
            }
        }
    }
}
