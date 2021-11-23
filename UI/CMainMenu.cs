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
        string infoBar;
        Game game;

        public CMainMenu(string combatLog, string _infoBar, Game game)
        {
            this.combatLog = combatLog;
            infoBar = _infoBar;
            this.game = game;
            // Constructor
        }

        public string Run(int playerHealth, int enemyHealth)
        {
            string headerinfo = $"You have: {playerHealth}hp left -- Enemys has: {enemyHealth}hp left\n";
            string prompt = combatLog;
            List<string> options = new List<string> { "Attack", "Inventory", "Escape fight" };
            Menu menu = new Menu(headerinfo, options, prompt);
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
