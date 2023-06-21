namespace Pokemon;

public class Squirtle : BasePokemon
{
    public override string Name => "Squirtle";
    public override int HitPoints { get; set; } = 20;

    public override List<Move> CurrentMoves { get; } = new()
    {
        new Move("Tackle", 3),
        new Move("Bubble", 5)
    };
}