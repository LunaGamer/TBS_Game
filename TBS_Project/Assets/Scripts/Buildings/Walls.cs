using Assets.Scripts.Base;

namespace Assets.Scripts.Buildings
{
    public class Walls : Building //walls class
    {

        public int defence; //castle defence

        public Walls()
        {
            buildingName = "Walls";
            lvl = 1;
            maxLvl = 10;
            upgrCost = 500;
            defence = 0;
            addStat1Text = "Defence " + defence;
            addStat2Text = "";
        }

        public override void lvlUp() //lvl up override for Walls
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
                        defence += 1;
                    }
                    addStat1Text = "Defence " + defence;
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