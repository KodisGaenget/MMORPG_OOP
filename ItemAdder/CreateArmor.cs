using System;
using static System.Console;
using GameLib;
using System.Linq;
using System.Collections.Generic;

namespace ItemAdder
{
    class CreateArmor : BaseMenu
    {
        BuildItem builditem = new BuildItem();
        public CreateArmor(ItemAdder itemAdder) : base(itemAdder)
        {
            // Constructor
        }

        public override void Run()
        {
            Clear();
            string name;
            int price, def;

            string material = SetArmorType();

            string slot = SetArmorSlot();

            Write($"\nCreating {slot.ToLower()}.");
            Write("\nSet name: ");
            name = ReadLine();

            Write("\nSet price: ");
            price = Convert.ToInt32(ReadLine());

            Write("\nSet defense: ");
            def = Convert.ToInt32(ReadLine());

            WriteLine($"{material} {slot} created with the following stats:\nName: {name}\nPrice: {price}\nDefense rating: {def}"); // Add details
            builditem.AddArmor(name, price, "Armor", slot, def, material, 1);
            WriteLine("Armor added. Press any key to return to the menu...");
            ReadKey();
            ItemAdder.MainMenu.Run();
        }
        private string SetArmorSlot()
        {
            string slot;
            List<string> options = new();

            foreach (string item in Enum.GetNames(typeof(Slot)))
            {
                if (item == "Weapon") { }
                else options.Add(item);
            }

            string prompt = "Choose armor slot:";
            Menu menu1 = new Menu(prompt, options);
            int selectedIndex1 = menu1.GetMenuIndex();
            slot = options[selectedIndex1];

            return slot;
        }

        private string SetArmorType()
        {
            string material;
            List<string> options = new();

            foreach (string item in Enum.GetNames(typeof(ArmorType)))
            {
                options.Add(item);
            }

            string prompt = "Choose armor type:";
            Menu menu = new Menu(prompt, options);
            int selectedIndex = menu.GetMenuIndex();
            material = options[selectedIndex];

            return material;
        }
    }
}