/* C#, lesson_41  22.04.2023					
					
Task № 4:					
Реалізуйте додаток із другого практичного завдання за допомогою виклику Invoke.					
					
Task № 2:					
Створіть додаток для виконання арифметичних операцій. Підтримувані операції:					
¦ Додавання двох чисел;					
¦ Віднімання двох чисел;					
¦ Множення двох чисел.					
Код програми обов’язково має використати механізм делегатів.					
*/
//--------------------------------------------------------------------------------------------------------					
using System;
using System.Globalization;
using static System.Console;
namespace Lesson_41_task_4
{
    public delegate int CalcDelegate(int a, int b);

    public class MyCalc
    {
        public int Add(int a, int b)
        {
            return a + b;
        }

        public int Sub(int a, int b)
        {
            return a - b;
        }

        public int Mult(int a, int b)
        {
            return a * b;
        }
    }

//--------------------------------------------------------------------------------------------------------					
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Program \"C# lesson_41 \"task 4\"\n");

            int index, a, b;
            MyCalc Calculator = new MyCalc();
            CalcDelegate DeleGate = null;

            do
            {
                Console.Write("\nEnter first  number: ");
                a = Convert.ToInt32(Console.ReadLine());
                Console.Write("\nEnter second number: ");
                b = Convert.ToInt32(Console.ReadLine());

                if (DeleGate?.Invoke(a, b) == null)
                    Console.WriteLine("\nThe delegate is still empty. \n");

                DeleGate += Calculator.Add;
                DeleGate += Calculator.Sub;
                DeleGate += Calculator.Mult;

                Console.WriteLine("After filling the delegate: \n");
                foreach (CalcDelegate item in DeleGate.GetInvocationList())
                {
                    Console.WriteLine($"{item.Method.Name}: {item.Invoke(a, b)}");
                }

                DeleGate -= Calculator.Add;
                DeleGate -= Calculator.Sub;
                DeleGate -= Calculator.Mult;

//--------------------------------------------------------------------------------------------------------					

                // продовжити ?					
                Console.Write("\n\nDo you want to continue? ('1' for 'yes'): ");
                index = Convert.ToInt32(Console.ReadLine());

            } while (index == 1);


            Console.WriteLine("\n\nThe program is over ...\n\n");
        }
    }
}
