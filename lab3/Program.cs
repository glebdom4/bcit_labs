using System;
using System.Collections;
using System.Collections.Generic;
using Shapes;
using SparseMatrix;
using ShapesCollections;

namespace lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Объекты классов Rectangle, Square и Circle
            Rectangle rect = new Rectangle(12, 22);
            Square square = new Square(24);
            Circle circle = new Circle(11);
            #endregion

            #region Коллекция класса ArrayList
            Console.WriteLine("Отсортированный необобщенный список");

            ArrayList shapesArrList = new ArrayList();
            shapesArrList.Add(rect);
            shapesArrList.Add(square);
            shapesArrList.Add(circle);

            shapesArrList.Sort();

            foreach (var shape in shapesArrList)
                Console.WriteLine(shape);
            #endregion

            #region Коллекция класса List<Shape>
            Console.WriteLine("\nОтсортированный обобщенный список");

            List<Shape> shapeList = new List<Shape>();
            shapeList.Add(rect);
            shapeList.Add(square);
            shapeList.Add(circle);

            shapeList.Sort();

            foreach (var shape in shapeList)
                Console.WriteLine(shape);
            #endregion

            #region Пример работы разрежённой матрицы Matrix3D<Shape>
            Console.WriteLine("\nМатрица");

            Matrix3D<Shape> matrix = new Matrix3D<Shape>(3, 3, 3, new ShapeMatrixCheckEmpty());
            matrix[0, 0, 0] = rect;
            matrix[1, 1, 1] = square;
            matrix[2, 2, 2] = circle;

            Console.WriteLine(matrix);
            #endregion

            #region Пример работы класса SimpleStack
            Console.WriteLine("Стек");

            SimpleStack<Shape> stack = new SimpleStack<Shape>();
            stack.Push(rect);
            stack.Push(square);
            stack.Push(circle);

            while (stack.Count > 0)
            {
                Shape shape = stack.Pop();
                Console.WriteLine(shape);
            }
            #endregion

            Console.ReadKey();
        }
    }
}
