using System;
using GameInterfaces;

namespace Characters
{
    public class Player : Character
    {
        public Inventory Inventory { get; private set; }

        public int CurrentExp { get; private set; }
        public string Class { get; private set; }

        public bool inDb = false;

        public Player(IClass charClass)
        {
            Inventory = new();
            Class = charClass.Name;
        }

        public Player()
        {
            Inventory = new();
            inDb = true;
        }

        public string UpdateLevel()
        {
            int oldLevel = Level;
            Level level = new();
            Level = level.GetLevel(CurrentExp);
            if (oldLevel < Level)
            {
                return $"You advanved from level {oldLevel} to level {Level}";
            }
            return $"You are level {Level}";
        }

        public void Equip(string slot, int itemId)
        {
            Inventory.RemoveItem(itemId);

            Equipment.EquipItem(slot, itemId);
        }

        public void UnEquip(string slot)
        {
            var oldItem = Equipment.GetEquipment()[slot];
            if (oldItem > 0)
            {
                Inventory.AddItem(oldItem, 1);
            }
            Equipment.UnequipItem(slot, -1);
        }

        public void SetInventory(Inventory inv)
        {
            Inventory = inv;
        }

        public void SetEquipment(Equipment eq)
        {
            Equipment = eq;
        }

        public void GainExp(int amount)
        {
            CurrentExp += amount;
        }

        // public override string ToString()
        // {
        //     return $"Id: {Id}, Name: {Name}, Class: {Class}, Original Hp: {OriginalHealth}, Current Hp: {CurrentHealth}, Power: {Power}, Armor: {Armor}, Damage: {Damage}, Level: {Level}, CurrentExp: {CurrentExp}";
        // }

    }
}


