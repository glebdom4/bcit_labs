using System;

namespace Shapes
{
    /// <summary>
    /// Класс Прямоугольник.
    /// </summary>
    class Rectangle : Shape, IPrint
    {
        /// <summary>
        /// Высота.
        /// </summary>
        private double height;
        /// <summary>
        /// Ширина.
        /// </summary>
        private double width;

        /// <summary>
        ///  Основной конструктор.
        /// </summary>
        /// <param name="height">Высота</param>
        /// <param name="width">Ширина</param>
        public Rectangle(double height, double width)
        {
            Type = "Прямоугольник";
            this.height = height;
            this.width = width;
        }

        /// <summary>
        /// Вычисление площади.
        /// </summary>
        public override double Area()
        {
            double area = height * width;

            return area;
        }

        /// <summary>
        /// Вывод информации о фигуре в консоль.
        /// </summary>
        public void Print()
        {
            Console.WriteLine(ToString());
        }
    }
}
