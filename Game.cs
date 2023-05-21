// See https://aka.ms/new-console-template for more information
using System.Text;

public class Game
{
    public char[] SecretPhrase { get; set; }
    public char[] HiddenPhrase { get; set; }
    public string Hint { get; set; }
    public List<Player> Players { get; set; } = new List<Player>();
    public int PlayerTurn { get; private set; } = 1;
    public List<char> GuessedLetters { get; set; } = new List<char>();

    public Game(Tuple<char[], string> phrase)
    {
        SecretPhrase = phrase.Item1;
        Hint = phrase.Item2;
        HiddenPhrase = HidPhraseOutput(SecretPhrase);
    }

    public Player GetCurrentPlayer()
    {
        return Players[PlayerTurn];
    }

    public void GuessLetter(char letter)
    {

        bool found = false;

        for (int i = 0; i < SecretPhrase.Length; i++)
        {
            if (SecretPhrase[i] == letter)
            {
                HiddenPhrase[i] = letter;
                GuessedLetters.Add(letter);
                found = true;
            }
            else if (SecretPhrase[i] == ' ')
            {
                HiddenPhrase[i] = ' ';
            }
        }

        if (!found)
        {
            Players[PlayerTurn].PlayerHang.addBodyPart();

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

    public void NextPlayer()
    {

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

    public void updateHiddenPhrase(char letter)
    {

    }


}