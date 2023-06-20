namespace Pokemon;

public class Move
{
    public string Name { get; }
    // public Types Type;
    public int Power { get; }
    // public int Accuracy;

    public Move(string name, int power)
    {
        Name = name;
        Power = power;
    }
}