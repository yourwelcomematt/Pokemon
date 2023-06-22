namespace Pokemon;

public static class ConsoleWriter
{
    public static void PrintWelcomeMessage()
    {
        Console.WriteLine("***** Welcome to the world of Pokemon! *****");
    }
    
    public static void PrintChoosePokemonPrompt(Trainer trainer)
    {
        Console.WriteLine($"\n{trainer.Name}, choose your Pokemon:");
    }
    
    public static void PrintAvailablePokemon(List<BasePokemon> availablePokemon)
    {
        foreach (var pokemon in availablePokemon)
        {
            Console.WriteLine($"- {pokemon.Name}");
        }
    }

    public static void PrintChosenPokemonMessage(Trainer trainer, BasePokemon chosenPokemon)
    {
        Console.WriteLine($"{trainer.Name} has chosen {chosenPokemon.Name}!");
    }

    public static void PrintStartBattleMessage()
    {
        Console.WriteLine("\nLet the battle commence! \n");
    }
    
    public static void PrintEnteredPokemonMessage(Trainer trainer)
    {
        Console.WriteLine($"{trainer.Name} entered {trainer.Pokemon[0].Name}!");
    }

    public static void PrintHpOfBothPokemon(BasePokemon currentTrainerPokemon, BasePokemon currentOpponentPokemon)
    {
        Console.WriteLine($"{currentTrainerPokemon.Name}'s HP is {currentTrainerPokemon.HitPoints}");
        Console.WriteLine($"{currentOpponentPokemon.Name}'s HP is {currentOpponentPokemon.HitPoints}");
    }

    public static void PrintChooseMovePrompt(BasePokemon currentTrainerPokemon)
    {
        Console.WriteLine($"\nWhat will {currentTrainerPokemon.Name} do?");
    }
    
    public static void PrintAvailableMoves(BasePokemon pokemon)
    {
        foreach (var move in pokemon.CurrentMoves)
        {
            Console.WriteLine($"- {move.Name}");
        }
    }

    public static void PrintChosenMoveMessage(BasePokemon currentTrainerPokemon, Move chosenMove)
    {
        Console.WriteLine($"{currentTrainerPokemon.Name} used {chosenMove.Name}!");
    }

    public static void PrintMoveOutcomeMessage(BasePokemon currentOpponentPokemon, Move chosenMove)
    {
        Console.WriteLine($"{currentOpponentPokemon.Name} took {chosenMove.Power} damage!");
    }

    public static void PrintFaintedPokemonMessage(BasePokemon currentOpponentPokemon)
    {
        Console.WriteLine($"{currentOpponentPokemon.Name} has fainted!");
    }
    
    public static void PrintWinMessage(Trainer currentTrainer)
    {
        Console.WriteLine($"{currentTrainer.Name} wins!");
    }

    public static void PrintInvalidInputMessage()
    {
        Console.WriteLine("\nOak's words echoed... There's a time and place for everything, but not now. Please choose an option from the list:");
    }
}