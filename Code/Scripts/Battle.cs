using Assets.Scripts.Army;
using UnityEngine;

namespace Assets.Scripts
{
    public class Battle : MonoBehaviour //class for calculating battle between crusade armies and attack on castle
    {
        public Rookie Rookie;
        public Shooter Shooter;
        public Infantry Infantry;
        public Cavalry Cavalry;
        public TurnsController turns;
        public int[] Attack1;
        public int[] Attack2;
        public int[] Defence1;
        public int[] Defence2;

        public void BattleCalculation(Player player1, Player player2, CrusadeArmy crusade1, ArmyScript army2) //Attack on castle calculation
        {
            while ((crusade1.rookie > 0 || crusade1.shooter > 0 || crusade1.infantry > 0 || crusade1.cavalry > 0) &&
                (army2.rookie > 0 || army2.shooter > 0 || army2.infantry > 0 || army2.cavalry > 0))
            {
                Attack1[0] = Cavalry.AttackCalculation(crusade1.cavalry, player1.church.crusadeAttack);
                Attack1[1] = Shooter.AttackCalculation(crusade1.shooter, player1.church.crusadeAttack);
                Attack1[2] = Infantry.AttackCalculation(crusade1.infantry, player1.church.crusadeAttack);
                Attack1[3] = Rookie.AttackCalculation(crusade1.rookie, player1.church.crusadeAttack);
                Attack2[0] = Cavalry.AttackCalculation(army2.cavalry, player2.church.castleAttack);
                Attack2[1] = Shooter.AttackCalculation(army2.shooter, player2.church.castleAttack);
                Attack2[2] = Infantry.AttackCalculation(army2.infantry, player2.church.castleAttack);
                Attack2[3] = Rookie.AttackCalculation(army2.rookie, player2.church.castleAttack);
                Defence1[0] = Rookie.DefenceCalculation(crusade1.rookie, 0);
                Defence1[1] = Shooter.DefenceCalculation(crusade1.shooter, 0);
                Defence1[2] = Infantry.DefenceCalculation(crusade1.infantry, 0);
                Defence1[3] = Cavalry.DefenceCalculation(crusade1.cavalry, 0);
                Defence2[0] = Rookie.DefenceCalculation(army2.rookie, player2.walls.defence);
                Defence2[1] = Shooter.DefenceCalculation(army2.shooter, player2.walls.defence);
                Defence2[2] = Infantry.DefenceCalculation(army2.infantry, player2.walls.defence);
                Defence2[3] = Cavalry.DefenceCalculation(army2.cavalry, player2.walls.defence);
                for (int i = 0; i < 4; i++)
                {
                    if (Attack1[i] > 0)
                    {
                        if (Defence2[0] > 0)
                        {
                            army2.rookie = ((Defence2[0] - Attack1[i]) / (Rookie.Defence + player2.walls.defence));
                            army2.rookie = army2.rookie > 0 ? army2.rookie : 0;
                            Defence2[0] = Rookie.DefenceCalculation(army2.rookie, player2.walls.defence);
                            switch (i)
                            {
                                case 0:
                                    {
                                        crusade1.cavalry = ((Defence1[3] - (Attack2[3] * 3 / 4)) / (Cavalry.Defence));
                                        crusade1.cavalry = crusade1.cavalry > 0 ? crusade1.cavalry : 0;
                                        Attack1[0] = Cavalry.AttackCalculation(crusade1.cavalry, player1.church.crusadeAttack);
                                        break;
                                    }
                                case 1:
                                    {
                                        break;
                                    }
                                case 2:
                                    {
                                        crusade1.infantry = ((Defence1[2] - (Attack2[3] * 3 / 4)) / (Infantry.Defence));
                                        crusade1.infantry = crusade1.infantry > 0 ? crusade1.infantry : 0;
                                        Attack1[2] = Infantry.AttackCalculation(crusade1.infantry, player1.church.crusadeAttack);
                                        break;
                                    }
                                case 3:
                                    {
                                        crusade1.rookie = ((Defence1[0] - (Attack2[3] * 3 / 4)) / (Rookie.Defence));
                                        crusade1.rookie = crusade1.rookie > 0 ? crusade1.rookie : 0;
                                        Attack1[3] = Rookie.AttackCalculation(crusade1.rookie, player1.church.crusadeAttack);
                                        break;
                                    }
                            }
                        }
                        else if (Defence2[1] > 0)
                        {
                            army2.shooter = ((Defence2[1] - Attack1[i]) / (Shooter.Defence + player2.walls.defence));
                            army2.shooter = army2.shooter > 0 ? army2.shooter : 0;
                            Defence2[1] = Shooter.DefenceCalculation(army2.shooter, player2.walls.defence);
                            switch (i)
                            {
                                case 0:
                                    {
                                        crusade1.cavalry = ((Defence1[3] - (Attack2[1] * 3 / 4)) / (Cavalry.Defence));
                                        crusade1.cavalry = crusade1.cavalry > 0 ? crusade1.cavalry : 0;
                                        Attack1[0] = Cavalry.AttackCalculation(crusade1.cavalry, player1.church.crusadeAttack);
                                        break;
                                    }
                                case 1:
                                    {
                                        break;
                                    }
                                case 2:
                                    {
                                        crusade1.infantry = ((Defence1[2] - (Attack2[1] * 3 / 4)) / (Infantry.Defence));
                                        crusade1.infantry = crusade1.infantry > 0 ? crusade1.infantry : 0;
                                        Attack1[2] = Infantry.AttackCalculation(crusade1.infantry, player1.church.crusadeAttack);
                                        break;
                                    }
                                case 3:
                                    {
                                        crusade1.rookie = ((Defence1[0] - (Attack2[1] * 3 / 4)) / (Rookie.Defence));
                                        crusade1.rookie = crusade1.rookie > 0 ? crusade1.rookie : 0;
                                        Attack1[3] = Rookie.AttackCalculation(crusade1.rookie, player1.church.crusadeAttack);
                                        break;
                                    }
                            }
                        }
                        else if (Defence2[2] > 0)
                        {
                            army2.infantry = ((Defence2[2] - Attack1[i]) / (Infantry.Defence + player2.walls.defence));
                            army2.infantry = army2.infantry > 0 ? army2.infantry : 0;
                            Defence2[2] = Infantry.DefenceCalculation(army2.infantry, player2.walls.defence);
                            switch (i)
                            {
                                case 0:
                                    {
                                        crusade1.cavalry = ((Defence1[3] - (Attack2[2] * 3 / 4)) / (Cavalry.Defence));
                                        crusade1.cavalry = crusade1.cavalry > 0 ? crusade1.cavalry : 0;
                                        Attack1[0] = Cavalry.AttackCalculation(crusade1.cavalry, player1.church.crusadeAttack);
                                        break;
                                    }
                                case 1:
                                    {
                                        break;
                                    }
                                case 2:
                                    {
                                        crusade1.infantry = ((Defence1[2] - (Attack2[2] * 3 / 4)) / (Infantry.Defence));
                                        crusade1.infantry = crusade1.infantry > 0 ? crusade1.infantry : 0;
                                        Attack1[2] = Infantry.AttackCalculation(crusade1.infantry, player1.church.crusadeAttack);
                                        break;
                                    }
                                case 3:
                                    {
                                        crusade1.rookie = ((Defence1[0] - (Attack2[2] * 3 / 4)) / (Rookie.Defence));
                                        crusade1.rookie = crusade1.rookie > 0 ? crusade1.rookie : 0;
                                        Attack1[3] = Rookie.AttackCalculation(crusade1.rookie, player1.church.crusadeAttack);
                                        break;
                                    }
                            }
                        }
                        else if (Defence2[3] > 0)
                        {
                            army2.cavalry = ((Defence2[3] - Attack1[i]) / (Cavalry.Defence + player2.walls.defence));
                            army2.cavalry = army2.cavalry > 0 ? army2.cavalry : 0;
                            Defence2[3] = Cavalry.DefenceCalculation(army2.cavalry, player2.walls.defence);
                            switch (i)
                            {
                                case 0:
                                    {
                                        crusade1.cavalry = ((Defence1[3] - (Attack2[0] * 3 / 4)) / (Cavalry.Defence));
                                        crusade1.cavalry = crusade1.cavalry > 0 ? crusade1.cavalry : 0;
                                        Attack1[0] = Cavalry.AttackCalculation(crusade1.cavalry, player1.church.crusadeAttack);
                                        break;
                                    }
                                case 1:
                                    {
                                        break;
                                    }
                                case 2:
                                    {
                                        crusade1.infantry = ((Defence1[2] - (Attack2[0] * 3 / 4)) / (Infantry.Defence));
                                        crusade1.infantry = crusade1.infantry > 0 ? crusade1.infantry : 0;
                                        Attack1[2] = Infantry.AttackCalculation(crusade1.infantry, player1.church.crusadeAttack);
                                        break;
                                    }
                                case 3:
                                    {
                                        crusade1.rookie = ((Defence1[0] - (Attack2[0] * 3 / 4)) / (Rookie.Defence));
                                        crusade1.rookie = crusade1.rookie > 0 ? crusade1.rookie : 0;
                                        Attack1[3] = Rookie.AttackCalculation(crusade1.rookie, player1.church.crusadeAttack);
                                        break;
                                    }
                            }
                        }
                    }
                }
                for (int i = 0; i < 4; i++)
                {
                    if (Attack2[i] > 0)
                    {
                        if (Defence1[0] > 0)
                        {
                            crusade1.rookie = ((Defence1[0] - Attack2[i]) / (Rookie.Defence));
                            crusade1.rookie = crusade1.rookie > 0 ? crusade1.rookie : 0;
                            Defence1[0] = Rookie.DefenceCalculation(crusade1.rookie, 0);
                            switch (i)
                            {
                                case 0:
                                    {
                                        army2.cavalry = ((Defence2[3] - (Attack1[3] * 3 / 4)) / (Cavalry.Defence + player2.walls.defence));
                                        army2.cavalry = army2.cavalry > 0 ? army2.cavalry : 0;
                                        Attack2[0] = Cavalry.AttackCalculation(army2.cavalry, player2.church.castleAttack);
                                        break;
                                    }
                                case 1:
                                    {
                                        break;
                                    }
                                case 2:
                                    {
                                        army2.infantry = ((Defence2[2] - (Attack1[3] * 3 / 4)) / (Infantry.Defence + player2.walls.defence));
                                        army2.infantry = army2.infantry > 0 ? army2.infantry : 0;
                                        Attack2[2] = Infantry.AttackCalculation(army2.infantry, player2.church.castleAttack);
                                        break;
                                    }
                                case 3:
                                    {
                                        army2.rookie = ((Defence2[0] - (Attack1[3] * 3 / 4)) / (Rookie.Defence));
                                        army2.rookie = army2.rookie > 0 ? army2.rookie : 0;
                                        Attack2[3] = Rookie.AttackCalculation(army2.rookie, player2.church.castleAttack);
                                        break;
                                    }
                            }
                        }
                        else if (Defence1[1] > 0)
                        {
                            crusade1.shooter = ((Defence1[1] - Attack2[i]) / (Shooter.Defence));
                            crusade1.shooter = crusade1.shooter > 0 ? crusade1.shooter : 0;
                            Defence1[1] = Shooter.DefenceCalculation(crusade1.shooter, 0);
                            switch (i)
                            {
                                case 0:
                                    {
                                        army2.cavalry = ((Defence2[3] - (Attack1[1] * 3 / 4)) / (Cavalry.Defence + player2.walls.defence));
                                        army2.cavalry = army2.cavalry > 0 ? army2.cavalry : 0;
                                        Attack2[0] = Cavalry.AttackCalculation(army2.cavalry, player2.church.castleAttack);
                                        break;
                                    }
                                case 1:
                                    {
                                        break;
                                    }
                                case 2:
                                    {
                                        army2.infantry = ((Defence2[2] - (Attack1[1] * 3 / 4)) / (Infantry.Defence + player2.walls.defence));
                                        army2.infantry = army2.infantry > 0 ? army2.infantry : 0;
                                        Attack2[2] = Infantry.AttackCalculation(army2.infantry, player2.church.castleAttack);
                                        break;
                                    }
                                case 3:
                                    {
                                        army2.rookie = ((Defence2[0] - (Attack1[1] * 3 / 4)) / (Rookie.Defence));
                                        army2.rookie = army2.rookie > 0 ? army2.rookie : 0;
                                        Attack2[3] = Rookie.AttackCalculation(army2.rookie, player2.church.castleAttack);
                                        break;
                                    }
                            }
                        }
                        else if (Defence1[2] > 0)
                        {
                            crusade1.infantry = ((Defence1[2] - Attack2[i]) / (Infantry.Defence));
                            crusade1.infantry = crusade1.infantry > 0 ? crusade1.infantry : 0;
                            Defence1[2] = Infantry.DefenceCalculation(crusade1.infantry, 0);
                            switch (i)
                            {
                                case 0:
                                    {
                                        army2.cavalry = ((Defence2[3] - (Attack1[2] * 3 / 4)) / (Cavalry.Defence + player2.walls.defence));
                                        army2.cavalry = army2.cavalry > 0 ? army2.cavalry : 0;
                                        Attack2[0] = Cavalry.AttackCalculation(army2.cavalry, player2.church.castleAttack);
                                        break;
                                    }
                                case 1:
                                    {
                                        break;
                                    }
                                case 2:
                                    {
                                        army2.infantry = ((Defence2[2] - (Attack1[2] * 3 / 4)) / (Infantry.Defence + player2.walls.defence));
                                        army2.infantry = army2.infantry > 0 ? army2.infantry : 0;
                                        Attack2[2] = Infantry.AttackCalculation(army2.infantry, player2.church.castleAttack);
                                        break;
                                    }
                                case 3:
                                    {
                                        army2.rookie = ((Defence2[0] - (Attack1[2] * 3 / 4)) / (Rookie.Defence));
                                        army2.rookie = army2.rookie > 0 ? army2.rookie : 0;
                                        Attack2[3] = Rookie.AttackCalculation(army2.rookie, player2.church.castleAttack);
                                        break;
                                    }
                            }
                        }
                        else if (Defence1[3] > 0)
                        {
                            crusade1.cavalry = ((Defence1[3] - Attack2[i]) / (Cavalry.Defence));
                            crusade1.cavalry = crusade1.cavalry > 0 ? crusade1.cavalry : 0;
                            Defence1[3] = Cavalry.DefenceCalculation(crusade1.cavalry, 0);
                            switch (i)
                            {
                                case 0:
                                    {
                                        army2.cavalry = ((Defence2[3] - (Attack1[0] * 3 / 4)) / (Cavalry.Defence + player2.walls.defence));
                                        army2.cavalry = army2.cavalry > 0 ? army2.cavalry : 0;
                                        Attack2[0] = Cavalry.AttackCalculation(army2.cavalry, player2.church.castleAttack);
                                        break;
                                    }
                                case 1:
                                    {
                                        break;
                                    }
                                case 2:
                                    {
                                        army2.infantry = ((Defence2[2] - (Attack1[0] * 3 / 4)) / (Infantry.Defence + player2.walls.defence));
                                        army2.infantry = army2.infantry > 0 ? army2.infantry : 0;
                                        Attack2[2] = Infantry.AttackCalculation(army2.infantry, player2.church.castleAttack);
                                        break;
                                    }
                                case 3:
                                    {
                                        army2.rookie = ((Defence2[0] - (Attack1[0] * 3 / 4)) / (Rookie.Defence));
                                        army2.rookie = army2.rookie > 0 ? army2.rookie : 0;
                                        Attack2[3] = Rookie.AttackCalculation(army2.rookie, player2.church.castleAttack);
                                        break;
                                    }
                            }
                        }
                    }
                }
            }
            if (crusade1.rookie <= 0 && crusade1.shooter <= 0 && crusade1.infantry <= 0 && crusade1.cavalry <= 0) //crusade army of attacker is destroyed
            {
                crusade1.rookie = 0;
                crusade1.shooter = 0;
                crusade1.infantry = 0;
                crusade1.cavalry = 0;
                crusade1.CrusadeSquad.transform.localPosition = crusade1.startPosition;
                crusade1.EndCrusade();
                if (!player2.AI)
                {
                    player2.ui.showInfoArmy();
                }
            }
            if (army2.rookie <= 0 && army2.shooter <= 0 && army2.infantry <= 0 && army2.cavalry <= 0) //army in defender castle is destroyed
            {
                player1.money += player2.money / 2;
                if (!player2.AI)
                {
                    player2.ui.GameOver();
                    Player.end = true;
                }
                else
                {
                    if (player2.crusade.Crusade)
                    {
                        player2.crusade.CrusadeSquad.transform.localPosition = player2.crusade.startPosition;
                        player2.crusade.CrusadeSquad.transform.localPosition = new Vector3(-1, -1, -1);
                        player2.crusade.CrusadeSquad.SetActive(false);
                    }
                    player2.gameObject.transform.localPosition = new Vector3(-1, -1, -1);
                    player2.gameObject.SetActive(false);
                    turns.CalculateTurns();
                }
                if (!player1.AI)
                {
                    player1.ui.showInfoPlayer();
                    player1.ui.showInfoCrusade();
                    if (!player1.Enemy1.gameObject.activeSelf &&
                        !player1.Enemy2.gameObject.activeSelf &&
                        !player1.Enemy3.gameObject.activeSelf)
                    {
                        player1.ui.Victory();
                        Player.end = true;
                    }
                }
            }
        }

