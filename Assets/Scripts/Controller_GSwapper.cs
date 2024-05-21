using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller_GSwapper : Controller_Player
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

    public override void Jump()
    {
        if (Input.GetKeyDown(KeyCode.W))
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
