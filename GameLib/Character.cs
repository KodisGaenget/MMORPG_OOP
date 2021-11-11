using System;

namespace GameLib
{
    public abstract class Character
    {
        public string Name { get; init; }
        public int OrignalHealth { get; init; }
        public int CurrentHealth { get; init; }
        public int Power { get; init; }
        public int Armor { get; }
        public int Damage { get; }
        public int Level { get; }

        public abstract int Attack();

    }

}
