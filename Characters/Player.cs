using System;
using System.Collections.Generic;
using GameInterfaces;
using PlayerClasses;

namespace Characters
{
    public class Player : Character
    {
        public Inventory Inventory { get; private set; }
        public Equipment Equipment { get; private set; }
        public int CurrentExp { get; private set; }
        public string Class { get; private set; }
        IClass charClass;
        public bool inDb = false;

        public Player(IClass charClass)
        {
            Inventory = new();
            this.charClass = charClass;
            Class = charClass.Name;
        }

        public Player()
        {
            charClass = CheckAndFind.GetClass(Class);
            Inventory = new();
            inDb = true;
        }

        public override int Attack()
        {
            // charClass.MainAbility(); //TODO Create method for MainAbility in Player
            // charClass.SecondaryAbility(); //TODO Create method fot SecondAbility in Player.
            return Damage;
        }

        public override int Block()
        {
            //TODO Somehow return a blockprocentage
            throw new NotImplementedException();
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


        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, Class: {Class}, Original Hp: {OriginalHealth}, Current Hp: {CurrentHealth}, Power: {Power}, Armor: {Armor}, Damage: {Damage}, Level: {Level}, CurrentExp: {CurrentExp}";
        }

    }
}


