using System;
using System.Collections.Generic;
using GameLib;

namespace UI
{
    class InvMenuTest
    {
        List<InventoryInfo> inventory;

        public InvMenuTest(List<InventoryInfo> inventory)
        {
            this.inventory = inventory;

            Run();
        }


        public string Run()
        {

            string headerinfo = $"Inventory:\n";
            string prompt = "";
            List<string> options = CreateStringMenu();
            CMenu menu = new CMenu(prompt, options, headerinfo);
            int selectedIndex = menu.GetMenuIndex();

            foreach (var item in options)
            {
                System.Console.Write(item);
            }

            return "";

        }

        private List<string> CreateStringMenu()
        {
            List<string> itemsAvailable = new();
            foreach (var item in inventory)
            {
                itemsAvailable.Add($"{item.Amount}x {item.Name}");
            }
            itemsAvailable.Add("Back");
            return itemsAvailable;
        }
    }
}