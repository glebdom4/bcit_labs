using System;
using System.Collections.Generic;
using System.Text;

namespace SparseMatrix
{
    /// <summary>
    /// Класс Разреженная матрица.
    /// </summary>
    public class Matrix3D<T>
    {

        /// <summary>
        /// Словарь для хранения значений.
        /// </summary>
        Dictionary<string, T> _matrix = new Dictionary<string, T>();

        /// <summary>
        /// Максимальное число элементов по оси X.
        /// </summary>
        int maxX;

        /// <summary>
        /// Максимальное число элементов по оси Y.
        /// </summary>
        int maxY;

        /// <summary>
        /// Максимальное число элементов по оси Z.
        /// </summary>
        int maxZ;

        /// <summary>
        /// Реализация интерфейса для проверки пустого элемента.
        /// </summary>
        IMatrixCheckEmpty<T> сheckEmpty;

        /// <summary>
        /// Основной конструктор.
        /// </summary>
        public Matrix3D(int x_size, int y_size, int z_size, IMatrixCheckEmpty<T> сheckEmptyParam)
        {
            this.maxX = x_size;
            this.maxY = y_size;
            this.maxZ = z_size;
            this.сheckEmpty = сheckEmptyParam;
        }

        /// <summary>
        /// Индексатор для доступа к данным.
        /// </summary>
        public T this[int x, int y, int z]
        {
            set
            {
                CheckBounds(x, y, z);
                string key = DictKey(x, y, z);
                this._matrix.Add(key, value);
            }
            get
            {
                CheckBounds(x, y, z);
                string key = DictKey(x, y, z);
                if (this._matrix.ContainsKey(key))
                    return this._matrix[key];
                else
                    return this.сheckEmpty.getEmptyElement();
            }
        }

        /// <summary>
        /// Проверка границ.
        /// </summary>
        void CheckBounds(int x, int y, int z)
        {
            if (x < 0 || x >= this.maxX)
            {
                throw new ArgumentOutOfRangeException("x", "x=" + x + " выходит за границы");
            }
            if (y < 0 || y >= this.maxY)
            {
                throw new ArgumentOutOfRangeException("y", "y=" + y + " выходит за границы");
            }
            if (z < 0 || z >= this.maxZ)
            {
                throw new ArgumentOutOfRangeException("z", "z=" + z + " выходит за границы");
            }
        }

        /// <summary>
        /// Формирование ключа.
        /// </summary>
        string DictKey(int x, int y, int z) => x.ToString() + "_" + y.ToString() + "_" + z.ToString();

        /// <summary>
        /// Приведение к строке.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder b = new StringBuilder();

            for (int i = 0; i < this.maxX; i++)
            {
                b.Append("[");

                for (int j = 0; j < this.maxY; j++)
                {
                    b.Append("[");

                    for (int z = 0; z < this.maxZ; z++)
                    {
                        if (!this.сheckEmpty.checkEmptyElement(this[i, j, z]))
                          b.Append(this[i, j, z].ToString());
                        else
                            b.Append(" - ");
                    }

                    if (j < this.maxY - 1)
                        b.Append("], ");
                    else
                        b.Append("]");
                    
                }

                b.Append("]\n");
            }
                return b.ToString();
        }

    }
}
