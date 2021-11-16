using System;
using static System.Console;
using GameLib;

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
            string[] options = { "Weapon", "Armor", "Consumable", "Key", "Exit" };
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
            string name, minDmg, price, maxDmg, type = "";
            string prompt = "Choose weapon type:";
            string[] options = { "Dagger", "Throwing Star\n", "Spellbook", "Staff\n", "Warhammer", "Double Edged Axe\n", "Exit" };            
            Menu menu = new Menu(prompt, options);
            int selectedIndex = menu.GetMenuIndex();
            switch (selectedIndex)
            {
                case 0:
                    type = options[0];
                    break;

                case 1:
                    type = options[1];
                    break;

                case 2:
                    type = options[2];
                    break;

                case 3:
                     type = options[3];
                    break;

                case 4:
                    type = options[4];
                    break;

                case 5:
                     type = options[5];
                    break;

                case 6:
                    type = options[6];
                    break;
            }

            Write($"\nYou chose to create a {type.ToLower()}.");
            Write("\nSet name: ");
            name = ReadLine();

            Write("\nSet price: ");
            price = ReadLine();

            Write("\nSet minimum damage: ");
            minDmg = ReadLine();

            Write("\nSet maximum damage: ");
            maxDmg = ReadLine();

            WriteLine($"{type} created with the following stats: "); // Add details
            // builditem.AddWeapon(name, price, minDmg, maxDmg);
        }
    }
}