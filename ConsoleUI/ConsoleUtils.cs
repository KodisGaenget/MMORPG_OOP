using System;

namespace ConsoleUI
{
    class ConsoleUtils
    {
        public static void TypeWriter(string _text)
        {
            for (int i = 0; i < _text.Length; i++)
            {
                Console.Write(_text[i]);
                System.Threading.Thread.Sleep(60);
            }
        }

    }
}