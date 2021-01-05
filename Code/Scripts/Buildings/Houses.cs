using Assets.Scripts.Base;

namespace Assets.Scripts.Buildings
{
    public class Houses : Building //Houses class
    {
        public int populationLimit; //limit of people in castle
        public int peopleBonus; //people income

        // Start is called before the first frame update
        public Houses()
        {
            buildingName = "Houses";
            lvl = 1;
            maxLvl = 25;
            upgrCost = 150;
            populationLimit = 200;
            peopleBonus = 10;
            addStat1Text = "People Limit: " + populationLimit;
            addStat2Text = "People Income: " + peopleBonus;
        }

        public override void lvlUp() //lvl up override for Houses
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
                    populationLimit += 200;
                    peopleBonus += 10;
                    addStat1Text = "People Limit: " + populationLimit;
                    addStat2Text = "People Income: " + peopleBonus;
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

        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}