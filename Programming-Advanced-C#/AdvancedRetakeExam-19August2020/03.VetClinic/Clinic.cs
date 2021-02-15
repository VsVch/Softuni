using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VetClinic
{
    class Clinic
    {
        private List<Pet> data;        

        public Clinic(int capacity)
        {
            this.Capacity = capacity;
            data = new List<Pet>(capacity);
        }

        public int Capacity { get; set; }        

        public void Add(Pet pet) 
        {
            if (data.Count < this.Capacity)
            {
                data.Add(pet);                             
            }        
        }

        public bool Remove(string name) 
        {
            Pet pet = data.FirstOrDefault(n => n.Name == name);

            if (pet != null)
            {
                data.Remove(pet);               
                return true;
            }
            return false;
        }
        public Pet GetPet(string name, string owner)
        {

            for (int i = 0; i < data.Count; i++)
            {
                if (data[i].Name == name && data[i].Owner == owner)
                {
                    Pet pet = data[i];
                    return pet;
                }
            }
            return null;
        }
        public Pet GetOldestPet()
        {
            if (data.Count == 0)
            {
                return null;
            }
            Pet pet = data.OrderByDescending(n => n.Age).First();
            return pet;        
        }
        public int Count() 
        {
             
            return data.Count;
        }
        public string GetStatistics()
        {
            StringBuilder petInfo = new StringBuilder();

            petInfo.AppendLine($"The clinic has the following patients:");

            foreach (Pet item in data)
            {
                petInfo.AppendLine($"Pet {item.Name} with owner: {item.Owner}");
            }
            return petInfo.ToString();        
        }
    }
}
