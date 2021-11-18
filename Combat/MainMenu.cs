using System;
using System.Collections.Generic;
using GameInterfaces;

namespace Combat.UI
{

    class MainMenu
    {
        string combatLog = "";

        public MainMenu(string combatLog)
        {
            this.combatLog = combatLog;
            // Constructor
        }

        public string Run(IFightable player)
        {
            string prompt = combatLog;
            List<string> options = new List<string> { "Attack", "Inventory", "Escape fight" };
            Menu menu = new Menu(prompt, options);
            int selectedIndex = menu.GetMenuIndex();
            switch (selectedIndex)
            {
                case 0:
                    Console.Write("Attack");
                    return "Attack";

                case 1:
                    Console.Write("Inventory");
                    return "Inventory";

                case 2:
                    Console.Write("Escape fight");
                    return "Escape";
            }
            return "";
        }
    }
}
