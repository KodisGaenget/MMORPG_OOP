using System;
using System.Collections.Generic;

namespace GameLib
{
    public class Player : Character
    {
        Inventory inventory = new();
        private List<Item> equipped = new();
        public int CurrentExp { get; private set; }
        public string CharClass { get; private set; }

        IClass charClass;
        IDataManager dataManager;

        internal bool inDb = false;

        public Player(IClass charClass)
        {
            this.charClass = charClass;
            CharClass = charClass.Name;
            Load();
        }

        public Player()
        {
            inDb = true;
            dataManager = new CharacterLoader();
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


        public void Load()
        {
            //dataManager.Load();
        }

        public void Save(Database database)
        {
            //dataManager.Save();
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

        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, Original Hp: {OriginalHealth}, Current Hp: {CurrentHealth}, Power: {Power}, Armor: {Armor}, Damage: {Damage}, Level: {Level}, CurrentExp: {CurrentExp}";
        }
    }
}


