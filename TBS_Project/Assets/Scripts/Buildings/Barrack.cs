using Assets.Scripts.Base;

namespace Assets.Scripts.Buildings
{
    public class Barrack : Building //Barracks class
    {
        public ArmyScript army;
        public bool Shooters;
        public bool Infantry;
        public bool Cavalry;
        public int shooterHire; //limit of shooters to hire in one turn
        public int infantryHire; //limit of infantry to hire in one turn
        public int cavalryHire; //limit of cavalry to hire in one turn

        public Barrack()
        {
            buildingName = "Barrack";
            lvl = 1;
            maxLvl = 10;
            upgrCost = 300;
            Shooters = true;
            Infantry = false;
            Cavalry = false;
            shooterHire = 1;
            infantryHire = 0;
            cavalryHire = 0;
            addStat1Text = "";
            addStat2Text = "";
        }

        public override void lvlUp() //lvl up override for Barracks
        {
            string currentName;
            if (!player.AI)
            {
                currentName = ui.currentNameField();
            }
            else
            {
                currentName = buildingName;
            }
            if (currentName == buildingName && maxLvl > lvl)
            {
                if (player.money >= upgrCost * lvl)
                {
                    base.lvlUp();
                    if (lvl <= 3)
                    {
                        shooterHire += 1;
                        army.maxShooter += 1;
                    }
                    if (lvl == 4)
                    {
                        Infantry = true;
                        infantryHire = 1;
                        army.maxInfantry += 1;
                    }
                    if (lvl < 7 && lvl > 4)
                    {
                        infantryHire += 1;
                        army.maxInfantry += 1;
                    }
                    if (lvl == 7)
                    {
                        Cavalry = true;
                        cavalryHire = 1;
                        army.maxCavalry += 1;
                    }
                    if (lvl <= 10 && lvl > 7)
                    {
                        cavalryHire += 1;
                        army.maxCavalry += 1;
                    }
                    if (!player.AI)
                    {
                        ui.showInfoArmy();
                        ui.showInfoBuilding(this);
                    }
                }
                else
                {
                    //not enough money message
                }
            }
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