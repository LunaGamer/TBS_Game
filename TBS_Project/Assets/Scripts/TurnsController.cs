using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class TurnsController : MonoBehaviour //class for turns distribution
    {
        public int turn; //current player turn
        public int PlayerCount; //number of players
        public Button button1;
        public Button button2;
        public Button button3;
        public Button button4;
        public GameObject[] AI;

        public void CalculateTurns() //get number of players (AI + Player) and appointment of turns to each player
        {
            AI = GameObject.FindGameObjectsWithTag("AI");
            for (int i = 0; i < AI.Length; i++)
            {
                AI[i].GetComponent<AIScript>().ActiveTurn = i + 2;
            }
            PlayerCount = AI.Length + 1;
        }

        // Start is called before the first frame update
        void Start()
        {
            CalculateTurns();
            turn = 1;
        }

        // Update is called once per frame
        void Update()
        {
            if (turn > PlayerCount) //reset turns (retun turn to Player)
            {
                turn = 1;
            }
        }
    }
}