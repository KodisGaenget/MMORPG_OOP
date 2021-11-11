using System;

namespace GameLib
{
    public abstract class Character
    {
        public int Id { get; init; }
        public string Name { get; init; }
        public int OriginalHealth { get; protected set; }
        public int CurrentHealth { get; protected set; }
        public int Power { get; protected set; }
        public int Armor { get; protected set; }
        public int Damage { get; protected set; }
        public int Level { get; protected set; }
        public int Position { get; protected set; }

        public abstract int Attack();

    }

}
