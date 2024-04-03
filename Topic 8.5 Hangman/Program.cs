using System.Runtime.InteropServices;

namespace Topic_8._5_Hangman
{
    internal class Program
    {
        //Wilson
        
        public static bool running = true;

        public static List<string> words = new List<string>() { "TEST" };

        public static List<string> wordLetters = new List<string>();

        public static List<string> usedLetters = new List<string>();

        public static List<string> guessedLetters = new List<string>();

        public static Random rnd = new Random();

        public static string wordSelection = "";

        public static int incorrectGuesses = 0;

        public static string letter = "";

        public static string selectedLetter = "";

        public static string difficulty = "";

        static void Main(string[] args)
        {
            Console.Title = "Hangman";

            while(running)
            {
                string selection = "";

                Console.Clear();

                HangmanTitlePrint();

                Console.WriteLine("    Welcome to Hangman! Would you like to play or add a new word to the pool?");
                Console.WriteLine("");
                Console.WriteLine("    Enter 'GAME' to play, 'NEW' to add a new word, or 'QUIT' to close the game: ");
                Console.WriteLine("");
                

                while (selection == "")
                {
                    Console.Write("    Selection: ");
                    selection = Console.ReadLine().ToUpper();

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

                        Console.WriteLine("");
                        Console.WriteLine("    Invalid Selection");
                        Console.WriteLine("");
                    }
                }
            }
        }

        public static void AddNewWord()
        {
            string newWord = "";
            int onlyLetters = 0; //0 means that the word only has letters in it
            bool waitingForWord = true;

            Console.Clear();

            HangmanTitlePrint();

            while (waitingForWord)
            {
                onlyLetters = 0;

                Console.Write("    Type the word you want to add (cannot have spaces or special characters): ");
                newWord = Console.ReadLine().ToUpper();
                
                for (int i = 0; i < newWord.Length; i++)
                {
                    if (newWord[i] < 65 || newWord[i] > 90) //65 is the value for A on the ASCII Table, 90 is the value for Z on the ASCII Table
                    {
                        onlyLetters++;
                    }
                }
                if (onlyLetters > 0)
                {
                    Console.WriteLine("");
                    Console.WriteLine("    This word cannot be added as it does not contain only letters");
                    Console.WriteLine("");
                }
                else if (words.Contains(newWord))
                {
                    Console.WriteLine("");
                    Console.WriteLine("    This word is already in the word pool");
                    Console.WriteLine("");
                }
                else if (newWord == "")
                {
                    Console.WriteLine("");
                    Console.WriteLine("    Please enter a word");
                    Console.WriteLine("");
                }
                else
                {
                    words.Add(newWord);
                    
                    Console.WriteLine("");
                    Console.WriteLine("    Word added");
                    Console.WriteLine("");

                    waitingForWord = false;
                }
            }
            
            Console.Write("    You will be returned to the main menu in 5 seconds");
            Thread.Sleep(5000);
        }

