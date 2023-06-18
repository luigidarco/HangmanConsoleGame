// See https://aka.ms/new-console-template for more information
using System.Text.RegularExpressions;
enum GameOption
{
    RandomGame = 1,
    PredefinedGame = 2,
    Exit = 3
}

public class Program
{
    public static void Main(string[] args)
    {
        Menu();
    }

    static void Menu()
    {
        GameOption userChoice;

        do
        {
            Console.Write(@"
Welcome to Hangman Game!
1. Start a random game.
2. Start a predefined game.
3. Exit.

Choose an option: ");

            userChoice = (GameOption)Convert.ToInt32(Console.ReadLine());

            switch (userChoice)
            {
                case GameOption.RandomGame:
                    // setupRandomGame();
                    break;
                case GameOption.PredefinedGame:
                    setupPredefinedGame();
                    break;
                case GameOption.Exit:
                    Console.WriteLine("Thanks for playing!");
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again. \n");
                    break;
            }

        } while (userChoice < GameOption.RandomGame || userChoice > GameOption.Exit);
    }

    static void setupPredefinedGame()
    {
        Console.Write("Input the secret phrase: ");
        char[] secretPhrase = Console.ReadLine().ToUpper().ToCharArray();

        Console.Write("Input a hint: ");
        string hint = Console.ReadLine();

        Game game = new Game("Predefined", secretPhrase, hint);
        setupPlayers(game);
        startGame(game);
    }

    #region Random Game Mode Setup
    // static void setupRandomGame()
    // {
    //     Console.WriteLine("How many rounds do you want to play? ");
    //     int numberOfRounds = Convert.ToInt32(Console.ReadLine());

    //     List<Tuple<char[], string>> randomPhrases = PhraseRepository.GetRandomPhrases(numberOfRounds);
    //     Game game = new Game(randomPhrases);
    //     setupPlayers(game);
    //     startGame(game);

    //     // DEBUG:: Convert char[] to string
    //     foreach (Tuple<char[], string> randomPhrase in randomPhrases)
    //     {
    //         string secretPhrase = new string(randomPhrase.Item1);
    //         Console.WriteLine($"Secret Phrase: {secretPhrase}");
    //     }
    // }
    #endregion

    static void setupPlayers(Game game)
    {
        int numberOfPlayers;
        do
        {
            Console.Write("How many players (1-4): ");
            numberOfPlayers = Convert.ToInt32(Console.ReadLine());
        } while (numberOfPlayers < 1 || numberOfPlayers > 4);

        for (int i = 0; i < numberOfPlayers; i++)
        {
            Console.Write($"Set player {i + 1} name: ");
            string playerName = Console.ReadLine();

            // Validate player name using regular expression
            bool isValidName = Regex.IsMatch(playerName, @"^[a-zA-Z0-9]+$");

            if (isValidName)
            {
                Player player = new Player(playerName);
                game.Players.Add(player);
            }
            else
            {
                Console.WriteLine("Invalid player name. Please enter a valid name.");
                i--; // Decrement i to repeat the input for the same player
            }

        }
    }
    static void startGame(Game game)
    {
        do
        {
            Console.Clear();

            if (game.Players.Count > 1)
            {
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine($"[{game.GetCurrentPlayer().Name}'s turn.]");
                Console.ForegroundColor = ConsoleColor.Black;
            }

            game.GetCurrentPlayer().Hang.Draw();
            Console.Write("Score(s): ");
            foreach (Player player in game.Players)
            {
                if (player == game.GetCurrentPlayer())
                {
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                }

                Console.Write($"{player.Name}:{player.Score}");
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write(player == game.Players[game.Players.Count - 1] ? "\n" : " | ");
            }
            Console.WriteLine($"Hint: {game.Hint}");
            Console.WriteLine($"Guessed letters: {game.getGuessedLetters()}");
            Console.WriteLine($"Hidden phrase: {new string(game.HiddenPhrase)}");

            // Check if all players are dead OR phrase is discovered.
            if (game.Players.All(player => player.Hang.IsDead()) || new string(game.HiddenPhrase) == new string(game.SecretPhrase))
            {
                results(game);
                break;
            }

            Console.Write("Input: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.ResetColor();

            // Get user input, capitalize and process it.
            string guess = Console.ReadLine().ToUpper();
            game.GuessLetter(guess, game.PlayerTurn);

            // if (game.IsOver() && new string(game.HiddenPhrase) == new string(game.SecretPhrase))
            // {
            //     game.HiddenPhrase = game.SecretPhrase;
            // }

        } while (true);

    }

    static void results(Game game)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("\nGame Over!");
        Console.ForegroundColor = ConsoleColor.Black;

        // Reveal the secret phrase in case of a loss.
        if (game.HiddenPhrase != game.SecretPhrase)
        {
            Console.WriteLine($"The secret phrase was: {new string(game.SecretPhrase)}");
        }

        // Show results for a solo game
        if (game.Players.Count == 1)
        {
            Console.WriteLine($"You ended up the game with {game.Players[0].Score} points!");
            return;
        }
    }
    public static void LoadingAnimation()
    {
        string[] frames = new string[]
        {
            "[ ● - - ]",
            "[ - ● - ]",
            "[ - - ● ]",
            "[ - ● - ]",
            "[ ● - - ]"
        };

        int currentFrameIndex = 0;
        int interations = 5;
        Console.CursorVisible = false;

        for (int i = 0; i < interations; i++)
        {
            Console.Write(frames[currentFrameIndex]);
            Thread.Sleep(50);
            Console.SetCursorPosition(Console.CursorLeft - frames[currentFrameIndex].Length, Console.CursorTop);
            currentFrameIndex = (currentFrameIndex + 1) % frames.Length;
        }
    }


}



