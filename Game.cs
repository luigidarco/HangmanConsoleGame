// See https://aka.ms/new-console-template for more information
using System.Text;

public class Game
{
    public int attempts { get; set; } = 0;
    public char[] secretPhrase { get; set; }
    public char[] hiddenPhrase { get; set; }
    public string hint { get; set; }
    private List<char> _guessedLetters = new List<char>();

    public List<char> guessedLetters
    {
        get { return _guessedLetters; }
        set
        {
            _guessedLetters = value;
        }
    }

    public Game(Phrase phrase)
    {
        secretPhrase = phrase.Text.ToCharArray();
        hiddenPhrase = CreateDisplayPhrase(phrase.Text);
        hint = phrase.Hint;
    }

    public char[] CreateDisplayPhrase(string phrase)
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
        for (int i = 0; i < hiddenPhrase.Length; i++)
        {
            if (secretPhrase[i] == letter)
            {
                hiddenPhrase[i] = letter;
            }
            else if (secretPhrase[i] == ' ')
            {
                hiddenPhrase[i] = ' ';
            }
        }
    }

    public string GetGuessedLettersString()
    {
        StringBuilder sb = new StringBuilder();


        for (int i = 0; i < _guessedLetters.Count; i++)
        {
            sb.Append(_guessedLetters[i]);

            if (i < _guessedLetters.Count - 1)
            {
                sb.Append(" - ");
            }
        }

        return sb.ToString();
    }
}