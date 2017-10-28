namespace Shapes
{
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
}
