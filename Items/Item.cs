using GameEnums;

namespace Items
{
    public abstract class Item
    {
        public int Id { get; init; }
        public string Name { get; init; }
        public int Price { get; init; }
        public ItemType ItemType { get; init; } // IF IT'S A CONSUMABLE, ARMOR OR WEAPON
        public int DropChance { get; set; }     //DELETE HERE? GET IT'S OWN CLASS AND TABLE?
        public Slot Slot { get; set; }
    }


}