using System;
using static System.Console;
using GameLib;
using System.Linq;
using System.Collections.Generic;

namespace ItemAdder
{
    class CreateKey : BaseMenu
    {
        BuildItem builditem = new BuildItem();
        public CreateKey(ItemAdder itemAdder) : base(itemAdder)
        {
            // Constructor
        }

        public override void Run()
        {
            Clear();
            string name;
            string prompt = "Key creator";
            List<string> options = new();
            Menu menu = new Menu(prompt, options);
            options.Add("Create new key");
            options.Add("Exit");
            int selectedIndex = menu.GetMenuIndex();
            switch (selectedIndex)
            {
                case 0:
                    Write("\nSet key name: ");
                    name = ReadLine();

                    WriteLine($"Key created with the following name: {name}"); // Add details
                    builditem.AddKey(name, "Key", 1);
                    WriteLine("Key added. Press any key to return to the menu...");
                    ReadKey();
                    ItemAdder.MainMenu.Run();
                    break;

                case 1:
                    ItemAdder.MainMenu.Run();
                    break;
            }
        }
    }
}