using Assets.Scripts.Base;

namespace Assets.Scripts.Army
{
    public class Infantry : Soldier //infantry unit class
    {
        public Infantry()
        {
            soldierName = "Infantry";
            Attack = 6;
            Defence = 8;
            Speed = 1;
            GS = 3;
            Cost = 20;
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