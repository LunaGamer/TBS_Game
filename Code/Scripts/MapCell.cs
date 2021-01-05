using UnityEngine;

namespace Assets.Scripts
{
    public class MapCell : MonoBehaviour
    {
        public CrusadeArmy squad;
        public void OnMouseDown() //onclick on the mapCell (for crusade squad movement)
        {
            if (squad.Crusade)
            {
                squad.moveSquad(gameObject.transform.localPosition);
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