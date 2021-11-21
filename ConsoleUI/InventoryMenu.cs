using System;
using System.Collections.Generic;
using GameLib;

namespace ConsoleUI
{
    class InventoryMenu
    {
        Game game;
        public InventoryMenu(Game game)
        {
            this.game = game;
            CreateConsumableMenu();
            Run();
        }


        public string Run()
        {

            string headerinfo = $"Inventory:\n";
            string prompt = "";
            List<string> options = CreateConsumableMenu();
            Menu menu = new Menu(prompt, options, headerinfo);
            int selectedIndex = menu.GetMenuIndex();

            foreach (var item in options)
            {
                System.Console.Write(item);
            }

            return "";

        }

        private List<string> CreateConsumableMenu()
        {
            List<string> consumablesAvailable = new();
            foreach (var item in game.player.GetItemIdsFromEquipment())
            {
                if (game.itemLoader.GetItemType(item) == "Consumable")
                {

                    consumablesAvailable.Add(game.itemLoader.GetConsumableDetails(item).ConsumableType.ToString());
                }
            }
            consumablesAvailable.Add("Back");
            return consumablesAvailable;
        }
    }
}