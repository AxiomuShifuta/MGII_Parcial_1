using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SecondGameManager : MonoBehaviour
{
        public static int actualPlayerTeam1 = 0;
        public static int actualPlayerTeam2 = 2;
        public TMP_Text textoGanador; 
        
        public List<GameObject> pinkGoalsList = new List<GameObject>();
        public List<GameObject> greenGoalsList = new List<GameObject>();
        
        public List<New_Player_Controller> Team1 = new List<New_Player_Controller>();
        public List<New_Player_Controller> Team2 = new List<New_Player_Controller>();




    //public List<Controller_Player> players;

    void Start()
        {
            textoGanador.gameObject.SetActive(false);
            Physics.gravity = new Vector3(0, -30, 0);          
        }

        void Update()
        {
            GetInput();
            GoalGone();
          
        }


        private void GetInput()
        {
            
            if (Input.GetKeyDown(KeyCode.Q))
            {
                if (actualPlayerTeam1 == 0)
                {
                    actualPlayerTeam1 = 1;
                   
                }
                else
                {
                    actualPlayerTeam1 = 0;
                    
                }
            }

            if (Input.GetKeyDown(KeyCode.O))
            {
                if (actualPlayerTeam2 == 2)
                {
                    actualPlayerTeam2 = 3;
                    
                }
                else
                {
                    actualPlayerTeam2 = 2;
                    
                }
            }

        }

    private void GoalGone()
    {
        foreach (GameObject goal in pinkGoalsList)
        {
            if (goal.gameObject == null)
            {
                pinkGoalsList.Remove(goal);
                /*Como el gameObject se destruye antes de ser eliminado de la lista, 
                 aparece por consola un error advirtiendo, lógicamente, que podría
                traer problemas. No ocurre nada, pero debería buscar la manera de 
                evitar el error.*/
            }
        }

        foreach (GameObject goal in greenGoalsList)
        {
            if (goal.gameObject == null)
            {
                greenGoalsList.Remove(goal);
            }
        }

        GameOver();
    }


    private void GameOver()
    {
        if(pinkGoalsList.Count <= 0)
        {
            Time.timeScale = 0f;
            textoGanador.text = "Gana el equipo verde.";
            textoGanador.gameObject.SetActive(true);
        }

        if (greenGoalsList.Count <= 0)
        {
            Time.timeScale = 0f;
            textoGanador.text = "Gana el equipo rosa.";
            textoGanador.gameObject.SetActive(true);
        }
    }
}

