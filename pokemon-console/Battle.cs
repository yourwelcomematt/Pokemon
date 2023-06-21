using NetCoreAudio;

namespace Pokemon;

public class Battle
{
    private readonly List<BasePokemon> _availablePokemon = new()
    {
        new Bulbasaur(),
        new Charmander(),
        new Squirtle()
    };

    private readonly List<Trainer> _trainers = new()
    {
        new Trainer("Ash"),
        new Trainer("Gary")
    };

    public void Start()
    {
        Console.WriteLine("*** Welcome to the world of Pokemon! ***");

        foreach (var trainer in _trainers)
        {
            Console.WriteLine($"\n{trainer.Name}, choose your Pokemon:");
            PrintAvailablePokemon();
            var choice = Console.ReadLine();
            var chosenPokemon = _availablePokemon.Find(pokemon => pokemon.Name.Equals(choice));
            trainer.Pokemon.Add(chosenPokemon);
            _availablePokemon.Remove(chosenPokemon);
            Console.WriteLine($"{trainer.Name} has chosen {chosenPokemon.Name}!");
        }
        
        Console.WriteLine("\nLet the battle commence! \n");
        
        var player = new Player();
        player.Play("../../../Music/Trainer Battle - Pokémon Red & Blue Extended.mp3");
        
        Thread.Sleep(1000);
        
        foreach (var trainer in _trainers)
        {
            Console.WriteLine($"{trainer.Name} entered {trainer.Pokemon[0].Name}!");
            Thread.Sleep(1000);
        }

        var neitherPokemonHasFainted = true;
        
        while (neitherPokemonHasFainted)
        {
            for (var i = 0; i < 2; i++)
            {
                Console.Clear();
                var currentTrainerPokemon = _trainers[i].Pokemon[0];
                var currentOpponentPokemon = i == 1 ? _trainers[i - 1].Pokemon[0] : _trainers[i + 1].Pokemon[0];
                
                Console.WriteLine($"\n{currentTrainerPokemon.Name}'s HP is {currentTrainerPokemon.HitPoints}");
                Console.WriteLine($"{currentOpponentPokemon.Name}'s HP is {currentOpponentPokemon.HitPoints}");

                Console.WriteLine($"\nWhat will {currentTrainerPokemon.Name} do?");
                PrintAvailableMoves(currentTrainerPokemon);
                var choice = Console.ReadLine();
                var chosenMove = currentTrainerPokemon.CurrentMoves.Find(move => move.Name == choice);

                Console.WriteLine($"\n{currentTrainerPokemon.Name} used {chosenMove.Name}!");
                Thread.Sleep(1000);
                Console.WriteLine($"{currentOpponentPokemon.Name} took {chosenMove.Power} damage!");
                Thread.Sleep(1000);
                currentOpponentPokemon.HitPoints -= chosenMove.Power;

                if (HasPokemonFainted(currentOpponentPokemon))
                {
                    Console.WriteLine($"\n{currentOpponentPokemon.Name} has fainted!");
                    
                    player.Play(
                        "../../../Music/Pokémon Red & Blue Music Trainer Victory Theme.mp3");
                    Thread.Sleep(1000);
                    
                    Console.WriteLine($"{_trainers[i].Name} wins!");
                    Thread.Sleep(31000);
                    
                    neitherPokemonHasFainted = false;
                    break;
                }
            }
            
            
        }
    }

    private void PrintAvailablePokemon()
    {
        foreach (var pokemon in _availablePokemon)
        {
            Console.WriteLine($"- {pokemon.Name}");
        }
    }

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