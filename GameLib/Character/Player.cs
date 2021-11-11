using System;
using System.Collections.Generic;

namespace GameLib
{
    public class Player : Character
    {
        private List<Item> inventory = new();
        private List<Item> equipped = new();
        public int CurrentExp { get; }
        IClass charClass;

        public Player(IClass charClass)
        {
            this.charClass = charClass;
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

    }
}
