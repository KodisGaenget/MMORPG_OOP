using System;

namespace ItemAdder
{
    public class Menu
    {
        private int SelectedIndex;
        private string[] Options;
        private string Prompt;
        public Menu(string prompt, string[] options)
        {
            Prompt = prompt;
            Options = options;
            SelectedIndex = 0;
        }

        private void DisplayOptions()
        {
            Console.WriteLine(Prompt);

            for (int i = 0; i < Options.Length; i++)
            {
                string currentOption = Options[i];
                string prefix;

                if (i == SelectedIndex)
                {
                    prefix = ">";
                }
                else
                {
                    prefix = " ";
                }
                Console.Write($"\n{prefix} {currentOption}");
            }
        }

        public int GetMenuIndex()
        {
            ConsoleKey keyPressed;
            do // Loopar igenom menyn tills det att enter trycks ned
            {
                Console.Clear(); // "Reloadar" per knapptryck
                DisplayOptions(); // Visar menyval
                Console.CursorVisible = false;
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                keyPressed = keyInfo.Key;

                // Hanterar piltangenter
                if (keyPressed == ConsoleKey.DownArrow)
                {
                    SelectedIndex++;
                    if (SelectedIndex == Options.Length)
                    {
                        SelectedIndex = 0;
                    }
                }

                else if (keyPressed == ConsoleKey.UpArrow)
                {
                    SelectedIndex--;
                    if (SelectedIndex == -1)
                    {
                        SelectedIndex = Options.Length - 1;
                    }
                }
                // Hanterar piltangenter end

            } while (keyPressed != ConsoleKey.Enter); // Loopa tills det att enter trycks

            return SelectedIndex; // Returnera indexvärde
        }
    }
}