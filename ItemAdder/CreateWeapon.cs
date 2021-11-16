using System;
using static System.Console;
using GameLib;
using System.Linq;
using System.Collections.Generic;

namespace ItemAdder
{
    class CreateWeapon : BaseMenu
    {
        BuildItem builditem = new BuildItem();
        public CreateWeapon(ItemAdder itemAdder) : base(itemAdder)
        {
            // Constructor
        }

        public override void Run()
        {
            Clear();
            string name, type = "";
            int minDmg, price, maxDmg;
            string prompt = "Choose weapon type:";

            List<string> options = new();

            foreach (string item in Enum.GetNames(typeof(WeaponType)))
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

            Write("\nSet minimum damage: ");
            minDmg = Convert.ToInt32(ReadLine());

            Write("\nSet maximum damage: ");
            maxDmg = Convert.ToInt32(ReadLine());

            WriteLine($"{type} created with the following stats:\nName: {name}\nPrice: {price}\nMinimum damage: {minDmg}\nMaximum damage: {maxDmg}"); // Add details
            builditem.AddWeapon(name, price, "Weapon", "Weapon", minDmg, maxDmg, type, 1);
            WriteLine("Weapon added. Press any key to return to the menu...");
            ReadKey();
            ItemAdder.MainMenu.Run();
        }
    }
}