using System;

namespace GameLib
{
    public abstract class Enemy
    {
        public int BaseDamage { get; }

        public abstract int Attack();
    }

}
