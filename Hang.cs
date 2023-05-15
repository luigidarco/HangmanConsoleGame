public class Hang
{
    public bool Head { get; set; }
    public bool Body { get; set; }
    public bool LeftArm { get; set; }
    public bool RightArm { get; set; }
    public bool LeftLeg { get; set; }
    public bool RightLeg { get; set; }

    public Hang()
    {
        Head = false;
        Body = false;
        LeftArm = false;
        RightArm = false;
        LeftLeg = false;
        RightLeg = false;
    }

    public void addHang(int attempts)
    {
        switch (attempts)
        {
            case 1:
                Head = true;
                break;
            case 2:
                Body = true;
                break;
            case 3:
                LeftArm = true;
                break;
            case 4:
                RightArm = true;
                break;
            case 5:
                LeftLeg = true;
                break;
            case 6:
                RightLeg = true;
                break;
        }
    }

    public void Draw()
    {
        Console.WriteLine("  _______");
        Console.WriteLine("  |     |");

        if (Head)
        {
            Console.WriteLine("  |     O");
        }
        else
        {
            Console.WriteLine("  |");
        }

        if (LeftArm && Body && RightArm)
            Console.WriteLine("  |    /|\\");
        else if (Body && LeftArm)
            Console.WriteLine("  |    /|");
        else if (Body && RightArm)
            Console.WriteLine("  |     |\\");
        else if (Body)
            Console.WriteLine("  |     |");
        else
            Console.WriteLine("  |");

        if (LeftLeg && RightLeg)
            Console.WriteLine("  |    / \\");
        else if (LeftLeg)
            Console.WriteLine("  |    / ");
        else if (RightLeg)
            Console.WriteLine("  |     \\");
        else
            Console.WriteLine("  |");
    }

}