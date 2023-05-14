// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

Menu();

void Menu()
{
    int choice;

    do
    {
        Console.WriteLine("Welcome to the Hangman Game!");
        Console.WriteLine("1. Start a Random Game.");
        Console.WriteLine("2. Start with a Predefined Phrase.");
        Console.WriteLine("3. Exit\n");
        Console.Write("Enter your choice: ");
        choice = Convert.ToInt32(Console.ReadLine());

        switch (choice)
        {
            case 1:
                Console.WriteLine("[Not implemented yet!]\n");
                break;
            case 2:
                setupPredefinedGame();
                break;
            default:
                Console.WriteLine("Invalid choice!");
                break;
        }

    } while (choice != 1 || choice != 2);
}

void setupPredefinedGame()
{
    Console.Write("Enter the phrase: ");
    string phrase = Console.ReadLine();

    Console.Write("Enter the hint: ");
    string hint = Console.ReadLine();

    Phrase customPhrase = new Phrase(phrase, hint, "General");
    PhraseRepository.add(customPhrase);

    Game game = new Game(PhraseRepository.getRandomPhrase());

    startGame(game);

    //PhraseRepository.add(phrase);
}

void startGame(Game game)
{
    // Console.WriteLine("Hint: " + game.hint);
    // Console.WriteLine("Hidden Phrase: " + game.hiddenPhrase);

    while (game.attempts < 6)
    {
        Console.Clear();
        Console.WriteLine(game.hiddenPhrase);
        Console.WriteLine("Hint: " + game.hint);
        Console.WriteLine("Guessed Letters: " + game.GetGuessedLettersString());
        Console.Write("Enter a letter: ");
        char letter = Convert.ToChar(Console.ReadLine());

        // In case of input a repeated letter.
        if (game.guessedLetters.Contains(letter))
        {
            Console.WriteLine("You already guessed this letter!");
            continue;
        }

        // If not, add to the guessed letters list.

        if (game.secretPhrase.Contains(letter))
        {
            Console.WriteLine("You guessed a letter!");
            game.guessedLetters.Add(letter);
            game.updateHiddenPhrase(letter);

        }
        else
        {
            game.attempts++;
            Console.WriteLine($"You missed! Attemps left: {(6 - game.attempts)}");
            Console.ReadLine();

            //Console.WriteLine(HangDraw());
        }

        if (game.hiddenPhrase.SequenceEqual(game.secretPhrase))
        {
            Console.Clear();
            Console.WriteLine("You won!");
            Console.ReadKey();
        }
    }

    if (game.attempts == 6)
    {
        Console.Clear();
        Console.WriteLine("You lost!");
        Console.ReadKey();
        Menu();
    }

}

