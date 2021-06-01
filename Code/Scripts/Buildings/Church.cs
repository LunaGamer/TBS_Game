using Assets.Scripts.Base;

namespace Assets.Scripts.Buildings
{
    public class Church : Building //church class
    {
        public int crusadeAttack; //attack bonus in crusade
        public int castleAttack; //attack bonus in castle

        public Church()
        {
            buildingName = "Church";
            lvl = 1;
            maxLvl = 10;
            upgrCost = 750;
            crusadeAttack = 0;
            castleAttack = 0;
            addStat1Text = "Crusade Attack: " + crusadeAttack;
            addStat2Text = "Def Attack: " + castleAttack;
        }

        public override void lvlUp() //lvl up override for Church
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
                    if (lvl % 2 == 0)
                    {
                        castleAttack += 1;
                    }
                    if (lvl % 3 == 0)
                    {
                        crusadeAttack += 1;
                    }
                    addStat1Text = "Crusade Attack: " + crusadeAttack;
                    addStat2Text = "Def Attack: " + castleAttack;
                    if (!player.AI)
                    {
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