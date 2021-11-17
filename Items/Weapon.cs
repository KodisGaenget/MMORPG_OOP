using GameEnums;

namespace Items
{
    public class Weapon : Item
    {
        public int MinDamage { get; set; }
        public int MaxDamage { get; set; }
        public WeaponType WeaponType { get; set; }

        public Weapon(string name, int id, int price, int minDamage, int maxDamage, WeaponType type, Slot slot, ItemType itemType)
        {
            Name = name;
            Id = id;
            Price = price;
            MinDamage = minDamage;
            MaxDamage = maxDamage;
            WeaponType = type;
            ItemType = itemType;
        }

        public Weapon()
        {
            //Needed to load from database.
        }
    }


}
