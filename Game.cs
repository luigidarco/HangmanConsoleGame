// See https://aka.ms/new-console-template for more information
using System.Text;

public class Game
{
    public string GameMode { get; set; }
    public List<Player> Players { get; set; } = new List<Player>();
    public int PlayerTurn { get; private set; } = 0;
    public char[] SecretPhrase { get; set; }
    public char[] HiddenPhrase { get; set; }
    public string Hint { get; set; }
    public HashSet<char> guessedLetters { get; set; }
    public const int scorePerHit = 10;
    public const int scorePerPhrase = 50;

    // Constructor for a predefined game
    public Game(string gameMode, char[] secretPhrase, string hint)
    {
        this.GameMode = gameMode;
        SecretPhrase = secretPhrase;
        Hint = hint;
        HiddenPhrase = Hid(SecretPhrase);
        guessedLetters = new HashSet<char>();
    }
    public void GuessLetter(string guess, int playerTurn)
    {
        Program.LoadingAnimation();
        // Check if the input is a phrase or a single letter.
        if (guess.Length > 1)
        {
            if (new string(SecretPhrase).Equals(guess))
            {
                Console.Beep(1000, 500);

                int underscoreCount = 0;
                foreach (char c in HiddenPhrase)
                {
                    if (c == '_')
                    {
                        underscoreCount++;
                    }
                }
                int bonus = scorePerPhrase + (underscoreCount * scorePerHit);
                Players[PlayerTurn].Score += bonus;

                HiddenPhrase = SecretPhrase;
                Console.WriteLine($"Congratulations! You guessed the secret phrase! \nYou earned {bonus} bonus points!");

                Console.ReadKey();
                return;
            }
            else
            {
                Players[PlayerTurn].Misses++;
                Players[PlayerTurn].Hang.AddBodyPart();
                Console.WriteLine("This is not the secret phrase!");
                Console.ReadKey();
                return;
            }
        }
        // In case the input is a single letter, convert it to uppercase.
        char letter = char.ToUpper(guess[0]);
        int lettersFound = 0;
        // Check if the letter has already been guessed.
        if (guessedLetters.Contains(letter))
        {
            Console.WriteLine("This letter has already been guessed. Try again.");
            Console.ReadKey();
            return;
        }
        else
        {
            for (int i = 0; i < SecretPhrase.Length; i++)
            {
                // If the letter is found, add 10 points to the player's score.
                if (SecretPhrase[i] == letter)
                {
                    lettersFound++;
                    HiddenPhrase[i] = letter;
                }
                // Set or skip a whitespace in the hidden phrase. 
                else if (SecretPhrase[i] == ' ')
                {
                    HiddenPhrase[i] = ' ';
                }
            }
            if (lettersFound == 0)
            {
                Players[PlayerTurn].Misses++;
                Players[PlayerTurn].Hang.AddBodyPart();
                Console.WriteLine("Letter not found. Try again.");
                Console.ReadKey();

                // Switch to the next player [1 to max 4]
                PlayerTurn = (PlayerTurn + 1) % Players.Count;
            }
            else
            {
                Players[PlayerTurn].Hits++;
                Players[PlayerTurn].Score += lettersFound * scorePerHit;
                Console.Beep(1000, 500);
                Console.WriteLine($"You found {lettersFound} letter(s)! +{lettersFound * scorePerHit} points!");
                Console.ReadKey();
            }
            guessedLetters.Add(letter);
        }
    }
    public Player GetCurrentPlayer()
    {
        return Players[PlayerTurn];
    }
    public string getGuessedLetters()
    {
        StringBuilder output = new StringBuilder();
        foreach (char letter in guessedLetters)
        {
            output.Append(letter);

            if (letter != guessedLetters.Last())
            {
                output.Append(", ");
            }
        }

        return output.ToString();
    }

    public char[] Hid(char[] phrase)
    {
        char[] displayPhrase = new char[phrase.Length];
        for (int i = 0; i < phrase.Length; i++)
        {
            if (phrase[i] == ' ')
            {
                displayPhrase[i] = ' ';
            }
            else
            {
                displayPhrase[i] = '_';
            }
        }
        return displayPhrase;
    }

    internal bool IsOver()
    {
        /* Let's recall the situations where the game is over:
        1. All player are dead. (1-4)
        2. The phrase is guessed.
        3. The player wants to quit.              
        */

        int numDeadPlayers = 0;
        foreach (Player player in Players)
        {
            if (GetCurrentPlayer().Hang.IsDead())
            {
                numDeadPlayers++;
            }
        }
        if (numDeadPlayers == Players.Count)
        {
            return true;
        }
        else if (new string(HiddenPhrase) == new string(SecretPhrase))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public Player getWinner()
    {
        Player winner = null;
        int highestScore = 0;

        foreach (Player player in Players)
        {
            if (player.Score > highestScore)
            {
                winner = player;
            }
        }
        return winner;
    }

    public void DrawHang(Player player)
    {
        player.Hang.Draw();
    }
}