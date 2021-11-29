using GameLib;
using System;

namespace UI
{
    public class PlayerInfoBar
    {
        public string InfoBar(Game game)
        {
            return DisplayCurrentRoom(game) + DisplayHP(game) + DisplayPower(game) + DisplayArmor(game) + DisplayLevel(game) + DisplayXPToNextLevel(game) + DisplayMoney(game) + BreakLine(2);
        }

        private string BreakLine(int n)
        {
            string s = "";
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(s);
            }
            return s; 
        }
        private string DisplayCurrentRoom(Game game)
        {
            return ConsoleUtils.ChangeColor("Write", $"\u25bc {game.roomHandler.GetRoomName(game.player.Position)} ", ConsoleColor.Yellow);
        }

        private string DisplayHelp(Game game)
        {
            return ConsoleUtils.ChangeColor("Write", $"? H", ConsoleColor.Yellow) + ConsoleUtils.ChangeColor("Write", "elp | \n", ConsoleColor.White);
        }
        private string DisplaySearch(Game game)
        {
            if (!game.player.IsRoomExamined(game.player.Position))
            {
                return ConsoleUtils.ChangeColor("Write", $"\u2315 S", ConsoleColor.Yellow) + ConsoleUtils.ChangeColor("Write", "earch | ", ConsoleColor.White);
            }
            return "";
        }

        private string DisplayArmor(Game game)
        {
            return ConsoleUtils.ChangeColor("Write", "\u16e5  ", ConsoleColor.Magenta) + ConsoleUtils.ChangeColor("Write", $"{game.GetDefense()} | ", ConsoleColor.White);
        }

        private string DisplayPower(Game game)
        {
            string text;
            if (game.player.CurrentPower < game.player.Power / 2.5) text = ConsoleUtils.ChangeColor("Write", $"\u2726  ", ConsoleColor.Blue) + ConsoleUtils.ChangeColor("Write", $"{game.player.CurrentPower}", ConsoleColor.Red) + ConsoleUtils.ChangeColor("Write", $" / {game.player.Power} | ", ConsoleColor.White);
            else if (game.player.CurrentPower < game.player.Power / 1.5) text = ConsoleUtils.ChangeColor("Write", $"\u2726  ", ConsoleColor.Blue) + ConsoleUtils.ChangeColor("Write", $"{game.player.CurrentPower}", ConsoleColor.Yellow) + ConsoleUtils.ChangeColor("Write", $" / {game.player.Power} | ", ConsoleColor.White);
            else text = ConsoleUtils.ChangeColor("Write", $"\u2726  ", ConsoleColor.Blue) + ConsoleUtils.ChangeColor("Write", $"{game.player.CurrentPower}", ConsoleColor.White) + ConsoleUtils.ChangeColor("Write", $" / {game.player.Power} | ", ConsoleColor.White);
            return text;
        }

        public string DisplayHP(Game game)
        {
            string text;
            if (game.player.CurrentHealth < game.player.OriginalHealth / 2.5) text = ConsoleUtils.ChangeColor("Write", "| ", ConsoleColor.White) + ConsoleUtils.ChangeColor("Write", $"\u2764  ", ConsoleColor.Red) + ConsoleUtils.ChangeColor("Write", $"{game.player.CurrentHealth}", ConsoleColor.Red) + ConsoleUtils.ChangeColor("Write", $" / {game.player.OriginalHealth} | ", ConsoleColor.White);
            else if (game.player.CurrentHealth < game.player.OriginalHealth / 1.5) text = ConsoleUtils.ChangeColor("Write", "| ", ConsoleColor.White) + ConsoleUtils.ChangeColor("Write", $"\u2764  ", ConsoleColor.Red) + ConsoleUtils.ChangeColor("Write", $"{game.player.CurrentHealth}", ConsoleColor.Yellow) + ConsoleUtils.ChangeColor("Write", $" / {game.player.OriginalHealth} | ", ConsoleColor.White);
            else text = ConsoleUtils.ChangeColor("Write", "| ", ConsoleColor.White) + ConsoleUtils.ChangeColor("Write", $"\u2764  ", ConsoleColor.Red) + ConsoleUtils.ChangeColor("Write", $"{game.player.CurrentHealth}", ConsoleColor.White) + ConsoleUtils.ChangeColor("Write", $" / {game.player.OriginalHealth} | ", ConsoleColor.White);
            return text;
        }

        private string DisplayMoney(Game game)
        {
            return ConsoleUtils.ChangeColor("Write", "\u20AB ", ConsoleColor.Green) + ConsoleUtils.ChangeColor("Write", $"{game.player.CoinPurse} | ", ConsoleColor.White);
        }

        private string DisplayLevel(Game game)
        {
            return ConsoleUtils.ChangeColor("Write", $"Level: {game.player.Level} | ", ConsoleColor.White);
        }

        private string DisplayXPToNextLevel(Game game)
        {
            return ConsoleUtils.ChangeColor("Write", $"XP to next level: {game.player.ExpToNextLevel()} | ", ConsoleColor.White);
        }
    }
}