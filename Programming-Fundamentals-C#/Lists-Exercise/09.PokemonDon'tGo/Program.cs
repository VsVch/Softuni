using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.PokemonDon_tGo
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> pokemonDistance = Console.ReadLine()
                                               .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                               .Select(int.Parse)
                                               .ToList();

            List<int> removeValue = new List<int>();
           
            while (pokemonDistance.Count != 0)
            {
                int index = int.Parse(Console.ReadLine());

                int digit = 0;

                if (index < 0 || index >= pokemonDistance.Count )
                {
                    if (index < 0)
                    {
                        index = pokemonDistance[0];
                        pokemonDistance[0] = pokemonDistance[pokemonDistance.Count - 1];
                        digit = pokemonDistance[pokemonDistance.Count - 1];

                    }
                    if (index > pokemonDistance.Count - 1)
                    {
                        index = pokemonDistance.Count - 1;
                        pokemonDistance[pokemonDistance.Count - 1] = pokemonDistance[0];
                        digit = pokemonDistance[0];
                    }
                }
                else
                {
                    digit = pokemonDistance[index];
                    pokemonDistance.RemoveAt(index);
                }

                removeValue.Add(digit);

                for (int i = 0; i < pokemonDistance.Count; i++)
                {
                    if (digit >= pokemonDistance[i])
                    {
                        pokemonDistance[i] += digit;
                    }
                    else
                    {
                        pokemonDistance[i] -= digit;
                    }
                }

            }
            Console.WriteLine(removeValue.Sum());
        }
    }
}
