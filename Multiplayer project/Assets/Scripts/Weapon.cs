using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {
    public float ammoSpeed;
    private Rigidbody2D theRB;
    public GameObject weaponEffect;
	// Use this for initialization
	void Start () {
        theRB = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        theRB.velocity = new Vector2(ammoSpeed * transform.localScale.x, 0);
	}


    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player 1")
        {
            FindObjectOfType<GameManager>().HurtP1();
        }
        if (other.tag == "Player 2")
        {
            FindObjectOfType<GameManager>().HurtP2();
        }
        Instantiate(weaponEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
