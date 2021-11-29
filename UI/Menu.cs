using System;
using System.Collections.Generic;
using GameLib;
namespace UI
{
    public class Menu
    {
        private int SelectedIndex;
        private List<string> Options = new();
        private string Prompt;
        private string Prompt2;
        Game game;
        private bool startMenu;

        public Menu(string prompt, List<string> options, string prompt2, Game game, bool startMenu)
        {
            Prompt = prompt;
            Options = options;
            SelectedIndex = 0;
            Prompt2 = prompt2;
            this.game = game;
            this.startMenu = startMenu;
        }

        private void DisplayOptions()
        {
            if(!startMenu)
            {
                PlayerInfoBar playerInfoBar = new();
                Console.Write(playerInfoBar.InfoBar(game));
            }
            Console.WriteLine(Prompt);

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

            Console.WriteLine($"\n\n{Prompt2}");
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
                // Hanterar piltangenter end

            } while (keyPressed != ConsoleKey.Enter); // Loopa tills det att enter trycks
            return SelectedIndex; // Returnera indexvärde
        }
    }
}