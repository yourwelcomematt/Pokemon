namespace Pokemon;

public class Charmander : BasePokemon
{
    public override int HitPoints { get; set; } = 30;

    public override Move[] CurrentMoves { get; } = 
    {
        new("Scratch", 3),
        new("Ember", 5)
    };
}