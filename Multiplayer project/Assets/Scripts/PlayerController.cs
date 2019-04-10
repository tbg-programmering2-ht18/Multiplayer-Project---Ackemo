using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float moveSpeed;
    public float jumpForce;
    private Rigidbody2D theRB;
    public KeyCode left;
    public KeyCode right;
    public KeyCode jump;
    public KeyCode attack;
    public Transform groundCheckPoint;
    public bool isGrounded;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    private Animator anim;
    public GameObject weapon;
    public Transform throwPoint;
    public float coolDown;
    public float coolDownTimer;

    // Use this for initialization
    void Start () {
        theRB = GetComponent<Rigidbody2D>();    // Finds the object with a Rigidbody2D (the player's rb)
        anim = GetComponent<Animator>();        // Finds the Animator of the player
	}
	
	// Update is called once per frame
	void Update () {

        isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, whatIsGround);   // A bool that checks if player touches ground (Is a bit big and makes the player able to jump from walls)

        if (coolDownTimer > 0)  // Cooldown timer for use of weapon
        {
            coolDownTimer -= Time.deltaTime;    // Time decided in Unity
        }

        if(coolDownTimer < 0)
        {
            coolDownTimer = 0;  //Resets timer
        }

        if (Input.GetKey(left)) // Movement
        {
            theRB.velocity = new Vector2(-moveSpeed, theRB.velocity.y); // If button left (Assigned in Unity) is pressed, changes the RB's velocity in x-axis
        } else if (Input.GetKey(right))
        {
            theRB.velocity = new Vector2(moveSpeed, theRB.velocity.y);  // If button right (Assigned in Unity) is pressed, changes the RB's velocity in x-axis
        } else
        {
            theRB.velocity = new Vector2(0, theRB.velocity.y);  // Makes sure so the player don't slide after release of buttonpress
        }
		
        if (Input.GetKeyDown(jump) && isGrounded)   //Jumping
        {
            theRB.velocity = new Vector2(theRB.velocity.x, jumpForce);  // If the button jump (Assigned in unity) and the bool isGrounded is true, the player will be able to jump based on jumpforce (Decided in unity)
        }

        if (Input.GetKeyDown(attack) && coolDownTimer == 0)     // Attacking
        {
            GameObject weaponClone = (GameObject)Instantiate(weapon, throwPoint.position, throwPoint.rotation); // If the button attack (Assigned in unity) is pressed, the weapon throws out from assigned throw point (Object in game)
            weapon.transform.localScale = transform.localScale; // Turns weapon after the way the player is facing
            anim.SetTrigger("Throw");   // Activates the animation Throw (Made in unity)
            coolDownTimer = coolDown;   // Activates the cooldown timer
            }

        if (theRB.velocity.x < 0)   // Makes a simple script to face other direction
        {
            transform.localScale = new Vector3(-2, 2, 1);   // Changes the x-scale to negative, and thus invert the sprite
        } else if (theRB.velocity.x > 0)
        {
            transform.localScale = new Vector3(2, 2, 1);    // Changes the x-scale to positive, making the player face right
        }

        anim.SetFloat("Speed", Mathf.Abs(theRB.velocity.x));    // Sets the float "Speed"(Found in unity) to the RB's velocity
        anim.SetBool("Grounded", isGrounded);   // Sets the bool "Grounded" to true if player touches ground
	}
}
