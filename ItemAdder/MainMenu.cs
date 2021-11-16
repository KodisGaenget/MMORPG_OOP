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
                    ItemAdder.CreateArmor.Run();
                    break;

                case 1:
                    // Consumable
                    break;

                case 2:
                    // Key
                    break;
                case 3:
                    ItemAdder.CreateWeapon.Run();
                    break;
            }
        }
    }
}