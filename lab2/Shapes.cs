using System;

namespace Shapes
{
    /// <summary>
    /// Класс фигура.
    /// </summary>
    abstract class Shape
    {
        /// <summary>
        /// Тип фигуры.
        /// </summary>
        public string Type { get; protected set; }

        /// <summary>
        /// Вычисление площади.
        /// </summary>
        /// <returns></returns>
        public abstract double Area();

        /// <summary>
        /// Приведение к строке, переопределение метода Object.
        /// </summary>
        public override string ToString()
        {
            return "Площадь " + Type + "а = " + string.Format("{0:F2}", Area()) + " кв. ед.";
        }

    }


    interface IPrint
    {
        void Print();
    }


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


    /// <summary>
    /// Класс Квадрат.
    /// </summary>
    class Square : Rectangle
    {
        /// <summary>
        /// Основной конструктор.
        /// </summary>
        /// <param name="size">Длина стороны квадрата</param>
        public Square(double size) : base(size, size)
        {
            Type = "Квадрат";
        }
    }


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
