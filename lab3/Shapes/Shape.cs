using System;

namespace Shapes
{
    /// <summary>
    /// Класс Фигура.
    /// </summary>
    abstract class Shape : IComparable
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
        /// Сравнение элементов.
        /// </summary>
        /// <param name="obj">правый параметр сравнения</param>
        /// <returns> -1 - если левый параметр меньше правого
        ///            0 - параметры равны
        ///            1 - если левый параметр больше правого
        /// </returns>
        public int CompareTo(object obj)
        {
            Shape p = (Shape)obj;

            if (this.Area() < p.Area()) return -1;
            else if (this.Area() == p.Area()) return 0;
            else return 1;
        }

        /// <summary>
        /// Приведение к строке, переопределение метода Object.
        /// </summary>
        public override string ToString()
        {
            return "Площадь " + Type + "а = " + string.Format("{0:F2}", Area()) + " кв. ед.";
        }

    }
}
