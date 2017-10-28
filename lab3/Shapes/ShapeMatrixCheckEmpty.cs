using SparseMatrix;

namespace Shapes
{
    class ShapeMatrixCheckEmpty : IMatrixCheckEmpty<Shape>
    {
        /// <summary>
        /// В качестве пустого элемента возвращается null.
        /// </summary>
        public Shape getEmptyElement() => null;

        /// <summary>
        /// Проверка что переданный параметр равен null.
        /// </summary>
        public bool checkEmptyElement(Shape element)
        {
            bool Result = false;
            if (element == null)
            {
                Result = true;
            }
            return Result;
        }
    }
}