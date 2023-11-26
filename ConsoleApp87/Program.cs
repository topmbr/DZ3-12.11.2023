using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp87
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Task<int> task = Task.Run(() =>
            {
                return CountPrimesInRange(0, 1000);
            });

            // Очікуємо на завершення завдання і отримуємо результат
            int primeCount = task.Result;

            Console.WriteLine($"Кількість простих чисел від 0 до 1000: {primeCount}");
            Console.WriteLine("Головний потік завершено.");
            Console.ReadLine();
        }
        static int CountPrimesInRange(int start, int end)
        {
            int count = 0;
            for (int i = start; i <= end; i++)
            {
                if (IsPrime(i))
                {
                    Console.Write($"{i} ");
                    count++;
                }
            }
            return count;
        }

        static bool IsPrime(int number)
        {
            if (number < 2)
                return false;

            for (int i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0)
                    return false;
            }

            return true;
        }
    }
}
