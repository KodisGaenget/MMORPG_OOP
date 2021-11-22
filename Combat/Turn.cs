using GameInterfaces;


namespace Combat
{
    public class Turn
    {
        IFightable dealer;
        IFightable taker;
        int rawDmg = 0;
        float resist = 0;

        public Turn(IFightable dealer, IFightable taker, int rawDmg, float resistance)
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

        private int CombatResult(int dmg, float resist)
        {
            float realDmg = (float)dmg - (dmg * (resist - 1));
            taker.CurrentHealth += -(int)realDmg;
            return (int)realDmg;
        }

        public IFightable GetTaker()
        {
            return taker;
        }



    }
}