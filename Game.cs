// See https://aka.ms/new-console-template for more information
using System.Text;

public class Game
{
    public char[] SecretPhrase { get; set; }
    public char[] HiddenPhrase { get; set; }
    public string Hint { get; set; }
    public List<Player> Players { get; set; } = new List<Player>();
    public int PlayerTurn { get; private set; } = 0;
    public List<char> GuessedLetters { get; set; } = new List<char>();
    public const int scorePerHit = 10;

    // Constructor for a random game
    public Game(Tuple<char[], string> phrase)
    {
        SecretPhrase = phrase.Item1;
        Hint = phrase.Item2;
        HiddenPhrase = HidPhraseOutput(SecretPhrase);
    }

    // Constructor for a predefined game
    public Game(char[] phrase, string hint)
    {
        SecretPhrase = phrase;
        Hint = hint;
        HiddenPhrase = HidPhraseOutput(SecretPhrase);
    }

    public Player GetCurrentPlayer()
    {
        return Players[PlayerTurn];
    }

    public void GuessLetter(char letter, int playerTurn)
    {

        bool found = false;
        int hits = 0;

        for (int i = 0; i < SecretPhrase.Length; i++)
        {
            // If the letter is found, add 10 points to the player's score.
            if (SecretPhrase[i] == letter)
            {
                hits++;
                HiddenPhrase[i] = letter;

                // Restrict the GuessedLetters list to only contain unique letters.
                if (!found) { GuessedLetters.Add(letter); }
                found = true;

            }

            // Set or skip a whitespace in the hidden phrase. 
            else if (SecretPhrase[i] == ' ')
            {
                HiddenPhrase[i] = ' ';
            }
        }
        if (!found)
        {
            Players[PlayerTurn].PlayerHang.AddBodyPart();
            Console.WriteLine("You missed!");
            Console.ReadKey();

            // Switch to the next player
            PlayerTurn = (PlayerTurn + 1) % Players.Count;

        }
        if (hits > 0)
        {
            Players[playerTurn].Score += (hits * scorePerHit);
            System.Console.WriteLine($"You found {hits} letter(s)! +{hits * scorePerHit} points!");
            Console.ReadKey();
        }
    }
    public string GetGuessedLetters()
    {
        StringBuilder output = new StringBuilder();

        for (int i = 0; i < GuessedLetters.Count; i++)
        {
            output.Append(GuessedLetters[i]);

            if (i < GuessedLetters.Count - 1)
            {
                output.Append(" - ");
            }
        }

        return output.ToString();
    }

    public char[] HidPhraseOutput(char[] phrase)
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
            if (player.PlayerHang.IsDead())
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
}