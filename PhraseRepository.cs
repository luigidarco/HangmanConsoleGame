public static class PhraseRepository
{
    private static Dictionary<char[], string> _phrases = new Dictionary<char[], string>() {
        { "HELLO WORLD".ToCharArray(), "A greeting" },
        { "GOODBYE".ToCharArray(), "A farewell" }
    };

    // A method to add a new phrase to the dictionary.
    public static void AddPhrase(char[] phrase, string hint)
    {
        char[] uppercasePhrase = phrase.Select(c => Char.ToUpper(c)).ToArray();
        _phrases.Add(phrase, hint);
    }

    public static Tuple<char[], string> GetRandomPhrase()
    {
        Random random = new Random();
        int index = random.Next(_phrases.Count);
        char[] phrase = _phrases.ElementAt(index).Key;
        string hint = _phrases.ElementAt(index).Value;
        return Tuple.Create(phrase, hint);
    }
}
