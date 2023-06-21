namespace Pokemon;

public class Trainer
{
    public string Name { get; }
    public List<BasePokemon> Pokemon { get; } = new();

    public Trainer(string name)
    {
        Name = name;
    }
}