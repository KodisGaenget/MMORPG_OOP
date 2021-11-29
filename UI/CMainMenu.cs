using System.Collections.Generic;
using GameLib;
using System;

namespace UI
{

    class CMainMenu
    {
        string combatLog = "";
        // private Menu menu;
        Game game;

        public CMainMenu(string combatLog, Game game)
        {
            this.combatLog = combatLog;
            this.game = game;
            // Constructor
        }

        public string DisplayEnemyHP() // TEMP TEST - Make into EnemyInfoBar
        {
            return $"\u2764  {game.combatHandler.enemyHealth}";
        }
        public string Run(int _roomID)
        {
            string prompt = $"Enemy: {game.spawner.GetEnemy(game.roomHandler.GetRoom(_roomID).EnemyInRoom).Name}\nHP: {DisplayEnemyHP()}"; // TEMP TEST
            string prompt2 = combatLog;
            List<string> options = new List<string> { "Attack", "Inventory", "Escape fight" };
            Menu menu = new Menu(prompt, options, prompt2, game, false);
            int selectedIndex = menu.GetMenuIndex();
            switch (selectedIndex)
            {
                case 0:
                    //Console.Write("Attack");
                    return "Attack";

                case 1:
                    //Console.Write("Inventory");
                    return "Inventory";

                case 2:
                    // Console.Write("Escape fight");
                    return "Escape";
            }
            return "";
        }

    }
}
