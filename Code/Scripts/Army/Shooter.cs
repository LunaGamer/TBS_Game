using Assets.Scripts.Base;

namespace Assets.Scripts.Army
{
    public class Shooter : Soldier //shooter unit class
    {
        public Shooter()
        {
            soldierName = "Shooter";
            Attack = 4;
            Defence = 3;
            Speed = 3;
            Cost = 8;
        }
        // Start is called before the first frame update
        void Start()
        {
            soldierName = "Shooter";
            Attack = 4;
            Defence = 3;
            Speed = 3;
            Cost = 8;
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}