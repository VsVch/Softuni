using System;
using System.Collections.Generic;
using System.Text;

namespace _08.Threeuple
{
    public class Threeuple<T1,T2,T3>
    {
        public Threeuple(T1 furstItem, T2 secondItem, T3 thirtItem)
        {
            FurstItem = furstItem;
            SecondItem = secondItem;
            ThirdItem = thirtItem;
        }

        public T1 FurstItem { get; set; }

        public T2 SecondItem { get; set; }

        public T3 ThirdItem { get; set; }

        public override string ToString()
        {
            return $"{FurstItem} -> {SecondItem} -> {ThirdItem}";
        }
    }
}
