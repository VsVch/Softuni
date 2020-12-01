using System;

namespace _01
{
    class Program
    {
        static void Main(string[] args)
        {
            int numPencils = int.Parse(Console.ReadLine());
            int numColorPens = int.Parse(Console.ReadLine());
            int numBooksForPainting = int.Parse(Console.ReadLine());
            int numBooks = int.Parse(Console.ReadLine());
            double pencilsPrice = numPencils * 4.75;
            double colorPensPrice = numColorPens * 1.80;
            double booksForPaintingPrice = numBooksForPainting * 6.50;
            double booksPrice = numBooks * 2.50;
            double price = pencilsPrice + colorPensPrice + booksForPaintingPrice + booksPrice;
            double totalPrice = price -((price * 5) / 100);
            Console.WriteLine($"Your total is {totalPrice:f2}lv");

        }
    }
}
