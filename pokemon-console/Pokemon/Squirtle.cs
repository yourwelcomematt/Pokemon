namespace Pokemon;

public class Squirtle : BasePokemon
{
    public override int HitPoints { get; set; } = 30;

    public override Move[] CurrentMoves { get; } =
    {
        new("Tackle", 3),
        new("Bubble", 5)
    };
}