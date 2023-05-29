// See https://aka.ms/new-console-template for more information
const int RANDOM_GAME_OPTION = 1;
const int PREDEFINED_GAME_OPTION = 2;
const int EXIT_OPTION = 3;

Menu();

void Menu()
{
    int userChoice;

    do
    {
        Console.WriteLine("Welcome to the Hangman Game!");
        Console.WriteLine($"{RANDOM_GAME_OPTION}. Start a random game.");
        Console.WriteLine($"{PREDEFINED_GAME_OPTION}. Start a predefined game.");
        Console.WriteLine($"{EXIT_OPTION}. Exit \n");

        System.Console.Write($"Choose an option: ");
        userChoice = Convert.ToInt32(Console.ReadLine());

        switch (userChoice)
        {
            case RANDOM_GAME_OPTION:
                setupRandomGame();
                break;
            case PREDEFINED_GAME_OPTION:
                setupPredefinedGame();
                break;
            case EXIT_OPTION:
                Console.WriteLine("Thanks for playing!");
                break;
            default:
                Console.WriteLine("Invalid option. Please try again. \n");
                break;
        }

    } while (userChoice < 1 || userChoice > 3);
}

void setupPredefinedGame()
{
    Console.Write("Input the secret phrase: ");
    char[] secretPhrase = Console.ReadLine().ToUpper().ToCharArray();

    Console.Write("Input a hint: ");
    string hint = Console.ReadLine();

    Game game = new Game(secretPhrase, hint);
    setupPlayers(game);
    startGame(game);
}

void setupRandomGame()
{
    Console.WriteLine("This is a random game. \n");
    Console.WriteLine("How many rounds do you want to play? ");
    int numberOfRounds = Convert.ToInt32(Console.ReadLine());

    List<Tuple<char[], string>> randomPhrases = PhraseRepository.GetRandomPhrases(numberOfRounds);
    Game game = new Game(randomPhrases);
    setupPlayers(game);
    startGame(game);

    // DEBUG:: Convert char[] to string
    foreach (Tuple<char[], string> randomPhrase in randomPhrases)
    {
        string secretPhrase = new string(randomPhrase.Item1);
        Console.WriteLine($"Secret Phrase: {secretPhrase}");
    }
}

void setupPlayers(Game game)
{
    Console.Write("How many players (1-4): ");
    int numberOfPlayers = Convert.ToInt32(Console.ReadLine());
    for (int i = 0; i < numberOfPlayers; i++)
    {
        Console.Write($"Set player {i + 1} name: ");
        string playerName = Console.ReadLine();
        Player player = new Player(playerName);
        game.Players.Add(player);
    }
}

void startGame(Game game)
{
    do
    {
        // Display the game

        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("[Round: " + game.RoundNumber + "]");




        Console.ForegroundColor = ConsoleColor.DarkBlue;
        Console.WriteLine($"[{game.GetCurrentPlayer().Name}'s turn.]");
        Console.ForegroundColor = ConsoleColor.Black;

        game.GetCurrentPlayer().PlayerHang.Draw();

        // Display all global players score:

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
        Console.WriteLine($"Guessed letters: {game.GetGuessedLetters()}");
        Console.WriteLine($"Hidden phrase: {new string(game.HiddenPhrase)}");
        Console.Write("\nType a \u001b[1mletter\u001b[0m, the phrase or SKIP. \n");
        Console.Write("Input: ");
        char letter = Convert.ToChar(Console.ReadLine().ToUpper());
        game.GuessLetter(letter, game.PlayerTurn);

        if (game.IsOver() && new string(game.HiddenPhrase) == new string(game.SecretPhrase))
        {
            game.HiddenPhrase = game.SecretPhrase;
        }

    } while (!game.IsOver());

    results(game);

}

void results(Game game)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("\nGame Over!");

    Console.ForegroundColor = ConsoleColor.Black;
    Console.WriteLine($"The secret phrase was: {new string(game.SecretPhrase)}");
    Console.WriteLine($"The winner is: {game.getWinner().Name} with {game.getWinner().Score} points!");
}