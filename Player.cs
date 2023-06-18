public class Player
{
    public string Name { get; set; }
    public int Score { get; set; }
    public int Attempts { get; set; }
    public int Hits { get; set; }
    public int Misses { get; set; }
    public Hang Hang;

    public Player(string name)
    {
        Name = name;
        Score = 0;
        Attempts = 0;
        Hits = 0;
        Misses = 0;
        Hang = new Hang();
    }
}