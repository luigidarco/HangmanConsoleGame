public class Hang
{
    private Dictionary<string, bool> bodyParts = new Dictionary<string, bool>()
    {
        { "Head", false },
        { "Body", false },
        { "LeftArm", false },
        { "RightArm", false },
        { "LeftLeg", false },
        { "RightLeg", false }
    };

    public void AddBodyPart()
    {
        foreach (KeyValuePair<string, bool> bodyPart in bodyParts)
        {
            if (!bodyPart.Value)
            {
                bodyParts[bodyPart.Key] = true;
                break;
            }
        }
    }

    public void Draw()
    {
        Console.WriteLine("  _______");
        Console.WriteLine("  |     |");

        if (bodyParts["Head"])
        {
            Console.WriteLine("  |     O");
        }
        else
        {
            Console.WriteLine("  |");
        }

        if (bodyParts["LeftArm"] && bodyParts["Body"] && bodyParts["RightArm"])
            Console.WriteLine("  |    /|\\");
        else if (bodyParts["LeftArm"] && bodyParts["Body"])
            Console.WriteLine("  |    /|");
        else if (bodyParts["LeftArm"] && bodyParts["RightArm"])
            Console.WriteLine("  |     |\\");
        else if (bodyParts["LeftArm"])
            Console.WriteLine("  |     |");
        else
            Console.WriteLine("  |");

        if (bodyParts["LeftLeg"] && bodyParts["RightLeg"])
            Console.WriteLine("  |    / \\");
        else if (bodyParts["LeftLeg"])
            Console.WriteLine("  |    / ");
        else if (bodyParts["RightLeg"])
            Console.WriteLine("  |     \\");
        else
            Console.WriteLine("  |");
    }

    internal void addBodyPart()
    {
        throw new NotImplementedException();
    }
}
