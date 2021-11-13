namespace GameLib
{
    public class Checker
    {

        internal string GetItemType(string type)
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
    }
}