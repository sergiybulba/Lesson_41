/* C#, lesson_41  22.04.2023																																					
																																					
Task № 1:																																					
Створіть додаток, який відображає текстове повідомлення. Використовуйте механізми делегатів. 																																					
Делегат має повертати void та приймати один параметр типу string (текст повідомлення). 																																					
Для тестування додатка створіть різні методи виклику через делегат.																																					
*/
//--------------------------------------------------------------------------------------------------------																																					
using System;
using System.Globalization;
using static System.Console;
namespace Lesson_41_task_1
{

    public delegate void TextDelegate(string str);
    public class Message
    {
        private string _text;
        public string TEXT
        {
            get { return _text; }
            set { _text = value; }
        }

        public Message()
        {
            _text = "";
        }

        public Message(string str)
        {
            _text = str;
        }

        public void PrintMessage(string name)
        {
            Console.WriteLine($"Message for {name}: {_text}");
        }

        public override string ToString()
        {
            return _text;
        }
    }


//--------------------------------------------------------------------------------------------------------																																					
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Program \"C# lesson_41 \"task 1\"\n");

            int index; string name;
            Message text = new Message();
            TextDelegate DeleGate = new TextDelegate(text.PrintMessage);

            do
            {
                Console.Write("\nEnter the message: ");
                text.TEXT = Console.ReadLine();
                Console.Write("\nEnter the person name whom your message is for: ");
                name = Console.ReadLine();

                Console.Write("\nA message sent over the phone: ");
                DeleGate(name);

                Console.Write("\nA message sent over the e-mail: ");
                DeleGate.Invoke(name);


                Console.Write("\nThere is no difference in the methods to pass information!  ");

//--------------------------------------------------------------------------------------------------------																																					

                // продовжити ?																																					
                Console.Write("\n\nDo you want to continue? ('1' for 'yes'): ");
                index = Convert.ToInt32(Console.ReadLine());

            } while (index == 1);


            Console.WriteLine("\n\nThe program is over ...\n\n");
        }
    }
}
