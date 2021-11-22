using System;

namespace UI
{
    class ConsoleUtils
    {
        public static void Red(string s)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(s);
            Console.ResetColor();
        }

        public static void Yellow(string s)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(s);
            Console.ResetColor();
        }

        public static void Green(string s)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(s);
            Console.ResetColor();
        }

        public static void Blue(string s)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(s);
            Console.ResetColor();
        }

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
    }
}