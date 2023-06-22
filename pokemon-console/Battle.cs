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

    private readonly Player _musicPlayer = new();

    public void Start()
    {
        ConsoleWriter.PrintWelcomeMessage();
        ChooseYourPokemon();
        
        ConsoleWriter.PrintBattleStartMessage();
        _musicPlayer.Play("../../../Music/Trainer Battle - Pokémon Red & Blue Extended.mp3");
        Thread.Sleep(1000);
        
        ConsoleWriter.PrintEnteredPokemonMessage(_trainers);
        StartGameLoop();
    }

    private void ChooseYourPokemon()
    {
        foreach (var trainer in _trainers)
        {
            ConsoleWriter.PrintChoosePokemonPrompt(trainer);
            ConsoleWriter.PrintAvailablePokemon(_availablePokemon);
            var pokemonChoice = Console.ReadLine();
            
            while (!InputValidator.IsValidPokemonChoice(_availablePokemon, pokemonChoice))
            {
                ConsoleWriter.PrintInvalidInputMessage();
                ConsoleWriter.PrintAvailablePokemon(_availablePokemon);
                pokemonChoice = Console.ReadLine();
            }
            
            var chosenPokemon = _availablePokemon.Find(pokemon => pokemon.Name.Equals(pokemonChoice, StringComparison.OrdinalIgnoreCase));
            trainer.Pokemon.Add(chosenPokemon);
            _availablePokemon.Remove(chosenPokemon);
            
            Console.Clear();
            ConsoleWriter.PrintChosenPokemonMessage(trainer, chosenPokemon);
        }
    }

    private void StartGameLoop()
    {
        var neitherPokemonHasFainted = true;
        
        while (neitherPokemonHasFainted)
        {
            for (var i = 0; i < 2; i++)
            {
                var currentTrainer = _trainers[i];
                var currentTrainerPokemon = currentTrainer.Pokemon[0];
                var currentOpponentPokemon = i == 1 ? _trainers[i - 1].Pokemon[0] : _trainers[i + 1].Pokemon[0];
                
                Console.Clear();
                ConsoleWriter.PrintHpOfBothPokemon(currentTrainerPokemon, currentOpponentPokemon);

                ConsoleWriter.PrintChooseMovePrompt(currentTrainerPokemon);
                ConsoleWriter.PrintAvailableMoves(currentTrainerPokemon);
                var moveChoice = Console.ReadLine();
                
                while (!InputValidator.IsValidMoveChoice(currentTrainerPokemon, moveChoice))
                {
                    ConsoleWriter.PrintInvalidInputMessage();
                    ConsoleWriter.PrintAvailableMoves(currentTrainerPokemon);
                    moveChoice = Console.ReadLine();
                }
                
                var chosenMove = currentTrainerPokemon.CurrentMoves.Find(move => move.Name.Equals(moveChoice, StringComparison.OrdinalIgnoreCase));

                Console.Clear();
                ConsoleWriter.PrintChosenMoveMessage(currentTrainerPokemon, chosenMove);
                Thread.Sleep(1000);
                ConsoleWriter.PrintMoveOutcomeMessage(currentOpponentPokemon, chosenMove);
                Thread.Sleep(1000);
                currentOpponentPokemon.HitPoints -= chosenMove.Power;

                if (HasPokemonFainted(currentOpponentPokemon))
                {
                    Console.Clear();
                    ConsoleWriter.PrintFaintedPokemonMessage(currentOpponentPokemon);
                    
                    _musicPlayer.Play("../../../Music/Pokémon Red & Blue Music Trainer Victory Theme.mp3");
                    Thread.Sleep(1000);
                    
                    ConsoleWriter.PrintWinMessage(currentTrainer);
                    Thread.Sleep(31000);
                    
                    neitherPokemonHasFainted = false;
                    break;
                }
            }
        }
    }

    private bool HasPokemonFainted(BasePokemon pokemon)
    {
        return pokemon.HitPoints <= 0;
    }
}