using System.Collections.Generic;

namespace GameLib
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

        // internal static KeyValuePair<string, int> FindItem(int searchedItem, string searchedSlot, IReadOnlyDictionary<string, int> items)
        // {
        //     KeyValuePair<string, int> founded = new();

        //     foreach (KeyValuePair<string, int> item in items)
        //     {
        //         if (item.Key == searchedSlot)
        //         {
        //             founded = item;
        //         }
        //         if (item.Value == searchedItem)
        //         {
        //             founded = item;
        //         }
        //     }
        //     return founded;
        // }
    }
}