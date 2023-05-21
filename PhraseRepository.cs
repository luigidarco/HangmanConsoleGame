public static class PhraseRepository
{
    private static Dictionary<char[], string> _phrases = new Dictionary<char[], string>() {
        { "Hello World".ToCharArray(), "A greeting" },
        { "Goodbye World".ToCharArray(), "A farewell" }
    };

    // A method to add a new phrase to the dictionary.
    public static void AddPhrase(char[] phrase, string hint)
    {
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
