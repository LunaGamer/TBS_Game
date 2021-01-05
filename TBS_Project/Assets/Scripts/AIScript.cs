using Assets.Scripts.Army;
using Assets.Scripts.Buildings;
using UnityEngine;

namespace Assets.Scripts
{
    public class AIScript : MonoBehaviour //class for AI actions
    {
        public bool behaviour; //AI behaviour type parameter
        public int ActiveTurn; //AI turn number
        int rnd;
        public Vector3 attackPoint;
        public TurnsController controller;
        public Player player;
        public ArmyScript army;
        public CrusadeArmy crusade;
        public TownHall townhall;
        public Houses houses;
        public Barrack barracks;
        public Church church;
        public Walls walls;
        public Rookie Rookie;
        public Shooter Shooter;
        public Infantry Infantry;
        public Cavalry Cavalry;

        void MakeTurn() //AI script to make actions on it's turn
        {
            if (Player.turnCount == 1)
            {
                houses.lvlUp();
                townhall.lvlUp();
            }
            if (behaviour) //if this AI is "builder" type
            {
                if (Player.turnCount % Random.Range(3,7) == 0 && player.money > 500)
                {
                    houses.lvlUp();
                    townhall.lvlUp();
                }
                if (Player.turnCount % Random.Range(7, 9) == 0)
                {
                    walls.lvlUp();
                    barracks.lvlUp();
                    for (int i = 0; i < 50; i++)
                    {
                        army.HireCavalry();
                        army.HireInfantry();
                        army.HireShooter();
                        army.HireRookie();
                    }
                }
                if (Player.turnCount%Random.Range(20,30) == 0)
                {
                    crusade.ConfirmCrusade(army.rookie/2, army.shooter/2, army.infantry/2, army.cavalry/2);
                    rnd = Random.Range(0, 100);
                }
            }
            else //if this AI is "aggressive" type
            {
                if (player.money > 300)
                {
                    barracks.lvlUp();
                    for (int i = 0; i < 20; i++)
                    {
                        army.HireCavalry();
                        army.HireInfantry();
                        army.HireShooter();
                        army.HireRookie();
                    }
                }
                if (Player.turnCount%Random.Range(5,9) == 0)
                {
                    townhall.lvlUp();
                    houses.lvlUp();
                    if (!crusade.Crusade)
                    {
                        crusade.ConfirmCrusade(army.rookie, army.shooter, army.infantry, army.cavalry);
                        rnd = Random.Range(0, 100);
                    }
                }                
            }
            if (crusade.Crusade)
            {
                if (rnd <= 33 && player.Enemy1.gameObject.activeSelf)
                {
                    attackPoint = player.Enemy1.crusade.CrusadeSquad.transform.localPosition;
                }
                else if (rnd > 33 && rnd <= 66 && player.Enemy2.gameObject.activeSelf)
                {
                    attackPoint = player.Enemy2.crusade.CrusadeSquad.transform.localPosition;
                }
                else if (rnd > 66 && rnd <= 100 && player.Enemy3.gameObject.activeSelf)
                {
                    attackPoint = player.Enemy3.crusade.CrusadeSquad.transform.localPosition;
                }
                else if (player.Enemy1.gameObject.activeSelf)
                {
                    attackPoint = player.Enemy1.crusade.CrusadeSquad.transform.localPosition;
                }
                else if (player.Enemy2.gameObject.activeSelf)
                {
                    attackPoint = player.Enemy2.crusade.CrusadeSquad.transform.localPosition;
                }
                else if (player.Enemy3.gameObject.activeSelf)
                {
                    attackPoint = player.Enemy3.crusade.CrusadeSquad.transform.localPosition;
                }
                MoveToAttack(attackPoint);
            }
            player.EndTurn();
            army.EndTurn();
            crusade.EndTurn();
        }

        void MoveToAttack(Vector3 point) //Function to move Army towards target
        {
            while (crusade.movePoints > 0)
            {
                int points = crusade.movePoints;
                crusade.moveSquad(point);
                if (crusade.movePoints == points)
                {
                    if (crusade.CrusadeSquad.transform.localPosition.x > point.x)
                    {
                        Vector3 newPoint = new Vector3(crusade.CrusadeSquad.transform.localPosition.x - 1,
                            crusade.CrusadeSquad.transform.localPosition.y,
                            crusade.CrusadeSquad.transform.localPosition.z);
                        crusade.moveSquad(newPoint);
                    }
                    else if (crusade.CrusadeSquad.transform.localPosition.x < point.x)
                    {
                        Vector3 newPoint = new Vector3(crusade.CrusadeSquad.transform.localPosition.x + 1,
                            crusade.CrusadeSquad.transform.localPosition.y,
                            crusade.CrusadeSquad.transform.localPosition.z);
                        crusade.moveSquad(newPoint);
                    }
                    else if (crusade.CrusadeSquad.transform.localPosition.y > point.y)
                    {
                        Vector3 newPoint = new Vector3(crusade.CrusadeSquad.transform.localPosition.x,
                            crusade.CrusadeSquad.transform.localPosition.y - 1,
                            crusade.CrusadeSquad.transform.localPosition.z);
                        crusade.moveSquad(newPoint);
                    }
                    else if (crusade.CrusadeSquad.transform.localPosition.y < point.y)
                    {
                        Vector3 newPoint = new Vector3(crusade.CrusadeSquad.transform.localPosition.x,
                            crusade.CrusadeSquad.transform.localPosition.y + 1,
                            crusade.CrusadeSquad.transform.localPosition.z);
                        crusade.moveSquad(newPoint);
                    }
                }
            }
        }
        // Start is called before the first frame update
        void Start()
        {
            int rnd = Random.Range(0, 100);
            if (rnd < 30) //Randomize AI behaviour type at the begining of the game
            {
                behaviour = false;
            }
        }

        // Update is called once per frame
        void Update()
        {
            if (controller.turn == ActiveTurn && !Player.end) 
            {
                MakeTurn(); //AI turn
                controller.turn += 1; //update turn controller parameter
            }
        }
    }
}