/* C#, lesson_41  22.04.2023					
					
Task № 3:					
Створіть додатки для виконання арифметичних операцій. Підтримувані операції:					
¦ Перевірка числа на парність;					
¦ Перевірка числа на непарність;					
¦ Перевірка на просте число;					
¦ Перевірка на число Фібоначчі.					
Обов’язково використовуйте делегат типу Predicate.					
*/
//--------------------------------------------------------------------------------------------------------					
using System;
using System.Globalization;
using static System.Console;
namespace Lesson_41_task_3
{
    public delegate bool Predicate(int number);

    public class Number
    {
        public bool Even_number(int number)     // парне число
        {
            return number % 2 == 0;
        }

        public bool Odd_number(int number)     // непарне число
        {
            return number % 2 == 1;
        }

        public bool Prime_number(int number)     // просте число
        {
            for (int i = 1; i <= number; i++)
            {
                if (number % i == 0 && i > 1 && i < number)
                    return false;
            }
            return true;
        }

        public bool Fibonacci_number(int number)     // число Фібоначчі
        {
            int fibonacci_prev = 1, fibonacci_next = fibonacci_prev, temp;
            do
            {
                if (number == fibonacci_next)
                    return true;
                temp = fibonacci_prev;
                fibonacci_prev = fibonacci_next;
                fibonacci_next += temp;
            } while (number >= fibonacci_next);
            return false;
        }
    }

//--------------------------------------------------------------------------------------------------------					
    class Program
    {
        static void Check(int a, Predicate myDelegate)          // метод для перевірки чисел через делегат
        {
            Console.WriteLine("\nThe result of numerical analysis of this number: \n");
            foreach (Predicate item in myDelegate.GetInvocationList())
            {
                Console.WriteLine($"{item.Method.Name}: {item(a)}");
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Program \"C# lesson_41 \"task 3\"\n");

            int index, a;
            Number number = new Number();
            Predicate DeleGate = new Predicate(number.Even_number);     // створення багатоадресноо делегата
            DeleGate += number.Odd_number;
            DeleGate += number.Prime_number;
            DeleGate += number.Fibonacci_number;

            do
            {
                do
                {
                    Console.Write("\nEnter the number: ");
                    a = Convert.ToInt32(Console.ReadLine());
                    if(a < 1)
                        Console.WriteLine("Incorrect! Try again.");
                } while (a < 1);

                Check(a, DeleGate);         // передача в метод заданого числа і делегата

//--------------------------------------------------------------------------------------------------------					

                // продовжити ?					
                Console.Write("\n\nDo you want to continue? ('1' for 'yes'): ");
                index = Convert.ToInt32(Console.ReadLine());

            } while (index == 1);

            Console.WriteLine("\n\nThe program is over ...\n\n");
        }
    }
}
