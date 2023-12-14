using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Numerics;

namespace dz12
{
    internal class Program
    {
        static void PrintNumbers(object prefix)
        {
            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine($"{prefix}{i}");
                Thread.Sleep(100);
            }
        }
        public static string[] GetMethodNames(object obj)
        {
            Type type = obj.GetType();
            MethodInfo[] methods = type.GetMethods(BindingFlags.Public | BindingFlags.Instance);
            string[] methodNames = new string[methods.Length];

            for (int i = 0; i < methods.Length; i++)
            {
                methodNames[i] = methods[i].Name;
            }

            return methodNames;
        }
        static async Task Main(string[] args)
        {
            // task1
            Thread t1 = new Thread(PrintNumbers);
            Thread t2 = new Thread(PrintNumbers);
            Thread t3 = new Thread(PrintNumbers);

            t1.Start("thread 1: ");
            t2.Start("thread 2: ");
            t3.Start("thread 3: ");

            // task2
            Console.Write("введите число для вычисления факториала: ");
            int number = int.Parse(Console.ReadLine());
            await CalculateFactorialAsync(number);
            Console.Write("введите число для вычисления квадрата: ");
            int numberForSquare = int.Parse(Console.ReadLine());
            int squareResult = CalculateSquare(numberForSquare);
            Console.WriteLine($"квадрат числа {numberForSquare} равен {squareResult}");

            // task3
            Refl refl = new Refl();
            string[] methodNames = GetMethodNames(refl);
            foreach (string name in methodNames)
            {
                Console.WriteLine(name);
            }
            Console.ReadKey();
        }
        static async Task CalculateFactorialAsync(int number)
        {
            int factorialResult = await Task.Run(() => CalculateFactorial(number));
            Console.WriteLine($"факториал числа {number} равен {factorialResult}");
        }

        static int CalculateFactorial(int number)
        {
            int result = 1;
            for (int i = 1; i <= number; i++)
            {
                result *= i;
            }
            Thread.Sleep(8000);
            return result;
        }

        static int CalculateSquare(int number)
        {
            return number * number;
        }
    }
}
