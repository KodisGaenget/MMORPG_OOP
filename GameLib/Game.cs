using System.Collections.Generic;
using Characters;
using DataManager;
using GameEnums;

namespace GameLib
{
    public class Game
    {
        public RoomHandler roomHandler;
        public CombatHandler combatHandler;
        Database db = new();
        public Player player;
        public Spawner spawner;
        PlayerLoader playerLoader;
        public ItemLoader itemLoader;


        public Game(int id)
        {
            this.roomHandler = new();
            playerLoader = new(db);
            itemLoader = new(db);
            spawner = new(db);
            SetChoosenPlayer(id);
        }

        #region PlayerMethods
        public void SavePlayer()
        {
            PlayerSaver playerSaver = new(db, player);
        }

        public void SetChoosenPlayer(int id)
        {
            player = playerLoader.GetPlayer(id);
        }

        public int GetDefense(Player player)
        {
            int FightDefence = player.Armor;
            foreach (var item in player.Equipment.GetEquipment())
            {
                if (itemLoader.GetItemType(item.Value) == "Armor")
                {
                    FightDefence += GetPlayerDef(item.Value);
                }
            }
            return FightDefence;
        }

        private int GetPlayerDef(int itemId)
        {
            foreach (var item in itemLoader.armorList)
            {
                if (item.Id == itemId)
                {
                    return item.Defense;
                }
            }
            return 0;
        }

        public Dictionary<string, int> GetAtkPower(Player player)
        {

            foreach (var item in player.Equipment.GetEquipment())
            {
                if (item.Key == "Weapon")
                {
                    return new(GetPlayerAtk(item.Value));
                }
            }
            return new();
        }

        private Dictionary<string, int> GetPlayerAtk(int itemId)
        {
            Dictionary<string, int> FightAtk = new();
            foreach (var item in itemLoader.weaponList)
            {
                if (item.Id == itemId)
                {
                    FightAtk.Add("Min", item.MinDamage);
                    FightAtk.Add("Max", item.MaxDamage);
                }
            }
            return FightAtk;
        }

        #endregion

        #region ItemMethods
        private KeyValuePair<int, int> FindItemInInventory(int id)
        {
            foreach (var item in player.Inventory.GetInventory())
            {
                if (id == item.Key)
                {
                    return item;
                }
            }
            return new();
        }

        private bool ConsumeItem(KeyValuePair<int, int> item)
        {
            foreach (var consumable in itemLoader.consumableList)
            {
                if (item.Key == consumable.Id)
                {
                    if (consumable.ConsumableType == ConsumableType.HealthPotion)
                    {
                        player.ChangeHealth(consumable.AmountToRestore);
                        player.Inventory.RemoveItem(item.Key, 1);
                        return true;
                    }
                }
            }
            return false;
        }
        #endregion

    }
}