namespace Pokemon;

public abstract class BasePokemon
{
    public abstract string Name { get; }
    public abstract int HitPoints { get; set; }
    // public int Level { get; }
    // public int Experience { get; private set; }
    
    // public int Attack;
    // public int SpecialAttack;
    // public int Defense;
    // public int SpecialDefense;
    // public int Speed;

    public abstract List<Move> CurrentMoves { get; }
}