        public void BattleCalculation(Player player1, Player player2, CrusadeArmy crusade1, CrusadeArmy crusade2) //one crusade army on another crusade armmy calculation
        {
            while ((crusade1.rookie > 0 || crusade1.shooter > 0 || crusade1.infantry > 0 || crusade1.cavalry > 0) &&
                (crusade2.rookie > 0 || crusade2.shooter > 0 || crusade2.infantry > 0 || crusade2.cavalry > 0))
            {
                Attack1[0] = Cavalry.AttackCalculation(crusade1.cavalry, player1.church.crusadeAttack);
                Attack1[1] = Shooter.AttackCalculation(crusade1.shooter, player1.church.crusadeAttack);
                Attack1[2] = Infantry.AttackCalculation(crusade1.infantry, player1.church.crusadeAttack);
                Attack1[3] = Rookie.AttackCalculation(crusade1.rookie, player1.church.crusadeAttack);
                Attack2[0] = Cavalry.AttackCalculation(crusade2.cavalry, player2.church.crusadeAttack);
                Attack2[1] = Shooter.AttackCalculation(crusade2.shooter, player2.church.crusadeAttack);
                Attack2[2] = Infantry.AttackCalculation(crusade2.infantry, player2.church.crusadeAttack);
                Attack2[3] = Rookie.AttackCalculation(crusade2.rookie, player2.church.crusadeAttack);
                Defence1[0] = Rookie.DefenceCalculation(crusade1.rookie, 0);
                Defence1[1] = Shooter.DefenceCalculation(crusade1.shooter, 0);
                Defence1[2] = Infantry.DefenceCalculation(crusade1.infantry, 0);
                Defence1[3] = Cavalry.DefenceCalculation(crusade1.cavalry, 0);
                Defence2[0] = Rookie.DefenceCalculation(crusade2.rookie, 0);
                Defence2[1] = Shooter.DefenceCalculation(crusade2.shooter, 0);
                Defence2[2] = Infantry.DefenceCalculation(crusade2.infantry, 0);
                Defence2[3] = Cavalry.DefenceCalculation(crusade2.cavalry, 0);
                for (int i = 0; i < 4; i++)
                {
                    if (Attack1[i] > 0)
                    {
                        if (Defence2[0] > 0)
                        {
                            crusade2.rookie = ((Defence2[0] - Attack1[i]) / (Rookie.Defence));
                            crusade2.rookie = crusade2.rookie > 0 ? crusade2.rookie : 0;
                            Defence2[0] = Rookie.DefenceCalculation(crusade2.rookie, 0);
                            switch (i)
                            {
                                case 0:
                                    {
                                        crusade1.cavalry = ((Defence1[3] - (Attack2[3] * 3 / 4)) / (Cavalry.Defence));
                                        crusade1.cavalry = crusade1.cavalry > 0 ? crusade1.cavalry : 0;
                                        Attack1[0] = Cavalry.AttackCalculation(crusade1.cavalry, player1.church.crusadeAttack);
                                        break;
                                    }
                                case 1:
                                    {
                                        break;
                                    }
                                case 2:
                                    {
                                        crusade1.infantry = ((Defence1[2] - (Attack2[3] * 3 / 4)) / (Infantry.Defence));
                                        crusade1.infantry = crusade1.infantry > 0 ? crusade1.infantry : 0;
                                        Attack1[2] = Infantry.AttackCalculation(crusade1.infantry, player1.church.crusadeAttack);
                                        break;
                                    }
                                case 3:
                                    {
                                        crusade1.rookie = ((Defence1[0] - (Attack2[3] * 3 / 4)) / (Rookie.Defence));
                                        crusade1.rookie = crusade1.rookie > 0 ? crusade1.rookie : 0;
                                        Attack1[3] = Rookie.AttackCalculation(crusade1.rookie, player1.church.crusadeAttack);
                                        break;
                                    }
                            }
                        }
                        else if (Defence2[1] > 0)
                        {
                            crusade2.shooter = ((Defence2[1] - Attack1[i]) / (Shooter.Defence));
                            crusade2.shooter = crusade2.shooter > 0 ? crusade2.shooter : 0;
                            Defence2[1] = Shooter.DefenceCalculation(crusade2.shooter, 0);
                            switch (i)
                            {
                                case 0:
                                    {
                                        crusade1.cavalry = ((Defence1[3] - (Attack2[1] * 3 / 4)) / (Cavalry.Defence));
                                        crusade1.cavalry = crusade1.cavalry > 0 ? crusade1.cavalry : 0;
                                        Attack1[0] = Cavalry.AttackCalculation(crusade1.cavalry, player1.church.crusadeAttack);
                                        break;
                                    }
                                case 1:
                                    {
                                        break;
                                    }
                                case 2:
                                    {
                                        crusade1.infantry = ((Defence1[2] - (Attack2[1] * 3 / 4)) / (Infantry.Defence));
                                        crusade1.infantry = crusade1.infantry > 0 ? crusade1.infantry : 0;
                                        Attack1[2] = Infantry.AttackCalculation(crusade1.infantry, player1.church.crusadeAttack);
                                        break;
                                    }
                                case 3:
                                    {
                                        crusade1.rookie = ((Defence1[0] - (Attack2[1] * 3 / 4)) / (Rookie.Defence));
                                        crusade1.rookie = crusade1.rookie > 0 ? crusade1.rookie : 0;
                                        Attack1[3] = Rookie.AttackCalculation(crusade1.rookie, player1.church.crusadeAttack);
                                        break;
                                    }
                            }
                        }
                        else if (Defence2[2] > 0)
                        {
                            crusade2.infantry = ((Defence2[2] - Attack1[i]) / (Infantry.Defence));
                            crusade2.infantry = crusade2.infantry > 0 ? crusade2.infantry : 0;
                            Defence2[2] = Infantry.DefenceCalculation(crusade2.infantry, 0);
                            switch (i)
                            {
                                case 0:
                                    {
                                        crusade1.cavalry = ((Defence1[3] - (Attack2[2] * 3 / 4)) / (Cavalry.Defence));
                                        crusade1.cavalry = crusade1.cavalry > 0 ? crusade1.cavalry : 0;
                                        Attack1[0] = Cavalry.AttackCalculation(crusade1.cavalry, player1.church.crusadeAttack);
                                        break;
                                    }
                                case 1:
                                    {
                                        break;
                                    }
                                case 2:
                                    {
                                        crusade1.infantry = ((Defence1[2] - (Attack2[2] * 3 / 4)) / (Infantry.Defence));
                                        crusade1.infantry = crusade1.infantry > 0 ? crusade1.infantry : 0;
                                        Attack1[2] = Infantry.AttackCalculation(crusade1.infantry, player1.church.crusadeAttack);
                                        break;
                                    }
                                case 3:
                                    {
                                        crusade1.rookie = ((Defence1[0] - (Attack2[2] * 3 / 4)) / (Rookie.Defence));
                                        crusade1.rookie = crusade1.rookie > 0 ? crusade1.rookie : 0;
                                        Attack1[3] = Rookie.AttackCalculation(crusade1.rookie, player1.church.crusadeAttack);
                                        break;
                                    }
                            }
                        }
                        else if (Defence2[3] > 0)
                        {
                            crusade2.cavalry = ((Defence2[3] - Attack1[i]) / (Cavalry.Defence));
                            crusade2.cavalry = crusade2.cavalry > 0 ? crusade2.cavalry : 0;
                            Defence2[3] = Cavalry.DefenceCalculation(crusade2.cavalry, 0);
                            switch (i)
                            {
                                case 0:
                                    {
                                        crusade1.cavalry = ((Defence1[3] - (Attack2[0] * 3 / 4)) / (Cavalry.Defence));
                                        crusade1.cavalry = crusade1.cavalry > 0 ? crusade1.cavalry : 0;
                                        Attack1[0] = Cavalry.AttackCalculation(crusade1.cavalry, player1.church.crusadeAttack);
                                        break;
                                    }
                                case 1:
                                    {
                                        break;
                                    }
                                case 2:
                                    {
                                        crusade1.infantry = ((Defence1[2] - (Attack2[0] * 3 / 4)) / (Infantry.Defence));
                                        crusade1.infantry = crusade1.infantry > 0 ? crusade1.infantry : 0;
                                        Attack1[2] = Infantry.AttackCalculation(crusade1.infantry, player1.church.crusadeAttack);
                                        break;
                                    }
                                case 3:
                                    {
                                        crusade1.rookie = ((Defence1[0] - (Attack2[0] * 3 / 4)) / (Rookie.Defence));
                                        crusade1.rookie = crusade1.rookie > 0 ? crusade1.rookie : 0;
                                        Attack1[3] = Rookie.AttackCalculation(crusade1.rookie, player1.church.crusadeAttack);
                                        break;
                                    }
                            }
                        }
                    }
                }
                for (int i = 0; i < 4; i++)
                {
                    if (Attack2[i] > 0)
                    {
                        if (Defence1[0] > 0)
                        {
                            crusade1.rookie = ((Defence1[0] - Attack2[i]) / (Rookie.Defence));
                            crusade1.rookie = crusade1.rookie > 0 ? crusade1.rookie : 0;
                            Defence1[0] = Rookie.DefenceCalculation(crusade1.rookie, 0);
                            switch (i)
                            {
                                case 0:
                                    {
                                        crusade2.cavalry = ((Defence2[3] - (Attack1[3] * 3 / 4)) / (Cavalry.Defence));
                                        crusade2.cavalry = crusade2.cavalry > 0 ? crusade2.cavalry : 0;
                                        Attack2[0] = Cavalry.AttackCalculation(crusade2.cavalry, 0);
                                        break;
                                    }
                                case 1:
                                    {
                                        break;
                                    }
                                case 2:
                                    {
                                        crusade2.infantry = ((Defence2[2] - (Attack1[3] * 3 / 4)) / (Infantry.Defence));
                                        crusade2.infantry = crusade2.infantry > 0 ? crusade2.infantry : 0;
                                        Attack2[2] = Infantry.AttackCalculation(crusade2.infantry, 0);
                                        break;
                                    }
                                case 3:
                                    {
                                        crusade2.rookie = ((Defence2[0] - (Attack1[3] * 3 / 4)) / (Rookie.Defence));
                                        crusade2.rookie = crusade2.rookie > 0 ? crusade2.rookie : 0;
                                        Attack2[3] = Rookie.AttackCalculation(crusade2.rookie, 0);
                                        break;
                                    }
                            }
                        }
                        else if (Defence1[1] > 0)
                        {
                            crusade1.shooter = ((Defence1[1] - Attack2[i]) / (Shooter.Defence));
                            crusade1.shooter = crusade1.shooter > 0 ? crusade1.shooter : 0;
                            Defence1[1] = Shooter.DefenceCalculation(crusade1.shooter, 0);
                            switch (i)
                            {
                                case 0:
                                    {
                                        crusade2.cavalry = ((Defence2[3] - (Attack1[1] * 3 / 4)) / (Cavalry.Defence));
                                        crusade2.cavalry = crusade2.cavalry > 0 ? crusade2.cavalry : 0;
                                        Attack2[0] = Cavalry.AttackCalculation(crusade2.cavalry, 0);
                                        break;
                                    }
                                case 1:
                                    {
                                        break;
                                    }
                                case 2:
                                    {
                                        crusade2.infantry = ((Defence2[2] - (Attack1[1] * 3 / 4)) / (Infantry.Defence));
                                        crusade2.infantry = crusade2.infantry > 0 ? crusade2.infantry : 0;
                                        Attack2[2] = Infantry.AttackCalculation(crusade2.infantry, 0);
                                        break;
                                    }
                                case 3:
                                    {
                                        crusade2.rookie = ((Defence2[0] - (Attack1[1] * 3 / 4)) / (Rookie.Defence));
                                        crusade2.rookie = crusade2.rookie > 0 ? crusade2.rookie : 0;
                                        Attack2[3] = Rookie.AttackCalculation(crusade2.rookie, 0);
                                        break;
                                    }
                            }
                        }
                        else if (Defence1[2] > 0)
                        {
                            crusade1.infantry = ((Defence1[2] - Attack2[i]) / (Infantry.Defence));
                            crusade1.infantry = crusade1.infantry > 0 ? crusade1.infantry : 0;
                            Defence1[2] = Infantry.DefenceCalculation(crusade1.infantry, 0);
                            switch (i)
                            {
                                case 0:
                                    {
                                        crusade2.cavalry = ((Defence2[3] - (Attack1[2] * 3 / 4)) / (Cavalry.Defence));
                                        crusade2.cavalry = crusade2.cavalry > 0 ? crusade2.cavalry : 0;
                                        Attack2[0] = Cavalry.AttackCalculation(crusade2.cavalry, 0);
                                        break;
                                    }
                                case 1:
                                    {
                                        break;
                                    }
                                case 2:
                                    {
                                        crusade2.infantry = ((Defence2[2] - (Attack1[2] * 3 / 4)) / (Infantry.Defence));
                                        crusade2.infantry = crusade2.infantry > 0 ? crusade2.infantry : 0;
                                        Attack2[2] = Infantry.AttackCalculation(crusade2.infantry, 0);
                                        break;
                                    }
                                case 3:
                                    {
                                        crusade2.rookie = ((Defence2[0] - (Attack1[2] * 3 / 4)) / (Rookie.Defence));
                                        crusade2.rookie = crusade2.rookie > 0 ? crusade2.rookie : 0;
                                        Attack2[3] = Rookie.AttackCalculation(crusade2.rookie, 0);
                                        break;
                                    }
                            }
                        }
                        else if (Defence1[3] > 0)
                        {
                            crusade1.cavalry = ((Defence1[3] - Attack2[i]) / (Cavalry.Defence));
                            crusade1.cavalry = crusade1.cavalry > 0 ? crusade1.cavalry : 0;
                            Defence1[3] = Cavalry.DefenceCalculation(crusade1.cavalry, 0);
                            switch (i)
                            {
                                case 0:
                                    {
                                        crusade2.cavalry = ((Defence2[3] - (Attack1[0] * 3 / 4)) / (Cavalry.Defence));
                                        crusade2.cavalry = crusade2.cavalry > 0 ? crusade2.cavalry : 0;
                                        Attack2[0] = Cavalry.AttackCalculation(crusade2.cavalry, 0);
                                        break;
                                    }
                                case 1:
                                    {
                                        break;
                                    }
                                case 2:
                                    {
                                        crusade2.infantry = ((Defence2[2] - (Attack1[0] * 3 / 4)) / (Infantry.Defence));
                                        crusade2.infantry = crusade2.infantry > 0 ? crusade2.infantry : 0;
                                        Attack2[2] = Infantry.AttackCalculation(crusade2.infantry, 0);
                                        break;
                                    }
                                case 3:
                                    {
                                        crusade2.rookie = ((Defence2[0] - (Attack1[0] * 3 / 4)) / (Rookie.Defence));
                                        crusade2.rookie = crusade2.rookie > 0 ? crusade2.rookie : 0;
                                        Attack2[3] = Rookie.AttackCalculation(crusade2.rookie, 0);
                                        break;
                                    }
                            }
                        }
                    }
                }
            }
            if (crusade1.rookie <= 0 && crusade1.shooter <= 0 && crusade1.infantry <= 0 && crusade1.cavalry <= 0) //crusade army of attacker is destroyed
            {
                crusade1.rookie = 0;
                crusade1.shooter = 0;
                crusade1.infantry = 0;
                crusade1.cavalry = 0;
                crusade1.CrusadeSquad.transform.localPosition = crusade1.startPosition;
                crusade1.EndCrusade();
                if (!player2.AI)
                {
                    player2.ui.showInfoCrusade();
                }
            }
            if (crusade2.rookie <= 0 && crusade2.shooter <= 0 && crusade2.infantry <= 0 && crusade2.cavalry <= 0) //crusade army of defender is destroyed
            {
                crusade2.rookie = 0;
                crusade2.shooter = 0;
                crusade2.infantry = 0;
                crusade2.cavalry = 0;
                crusade2.CrusadeSquad.transform.localPosition = crusade2.startPosition;
                crusade2.EndCrusade();
                if (!player1.AI)
                {
                    player1.ui.showInfoCrusade();
                }
            }
        }

        // Start is called before the first frame update
        void Start()
        {
            Attack1 = new int[4];
            Attack2 = new int[4];
            Defence1 = new int[4];
            Defence2 = new int[4];
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}