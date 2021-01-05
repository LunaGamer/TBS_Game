using Assets.Scripts.Base;

namespace Assets.Scripts.Army
{
    public class Cavalry : Soldier //cavalry unit class
    {
        public Cavalry()
        {
            soldierName = "Cavalry";
            Attack = 7;
            Defence = 20;
            Speed = 3;
            GS = 4;
            Cost = 48;
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