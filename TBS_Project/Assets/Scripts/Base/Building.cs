using UnityEngine;

namespace Assets.Scripts.Base
{
    public abstract class Building : MonoBehaviour //Basic class for all buildings
    {
        // Start is called before the first frame update
        public int lvl;
        public int maxLvl;
        public int upgrCost;
        public string buildingName;
        public string addStat1Text;
        public string addStat2Text;
        public InterfaceController ui;
        public Player player;

        public virtual void lvlUp() //basic lvlup for every building
        {
            player.money -= lvl * upgrCost;
            lvl += 1;
            if (!player.AI)
            {
                ui.showInfoPlayer();
            }
        }
                
        public void OnMouseDown() //onclick function to show info about current building in UI
        {
            if (!player.AI)
            {
                ui.showInfoBuilding(this);
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