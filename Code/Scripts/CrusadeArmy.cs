using System;
using UnityEngine;

namespace Assets.Scripts
{
    public class CrusadeArmy : MonoBehaviour //class for crusade army (attack squad composition, movement on the map)
    {
        public int rookie; //number of rookies in crusade squad
        public int shooter; //number of shooters in crusade squad
        public int infantry; //number of infantry in crusade squad
        public int cavalry; //number of cavalry in crusade squad
        public int moveSpeed; //movespeed, minimal value in the group
        public int movePoints; //movespeed*GS - max distance on the map in one turn
        public bool Crusade; //bool parameter, true - crusade is started
        public Player player;
        public Battle battle;
        public ArmyScript Army;
        public InterfaceController ui;
        public GameObject CrusadeSquad;
        public Vector3 startPosition; //position of the castle


        public CrusadeArmy()
        {
            Crusade = false;
            rookie = 0;
            shooter = 0;
            infantry = 0;
            cavalry = 0;
        }

        public void ConfirmCrusade(int r, int s, int i, int c) //function to start crusade
        {
            if (r != 0 || s != 0 || i != 0 || c != 0)
            {
                rookie = r;
                shooter = s;
                infantry = i;
                cavalry = c;
                Army.rookie -= rookie;
                Army.shooter -= shooter;
                Army.infantry -= infantry;
                Army.cavalry -= cavalry;
                if (rookie != 0)
                {
                    moveSpeed = 1;
                }
                else if (infantry != 0)
                {
                    moveSpeed = 1;
                }
                else if (shooter != 0)
                {
                    moveSpeed = 3;
                }
                else if (cavalry != 0)
                {
                    moveSpeed = 3;
                }
                Crusade = true;
                movePoints = moveSpeed;
                CrusadeSquad.SetActive(true);
                if (!player.AI)
                {
                    ui.showInfoArmy();
                    ui.showInfoCrusade();
                }
            }
        }

        public void EndCrusade() //function to end crusade
        {
            if (Crusade && CrusadeSquad.transform.localPosition == startPosition)
            {
                Army.rookie += rookie;
                Army.shooter += shooter;
                Army.infantry += infantry;
                Army.cavalry += cavalry;
                rookie = 0;
                shooter = 0;
                infantry = 0;
                cavalry = 0;
                Crusade = false;
                CrusadeSquad.SetActive(false);
                if (!player.AI)
                {
                    ui.CrusadeEnd();
                }
            }
        }

        public void moveSquad(Vector3 point) //function to move crusadeSquad on the map
        {
            if (!Player.end)
            {
                Vector3 current = new Vector3(CrusadeSquad.transform.localPosition.x, CrusadeSquad.transform.localPosition.y, CrusadeSquad.transform.localPosition.z);
                if ((Math.Abs(current.x - point.x) + Math.Abs(current.y - point.y))
                    <= movePoints)
                {
                    CrusadeSquad.transform.localPosition = point;
                    movePoints -= (int)(Math.Abs(current.x - point.x) + Math.Abs(current.y - point.y));                    
                    if (player.Enemy1.crusade.CrusadeSquad.activeSelf && CrusadeSquad.transform.localPosition == player.Enemy1.crusade.CrusadeSquad.transform.localPosition)
                    {
                        battle.BattleCalculation(player, player.Enemy1, this, player.Enemy1.crusade); //battle enemy crusade squad
                    }
                    else if (CrusadeSquad.transform.localPosition.x == player.Enemy1.gameObject.transform.localPosition.x
                        && CrusadeSquad.transform.localPosition.y == player.Enemy1.gameObject.transform.localPosition.y)
                    {
                        battle.BattleCalculation(player, player.Enemy1, this, player.Enemy1.army); //attack on enemy castle
                    }
                    if (player.Enemy2.crusade.CrusadeSquad.activeSelf && CrusadeSquad.transform.localPosition == player.Enemy2.crusade.CrusadeSquad.transform.localPosition)
                    {
                        battle.BattleCalculation(player, player.Enemy2, this, player.Enemy2.crusade);
                    }
                    else if (CrusadeSquad.transform.localPosition.x == player.Enemy2.gameObject.transform.localPosition.x
                        && CrusadeSquad.transform.localPosition.y == player.Enemy2.gameObject.transform.localPosition.y)
                    {
                        battle.BattleCalculation(player, player.Enemy2, this, player.Enemy2.army);
                    }
                    if (player.Enemy3.crusade.CrusadeSquad.activeSelf && CrusadeSquad.transform.localPosition == player.Enemy3.crusade.CrusadeSquad.transform.localPosition)
                    {
                        battle.BattleCalculation(player, player.Enemy3, this, player.Enemy3.crusade);
                    }
                    else if (CrusadeSquad.transform.localPosition.x == player.Enemy3.gameObject.transform.localPosition.x
                        && CrusadeSquad.transform.localPosition.y == player.Enemy3.gameObject.transform.localPosition.y)
                    {
                        battle.BattleCalculation(player, player.Enemy3, this, player.Enemy3.army);
                    }
                }
                if (!player.AI)
                {
                    ui.showInfoCrusade();
                }
            }
        }

        public void EndTurn() //reser movepoints at the end of the turn
        {
            if (Crusade)
            {
                movePoints = moveSpeed;
                if (!player.AI)
                {
                    ui.showInfoCrusade();
                }
            }
        }


        // Start is called before the first frame update
        void Start()
        {
            Crusade = false;
            rookie = 0;
            shooter = 0;
            infantry = 0;
            cavalry = 0;
            startPosition = CrusadeSquad.transform.localPosition;
            CrusadeSquad.SetActive(false);
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}