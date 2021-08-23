using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Models.Aquariums
{
    public abstract class Aquarium : IAquarium
    {
        private string name;

        private readonly List<IDecoration> decorations;
        private readonly List<IFish> fishes;
        public Aquarium(string name, int capacity)
        {
            decorations = new List<IDecoration>();
            fishes =new List<IFish>();

            Name = name;
            Capacity = capacity;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidFishName));
                }
                this.name = value;
            }
        }

        public int Capacity { get; private set; }

        public int Comfort => decorations.Sum(d => d.Comfort);

        public ICollection<IDecoration> Decorations => decorations.AsReadOnly();

        public ICollection<IFish> Fish => fishes.AsReadOnly();

        public void AddDecoration(IDecoration decoration)
        {
            decorations.Add(decoration);
        }

        public void AddFish(IFish fish)
        {
            if (fishes.Sum(f => f.Size) + fish.Size > Capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughCapacity);
            }

            fishes.Add(fish);
        }

        public void Feed()
        {
            foreach (var fish in fishes)
            {
                fish.Eat();
            }
        }

        public string GetInfo()
        {
            StringBuilder sb = new StringBuilder();
            int counter = 0;
            sb.AppendLine($"{this.Name} ({this.GetType().Name}):");

            sb.Append("Fish: ");

            if (fishes.Count == 0)
            {
                sb.AppendLine("none");
            }
            else
            {
                foreach (var fish in fishes)
                {

                    if (counter == fishes.Count - 1)
                    {
                        sb.Append($"{ fish.Name}");
                    }
                    else
                    {
                        sb.Append($"{ fish.Name}, ");
                    }
                    counter++;
                }
                sb.AppendLine();
            }
            
            sb.AppendLine($"Decorations: {decorations.Count}");
            sb.AppendLine($"Comfort: {Comfort}");

            return sb.ToString().TrimEnd();
        }

        public bool RemoveFish(IFish fish)
        {
            return fishes.Remove(fish);
        }
    }
}
