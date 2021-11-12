using System;
using System.Collections.Generic;

namespace GameLib
{
    public class Player : Character
    {
        public Inventory Inventory { get; private set; }
        public Equipped Equipped { get; private set; }
        public int CurrentExp { get; private set; }
        public string CharClass { get; private set; }

        IClass charClass;
        //IDataManager dataManager;
        internal bool inDb = false;

        public Player(IClass charClass)
        {
            Inventory = new();
            Equipped = new();
            this.charClass = charClass;
            CharClass = charClass.Name;
        }

        public Player()
        {
            inDb = true;
        }

        public override int Attack()
        {
            throw new NotImplementedException();
        }

        public void Equip(Item item)
        {
            // Inventory.RemoveFromItem(item);
            Equipped.SetSlot(item);
        }
        public void UnEquip(Item item)
        {
            //Equipped.Remove(item);
            //inventory.AddItemToInventory(item);
        }
        internal void SetInventory(Inventory inv)
        {
            Inventory = inv;
        }


        // public void Load()
        // {
        //     dataManager.Load(db);
        // }

        // public void Save(Database database)
        // {
        //     //dataManager.Save();
        // }


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

        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, Original Hp: {OriginalHealth}, Current Hp: {CurrentHealth}, Power: {Power}, Armor: {Armor}, Damage: {Damage}, Level: {Level}, CurrentExp: {CurrentExp}";
        }
    }
}


