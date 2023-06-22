namespace Pokemon;

public static class ConsoleWriter
{
    public static void PrintAvailablePokemon(List<BasePokemon> availablePokemon)
    {
        foreach (var pokemon in availablePokemon)
        {
            Console.WriteLine($"- {pokemon.Name}");
        }
    }
    
    public static void PrintAvailableMoves(BasePokemon pokemon)
    {
        foreach (var move in pokemon.CurrentMoves)
        {
            Console.WriteLine($"- {move.Name}");
        }
    }
}