using System;

namespace Characters
{
    public class Enemy : Character
    {
        public int expValue { get; set; }

        public void Load(Equipment eq)
        {
            Equipment = eq;
        }
    }
}
