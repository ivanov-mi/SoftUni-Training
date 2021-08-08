using System.Collections.Generic;
using System.Linq;

namespace _09.PokemonTrainer
{
    public class Trainer
    {
        public Trainer(string trainerName)
        {
            this.TrainerName = trainerName;
            this.NumberOfBadges = 0;
            this.CollectionOfPokemons = new List<Pokemon>();
        }

        public string TrainerName { get; set; }
        public int NumberOfBadges { get; set; }
        public List<Pokemon> CollectionOfPokemons { get; set; }

        public void AddPokemon(Pokemon pokemon)
        {
            this.CollectionOfPokemons.Add(pokemon);
        }

        public bool TrainerHasPokemonWithCurrentElement(string element)
        {
            return CollectionOfPokemons.Any(x => x.Element == element);
        }

        public void ReduceHealth()
        {
            foreach (var pokemon in CollectionOfPokemons)
            {
                pokemon.Health -= 10;
            }

            CollectionOfPokemons = CollectionOfPokemons.Where(x => x.Health > 0).ToList();
        }

        public override string ToString()
        {
            return $"{this.TrainerName} {this.NumberOfBadges} {this.CollectionOfPokemons.Count}";
        }
    }
}
