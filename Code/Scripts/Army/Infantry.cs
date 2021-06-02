using Assets.Scripts.Base;

namespace Assets.Scripts.Army
{
    public class Infantry : Soldier //infantry unit class
    {
        public Infantry()
        {
            soldierName = "Infantry";
            Attack = 8;
            Defence = 6;
            Speed = 1;
            Cost = 20;
        }
        // Start is called before the first frame update
        void Start()
        {
            soldierName = "Infantry";
            Attack = 8;
            Defence = 6;
            Speed = 1;
            Cost = 20;
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}