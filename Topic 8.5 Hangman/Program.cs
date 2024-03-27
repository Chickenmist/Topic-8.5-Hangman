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
            Console.Title = "Hangman";

            while(running)
            {
                string selection = "";

                HangmanTitlePrint();

                Console.WriteLine("Welcome to Hangman! Would you like to play or add a new word to the pool?");
                Console.WriteLine("");
                Console.WriteLine("Enter 'GAME' to play, 'NEW' to add a new word, or 'QUIT' to close the game: ");

                while (selection == "")
                {
                    selection = Console.ReadLine().ToUpper();
                    Console.WriteLine("");

                    if (selection == "GAME")
                    {
                        Game();
                    }
                    else if (selection == "NEW")
                    {
                        AddNewWord();
                    }
                    else if (selection == "QUIT")
                    {
                        running = false;
                    }
                    else
                    {
                        selection = "";

                        Console.WriteLine("Invalid Selection");
                        Console.WriteLine("");
                    }
                }
                Console.WriteLine("");
            }
        }

        public static void AddNewWord()
        {
            string newWord = "";
            int onlyLetters = 0; //0 means that the word only has letters in it

            Console.Clear();

            HangmanTitlePrint();

            while (newWord == "")
            {
                Console.Write("Type the word you want to add (cannot have spaces or special characters): ");
                newWord = Console.ReadLine().ToUpper().Trim().Replace(" ", "");

                Console.WriteLine((int)newWord[0]);
            }

            for (int i = 0; i < newWord.Length; i++)
            {
                if (newWord[i] < 65 || newWord[i] > 90) //65 is the value for A on the ASCII Table, 90 is the value for Z on the ASCII Table
                {
                    onlyLetters++;
                }
            }

            if (onlyLetters > 0 || words.Contains(newWord))
            {
                Console.WriteLine("");
                Console.WriteLine("Cannot add this word");
            }
            else
            {
                words.Add(newWord);
                
                Console.WriteLine("");
                Console.WriteLine("Word added");

            }

            Console.Clear();
        }

        public static void Game()
        {
            Random random = new Random();
            int guesses, wordSelection;
            string difficulty;
            bool gameActive = true, difficultyNotSelected = true;

            Console.Clear();

            HangmanTitlePrint();

            while(difficultyNotSelected)
            {
                Console.WriteLine("Please select a difficulty: ");
                Console.WriteLine("Normal: 5 guesses");
                Console.WriteLine("Hard: 3 guesses");
                Console.Write("Difficulty: ");
                difficulty = Console.ReadLine().ToUpper();

                if (difficulty == "NORMAL")
                {
                    guesses = 5;
                    difficultyNotSelected = false;
                }
                else if (difficulty == "HARD")
                {
                    guesses = 3;
                    difficultyNotSelected = false;
                }
                else
                {
                    Console.WriteLine("");
                    Console.WriteLine("Invalid");
                    Console.WriteLine("");
                }
            }

            Console.Clear();


        }

        public static void HangmanTitlePrint()
        {
            Console.WriteLine(" ____ ____ ____ ____ ____ ____ ____ ");
            Console.WriteLine("||H |||A |||N |||G |||M |||A |||N ||");
            Console.WriteLine("||__|||__|||__|||__|||__|||__|||__||");
            Console.WriteLine("|/__\\|/__\\|/__\\|/__\\|/__\\|/__\\|/__\\|");
            Console.WriteLine("");
        }
    }
}