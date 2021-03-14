using System;

namespace CustomListExercise
{
    public class Starup
    {
        static void Main(string[] args)
        {
            CustomList myList = new CustomList();

            myList.Add(10);
            myList.Add(20);

            myList.MyInsert(0,100);
            myList.MyInsert(1, 200);
            myList.MyInsert(4, 300);

            
        }        
    }
    
}
