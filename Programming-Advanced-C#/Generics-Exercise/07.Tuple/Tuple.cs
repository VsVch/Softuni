using System;
using System.Collections.Generic;
using System.Text;

namespace _07.Tuple
{
    class Tuple<T1,T2>
    {
        public Tuple(T1 itemOne, T2 itemTwo)
        {
            this.ItemOne = itemOne;
            this.ItemTwo = itemTwo;
        }

        public T1 ItemOne { get; set; }

        public T2 ItemTwo { get; set; }

        public override string ToString()
        {
            return $"{this.ItemOne} -> {this.ItemTwo}";
        }
    }

}
