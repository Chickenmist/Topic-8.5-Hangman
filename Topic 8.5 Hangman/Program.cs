using System.Runtime.InteropServices;

namespace Topic_8._5_Hangman
{
    internal class Program
    {
        //Wilson
        
        public static bool running = true;

        public static List<string> words = new List<string>() { "", "", "" };

        static void Main(string[] args)
        {
            while(running)
            {
                string selection = "";

                Console.WriteLine(" ____ ____ ____ ____ ____ ____ ____ ");
                Console.WriteLine("||H |||A |||N |||G |||M |||A |||N ||");
                Console.WriteLine("||__|||__|||__|||__|||__|||__|||__||");
                Console.WriteLine("|/__\\|/__\\|/__\\|/__\\|/__\\|/__\\|/__\\|");
                Console.WriteLine("");

                while (selection == "")
                {
                    selection = Console.ReadLine().ToUpper();

                    if (selection == "GAME")
                    {
                        Game();
                    }
                    else if (selection == "NEW")
                    {
                        AddNewWord();
                    }
                    else
                    {
                        selection = "";
                    }
                }
                Console.WriteLine("");
            }
        }

        public static void AddNewWord()
        {
            string newWord = "";

            while(newWord == "")
            {
                Console.Write("Type the word you want to add (cannot have spaces or special characters): ");
                newWord = Console.ReadLine().ToUpper();

                if (words.Contains(newWord) || newWord.Contains("1"))
                {
                    Console.WriteLine("");
                    Console.WriteLine("Cannot add this word");
                }
                else
                {
                    Console.WriteLine("Word added");
                }
            }
        }

        public static void Game()
        {
            Random random = new Random();
            int guesses, wordSelection;
            bool gameActive = true;

        }
    }
}