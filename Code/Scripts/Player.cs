using Assets.Scripts.Buildings;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class Player : MonoBehaviour //Player mane class
    {
        public bool AutoHire;
        public bool AI; //determines if the current player is controlled by AI or not
        public static bool end; //static parameter to trake if game ended or not
        public static int turnCount; //static parameter to count turns
        public int money; //player money
        public int people; //player people
        public TownHall hall;
        public Houses houses;
        public Barrack barracks;
        public Church church;
        public Walls walls;
        public ArmyScript army;
        public CrusadeArmy crusade;
        public Player Enemy1;
        public Player Enemy2;
        public Player Enemy3;
        public InterfaceController ui;
        public TurnsController controller;


        // Start is called before the first frame update
        public Player()
        {
            money = 500;
            people = 100;
        }

        public void EndTurn() //Calculation of money and people income at the end of turn
        {
            money += people * hall.tax / 100;
            if (people + houses.peopleBonus <= houses.populationLimit)
            {
                people += houses.peopleBonus;
            }
            else
            {
                people = houses.populationLimit;
            }            
            if (!AI)
            {
                turnCount += 1;
                controller.turn += 1;
                if (AutoHire)
                {
                    for (int i=0;i<5;i++)
                    {
                        army.HireRookie();
                        army.HireShooter();
                        army.HireInfantry();
                        army.HireCavalry();
                    }
                }
                ui.showInfoPlayer();
            }
        }

        public void AutoHireChange()
        {
            AutoHire = !AutoHire;
        }

        void Start()
        {
            end = false;
            turnCount = 1;
            money = 500;
            people = 100;
            if (!AI)
            {
                AutoHire = true;
                ui.showInfoPlayer();
                ui.showInfoBuilding(hall);
            }
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}