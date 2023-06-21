namespace Pokemon;

public class Bulbasaur : BasePokemon
{
    public override string Name => "Bulbasaur";
    public override int HitPoints { get; set; } = 20;

    public override List<Move> CurrentMoves { get; } = new()
    {
        new Move("Tackle", 3),
        new Move("Vine Whip", 5)
    };
}