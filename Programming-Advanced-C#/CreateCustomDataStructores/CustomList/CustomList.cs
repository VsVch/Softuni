using System;
using System.Collections.Generic;
using System.Text;

namespace CustomListExercise
{
    public class CustomList
    {
        private const int initialCpacity = 2;

        private int[] array;

        public CustomList()
        {
            this.array = new int[initialCpacity];
        }

        public int Count { get; private set; }

        public int this[int index]
        {
            get 
            {
                this.ValidateIndex(index);
                return array[index];            
            }
            set 
            {
                this.ValidateIndex(index);
                this.array[index] = value;
            }
        }     
        public void Add(int number) 
        {

            if (this.Count == this.array.Length)
            {
               this.ReSize();
            }

            this.array[this.Count] = number;
            this.Count++;      
      
        }

        public int MyRemoveAtt(int index)
        {
            IndexValidation(index);

            int number = this.array[index];
            this.array[index] = default;
            this.Shift(index);
            this.Count--;

            if (this.Count == this.array.Length / 4)
            {
                this.Shrink();
            }

            return number;
        }

        public void MyInsert(int index, int item) 
        {
            if (index < 0 || index > this.Count)
            {
                throw new ArgumentOutOfRangeException("Index out of range!");
            }

            if (this.array.Length == this.Count)
            {
               this.ReSize();
            }

            this.ShiftRight(index);
            this.array[index] = item;
            this.Count++;

        }

        public bool MyContains(int number) 
        {
            foreach (var num in this.array)
            {
                if (num == number)
                {
                    return true;
                }
            }

            return false;       
        }

        private void ShiftRight(int index)
        {
            for (int i = Count ; i > index; i--)
            {
                this.array[i] = this.array[i - 1];

            }
        }

        private void Shrink()
        {
            int[] copy = new int[this.array.Length / 2];

            Array.Copy(this.array, copy, this.Count);

            this.array = copy;
        }

        private void Shift(int index)
        {
            for (int i = index; i < this.Count - 1; i++)
            {
                this.array[i] = this.array[i + 1];
            }
            array[Count - 1] = 0;
        }
        private void ReSize() 
        {
            int[] copy = new int[this.array.Length * 2];

            for (int i = 0; i < this.array.Length; i++)
            {
                copy[i] = this.array[i];
            }

            array = copy;        
        }

        private int IndexValidation(int index)        
        {
            if (index < 0 || index >= this.Count)
            {
                throw new ArgumentOutOfRangeException("Index out of range!");
            }
            return index;
        }
        private void ValidateIndex(int index)
        {
            if (index >= this.Count)
            {
                throw new ArgumentOutOfRangeException("Ivalide index!");
            }
        }

       

        
    }
}
