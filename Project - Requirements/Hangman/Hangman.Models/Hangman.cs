namespace Hangman.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using global::Hangman.Data.Interfaces;
    using global::Hangman.Data.Utility;

    public class Hangman
    {
        private const string StartMessage = "Welcome to “Hangman” game. Please try to guess my secret word. \n" +
                                            "Use 'top' to view the top scoreboard, 'restart' to start a new game, 'help' \nto cheat and 'exit' " +
                                            "to quit the game.";

        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly IWordsRepository wordsRepository;
        private readonly Scoreboard scoreboard;

        private bool isCheated = false;
        private bool isRestartRequested = false;
         
        private int mistakeCounter = 0;
        private string theChosenWord;
        private char[] unknownWord;
        private Dictionary<string, int> score;

        public Hangman(IReader reader, IWriter writer, IWordsRepository wordsRepository)
        {
            this.reader = reader;
            this.writer = writer;
            this.wordsRepository = wordsRepository;
            this.scoreboard = new Scoreboard();
        }

        public void Start()
        {
            string[] someWords = this.wordsRepository.EnglishWords.ToArray();

            this.score = new Dictionary<string, int>();
            do
            {
                this.gen(someWords);
                Console.WriteLine(StartMessage);
                this.isCheated = false;
                this.mistakeCounter = 0;
                do
                {
                    this.PrintGuessedWord();
                    this.writer.ShowMessage("Enter your guess: ");
                    string enteredString = Console.ReadLine();
                    this.ProcessCommand(enteredString);
                    if (this.isRestartRequested)
                    {
                        break;
                    }
                }
                while (!this.IsWordKnown());

                if (this.isRestartRequested)
                {
                    this.isRestartRequested = false;
                    Console.WriteLine();
                    continue;
                }

                if (!this.isCheated)
                {
                    this.writer.ShowMessage("You won with {0} mistakes.\n", this.mistakeCounter);
                    this.PrintGuessedWord();
                    this.writer.ShowMessage("Please enter your name for the top scoreboard: ");
                    this.AddInScoreboard(this.score);
                    this.Printboard(this.score);
                }
                else
                {
                    this.writer.ShowMessage("You won with {0} mistakes but you have cheated. You are not allowed\n", this.mistakeCounter);
                    this.writer.ShowMessage("to enter into the scoreboard.\n");
                    this.PrintGuessedWord();
                }
            }
            while (true);
        }

        bool IsValidLetter(string enteredString)
        {
            char enteredSymbol;
            var isLetterValid = char.TryParse(enteredString, out enteredSymbol) &&
                                char.IsLetter(enteredSymbol);
            return isLetterValid;
        }

        private void PrintGuessedWord()
        {
            this.writer.ShowMessage("The secret word is: ");
            this.writer.ShowMessage(string.Join(" ", this.unknownWord));
            this.writer.ShowMessage(Environment.NewLine);
        }

        private void ProcessCommand(string command)
        {
            command = command.ToLower();

            switch (command)
            {
                case "top":
                    {
                        this.Printboard(this.score);
                        break;
                    }
                case "restart":
                    {
                        this.isRestartRequested = true;
                        break;
                    }
                case "help":
                    {
                        this.isCheated = true;
                        this.ExecuteHelpCommand();
                        break;
                    }
                case "exit":
                    {
                        Console.WriteLine("Good bye!");
                        Environment.Exit(1);
                        break;
                    }
                default:
                    {
                        this.ReadLetter(command);
                        break;
                    }
            }
        }
 
        private void ReadLetter(string command)
        {
            if (!this.IsValidLetter(command))
            {
                this.writer.ShowMessage("Incorrect guess or command!\n");
                return;
            }

            bool isLetterInTheWord = false;
            int letterKnown = 0;
            char enteredSymbol = char.Parse(command);
            for (int i = 0; i < this.unknownWord.Length; i++)
            {
                if (this.theChosenWord[i] == enteredSymbol)
                {
                    this.unknownWord[i] = enteredSymbol;
                    letterKnown++;
                    isLetterInTheWord = true;
                }
            }

            if (isLetterInTheWord)
            {
                Console.WriteLine("Good job! You revealed {0} letters.", letterKnown);
            }
            else
            {
                Console.WriteLine("Sorry! There are no unrevealed letters \"{0}\".", command);
                this.mistakeCounter++;
            }
        }

        private void gen(string[] someWords)
        {
            Random randomNumber = new Random();
            this.theChosenWord = someWords[randomNumber.Next(0, 10)];
            int lengthOfTheWord = this.theChosenWord.Length;
            this.unknownWord = new char[lengthOfTheWord];
            for (int i = 0; i < lengthOfTheWord; i++)
            {
                this.unknownWord[i] = '_';
            }
        }

        private bool IsWordKnown()
        {
            for (int i = 0; i < this.unknownWord.Length; i++)
            {
                if (this.unknownWord[i] == '_')
                {
                    return false;
                }
            }
            return true;
        }

        private void AddInScoreboard(Dictionary<string, int> score)
        {
            string name = string.Empty;
            bool hasDouble = false;
            do
            {
                hasDouble = false;
                name = Console.ReadLine();
                foreach (var item in score)
                {
                    if (item.Key == name)
                    {
                        Console.Write("This name already exists in the Scoreboard! Type another: ");
                        hasDouble = true;
                    }
                }
            }
            while (hasDouble);
            score.Add(name, this.mistakeCounter);
            this.mistakeCounter = 0;
        }

        private void Printboard(Dictionary<string, int> score)
        {
            if (score.Count == 0)
            {
                Console.WriteLine("Empty Scoreboard!");
                return;
            }
            List<KeyValuePair<string, int>> key = new List<KeyValuePair<string, int>>();
            foreach (var item in score)
            {
                KeyValuePair<string, int> current = new KeyValuePair<string, int>(item.Key, item.Value);
                key.Add(current);
            }
            key.Sort(new OutComparer());
            Console.WriteLine("Scoreboard:");
            for (int i = 0; i < score.Count; i++)
            {
                Console.WriteLine("{0}. {1} --> {2} mistake", i + 1, key[i].Key, key[i].Value);
                if (i == 4)
                {
                    break;
                }
            }
            Console.WriteLine();
        }

        private void ExecuteHelpCommand()
        {
            this.isCheated = true;
            for (int i = 0; i < this.unknownWord.Length; i++)
            {
                if (this.unknownWord[i] == '_')
                {
                    this.unknownWord[i] = this.theChosenWord[i];
                    break;
                }
            }
        }
    }
}