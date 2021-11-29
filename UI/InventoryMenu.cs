using GameLib;
using Items;
using System;
using System.Collections.Generic;
using GameEnums;

namespace UI
{

    class InventoryMenu
    {
        List<InventoryInfo> inventory;
        int selectedIndex;
        Game game;
        // NewBaseType newBaseType;

        public InventoryMenu(List<InventoryInfo> _inventory, Game _game)
        {
            inventory = _inventory;
            selectedIndex = 0;
            game = _game;
        }

        public void Run()
        {
            ConsoleKeyInfo keyPressed;
            bool InvLoop = true;
            while(InvLoop)
            {

            do
            {
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

            if (keyPressed.Key == ConsoleKey.Enter)
            {

                if (inventory.Count != 0)
                {
                    UseItem();
                    Console.Clear();
                }
            }

            } while (keyPressed.Key != ConsoleKey.Enter && keyPressed.Key != ConsoleKey.Escape);

            if(keyPressed.Key == ConsoleKey.Escape)
            {
                InvLoop = false;
                break;
            }
            }
        }
        private void DisplayInventory()
        {
            Console.Clear();
            PlayerInfoBar playerInfoBar = new();
            Console.Write(playerInfoBar.InfoBar(game));
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

                
                // if(game.itemLoader.GetItemDetails(selectedIndex).ItemType == ItemType.Consumable)
                // {
                //                     // Consumable dets
                // Console.Write($"Name: {game.itemLoader.GetConsumableDetails(selectedIndex).Name}\n");
                // Console.Write($"Max stack: {game.itemLoader.GetConsumableDetails(selectedIndex).MaxStack}\n");
                // Console.Write($"Consumable type: {game.itemLoader.GetConsumableDetails(selectedIndex).ConsumableType}\n");
                // Console.Write($"Restore: {game.itemLoader.GetConsumableDetails(selectedIndex).AmountToRestore}\n\n");
                // }

                // Console.Write($"ItemType: {game.itemLoader.GetItemDetails(i).ItemType}");
                // Console.Write($"ItemName: {game.itemLoader.GetItemDetails(i).Name}");

                // // Armor dets
                // Console.WriteLine("Armor:");
                // Console.Write($"Def: {game.itemLoader.GetArmorDetails(i).Defense}\n");
                // Console.Write($"Material: {game.itemLoader.GetArmorDetails(i).Material}\n");
                // Console.Write($"Slot: {game.itemLoader.GetArmorDetails(i).Slot}\n");
                // Console.Write($"ItemType: {game.itemLoader.GetArmorDetails(i).ItemType}\n\n");

                // // Weapon dets
                // Console.WriteLine("Weapon:");
                // Console.Write($"Mindamage: {game.itemLoader.GetWeaponDetails(i).MinDamage}\n");
                // Console.Write($"Maxdamage: {game.itemLoader.GetWeaponDetails(i).MaxDamage}\n");
                // Console.Write($"Name: {game.itemLoader.GetWeaponDetails(i).Name}\n");
            }
        }
        private void UseItem()
        {
            game.ConsumeItem(inventory[selectedIndex].Id);
        }
    }
}