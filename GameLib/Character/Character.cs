using System;

namespace GameLib
{
    public abstract class Character
    {
        public int Id { get; init; }
        public string Name { get; init; }
        public int OriginalHealth { get; init; }
        public int CurrentHealth { get; init; }
        public int Power { get; init; }
        public int Armor { get; internal set; }
        public int Damage { get; internal set; }
        public int Level { get; internal set; }

        public abstract int Attack();

    }

}
