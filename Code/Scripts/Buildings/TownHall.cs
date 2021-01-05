using Assets.Scripts.Base;

namespace Assets.Scripts.Buildings
{
    public class TownHall : Building
    {
        public int tax; //tax parameter



        public TownHall()
        {
            buildingName = "TownHall";
            lvl = 1;
            maxLvl = 10;
            upgrCost = 200;
            tax = 10;
            addStat1Text = "Tax: " + tax;
            addStat2Text = "";
        }

        public override void lvlUp() //lvl up override for Townhall
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
                    tax += 2;
                    addStat1Text = "Tax: " + tax;
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