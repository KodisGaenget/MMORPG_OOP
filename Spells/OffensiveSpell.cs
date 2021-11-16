using System;

namespace Spells
{
    public class OffensiveSpell : Spell
    {
        internal int BaseDamage { get; init; }

        public OffensiveSpell(int id, string name, int drainPower, int baseDamage)
        {
            Id = id;
            Name = name;
            DrainPower = drainPower;
            BaseDamage = baseDamage;
        }
    }
}
