// Credits to code by GamesplusJames https://www.youtube.com/user/gamesplusjames
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {
    public float ammoSpeed;
    private Rigidbody2D theRB;
    public GameObject weaponEffect;
	// Use this for initialization <- auto generated comment and function by Unity
	void Start () {
        theRB = GetComponent<Rigidbody2D>(); // Locates the component Rigidbody2D of asigned object (Decided in unity)
	}
	
	// Update is called once per frame <- auto generated comment and function by Unity
	void Update () {
        theRB.velocity = new Vector2(ammoSpeed * transform.localScale.x, 0);    // Creates a movement for the weapon (Known Error: weapon don't turn with player so can induce self harm)
	}


    void OnTriggerEnter2D(Collider2D other) // If weapon collide with other object this function activates
    {
        if(other.tag == "Player 1")     // Defines object by tag (Decided in unity)
        {
            FindObjectOfType<GameManager>().HurtP1(); // Using the function in Gamemanager
        }
        if (other.tag == "Player 2")
        {
            FindObjectOfType<GameManager>().HurtP2();
        }
        Instantiate(weaponEffect, transform.position, transform.rotation);  // Instantiate the weaponeffect, position and rotation (Values decided in Unity)
        Destroy(gameObject);    // Destroys the object (Weapon, not player)
    }
}
