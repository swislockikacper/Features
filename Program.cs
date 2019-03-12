using System;

namespace NewFeatures
{
    class Program
    {
        static void Main(string[] args)
        {
            var demo = new Demo();

            //Yield
            var elements = demo.ListWithYieldReturn();

            Console.WriteLine("YIELD");
            foreach (var element in elements)
            {
                Console.Write($"{element}, ");
            }
            Console.WriteLine();
            Console.WriteLine();

            //Checking types of objects
            Console.WriteLine("TYPES");

            Console.WriteLine(demo.IsIntExpression(null));
            Console.WriteLine(demo.IsIntExpression(3));
            Console.WriteLine(demo.IsIntExpression("test"));
            Console.WriteLine();

            //References
            Console.WriteLine("REFERENCES");

            demo.PrintNumbers();

            ref var number = ref demo.Find(1);
            number = 5;
            Console.WriteLine("Numbers after change in Program.cs");

            demo.PrintNumbers();
            Console.WriteLine();

            //Functions
            Console.WriteLine("FUNCTIONS");

            Console.WriteLine($"Fibnacci from 5 = {demo.Fibonacci(5)}");
            Console.WriteLine();

            //Func
            Console.WriteLine("FUNC");
            demo.FuncTest();
            Console.WriteLine();

            //Switch types
            Console.WriteLine("TYPES");
            demo.PrintType(5);
            demo.PrintType((long)5);
            demo.PrintType((short)5);
            demo.PrintType("test");


            //Iterator
            Console.WriteLine("ITERATOR");
            foreach (var element in demo.GetElementsAfterFiltering())
            {
                Console.Write(element + ", ");
            }

            Console.ReadKey();
        }
    }
}
