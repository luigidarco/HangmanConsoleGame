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

        // [1] Head part 
        if (bodyParts["Head"])
        {
            Console.WriteLine("  |     O");
        }
        else
        {
            Console.WriteLine("  |");
        }

        // [2] Body and Arms part
        if (bodyParts["LeftArm"] && bodyParts["Body"] && bodyParts["RightArm"])
            Console.WriteLine("  |    /|\\");
        else if (bodyParts["LeftArm"] && bodyParts["Body"])
            Console.WriteLine("  |    /|");
        else if (bodyParts["Body"])
            Console.WriteLine("  |     |");
        else
            Console.WriteLine("  |");

        //[3] Legs part
        if (bodyParts["LeftLeg"] && bodyParts["RightLeg"])
            Console.WriteLine("  |    / \\");
        else if (bodyParts["LeftLeg"])
            Console.WriteLine("  |    / ");
        else if (bodyParts["RightLeg"])
            Console.WriteLine("  |     \\");
        else
            Console.WriteLine("  |");
    }

    internal bool IsDead()
    {
        foreach (KeyValuePair<string, bool> bodyPart in bodyParts)
        {
            if (!bodyPart.Value)
            {
                return false;
            }
        }
        return true;
    }
}
