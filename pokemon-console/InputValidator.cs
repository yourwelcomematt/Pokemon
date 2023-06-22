namespace Pokemon;

public static class InputValidator
{
    public static bool IsValidPokemonChoice(List<BasePokemon> availablePokemon, string choice)
    {
        return availablePokemon.Find(pokemon => pokemon.Name.Equals(choice, StringComparison.OrdinalIgnoreCase)) != null;
    }
    
    public static bool IsValidMoveChoice(BasePokemon pokemon, string choice)
    {
        return pokemon.CurrentMoves.Find(move => move.Name.Equals(choice, StringComparison.OrdinalIgnoreCase)) != null;
    }
}