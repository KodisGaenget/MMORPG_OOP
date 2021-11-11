using System;
using System.Collections.Generic;

namespace GameLib
{
    public class Player : Character
    {
        Inventory inventory;
        private List<Item> equipped = new();
        public int CurrentExp { get; private set; }

        IClass charClass;

        public Player(IClass charClass)
        {
            inventory = new();
            this.charClass = charClass;
        }

        private Player() { }

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



        public void ChangeHealth(int value)
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
                System.Console.WriteLine("You are dead!");
            }
        }

        public void ChangePosition(int newPos)
        {
            Position = newPos;
        }

        public void SaveCharacter(Database db)
        {
            db.SavePlayer(this);
        }

        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, Original Hp: {OriginalHealth}, Current Hp: {CurrentHealth}, Power: {Power}, Armor: {Armor}, Damage: {Damage}, Level: {Level}, CurrentExp: {CurrentExp}";
        }
    }
}
