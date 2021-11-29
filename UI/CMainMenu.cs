using System;
using System.Collections.Generic;
using GameInterfaces;
using GameLib;


namespace UI
{

    class CMainMenu
    {
        string combatLog = "";
        private Menu menu;
        Game game;

        public CMainMenu(string combatLog, Game game)
        {
            this.combatLog = combatLog;
            this.game = game;
            // Constructor
        }

        public string Run()
        {
            string prompt = $"{game.combatHandler.playerHealth} vs {game.combatHandler.enemyHealth}";
            string prompt2 = combatLog;
            List<string> options = new List<string> { "Attack", "Inventory", "Escape fight" };
            Menu menu = new Menu(prompt, options, prompt2);
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
