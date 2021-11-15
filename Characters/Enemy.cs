using System;

namespace Characters
{
    public abstract class Enemy
    {
        public int BaseDamage { get; }

        public abstract int Attack();
    }

}