        public static void GameDifficultySelection()
        {
            bool difficultyNotSelected = true;

            Console.Clear();
            
            wordSelection = words[rnd.Next(words.Count - 1)];

            SetWordLetters();
            
            HangmanTitlePrint();

            while(difficultyNotSelected)
            {
                Console.WriteLine("    Please select a difficulty: ");
                Console.WriteLine("");
                Console.WriteLine("    Normal: 5 incorrect guesses");
                Console.WriteLine("");
                Console.WriteLine("    Hard: 3 incorrect guesses");
                Console.WriteLine("");
                Console.Write("    Difficulty: ");
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
                    Console.WriteLine("    Invalid");
                    Console.WriteLine("");
                }
            }
        }

        public static void NormalGame()
        {
            bool gameActive = true;

            incorrectGuesses =  0;

            while (gameActive)
            {
                if (incorrectGuesses < 6)
                {
                    if (wordLetters.Contains("_"))
                    {
                        letter = "";
                        Console.Clear();
                        
                        HangmanTitlePrint();
                        
                        DrawGallows();
                        
                        RemainingGuesses();
                        
                        PrintRevealedLetters();
                        
                        PrintGuessedLetters();

                        MakeGuess();
                    }
                    else
                    {
                        HangmanTitlePrint();

                        Console.WriteLine("      +---+");
                        Console.WriteLine("      |   |");
                        Console.WriteLine("          |");
                        Console.WriteLine("          |");
                        Console.WriteLine("          |");
                        Console.WriteLine("     / \\  |");
                        Console.WriteLine("    =========");
                        Console.WriteLine("");

                        Console.WriteLine("    You guessed the word! Well done!");
                        Console.ReadLine();
                        gameActive = false;
                    }
                    
                }
                else if (incorrectGuesses == 6)
                {
                    Console.Clear();

                    HangmanTitlePrint();

                    DrawGallows();

                    RemainingGuesses();

                    PrintRevealedLetters();

                    PrintGuessedLetters();

                    GameOver();
                }
            }


        }

        public static void HardGame()
        {

        }

        public static void HangmanTitlePrint()
        {
            Console.WriteLine("     ____ ____ ____ ____ ____ ____ ____ ");
            Console.WriteLine("    ||H |||A |||N |||G |||M |||A |||N ||");
            Console.WriteLine("    ||__|||__|||__|||__|||__|||__|||__||");
            Console.WriteLine("    |/__\\|/__\\|/__\\|/__\\|/__\\|/__\\|/__\\|");
            Console.WriteLine("");
        }

        public static void DrawGallows()
        {
            if (difficulty == "NORMAL")
            {
                switch (incorrectGuesses)
                {
                    case 0:
                        Console.WriteLine("      +---+");
                        Console.WriteLine("      |   |");
                        Console.WriteLine("          |");
                        Console.WriteLine("          |");
                        Console.WriteLine("          |");
                        Console.WriteLine("          |");
                        Console.WriteLine("    =========");
                        Console.WriteLine("");
                        break;
                        
                    case 1:
                        Console.WriteLine("      +---+");
                        Console.WriteLine("      |   |");
                        Console.WriteLine("      O   |");
                        Console.WriteLine("          |");
                        Console.WriteLine("          |");
                        Console.WriteLine("          |");
                        Console.WriteLine("    =========");
                        Console.WriteLine("");
                        break;

                    case 2:
                        Console.WriteLine("      +---+");
                        Console.WriteLine("      |   |");
                        Console.WriteLine("      O   |");
                        Console.WriteLine("      |   |");
                        Console.WriteLine("          |");
                        Console.WriteLine("          |");
                        Console.WriteLine("    =========");
                        Console.WriteLine("");
                        break;

                    case 3:
                        Console.WriteLine("      +---+");
                        Console.WriteLine("      |   |");
                        Console.WriteLine("      O   |");
                        Console.WriteLine("     /|   |");
                        Console.WriteLine("          |");
                        Console.WriteLine("          |");
                        Console.WriteLine("    =========");
                        Console.WriteLine(""); 
                        break;

                    case 4:
                        Console.WriteLine("      +---+");
                        Console.WriteLine("      |   |");
                        Console.WriteLine("      O   |");
                        Console.WriteLine("     /|\\  |");
                        Console.WriteLine("          |");
                        Console.WriteLine("          |");
                        Console.WriteLine("    =========");
                        Console.WriteLine(""); 
                        break;

                    case 5:
                        Console.WriteLine("      +---+");
                        Console.WriteLine("      |   |");
                        Console.WriteLine("      O   |");
                        Console.WriteLine("     /|\\  |");
                        Console.WriteLine("     /    |");
                        Console.WriteLine("          |");
                        Console.WriteLine("    =========");
                        Console.WriteLine("");
                        break;

                    case 6:
                        Console.WriteLine("      +---+");
                        Console.WriteLine("      |   |");
                        Console.WriteLine("      O   |");
                        Console.WriteLine("     /|\\  |");
                        Console.WriteLine("     / \\  |");
                        Console.WriteLine("          |");
                        Console.WriteLine("    =========");
                        Console.WriteLine("");
                        break;
                }
            }
            else if (difficulty == "HARD")
            {
                switch (incorrectGuesses)
                {
                    case 0:
                        Console.WriteLine("      +---+");
                        Console.WriteLine("      |   |");
                        Console.WriteLine("          |");
                        Console.WriteLine("          |");
                        Console.WriteLine("          |");
                        Console.WriteLine("          |");
                        Console.WriteLine("    =========");
                        Console.WriteLine("");
                        break;
                    
                    case 1:
                        Console.WriteLine("      +---+");
                        Console.WriteLine("      |   |");
                        Console.WriteLine("      O   |");
                        Console.WriteLine("      |   |");
                        Console.WriteLine("          |");
                        Console.WriteLine("          |");
                        Console.WriteLine("    =========");
                        Console.WriteLine("");
                        break;
                    
                    case 2:
                        Console.WriteLine("      +---+");
                        Console.WriteLine("      |   |");
                        Console.WriteLine("      O   |");
                        Console.WriteLine("     /|\\  |");
                        Console.WriteLine("          |");
                        Console.WriteLine("          |");
                        Console.WriteLine("    =========");
                        Console.WriteLine("");
                        break;
                    
                    case 3:
                        Console.WriteLine("      +---+");
                        Console.WriteLine("      |   |");
                        Console.WriteLine("      O   |");
                        Console.WriteLine("     /|\\  |");
                        Console.WriteLine("     /    |");
                        Console.WriteLine("          |");
                        Console.WriteLine("    =========");
                        Console.WriteLine("");
                        break;
                    
                    case 4:
                        Console.WriteLine("      +---+");
                        Console.WriteLine("      |   |");
                        Console.WriteLine("      O   |");
                        Console.WriteLine("     /|\\  |");
                        Console.WriteLine("     / \\  |");
                        Console.WriteLine("          |");
                        Console.WriteLine("    =========");
                        Console.WriteLine("");
                        break;
                }
            }
        }

        public static void RemainingGuesses()
        {
            Console.WriteLine($"    Incorrect guesses = {incorrectGuesses}");
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
            Console.Write("    ");
            for (int i = 0; i < wordLetters.Count; i++) 
            {
                Console.Write($"{wordLetters[i]}");
            }
            Console.WriteLine("");
            Console.WriteLine("");
        }

        public static void PrintGuessedLetters()
        {
            Console.Write("    Guessed Letters = ");

            for (int i = 0;i < guessedLetters.Count(); i++)
            {
                Console.Write($"{guessedLetters[i]} ");
            }

            Console.WriteLine("");
            Console.WriteLine("");
        }

        public static void MakeGuess()
        {
            int notInWord = 0;

            bool letterNotSelected = true;

            while (letterNotSelected)
            {
                Console.Write("    Guess: ");
                selectedLetter = Console.ReadLine().ToUpper().Trim();

                if (selectedLetter.Length > 1 || selectedLetter.Length == 0) //This makes sure there is only one character in the guess 
                {
                    Console.WriteLine("");
                    Console.WriteLine("    Invalid Guess");
                    Console.WriteLine("");
                }
                else if (guessedLetters.Contains(selectedLetter))
                {
                    Console.WriteLine("");
                    Console.WriteLine("    You have already guessed that letter");
                    Console.WriteLine("");
                }
                else
                {
                    for (int i = 0; i < selectedLetter.Length; i++) //This makes sure that the guess is a letter
                        {
                            if (selectedLetter[i] < 65 || selectedLetter[i] > 90) //Considering that there is only one character in the string this shouldn't loop multiple times
                            {
                                Console.WriteLine("");
                                Console.WriteLine("    Invalid Guess");
                                Console.WriteLine("");
                            }
                            else
                            {
                                letter = selectedLetter;
                                letterNotSelected = false;
                            }
                    }
                }       
            }
            
            guessedLetters.Add(letter); //This adds the guessed letter to a list so that it can't be guessed again
            
            for (int i = 0; i < wordSelection.Length; i++) //Scans the word for the letter
            {
                if (letter == wordSelection[i] + "") //The letter is in that position in the word
                {
                    wordLetters[i] = letter;
                }
                else //The letter is not in that position in the word
                {
                    notInWord++;
                }
            }

            if (notInWord >= wordSelection.Length) //If this happens then the letter was not in the word
            {
                incorrectGuesses++;

                Console.WriteLine("");
                Console.WriteLine("    That letter was not in the word");
                Console.WriteLine("");
                Console.Write("    Press enter to continue");
                Console.ReadLine();
            }
            else //Letter was in the word
            {
                Console.WriteLine("");
                Console.WriteLine("    That letter was in the word");
                Console.WriteLine("");
                Console.Write("    Press enter to continue");
                Console.ReadLine();
            }
        }

        public static void GameOver()
        {
            if (difficulty == "NORMAL")
            {
                Console.WriteLine("You have guessed incorrectly more than 5 times. You lose");

                Console.WriteLine("You will be returned to the main menu in 5 seconds");
                Thread.Sleep(5000);
            }
            else if (difficulty == "HARD")
            {
                Console.WriteLine("You have guessed incorrectly more than 3 times. You lose");

                Console.WriteLine("You will be returned to the main menu in 5 seconds");
                Thread.Sleep(5000);
            }
        }
    }
}