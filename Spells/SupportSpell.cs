using System;

namespace Spells
{
    public class SupportSpell : Spell
    {
        public int NumberOfRounds { get; init; }
        public int BuffValue { get; init; }

        public SupportSpell(int id, string name, int numberOfRounds, int buffValue)
        {
            Id = id;
            Name = name;
            NumberOfRounds = numberOfRounds;
            BuffValue = buffValue;
        }


    }
}
