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