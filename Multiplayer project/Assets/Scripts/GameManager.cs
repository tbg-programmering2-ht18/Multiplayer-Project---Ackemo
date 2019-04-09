
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public GameObject player1;
    public GameObject player2;
    public GameObject p1Wins;
    public GameObject p2Wins;

    public int P1hp;
    public int P2hp;

    public GameObject[] p1Bar;
    public GameObject[] p2Bar;

    // Use this for initialization
    void Start () {
     	
	}
	// Update is called once per frame
	void Update () {
		if(P1hp <= 0)
        {
            player1.SetActive(false);
            p2Wins.SetActive(true);
        }

        if (P2hp <= 0)
        {
            player2.SetActive(false);
            p1Wins.SetActive(true);
        }
    }
    public void HurtP1()
    {
        P1hp -= 1;
        for(int i = 0; i < p1Bar.Length; i++)
        {
            if (P1hp > i){

                p1Bar[i].SetActive(true);
            }else
            {
                p1Bar[i].SetActive(false);
            }
        }
    }
    public void HurtP2()
    {
        P2hp -= 1;
        for (int i = 0; i < p2Bar.Length; i++)
        {
            if (P2hp > i)
            {

                p2Bar[i].SetActive(true);
            }
            else
            {
                p2Bar[i].SetActive(false);
            }
        }
    }
}
