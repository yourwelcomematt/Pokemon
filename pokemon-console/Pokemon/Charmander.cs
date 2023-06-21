namespace Pokemon;

public class Charmander : BasePokemon
{
    public override string Name => "Charmander";
    public override int HitPoints { get; set; } = 20;

    public override List<Move> CurrentMoves { get; } = new()
    {
        new Move("Scratch", 3),
        new Move("Ember", 5)
    };
}