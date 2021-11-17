using System;
using static System.Console;
using DataManager;
using GameEnums;
using System.Collections.Generic;

namespace ItemAdder
{
    class CreateConsumable : BaseMenu
    {
        BuildItem builditem = new BuildItem();
        public CreateConsumable(ItemAdder itemAdder) : base(itemAdder)
        {
            // Constructor
        }

        public override void Run()
        {
            Clear();
            string name, type = "";
            int price, amountToRestore;
            string prompt = "Choose consumable type:";

            List<string> options = new();

            foreach (string item in Enum.GetNames(typeof(ConsumableType)))
            {
                options.Add(item);
            }

            Menu menu = new Menu(prompt, options);
            int selectedIndex = menu.GetMenuIndex();
            type = options[selectedIndex];

            Write($"\nYou chose to create a {type.ToLower()}.");
            Write("\nSet name: ");
            name = ReadLine();

            Write("\nSet price: ");
            price = Convert.ToInt32(ReadLine());

            Write("\nSet amount to restore: ");
            amountToRestore = Convert.ToInt32(ReadLine());

            WriteLine($"{type} created with the following stats:\nName: {name}\nPrice: {price}\nAmount to restore: {amountToRestore}"); // Add details
            builditem.AddConsumable(name, price, "Consumable", amountToRestore, type, 5);
            WriteLine("Consumable added. Press any key to return to the menu...");
            ReadKey();
            ItemAdder.MainMenu.Run();

            // string name, int id, int price, int amountToRestore, ConsumableType consumableType, ItemType itemType
        }
    }
}