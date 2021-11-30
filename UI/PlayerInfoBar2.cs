using System;
using System.Threading;
using GameLib;
using GameEnums;

namespace UI
{
    class PlayerInfoBar2
    {
        Game game;

        public PlayerInfoBar2(Game game)
        {
            this.game = game;
        }

        public string FullBar()
        {
            return CurrentRoom() + HealthPoints() + Power() + Armor() + Damage() + Level() + XpToNextLevel() + Money();
        }

        public string CurrentRoom()
        {
            return ConsoleUtils.ChangeColor("Write", $"\u25bc {game.roomHandler.GetRoomName(game.player.Position)} ", ConsoleColor.Yellow);
        }

        public string HealthPoints()
        {
            string text;
            if (game.player.CurrentHealth < game.player.OriginalHealth / 2.5) text = ConsoleUtils.ChangeColor("Write", "| ", ConsoleColor.White) + ConsoleUtils.ChangeColor("Write", $"\u2764  ", ConsoleColor.Red) + ConsoleUtils.ChangeColor("Write", $"{game.player.CurrentHealth}", ConsoleColor.Red) + ConsoleUtils.ChangeColor("Write", $" / {game.player.OriginalHealth} | ", ConsoleColor.White);
            else if (game.player.CurrentHealth < game.player.OriginalHealth / 1.5) text = ConsoleUtils.ChangeColor("Write", "| ", ConsoleColor.White) + ConsoleUtils.ChangeColor("Write", $"\u2764  ", ConsoleColor.Red) + ConsoleUtils.ChangeColor("Write", $"{game.player.CurrentHealth}", ConsoleColor.Yellow) + ConsoleUtils.ChangeColor("Write", $" / {game.player.OriginalHealth} | ", ConsoleColor.White);
            else text = ConsoleUtils.ChangeColor("Write", "| ", ConsoleColor.White) + ConsoleUtils.ChangeColor("Write", $"\u2764  ", ConsoleColor.Red) + ConsoleUtils.ChangeColor("Write", $"{game.player.CurrentHealth}", ConsoleColor.White) + ConsoleUtils.ChangeColor("Write", $" / {game.player.OriginalHealth} | ", ConsoleColor.White);
            return text;
        }

        public string Search()
        {
            if (!game.player.IsRoomExamined(game.player.Position))
            {
                return ConsoleUtils.ChangeColor("Write", $"\u2315 S", ConsoleColor.Yellow) + ConsoleUtils.ChangeColor("Write", "earch | ", ConsoleColor.White);
            }
            return "";
        }

        public string Help()
        {
            return ConsoleUtils.ChangeColor("Write", $"? H", ConsoleColor.Yellow) + ConsoleUtils.ChangeColor("Write", "elp | \n", ConsoleColor.White);
        }

        public string Power()
        {
            string text;
            if (game.player.CurrentPower < game.player.Power / 2.5) text = ConsoleUtils.ChangeColor("Write", $"\u2726  ", ConsoleColor.Blue) + ConsoleUtils.ChangeColor("Write", $"{game.player.CurrentPower}", ConsoleColor.Red) + ConsoleUtils.ChangeColor("Write", $" / {game.player.Power} | ", ConsoleColor.White);
            else if (game.player.CurrentPower < game.player.Power / 1.5) text = ConsoleUtils.ChangeColor("Write", $"\u2726  ", ConsoleColor.Blue) + ConsoleUtils.ChangeColor("Write", $"{game.player.CurrentPower}", ConsoleColor.Yellow) + ConsoleUtils.ChangeColor("Write", $" / {game.player.Power} | ", ConsoleColor.White);
            else text = ConsoleUtils.ChangeColor("Write", $"\u2726  ", ConsoleColor.Blue) + ConsoleUtils.ChangeColor("Write", $"{game.player.CurrentPower}", ConsoleColor.White) + ConsoleUtils.ChangeColor("Write", $" / {game.player.Power} | ", ConsoleColor.White);
            return text;
        }

        public string Armor()
        {
            return ConsoleUtils.ChangeColor("Write", "\u16e5  ", ConsoleColor.Magenta) + ConsoleUtils.ChangeColor("Write", $"{game.GetDefense()} | ", ConsoleColor.White);
        }

        public string Damage()
        {
            string text = ConsoleUtils.ChangeColor("Write", $"\u2726  ", ConsoleColor.Blue) + ConsoleUtils.ChangeColor("Write", $"{game.player.MinDamage} - {game.player.MaxDamage} ", ConsoleColor.Blue);
            return text;
        }

        public string Level()
        {
            return ConsoleUtils.ChangeColor("Write", $"Level: {game.player.Level} | ", ConsoleColor.White);
        }

        public string XpToNextLevel()
        {
            return ConsoleUtils.ChangeColor("Write", $"XP to next level: {game.player.ExpToNextLevel()} | ", ConsoleColor.White);
        }

        public string Money()
        {
            return ConsoleUtils.ChangeColor("Write", "\u20AB ", ConsoleColor.Green) + ConsoleUtils.ChangeColor("Write", $"{game.player.CoinPurse} | ", ConsoleColor.White);
        }
    }
}