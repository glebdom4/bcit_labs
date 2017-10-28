using System;

namespace Shapes
{
    /// <summary>
    /// Класс Круг.
    /// </summary>
    class Circle : Shape, IPrint
    {
        /// <summary>
        /// Радиус круга.
        /// </summary>
        private double radius;

        /// <summary>
        /// Основной конструктор.
        /// </summary>
        /// <param name="radius">Радиус круга</param>
        public Circle(double radius)
        {
            Type = "Круг";
            this.radius = radius;
        }

        /// <summary>
        /// Вычисление площади.
        /// </summary>
        public override double Area()
        {
            double area = Math.PI * Math.Pow(radius, 2);

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
