using Characters;
using Combat;

namespace DataManager
{
    public class CombatHandler
    {
        CombatSystem combat;
        public string combatLog = "";
        public string result = "";
        public int playerHealth = 0;
        public int enemyHealth = 0;
        public bool combatOver = false;
        public bool playersTurn;

        public CombatHandler()
        {

        }

        public bool StartNewCombat(Player player, Player enemy, ItemLoader itemLoader)
        {
            combat = new(player, enemy, itemLoader);
            bool playersTurn = combat.Run();
            UpdateCombatStatus();
            if (!playersTurn && combat.fighter2.CurrentHealth! <= 0)
            {
                ContinueCombat();
            }
            return true;
        }

        public void UpdateCombatStatus()
        {
            playerHealth = combat.fighter1.CurrentHealth;
            enemyHealth = combat.fighter2.CurrentHealth;
            combatLog = combat.combatLog;
            result = combat.endingMessage;
            combatOver = combat.combatOver;
        }

        public bool ContinueCombat()
        {
            playersTurn = combat.Run();
            UpdateCombatStatus();
            if (!playersTurn)
            {
                ContinueCombat();
                UpdateCombatStatus();
            }
            if (combat.fighter2.CurrentHealth! <= 0)
            {
                return true;
            }
            else if (combat.fighter1.CurrentHealth! <= 0)
            {
                return false;
            }
            return true;
        }
    }
}