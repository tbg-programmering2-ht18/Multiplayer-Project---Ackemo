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
        theRB = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

        isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, whatIsGround);
        if (coolDownTimer > 0)
        {
            coolDownTimer -= Time.deltaTime;
        }

        if(coolDownTimer < 0)
        {
            coolDownTimer = 0;
        }

        if (Input.GetKey(left))
        {
            theRB.velocity = new Vector2(-moveSpeed, theRB.velocity.y);
        } else if (Input.GetKey(right))
        {
            theRB.velocity = new Vector2(moveSpeed, theRB.velocity.y);
        } else
        {
            theRB.velocity = new Vector2(0, theRB.velocity.y);
        }
		
        if (Input.GetKeyDown(jump) && isGrounded)
        {
            theRB.velocity = new Vector2(theRB.velocity.x, jumpForce);
        }

        if (Input.GetKeyDown(attack) && coolDownTimer == 0)
        {
            GameObject weaponClone = (GameObject)Instantiate(weapon, throwPoint.position, throwPoint.rotation);
            weapon.transform.localScale = transform.localScale;
            anim.SetTrigger("Throw");
            coolDownTimer = coolDown;
        }

        if (theRB.velocity.x < 0)
        {
            transform.localScale = new Vector3(-2, 2, 1);
        } else if (theRB.velocity.x > 0)
        {
            transform.localScale = new Vector3(2, 2, 1);
        }

        anim.SetFloat("Speed", Mathf.Abs(theRB.velocity.x));
        anim.SetBool("Grounded", isGrounded);
	}
}
