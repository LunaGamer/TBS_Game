using System;
using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts.Base;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class InterfaceController : MonoBehaviour //class for UI
    {
        public Player player;
        public ArmyScript army;
        public CrusadeArmy crusade;
        public Text money;
        public Text people;
        public Text money2;
        public Text people2;
        public Text turns;
        public Text turns2;
        public Text ArmyRookies;
        public Text ArmyShooters;
        public Text ArmyInfantry;
        public Text ArmyCavalry;
        public Text ArmyRookies2;
        public Text ArmyShooters2;
        public Text ArmyInfantry2;
        public Text ArmyCavalry2;
        public Text BuildingName;
        public Text BuildingLevel;
        public Text BuildingMaxLevel;
        public Text BuildingUpgradeCost;
        public Text BuildingAddField1;
        public Text BuildingAddField2;
        public Button upgradeButton;
        public Text SoldierName;
        public Text SoldierAttack;
        public Text SoldierDefence;
        public Text SoldierSpeed;
        public Text SoldierCost;
        public GameObject CrusadePanel;
        public Text CrusadeRookies;
        public Text CrusadeShooters;
        public Text CrusadeInfantry;
        public Text CrusadeCavalry;
        public Text CrusadeRookies2;
        public Text CrusadeShooters2;
        public Text CrusadeInfantry2;
        public Text CrusadeCavalry2;
        public Text CrusadeMode;
        public Text CrusadeMoves;
        public InputField inputRookie;
        public InputField inputShooter;
        public InputField inputInfantry;
        public InputField inputCavalry;
        public Button CrusadeButton;
        public Button EndCrusadeButton;
        public Button CastleButton;
        public Button TurnButton;
        public GameObject GameEndPanel;
        public Text GameEndText;
        public Button ExitButton;
        public Button RestartButton;

        public void showInfoPlayer() //update basic info (money and people)
        {
            money.text = "Money: " + player.money.ToString();
            people.text = "People: " + player.people.ToString();
            turns.text = "Turn: " + Player.turnCount;
            money2.text = "Money: " + player.money.ToString();
            people2.text = "People: " + player.people.ToString();
            turns2.text = "Turn: " + Player.turnCount;
        }
        public void showInfoArmy() //update info about army in the castle
        {
            ArmyRookies.text = "Rookies: " + army.rookie + "; max: " + army.maxRookie + "; Cost: " + army.Rookie.Cost;
            ArmyShooters.text = "Shooters: " + army.shooter + "; max: " + army.maxShooter + "; Cost: " + army.Shooter.Cost;
            ArmyInfantry.text = "Infantry: " + army.infantry + "; max: " + army.maxInfantry + "; Cost: " + army.Infantry.Cost;
            ArmyCavalry.text = "Cavalry: " + army.cavalry + "; max: " + army.maxCavalry + "; Cost: " + army.Cavalry.Cost;
            ArmyRookies2.text = "Rookies: " + army.rookie;
            ArmyShooters2.text = "Shooters: " + army.shooter;
            ArmyInfantry2.text = "Infantry: " + army.infantry;
            ArmyCavalry2.text = "Cavalry: " + army.cavalry;
        }

        public void showInfoCrusade() //update info about crusade army (attack squad) or update panel for composing crusade squad
        {
            if (CrusadePanel.activeInHierarchy)
            {
                CrusadeRookies.text = "Rookies: max " + army.rookie;
                CrusadeShooters.text = "Shooters: max " + army.shooter;
                CrusadeInfantry.text = "Infantry: max " + army.infantry;
                CrusadeCavalry.text = "Cavalry: max " + army.cavalry;
            }
            if (crusade.Crusade)
            {
                CrusadeMode.text = "Crusade: On";
                CrusadeRookies2.text = "Rookies: " + crusade.rookie;
                CrusadeShooters2.text = "Shooters: " + crusade.shooter;
                CrusadeInfantry2.text = "Infantry: " + crusade.infantry;
                CrusadeCavalry2.text = "Cavalry: " + crusade.cavalry;
                CrusadeMoves.text = "Map Moves: " + crusade.movePoints;

            }
            else
            {
                CrusadeMode.text = "Crusade: Off";
                CrusadeRookies2.text = "Rookies: ";
                CrusadeShooters2.text = "Shooters: ";
                CrusadeInfantry2.text = "Infantry: ";
                CrusadeCavalry2.text = "Cavalry: ";
                CrusadeMoves.text = "";
    }
        }

        public void OpenCrusade() //show panel for composing crusade squad
        {
            if (!crusade.Crusade)
            {
                CrusadeButton.interactable = false;
                CrusadePanel.SetActive(true);
                inputRookie.text = "0";
                inputShooter.text = "0";
                inputInfantry.text = "0";
                inputCavalry.text = "0";
                showInfoCrusade();
            }
        }

        public void CloseCrusade() //close composing crusade squad
        {
            CrusadeButton.interactable = true;
            CrusadePanel.SetActive(false);
        }

        public void CheckMax(InputField input) //update input fields at crusade composing panel so its values are not bigger than its possible by number of units in army
        {
            int soldierType;
            switch (input.name)
            {
                case "InputRookie":
                    soldierType = 1;
                    break;
                case "InputShooter":
                    soldierType = 2;
                    break;
                case "InputInfantry":
                    soldierType = 3;
                    break;
                case "InputCavalry":
                    soldierType = 4;
                    break;
                default:
                    soldierType = 0;
                    break;
            }
            if (Convert.ToInt32(input.text) > army.GetSoldierMax(soldierType))
            {
                input.text = army.GetSoldierMax(soldierType).ToString();
            }
        }

        public void CrusadeConfirm() //confirm crusade squad composition and start the crusade
        {
            int r = Convert.ToInt32(inputRookie.text);
            int s = Convert.ToInt32(inputShooter.text);
            int i = Convert.ToInt32(inputInfantry.text);
            int c = Convert.ToInt32(inputCavalry.text);
            if (r != 0 || s != 0 || i != 0 || c != 0)
            {
                crusade.ConfirmCrusade(r, s, i, c);
                CrusadeButton.interactable = false;
                EndCrusadeButton.interactable = true;
                CrusadePanel.SetActive(false);                
            }
        }

        public void CrusadeEnd() //UI update if crusade ended
        {
            EndCrusadeButton.interactable = false;
            CrusadeButton.interactable = true;
            showInfoCrusade();
            showInfoArmy();
        }

        public void showInfoBuilding(Building building) //show info about choosen building in castle
        {
            int upgrade = building.upgrCost * building.lvl;
            BuildingName.text = building.buildingName;
            BuildingLevel.text = "lvl: " + building.lvl.ToString();
            BuildingMaxLevel.text = "max: " + building.maxLvl.ToString();
            BuildingUpgradeCost.text = "Ugrade Cost: " + upgrade.ToString();
            BuildingAddField1.text = building.addStat1Text;
            BuildingAddField2.text = building.addStat2Text;
            upgradeButton.gameObject.SetActive(true);
            upgradeButton.interactable = true;
            if (building.lvl == building.maxLvl)
                upgradeButton.interactable = false;
        }

        public string currentNameField() //return current building name
        {
            return BuildingName.text;
        }

        public void showInfoSoldier(Soldier soldier) //show info about choosen soldier unit
        {
            SoldierName.text = soldier.soldierName;
            SoldierAttack.text = "Att: " + soldier.Attack.ToString();
            SoldierDefence.text = "Def: " + soldier.Defence.ToString();
            SoldierSpeed.text = "Speed: " + soldier.Speed.ToString();
            SoldierCost.text = "Cost: " + soldier.Cost.ToString();
            upgradeButton.interactable = false;
            upgradeButton.gameObject.SetActive(false);            
        }

        public void GameOver() //GameOver panel and text
        {
            upgradeButton.interactable = false;
            CrusadeButton.interactable = false;
            EndCrusadeButton.interactable = false;
            CastleButton.interactable = false;
            TurnButton.interactable = false;
            ExitButton.interactable = true;
            RestartButton.interactable = true;
            GameEndPanel.SetActive(true);
            GameEndText.text = "GameOver\n You Lose!";
        }

        public void Victory() //Victory panel and text
        {
            upgradeButton.interactable = false;
            CrusadeButton.interactable = false;
            EndCrusadeButton.interactable = false;
            CastleButton.interactable = false;
            TurnButton.interactable = false;
            ExitButton.interactable = true;
            RestartButton.interactable = true;
            GameEndPanel.SetActive(true);
            GameEndText.text = "Victory!";
        }

        public void RestartGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        public void ExitGame()
        {
            Application.Quit();
        }

        // Start is called before the first frame update
        void Start() //Starting settings of the UI
        {
            EndCrusadeButton.interactable = false;
            ExitButton.interactable = false;
            RestartButton.interactable = false;
            CrusadeMode.text = "Crusade: Off";
            inputRookie.text = "0";
            inputShooter.text = "0";
            inputInfantry.text = "0";
            inputCavalry.text = "0";
            CrusadeMoves.text = "";
            CrusadePanel.SetActive(false);
            GameEndPanel.SetActive(false);
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}