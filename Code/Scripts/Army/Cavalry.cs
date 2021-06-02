using Assets.Scripts.Base;

namespace Assets.Scripts.Army
{
    public class Cavalry : Soldier //cavalry unit class
    {
        public Cavalry()
        {
            soldierName = "Cavalry";
            Attack = 20;
            Defence = 7;
            Speed = 3;
            Cost = 48;
        }
        // Start is called before the first frame update
        void Start()
        {
            soldierName = "Cavalry";
            Attack = 20;
            Defence = 7;
            Speed = 3;
            Cost = 48;
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}