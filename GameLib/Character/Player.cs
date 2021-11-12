using System;
using System.Collections.Generic;

namespace GameLib
{
    public class Player : Character
    {
        Inventory inventory;
        private List<Item> equipped = new();
        public int CurrentExp { get; private set; }
        public string CharClass { get; private set; }

        IClass charClass;
        internal bool inDb = false;

        public Player(IClass charClass)
        {
            inventory = new();
            this.charClass = charClass;
            CharClass = charClass.Name;
        }

        private Player()
        {
            inDb = true;
        }

        public override int Attack()
        {
            throw new NotImplementedException();
        }

        public void Equip(Item item)
        {
            inventory.RemoveFromItem(item);
            equipped.Add(item);
        }
        public void UnEquip(Item item)
        {
            equipped.Remove(item);
            //inventory.AddItemToInventory(item);
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

        public void ChangePosition(int newPos)
        {
            Position = newPos;
        }

        public void SaveCharacter(Database db)
        {
            db.SavePlayer(this);
            inventory.SaveInventory(this, db);
        }

        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, Original Hp: {OriginalHealth}, Current Hp: {CurrentHealth}, Power: {Power}, Armor: {Armor}, Damage: {Damage}, Level: {Level}, CurrentExp: {CurrentExp}";
        }
    }
}
