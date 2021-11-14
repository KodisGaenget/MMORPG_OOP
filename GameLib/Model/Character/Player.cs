using System;
using System.Collections.Generic;

namespace GameLib
{
    public class Player : Character
    {
        public Inventory Inventory { get; private set; }
        public Equipment Equipment { get; private set; }
        public int CurrentExp { get; private set; }
        public string Class { get; private set; }

        IClass charClass;
        internal bool inDb = false;

        public Player(IClass charClass)
        {
            Inventory = new();
            this.charClass = charClass;
            Class = charClass.Name;
        }

        public Player()
        {
            Inventory = new();
            inDb = true;
        }

        public override int Attack()
        {
            throw new NotImplementedException();
        }

        public int GetDefense(ItemLoader itemLoader)
        {
            int FightDefence = this.Armor;
            foreach (var item in Equipment.GetEquipment())
            {
                if (itemLoader.GetItemType(item.Value) == "Armor")
                {
                    FightDefence += GetArmorDef(item.Value, itemLoader);
                }
            }
            return FightDefence;
        }

        private int GetArmorDef(int itemId, ItemLoader itemLoader)
        {
            foreach (var item in itemLoader.armorList)
            {
                if (item.Id == itemId)
                {
                    return item.Defense;
                }
            }
            return 0;
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
            Equipment.RemoveItem(slot, -1);
        }

        internal void SetInventory(Inventory inv)
        {
            Inventory = inv;
        }

        internal void SetEquipment(Equipment eq)
        {
            Equipment = eq;
        }


        public bool ChangeHealth(int value)
        {
            int newHp = CurrentHealth + value;

            if (newHp >= OriginalHealth)
            {
                CurrentHealth = OriginalHealth;
            }
            else if (newHp < OriginalHealth)
            {
                CurrentHealth = newHp;
            }
            if (CurrentHealth <= 0)
            {
                return true;
            }
            return false;
        }

        internal void ChangePosition(int newPos)
        {
            Position = newPos;
        }

        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, Class: {Class}, Original Hp: {OriginalHealth}, Current Hp: {CurrentHealth}, Power: {Power}, Armor: {Armor}, Damage: {Damage}, Level: {Level}, CurrentExp: {CurrentExp}";
        }

    }
}


