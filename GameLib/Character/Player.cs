using System;
using System.Collections.Generic;

namespace GameLib
{
    public class Player : Character
    {
        private List<Item> inventory = new();
        private List<Item> equipped = new();
        public int CurrentExp { get; private set; }
        public int Position { get; private set; }
        IClass charClass;

        public Player(IClass charClass)
        {
            this.charClass = charClass;
        }

        private Player()
        {

        }

        public override int Attack()
        {
            throw new NotImplementedException();
        }

        public void Equip()
        {

        }
        public void UnEquip()
        {

        }

        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, Original Hp: {OriginalHealth}, Current Hp: {CurrentHealth}, Power: {Power}, Armor: {Armor}, Damage: {Damage}, Level: {Level}, CurrentExp: {CurrentExp}";
        }

    }
}
