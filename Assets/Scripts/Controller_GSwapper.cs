using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller_GSwapper : New_Player_Controller
{
    [SerializeField]private bool onCeiling;
    [SerializeField]private bool inverseGravity = false;
 


    // Update is called once per frame
     public override void FixedUpdate()
    {
        if (inverseGravity == true)
        {
            rb.AddForce(new Vector3(0, 40, 0), ForceMode.Impulse);
        }
        
        else rb.AddForce(new Vector3(0, -40, 0));
        

        base.FixedUpdate();
    }

     
    public override void JumpTeam2()
    {
        if (playerNumber == SecondGameManager.actualPlayerTeam2)
        {

            if (Input.GetKeyDown(KeyCode.I))
            {
                if (onFloor)
                {
                    inverseGravity = true;

                }

                if (onCeiling)
                {
                    inverseGravity = false;

                }
            }
        }
    }

    public override void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ceiling"))
        {
            onCeiling = true;
        }
        
        base.OnCollisionEnter(collision);
    }

    public override void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ceiling"))
        {
            onCeiling = false;
        }
        base.OnCollisionExit(collision);
    }


}
