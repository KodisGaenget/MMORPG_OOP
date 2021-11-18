using System;
using System.Collections.Generic;

namespace Combat.UI
{
    public class Menu
    {
        private int SelectedIndex;
        private List<string> Options = new();
        private string Prompt;
        public Menu(string prompt, List<string> options)
        {
            Prompt = prompt;
            Options = options;
            SelectedIndex = 0;
        }

        private void DisplayOptions()
        {

            for (int i = 0; i < Options.Count; i++)
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
            Console.WriteLine("\n" + Prompt);
        }

        public int GetMenuIndex()
        {
            ConsoleKey keyPressed;
            do
            {
                Console.Clear();
                DisplayOptions();
                Console.CursorVisible = false;
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                keyPressed = keyInfo.Key;

                if (keyPressed == ConsoleKey.DownArrow)
                {
                    SelectedIndex++;
                    if (SelectedIndex == Options.Count)
                    {
                        SelectedIndex = 0;
                    }
                }

                else if (keyPressed == ConsoleKey.UpArrow)
                {
                    SelectedIndex--;
                    if (SelectedIndex == -1)
                    {
                        SelectedIndex = Options.Count - 1;
                    }
                }
            } while (keyPressed != ConsoleKey.Enter);

            return SelectedIndex;
        }
    }
}