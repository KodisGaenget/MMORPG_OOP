using System;
using Characters;
using GameInterfaces;
using DataManager;
using Items;
using GameEnums;

namespace Combat
{
    public class Turn
    {
        IFightable dealer;
        IFightable taker;
        int rawDmg = 0;
        int resist = 0;

        public Turn(IFightable dealer, IFightable taker, int rawDmg, int resistance)
        {
            this.dealer = dealer;
            this.taker = taker;
            this.rawDmg = rawDmg;
            resist = resistance;
        }

        public string Attack()
        {
            int dealtDmg = 0;
            dealtDmg = CombatResult(rawDmg, resist);
            return $"{dealer.Name} dealt {dealtDmg} to {taker.Name}.";

        }

        private int CombatResult(int dmg, int resist)
        {
            int realDmg = (dmg * resist);
            taker.ChangeHealth(realDmg);
            return realDmg;
        }



    }
}