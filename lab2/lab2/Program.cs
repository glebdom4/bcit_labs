using System;
using Shapes;

namespace lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            Rectangle rect = new Rectangle(3, 2);
            Square square = new Square(5);
            Circle circle = new Circle(5);

            rect.Print();
            square.Print();
            circle.Print();

            Console.ReadKey();
        }
    }
}
