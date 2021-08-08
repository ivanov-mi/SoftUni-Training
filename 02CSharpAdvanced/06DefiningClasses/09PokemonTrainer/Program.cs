using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.PokemonTrainer
{
    class Program
    {
        static void Main()
        {
            var trainers = new List<Trainer>();
            string inputLine = string.Empty;

            while ((inputLine = Console.ReadLine())?.ToLower() != "tournament")
            {
                var trainerInput = inputLine.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var trainerName = trainerInput[0];
                var pokemonName = trainerInput[1];
                var pokemonElement = trainerInput[2];
                var pokemonHealth = int.Parse(trainerInput[3]);

                var newPokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);

                if (!trainers.Any(x => x.TrainerName == trainerName))
                {
                    trainers.Add(new Trainer(trainerName));
                }

                var currentTrainer = trainers.Where(x => x.TrainerName == trainerName)
                    .FirstOrDefault();

                currentTrainer.AddPokemon(newPokemon);           
            }

            var command = string.Empty;

            while ((command = Console.ReadLine())?.ToLower() != "end")
            {
                foreach (var trainer in trainers)
                {
                    if (trainer.TrainerHasPokemonWithCurrentElement(command))
                    {
                        trainer.NumberOfBadges++;
                    }
                    else
                    {
                        trainer.ReduceHealth();
                    }                    
                }
            }

            foreach (var trainer in trainers.OrderByDescending(x => x.NumberOfBadges))
            {
                Console.WriteLine(trainer);
            }
        }
    }
}
