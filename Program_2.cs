/* C#, lesson_41  22.04.2023					
					
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
namespace Lesson_41_task_2
{
    enum MATH { ADD = 1, SUB, MULT }

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
            Console.WriteLine("Program \"C# lesson_41 \"task 2\"\n");

            int index, a, b;
            MyCalc Calculator = new MyCalc();
            CalcDelegate[] DeleGate = new CalcDelegate[3];
            DeleGate[0] = Calculator.Add;
            DeleGate[1] = Calculator.Sub;
            DeleGate[2] = Calculator.Mult;

            do
            {
                Console.Write("\nEnter first  number: ");
                a = Convert.ToInt32(Console.ReadLine());
                Console.Write("\nEnter second number: ");
                b = Convert.ToInt32(Console.ReadLine());

                Console.Write("\nChoose operation (1 - add, 2 - sub, 3 - mult): ");
                index = Convert.ToInt32(Console.ReadLine());

                Console.Write("\nResult = ");
                switch (index)
                {
                    case (int)MATH.ADD:
                        Console.WriteLine(DeleGate[0](a, b));
                        break;
                    case (int)MATH.SUB:
                        Console.WriteLine(DeleGate[1](a, b));
                        break;
                    case (int)MATH.MULT:
                        Console.WriteLine(DeleGate[2](a, b));
                        break;
                    default:
                        Console.WriteLine("Incorrect choice! Try again.");
                        break;
                }

//--------------------------------------------------------------------------------------------------------					

                // продовжити ?					
                Console.Write("\n\nDo you want to continue? ('1' for 'yes'): ");
                index = Convert.ToInt32(Console.ReadLine());

            } while (index == 1);


            Console.WriteLine("\n\nThe program is over ...\n\n");
        }
    }
}
