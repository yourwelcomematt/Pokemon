namespace Pokemon;

public class Trainer
{
    public List<BasePokemon> Pokemon { get; }

    public Trainer(BasePokemon chosenPokemon)
    {
        Pokemon = new List<BasePokemon> {chosenPokemon};
    }
}