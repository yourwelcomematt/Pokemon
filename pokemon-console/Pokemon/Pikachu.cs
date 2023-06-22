namespace Pokemon;

public class Pikachu : BasePokemon
{
    public override string Name => "Pikachu";
    public override int HitPoints { get; set; } = 30;

    public override List<Move> CurrentMoves { get; } = new()
    {
        new Move("Quick Attack", 3),
        new Move("Thunder Shock", 10)
    };
}