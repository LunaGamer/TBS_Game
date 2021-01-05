using UnityEngine;
using Assets.Scripts.Army;
using Assets.Scripts.Buildings;

namespace Assets.Scripts
{
    public class ArmyScript : MonoBehaviour //class for Army in castle (hiring units)
    {
        public Player player;
        public Barrack barracks;
        public Church church;
        public Walls walls;
        public InterfaceController ui;
        public int rookie; //number of rookies
        public int shooter; //number of shooter
        public int maxShooter; //shooters limit for hiring on one turn
        public int infantry; //number of infantry 
        public int maxInfantry; //infantry limit for hiring on one turn
        public int cavalry; //number of cavalry
        public int maxCavalry; //cavalry limit for hiring on one turn
        public Rookie Rookie;
        public Shooter Shooter;
        public Infantry Infantry;
        public Cavalry Cavalry;

        public ArmyScript()
        {
            rookie = 0;
            shooter = 0;
            maxShooter = 1;
            infantry = 0;
            maxInfantry = 0;
            cavalry = 0;
            maxCavalry = 0;
        }

        public void HireRookie() //function to hire rookie
        {
            if (Rookie.Hire(player, 1))
            {
                rookie += 1;
                if (!player.AI)
                {
                    ui.showInfoArmy();
                }
            }

        }
        public void HireShooter() //function to hire shooter
        {
            if (Shooter.Hire(player, maxShooter))
            {
                shooter += 1;
                maxShooter -= 1;
                if (!player.AI)
                {
                    ui.showInfoArmy();
                }
            }
        }
        public void HireInfantry() //function to hire infantry
        {
            if (Infantry.Hire(player, maxInfantry))
            {
                infantry += 1;
                maxInfantry -= 1;
                if (!player.AI)
                {
                    ui.showInfoArmy();
                }
            }
        }

        public void HireCavalry() //function to hire cavalry
        {
            if (Cavalry.Hire(player, maxCavalry))
            {
                cavalry += 1;
                maxCavalry -= 1;
                if (!player.AI)
                {
                    ui.showInfoArmy();
                }
            }
        }

        public void EndTurn() //function to reset limits at the end of the turn
        {
            maxShooter = barracks.shooterHire;
            maxInfantry = barracks.infantryHire;
            maxCavalry = barracks.cavalryHire;
            if (!player.AI)
            {
                ui.showInfoArmy();
            }
        }

        public int GetSoldierMax(int type) //function getting max available soldiers of certain type
        {
            return type switch
            {
                1 => rookie,
                2 => shooter,
                3 => infantry,
                4 => cavalry,
                _ => 0,
            };
        }


        // Start is called before the first frame update
        void Start()
        {
            rookie = 0;
            shooter = 0;
            maxShooter = 1;
            infantry = 0;
            maxInfantry = 0;
            cavalry = 0;
            maxCavalry = 0;
            if (!player.AI)
            {
                ui.showInfoArmy();
            }
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}