using UnityEngine;

namespace Assets.Scripts.Base
{
    public class Soldier : MonoBehaviour //basic class for every soldier unit
    {
        public bool AI;
        public string soldierName;
        public int Attack;
        public int Defence;
        public int Speed;
        public int GS;
        public int Cost;
        public InterfaceController ui;

        public bool Hire(Player player, int limit) //Hire unit funtion
        {
            if (player.money >= Cost && limit > 0)
            {
                player.money -= Cost;
                if (!player.AI)
                {
                    ui.showInfoPlayer();
                }
                return true;
            }
            else
            {
                return false;
            }
        }

       
        public void OnMouseDown() //onclick function to show info about current soldier unit in UI
        {
            if (!AI)
            {
                ui.showInfoSoldier(this);
            }
        }

        public int AttackCalculation(int count, int bonus) //calculate attack of number of units with bonus from buildings
        {
            if (count <= 0)
            {
                return 0;
            }
            return count * (Attack + bonus);
        }

        public int DefenceCalculation(int count, int bonus) //calculate defence of number of units with bonus from buildings
        {
            if (count <= 0)
            {
                return 0;
            }
            return count * (Defence + bonus);
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}