using System;

namespace UI
{
    class ConsoleUtils
    {
        public static string ChangeColor(string n, string s, ConsoleColor consoleColor)
        {
            Console.ForegroundColor = consoleColor;

            if (n == "Write")
            {
                Console.Write(s);
            }

            if (n == "WriteLine")
            {
                Console.WriteLine(s);
            }

            Console.ResetColor();
            return string.Empty;
        }

        public static void BreakLine(string s)
        {
            int charCount = 0;
            for (int i = 0; i < s.Length; i++)
            {
                Console.Write(s[i]);
                charCount++;
                if (charCount > 100 && s[i] == ' ')
                {
                    Console.WriteLine();
                    charCount = 0;
                }
            }
        }
        public static void Test(string _text)
        {
            for (int i = 0; i < _text.Length; i++)
            {
                Console.Write(_text[i]);
                System.Threading.Thread.Sleep(60);
            }
        }
        public static void TypeWriter(string s)
        {
            int i = 0;
            do
            {
                while (!Console.KeyAvailable)
                {
                    Console.Write(s[i]);
                    i++;
                    System.Threading.Thread.Sleep(40);
                    if (i >= s.Length) break;
                }
            } while (Console.ReadKey(true).Key != ConsoleKey.Enter);
            if (i < s.Length) Console.Write(s.Substring(i, s.Length - i));
        }
    }
}