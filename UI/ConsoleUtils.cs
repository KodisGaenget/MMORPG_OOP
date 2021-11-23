using System;

namespace UI
{
    class ConsoleUtils
    {
        public static string ChangeColor(string n, string s, ConsoleColor consoleColor)
        {
            Console.ForegroundColor = consoleColor;

            if (n == "Write") Console.Write(s);

            if (n == "WriteLine") Console.WriteLine(s);

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

        public static int CountStringLines(string s)
        {
            int lineCount = 1;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '\n') lineCount++;
            }

            return lineCount;
        }

        public static void TypeWriter(string s, ConsoleKey consoleKey, bool skipText)
        {
            if (!skipText)
            {
                Console.SetCursorPosition(0, CountStringLines(s) + 4);
                ChangeColor("Write", "Press ", ConsoleColor.DarkGray);
                ChangeColor("Write", $"{consoleKey.ToString().ToUpper()}", ConsoleColor.DarkYellow);
                ChangeColor("Write", " to skip", ConsoleColor.DarkGray);
            }
            Console.SetCursorPosition(0, 2);

            int i = 0;
            do
            {
                Console.ForegroundColor = ConsoleColor.White;
                while (!Console.KeyAvailable)
                {
                    Console.Write($"{s[i]}");
                    i++;
                    System.Threading.Thread.Sleep(40);
                    if (i >= s.Length) break;
                }
            } while (Console.ReadKey(true).Key != consoleKey);
            if (i < s.Length) Console.Write($"{s.Substring(i, s.Length - i)}");
            Console.ResetColor();
        }
    }
}