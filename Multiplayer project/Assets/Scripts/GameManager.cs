
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public GameObject player1;
    public GameObject player2;

    public int P1hp;
    public int P2hp;



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(P1hp <= 0)
        {
            player1.SetActive(false);
        }

        if (P2hp <= 0)
        {
            player2.SetActive(false);
        }
    }
}
