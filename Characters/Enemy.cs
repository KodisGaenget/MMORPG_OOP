using System;

namespace Characters
{
    public class Enemy : Character
    {
        public int expValue { get; set; }

        public override int Attack()
        {
            return Damage;
        }

        public override int Block()
        {
            //TODO Somehome return a blockprocentage.
            throw new NotImplementedException();
        }
    }
}
