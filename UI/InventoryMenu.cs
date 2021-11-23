using GameLib;
using Items;
using System;
using System.Collections.Generic;

namespace UI
{
    class InventoryMenu
    {
        List<InventoryInfo> inventory;
        int selectedIndex;
        Game game;

        public InventoryMenu(List<InventoryInfo> _inventory, Game _game)
        {
            inventory = _inventory;
            selectedIndex = 0;
            game = _game;
        }

        public void Run()
        {
            ConsoleKeyInfo keyPressed;
            do
            {
                Console.Clear();
                DisplayInventory();
                keyPressed = Console.ReadKey(true);

                if (keyPressed.Key == ConsoleKey.DownArrow)
                {
                    selectedIndex++;
                    if (selectedIndex == inventory.Count)
                    {
                        selectedIndex = 0;
                    }
                }

                if (keyPressed.Key == ConsoleKey.UpArrow)
                {
                    selectedIndex--;
                    if (selectedIndex == -1)
                    {
                        selectedIndex = inventory.Count - 1;
                    }
                }


            } while (keyPressed.Key != ConsoleKey.Enter && keyPressed.Key != ConsoleKey.Escape);

            if (keyPressed.Key == ConsoleKey.Enter)
            {
                if (inventory.Count != 0)
                {
                    UseItem();
                }

            }
        }


        private void DisplayInventory()
        {
            ConsoleUtils.ChangeColor("Write", "\u25a3", ConsoleColor.Yellow);
            Console.Write(" Inventory (press Enter to use/equip. Press Escape to go back.)\n\n");
            for (int i = 0; i < inventory.Count; i++)
            {

                string inventoryItem = inventory[i].Name;
                int itemAmount = inventory[i].Amount;
                string prefix;

                if (i == selectedIndex)
                {
                    prefix = ">";
                }
                else
                {
                    prefix = " ";
                }
                Console.WriteLine($"{prefix} {itemAmount}x {inventoryItem}");
            }
        }

        private void UseItem()
        {
            game.ConsumeItem(inventory[selectedIndex].Id);
        }
    }
}