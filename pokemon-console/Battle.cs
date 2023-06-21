namespace Pokemon;

public class Battle
{
    // private List<BasePokemon> AvailablePokemon = new()
    // {
    //     new Bulbasaur(),
    //     new Charmander(),
    //     new Squirtle()
    // };

    private Trainer trainer1 = new(new Bulbasaur());
    private Trainer trainer2 = new(new Charmander());

    public void Start()
    {
        Console.WriteLine("*** Welcome to the world of Pokemon! ***\n");

        // Console.WriteLine("Trainer 1, choose your Pokemon:");
        // PrintAvailablePokemon();
        // var choice = Console.ReadLine();
        // var chosenPokemon = AvailablePokemon.Find(pokemon => pokemon.Name == choice);
        // trainer1 = new Trainer(chosenPokemon);
        // AvailablePokemon.Remove(chosenPokemon);
        //
        // Console.WriteLine("Trainer 2, choose your Pokemon:");
        // PrintAvailablePokemon();
        // var choice2 = Console.ReadLine();
        // var chosenPokemon2 = AvailablePokemon.Find(pokemon => pokemon.Name == choice2);
        // trainer2 = new Trainer(chosenPokemon2);
        //
        // Console.WriteLine($"Trainer 1 has chosen {trainer1.Pokemon[0].Name}");
        // Console.WriteLine($"Trainer 2 has chosen {trainer2.Pokemon[0].Name}");
        Console.WriteLine("Let the battle commence! \n");
        
        var currentTrainer1Pokemon = trainer1.Pokemon[0];
        var currentTrainer1PokemonName = currentTrainer1Pokemon.Name;
        
        var currentTrainer2Pokemon = trainer2.Pokemon[0];
        var currentTrainer2PokemonName = currentTrainer2Pokemon.Name;
        
        Console.WriteLine($"Trainer 1 entered {currentTrainer1PokemonName}!");
        Console.WriteLine($"Trainer 2 entered {currentTrainer2PokemonName}!");
        
        while (true)
        {
            Console.WriteLine($"\n{currentTrainer1PokemonName}'s HP is {currentTrainer1Pokemon.HitPoints}");
            Console.WriteLine($"{currentTrainer2PokemonName}'s HP is {currentTrainer2Pokemon.HitPoints}");
            
            Console.WriteLine($"\nWhat will {currentTrainer1PokemonName} do?");
            PrintAvailableMoves(currentTrainer1Pokemon);
            var choice = Console.ReadLine();
            var chosenMove = currentTrainer1Pokemon.CurrentMoves.Find(move => move.Name == choice);
            Console.WriteLine($"\n{currentTrainer1PokemonName} used {chosenMove.Name}!");
            Console.WriteLine($"{currentTrainer2PokemonName} took {chosenMove.Power} damage!");
            currentTrainer2Pokemon.HitPoints -= chosenMove.Power;

            if (HasPokemonFainted(currentTrainer2Pokemon))
            {
                Console.WriteLine($"\n{currentTrainer2PokemonName} has fainted!");
                Console.WriteLine("Trainer 1 wins!");
                break;
            }

            Console.WriteLine($"\n{currentTrainer1PokemonName}'s HP is {currentTrainer1Pokemon.HitPoints}");
            Console.WriteLine($"{currentTrainer2PokemonName}'s HP is {currentTrainer2Pokemon.HitPoints}");
            
            Console.WriteLine($"\nWhat will {currentTrainer2PokemonName} do?");
            PrintAvailableMoves(currentTrainer2Pokemon);
            var choice2 = Console.ReadLine();
            var chosenMove2 = currentTrainer2Pokemon.CurrentMoves.Find(move => move.Name == choice2);
            Console.WriteLine($"\n{currentTrainer2PokemonName} used {chosenMove2.Name}!");
            Console.WriteLine($"{currentTrainer1PokemonName} took {chosenMove2.Power} damage!");
            currentTrainer1Pokemon.HitPoints -= chosenMove2.Power;
            
            if (HasPokemonFainted(currentTrainer1Pokemon))
            {
                Console.WriteLine($"\n{currentTrainer1PokemonName} has fainted!");
                Console.WriteLine("Trainer 2 wins!");
                break;
            }
        }
    }

    // private void PrintAvailablePokemon()
    // {
    //     foreach (var pokemon in AvailablePokemon)
    //     {
    //         Console.WriteLine($"- {pokemon.Name}");
    //     }
    // }

    private void PrintAvailableMoves(BasePokemon pokemon)
    {
        foreach (var move in pokemon.CurrentMoves)
        {
            Console.WriteLine($"- {move.Name}");
        }
    }

    private bool HasPokemonFainted(BasePokemon pokemon)
    {
        return pokemon.HitPoints <= 0;
    }
}