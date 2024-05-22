using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondGameManager : MonoBehaviour
{

        public static bool gameOver = false;

        public static int actualPlayerTeam1 = 0;
        public static int actualPlayerTeam2 = 2;


        //public List<Controller_Player> players;

        void Start()
        {
            Physics.gravity = new Vector3(0, -30, 0);
            gameOver = false;
            //SetConstraits();
        }

        void Update()
        {
            GetInput();
          
        }


        private void GetInput()
        {
            
            if (Input.GetKeyDown(KeyCode.Q))
            {
                if (actualPlayerTeam1 == 0)
                {
                    actualPlayerTeam1 = 1;
                    //SetConstraits();
                }
                else
                {
                    actualPlayerTeam1 = 0;
                    //SetConstraits();
                }
            }

            if (Input.GetKeyDown(KeyCode.O))
            {
                if (actualPlayerTeam2 == 2)
                {
                    actualPlayerTeam2 = 3;
                    //SetConstraits();
                }
                else
                {
                    actualPlayerTeam2 = 2;
                    //SetConstraits();
                }
            }

        }

        //private void SetConstraits()
        //{
        //    foreach (Controller_Player p in players)
        //    {
        //        if (p == players[actualPlayer])
        //        {
        //            p.rb.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
        //        }
        //        else
        //        {
        //            p.rb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
        //        }
        //    }
        //}
}

