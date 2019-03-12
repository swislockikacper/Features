using System;
using System.Collections.Generic;

namespace NewFeatures
{
    class Demo
    {
        private int[] elements;

        public Demo()
        {
            elements = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        }

        public IEnumerable<int> ListWithYieldReturn()
        {
            foreach (var element in elements)
            {
                if (element > 5)
                    yield return element;
            }
        }

        public string IsIntExpression(object o)
        {
            if (o is null)
                return "Object is null";
            if (o is int i)
                return $"Object is int = {i}";

            return "It's not int object";
        }

        public ref int Find(int number)
        {
            for (int i = 0; i < elements.Length; i++)
            {
                if (elements[i] == number)
                {
                    Console.WriteLine($"Number in array at {i} index is {elements[i]}");
                    return ref elements[i];
                }
            }

            throw new IndexOutOfRangeException($"Number {number} not found");
        }

        public void PrintNumbers()
        {
            foreach (var element in elements)
            {
                Console.Write($"{element}, ");
            }

            Console.WriteLine();
        }

        public int Fibonacci(int x)
        {
            if (x < 0)
                throw new ArgumentException("Number must be greather than 0", nameof(x));

            return Fib(x).previous;

            (int current, int previous) Fib(int i)
            {
                if (i == 0)
                    return (1, 0);

                var (p, pp) = Fib(i - 1);

                return (p + pp, p);
            }
        }

        public void FuncTest()
        {
            var x = DoMaths(Add);
            var y = DoMaths(Subtract);
            var z = DoMaths((int a, int b) => { return x * y; });

            Console.WriteLine("Sum = " + x);
            Console.WriteLine("Subtract = " + y);
            Console.WriteLine("Product = " + z);
        }

        private int DoMaths(Func<int, int, int> mathFunction)
        {
            var x = 10;
            var y = 5;

            return mathFunction(x, y);
        }

        private int Add(int x, int y)
            => x + y;

        private int Subtract(int x, int y)
            => x - y;

        public void PrintType(object o)
        {
            switch (o)
            {
                case int i:
                    Console.WriteLine("It's int");
                    break;
                case long i:
                    Console.WriteLine("It's long");
                    break;
                case short i:
                    Console.WriteLine("It's short");
                    break;
                case string s:
                    Console.WriteLine("It's string");
                    break;
                default:
                    Console.WriteLine("It's another type");
                    break;
                case null:
                    throw new ArgumentNullException("Object cannot be null");
            }
        }

        private IEnumerable<T> Filter<T>(IEnumerable<T> elements, Func<T, bool> filter)
        {
            if (elements == null)
                throw new ArgumentNullException(nameof(elements));
            if (filter == null)
                throw new ArgumentNullException(nameof(filter));

            return Iterator();

            IEnumerable<T> Iterator()
            {
                foreach (var element in elements)
                {
                    if (filter(element))
                        yield return element;
                }
            }
        }

        private bool GetElementsBiggerThan5(int element)
            => element > 5 ? true : false;

        public IEnumerable<int> GetElementsAfterFiltering()
            => Filter(elements, GetElementsBiggerThan5);
    }
}

