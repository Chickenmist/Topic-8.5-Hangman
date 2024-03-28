using System.Runtime.InteropServices;

namespace Topic_8._5_Hangman
{
    internal class Program
    {
        //Wilson
        
        public static bool running = true;

        public static List<string> words = new List<string>() { "", "", "" };

        public static List<string> wordLetters = new List<string>();

        public static List<string> usedLetters = new List<string>();

        public static Random rnd = new Random();

        public static string wordSelection = "";

        public static int incorrectGuesses = 0;

        public static string letter = "";

        public static string selectedLetter = "";

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
                        GameDifficultySelection();
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
                newWord = Console.ReadLine().ToUpper();
                
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
                    Console.Write("Cannot add this word");
                }
                else
                {
                    words.Add(newWord);
                    
                    Console.WriteLine("");
                    Console.Write("Word added");
                }
            }

            Console.Read();
            Console.Clear();
        }

        public static void GameDifficultySelection()
        {
            string difficulty;
            bool difficultyNotSelected = true;

            Console.Clear();
            
            wordSelection = words[rnd.Next(words.Count - 1)];

            SetWordLetters();
            
            HangmanTitlePrint();

            while(difficultyNotSelected)
            {
                Console.WriteLine("Please select a difficulty: ");
                Console.WriteLine("Normal: 5 incorrect guesses");
                Console.WriteLine("Hard: 3 incorrect guesses");
                Console.Write("Difficulty: ");
                difficulty = Console.ReadLine().ToUpper();

                if (difficulty == "NORMAL")
                {
                    difficultyNotSelected = false;
                    NormalGame();
                }
                else if (difficulty == "HARD")
                {
                    difficultyNotSelected = false;
                    HardGame();
                }
                else
                {
                    Console.WriteLine("");
                    Console.WriteLine("Invalid");
                    Console.WriteLine("");
                }
            }
        }

        public static void NormalGame()
        {
            while (incorrectGuesses < 5)
            {
                letter = "";

                Console.Clear();

                HangmanTitlePrint();

                DrawGallows();

                RemainingGuesses();

                PrintRevealedLetters();

                
                
            }

        }

        public static void HardGame()
        {

        }

        public static void HangmanTitlePrint()
        {
            Console.WriteLine(" ____ ____ ____ ____ ____ ____ ____ ");
            Console.WriteLine("||H |||A |||N |||G |||M |||A |||N ||");
            Console.WriteLine("||__|||__|||__|||__|||__|||__|||__||");
            Console.WriteLine("|/__\\|/__\\|/__\\|/__\\|/__\\|/__\\|/__\\|");
            Console.WriteLine("");
        }

        public static void DrawGallows()
        {
            Console.WriteLine("  +---+");
            Console.WriteLine("  |   |");
            Console.WriteLine("      |");
            Console.WriteLine("      |");
            Console.WriteLine("      |");
            Console.WriteLine("      |");
            Console.WriteLine("=========");
            Console.WriteLine("");
        }

        public static void RemainingGuesses()
        {
            Console.WriteLine($"Incorrect guesses = {incorrectGuesses}");
            Console.WriteLine("");
        }

        public static void SetWordLetters()
        {
            for (int i = 0; i < wordSelection.Length; i++)
            {
                wordLetters.Add("_");
            }
        }

        public static void PrintRevealedLetters()
        {
            for (int i = 0; i < wordLetters.Count - 1; i++) 
            {
                Console.WriteLine(wordLetters[i]);
            }
        }

        public static void MakeGuess()
        {
            while (letter == "")
            {
                Console.Write("Guess: ");
                selectedLetter = Console.ReadLine().ToUpper();



            }
        }
    }
}