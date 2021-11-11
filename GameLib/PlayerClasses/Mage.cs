using System;
using System.Collections.Generic;

namespace GameLib
{
    public class Mage : IClass
    {
        public int health => 100;
        public string Name => "Mage";

        private List<Spell> learnedSpells = new();

        public int Block(int i)
        {
            throw new NotImplementedException();
        }

        public int MainAbility()
        {
            throw new NotImplementedException();
        }

        public int SecondaryAbility()
        {
            throw new NotImplementedException();
        }
    }
}
