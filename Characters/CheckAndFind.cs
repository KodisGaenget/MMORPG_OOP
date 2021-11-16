using System.Collections.Generic;
using GameInterfaces;
using PlayerClasses;

namespace Characters
{
    internal static class CheckAndFind
    {

        internal static string GetItemType(string type)
        {
            if (type == "Helmet" || type == "Chest" || type == "Gloves" || type == "Legs" || type == "Boots" || type == "Armor")
            {
                return "Armor";
            }
            if (type == "Weapon")
            {
                return "Weapon";
            }
            return "Empty";
        }

        internal static KeyValuePair<int, int> FindItem(int searched, IReadOnlyDictionary<int, int> items)
        {
            KeyValuePair<int, int> founded = new();

            foreach (KeyValuePair<int, int> item in items)
            {
                if (item.Key == searched)
                {
                    founded = item;
                }
            }
            return founded;
        }

        public static IClass GetClass(string classToFind)
        {
            if (classToFind == "Mage")
            {
                return new Mage();
            }
            else if (classToFind == "Rogue")
            {
                return new Rogue();
            }
            else if (classToFind == "Warrior")
            {
                return new Warrior();
            }
            return null;
        }


    }
}