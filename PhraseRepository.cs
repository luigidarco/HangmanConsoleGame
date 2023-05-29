using System;
using System.Collections.Generic;
using System.Linq;

public static class PhraseRepository
{
    private static Dictionary<char[], string> _phrases = new Dictionary<char[], string>() {
        { "HELLO WORLD".ToCharArray(), "A greeting" },
        { "GOODBYE".ToCharArray(), "A farewell" }
    };
    static int phrasesCounter = _phrases.Count;
    private static List<KeyValuePair<char[], string>> _shuffledPhrases;
    private static int _currentIndex = 0;

    static PhraseRepository()
    {
        ShufflePhrases();
    }

    public static void AddPhrase(char[] phrase, string hint)
    {
        char[] uppercasePhrase = phrase.Select(c => Char.ToUpper(c)).ToArray();
        _phrases.Add(phrase, hint);
        ShufflePhrases();
    }

    // A method to add a new phrase to the dictionary.
    private static void ShufflePhrases()
    {
        Random random = new Random();
        _shuffledPhrases = _phrases.OrderBy(x => random.Next()).ToList();
    }

    public static KeyValuePair<char[], string> GetRandomPhrase()
    {
        if (_currentIndex >= _shuffledPhrases.Count)
        {
            ShufflePhrases();
            _currentIndex = 0;
        }

        var phrasePair = _shuffledPhrases[_currentIndex];
        _currentIndex++;
        return phrasePair;
    }
}
