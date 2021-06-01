using Assets.Scripts.Base;

namespace Assets.Scripts.Army
{
    public class Rookie : Soldier //rookie unit class
    {
        public Rookie()
        {
            soldierName = "Rookie";
            Attack = 2;
            Defence = 2;
            Speed = 1;
            Cost = 2;
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