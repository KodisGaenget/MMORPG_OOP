using System;

namespace Characters
{
    public class Enemy : Character
    {
        public int LootID { get; set; }
        public int expValue { get; set; }

        public override int Attack()
        {
            return 0;
        }
    }
}
