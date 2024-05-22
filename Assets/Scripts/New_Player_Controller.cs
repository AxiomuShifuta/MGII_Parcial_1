using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class New_Player_Controller : MonoBehaviour
{
    public float jumpForce = 10;

    public float speed = 5;

    public int playerNumber;

    public Rigidbody rb;

    private BoxCollider col;

    public LayerMask floor;

    internal RaycastHit leftHit, rightHit, downHit;

    public float distanceRay, downDistanceRay;

    private bool canMoveLeft, canMoveRight, canJump;
    
    internal bool onFloor;

    public bool isTeam1;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        col = GetComponent<BoxCollider>();
        //rb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
    }

    public virtual void FixedUpdate()
    {
      MovementTeam1();
      
      MovementTeam2();
      
    }

    public virtual void Update() 
    {
        JumpTeam1();
        JumpTeam2();
    }

    private void MovementTeam1()
    {
        if (isTeam1 && playerNumber == SecondGameManager.actualPlayerTeam1)
        {

            if (Input.GetKey(KeyCode.A))
            {
                rb.velocity = new Vector3(1 * -speed, rb.velocity.y, 0);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                rb.velocity = new Vector3(1 * speed, rb.velocity.y, 0);
            }
            else
            {
                rb.velocity = new Vector3(0, rb.velocity.y, 0);
            }

        }
    }

    private void MovementTeam2()
    {
        if(!isTeam1 && playerNumber == SecondGameManager.actualPlayerTeam2)
        {

            if (Input.GetKey(KeyCode.J))
            {
                rb.velocity = new Vector3(1 * -speed, rb.velocity.y, 0);
            }
            else if (Input.GetKey(KeyCode.L))
            {
                rb.velocity = new Vector3(1 * speed, rb.velocity.y, 0);
            }
            else
            {
                rb.velocity = new Vector3(0, rb.velocity.y, 0);
            }
        }
    }

    public virtual void JumpTeam1()
    {
        if (playerNumber == SecondGameManager.actualPlayerTeam1)
        {
            if (Input.GetKeyDown(KeyCode.W) && onFloor)
            {
                rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
            }
        }
       
       
        
    }

    public virtual void JumpTeam2()
    {
        if (playerNumber == SecondGameManager.actualPlayerTeam2)
        {
            if (Input.GetKeyDown(KeyCode.I) && onFloor)
            {
              rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
            }
        }
    }

    public virtual void OnCollisionEnter(Collision collision)
    {
      
        if (collision.gameObject.CompareTag("Floor"))
        {
            onFloor = true;
        }

    }

    public virtual void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            onFloor = false;
        }
    }
}
