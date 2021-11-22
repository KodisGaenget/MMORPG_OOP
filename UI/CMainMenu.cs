using System;
using System.Collections.Generic;
using GameInterfaces;

namespace UI
{

    class CMainMenu
    {
        string combatLog = "";
        private CMenu menu;

        public CMainMenu(string combatLog)
        {
            this.combatLog = combatLog;
            // Constructor
        }

        public string Run(int playerHealth, int enemyHealth)
        {
            string headerinfo = $"You have: {playerHealth}hp left -- Enemys has: {enemyHealth}hp left\n";
            string prompt = combatLog;
            List<string> options = new List<string> { "Attack", "Inventory", "Escape fight" };
            CMenu menu = new CMenu(prompt, options, headerinfo);
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
