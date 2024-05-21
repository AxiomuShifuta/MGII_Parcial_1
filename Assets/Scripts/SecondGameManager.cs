using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondGameManager : MonoBehaviour
{
    public class GameManager : MonoBehaviour
    {
        public static bool gameOver = false;


        public static int actualPlayer = 0;

        public List<Controller_Target> targets;

        public List<Controller_Player> players;

        void Start()
        {
            Physics.gravity = new Vector3(0, -30, 0);
            gameOver = false;
            SetConstraits();
        }

        void Update()
        {
            GetInput();
          
        }


        private void GetInput()
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                if (actualPlayer <= 0)
                {
                    actualPlayer = 3;
                    SetConstraits();
                }
                else
                {
                    actualPlayer--;
                    SetConstraits();
                }
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (actualPlayer >= 3)
                {
                    actualPlayer = 0;
                    SetConstraits();
                }
                else
                {
                    actualPlayer++;
                    SetConstraits();
                }
            }
        }

        private void SetConstraits()
        {
            foreach (Controller_Player p in players)
            {
                if (p == players[actualPlayer])
                {
                    p.rb.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
                }
                else
                {
                    p.rb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
                }
            }
        }
    }
}
