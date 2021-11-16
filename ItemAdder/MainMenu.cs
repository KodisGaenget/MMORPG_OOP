using System;
using static System.Console;
using GameLib;
using System.Linq;
using System.Collections.Generic;

namespace ItemAdder
{
    class MainMenu : BaseMenu
    {
        BuildItem builditem = new BuildItem();
        public MainMenu(ItemAdder itemAdder) : base(itemAdder)
        {
            // Constructor
        }

        public override void Run()
        {
            string prompt = "Which item would you like to create?";
            List<string> options = new();

            foreach (string type in Enum.GetNames(typeof(ItemType)))
            {
                options.Add(type);
            }

            Menu menu = new Menu(prompt, options);
            int selectedIndex = menu.GetMenuIndex();
            switch (selectedIndex)
            {
                case 0:
                    CreateWeapon();
                    break;

                case 1:
                    // CreateArmor();
                    break;

                case 2:
                    // CreateConsumable();
                    break;
                case 3:
                    // CreateKey();
                    break;
            }
        }

        public void CreateWeapon() // Flytta till egen klass med eller utan andra createfunktioner
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
            for (int i = 0; i < options.Count; i++)
            {
                type = options[i];
            }

            Write($"\nYou chose to create a {type.ToLower()}.");
            Write("\nSet name: ");
            name = ReadLine();

            Write("\nSet price: ");
            price = Convert.ToInt32(ReadLine());

            Write("\nSet minimum damage: ");
            minDmg = Convert.ToInt32(ReadLine());

            Write("\nSet maximum damage: ");
            maxDmg = Convert.ToInt32(ReadLine());

            WriteLine($"{type} created with the following stats: "); // Add details
            builditem.AddWeapon(name, price, "Weapon", "Weapon", minDmg, maxDmg, type, 1);
            WriteLine("Weapon added. Press any key to return to the menu...");
            ReadKey();
            Run();
        }
    }
}