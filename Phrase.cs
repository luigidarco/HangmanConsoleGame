public class Phrase
{
    public string Text { get; }
    public string Hint { get; }
    public string Category { get; }

    public Phrase(string text, string hint, string category)
    {
        Text = text;
        Hint = hint;
        Category = category;
    }

}