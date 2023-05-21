// See https://aka.ms/new-console-template for more information
Menu();

void Menu()
{
    int choice;

    do
    {
        Console.WriteLine("Welcome to the Hangman Game!");
        Console.WriteLine("1. Start a random game.");
        Console.WriteLine("2. Exit\n");
        Console.Write("Enter your choice: ");
        choice = Convert.ToInt32(Console.ReadLine());

        switch (choice)
        {
            case 1:
                startRandomGame();
                break;
            case 2:
                Console.WriteLine("Thank you for playing!");
                break;
            default:
                Console.WriteLine("Invalid choice!");
                break;
        }

    } while (choice != 1 || choice != 2);
}

void startRandomGame()
{
    Tuple<char[], string> randomPhrase = PhraseRepository.GetRandomPhrase();
    Game game = new Game(randomPhrase);

    // Convert char[] to string
    string secretPhrase = new string(game.SecretPhrase);
    Console.WriteLine($"Secret Phrase: {secretPhrase}");
}



