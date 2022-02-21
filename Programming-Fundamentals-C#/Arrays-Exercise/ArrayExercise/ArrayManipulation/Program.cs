using System;
using System.Linq;
using System.Text;

namespace ArrayManipolation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            InputArray array = new InputArray();

            string input;

            Console.WriteLine(array.ToString());

            while ((input = Console.ReadLine()) != "Exit".ToLower())
            {
                var commands = input.Split(' ');

                int number;

                switch (commands[0].ToLower())
                {
                    case "1":
                        number = int.Parse(commands[1]);
                        array.Input(number);
                        break;
                    case "2":
                        array.Output();
                        break;
                    case "3":
                        number = int.Parse(commands[1]);
                        array.AddToEnd(number);
                        break;
                    case "4":
                        array.RemoveFromBegining();
                        break;
                    case "5":
                        array.Sort();
                        break;
                    case "6":
                        array.Print();
                        break;
                    case "7":
                        number = int.Parse(commands[1]);
                        string data = array.SelectElement(number);
                        Console.WriteLine(data);
                        break;
                    default:
                        Console.WriteLine("Invalid command");
                        break;
                }
            }
        }
    }
}

public class InputArray
{
    private int[] array;
    private int Length = 4;
    private int Count = 0;

    public InputArray()
    {
        array = new int[Length];
    }

    public void Input(int num)
    {

        this.array[Count] = num;

        Count++;

        CheckArraylength(array);
    }

    public void Output()
    {
        if (Count != 0)
        {
            for (int i = 0; i < Count - 1; i++)
            {
                array[i] = array[i + 1];
            }
            Count--;
            array[Count] = 0;
        }
    }

    public void AddToEnd(int num)
    {

        for (int i = Count; i >= 0; i--)
        {
            var currentNum = array[i];

            array[i + 1] = currentNum;
        }

        array[0] = num;

        Count++;

        CheckArraylength(array);
    }

    public void RemoveFromBegining()
    {
        for (int i = 0; i < Count - 1; i++)
        {
            array[i] = array[i + 1];
        }

        Count--;
        array[Count] = 0;
    }

    public void Sort()
    {
        Array.Sort(array, 0, Count);
    }

    public void Print()
    {
        var newArray = new int[Count];

        var copyArray = CopyArray(array, newArray);

        Console.WriteLine(String.Join(" ", copyArray));
    }

    public string SelectElement(int position)
    {
        if (position - 1 > Count || position - 1 < 0)
        {
            return $"This position '{position}' is outside from the collection boundary.";
        }

        return array[position - 1].ToString();
    }

    private void CheckArraylength(int[] array)
    {
        var doubleArrayLength = new int[Length * 2];

        if (Count * 2 == Length)
        {
            this.array = CopyArray(array, doubleArrayLength);
        }
    }

    private int[] CopyArray(int[] array, int[] arrayForCopyValue)
    {
        for (int i = 0; i < Count; i++)
        {
            arrayForCopyValue[i] = array[i];
        }

        return arrayForCopyValue;
    }

    public override string ToString()
    {
        var sb = new StringBuilder();

        sb.AppendLine("                                 For Add element press: '1' interval 'selected number'");
        sb.AppendLine("                              For Remove element press: '2'");
        sb.AppendLine("        For Add element in the end of collection press: '3' interval 'selected number'");
        sb.AppendLine("For Remove element in the Begining of collection press: '4'");
        sb.AppendLine("                  For Sort element in collection press: '5'");
        sb.AppendLine("                 For Print element in collection press: '6'");
        sb.AppendLine("               For see element in exact position press: '7' interval 'select position'");
        sb.AppendLine("                             For exit from the program: 'Exit'");
        sb.AppendLine("                                         Choose option:");  


        return sb.ToString();
    }
}