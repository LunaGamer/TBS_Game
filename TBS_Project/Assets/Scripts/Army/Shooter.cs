using Assets.Scripts.Base;

namespace Assets.Scripts.Army
{
    public class Shooter : Soldier //shooter unit class
    {
        public Shooter()
        {
            soldierName = "Shooter";
            Attack = 3;
            Defence = 4;
            Speed = 3;
            GS = 3;
            Cost = 8;
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