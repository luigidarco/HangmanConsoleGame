public static class PhraseRepository
{
    private static List<Phrase> _phrases = new List<Phrase>();

    // A method to add a new object to the list of phrases.
    public static void add(Phrase phrase)
    {
        _phrases.Add(phrase);
    }

    public static Phrase getRandomPhrase()
    {
        Random random = new Random();
        int index = random.Next(_phrases.Count);
        return _phrases[index];
    }
}