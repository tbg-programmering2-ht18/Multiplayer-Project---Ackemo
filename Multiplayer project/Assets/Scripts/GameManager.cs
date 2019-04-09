
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public GameObject player1;
    public GameObject player2;
    public GameObject p1Wins;
    public GameObject p2Wins;

    public int P1hp;
    public int P2hp;

    public GameObject[] p1Bar;
    public GameObject[] p2Bar;
    public KeyCode scorekprShow;
    public KeyCode scorekprHide;
    public GameObject ScoreKeeper;
    
	// Update is called once per frame
	public void Update () {

        if (Input.GetKeyDown(scorekprShow))
        {
            ScoreKeeper.SetActive(true);
        }
        if (Input.GetKeyDown(scorekprHide))
        {
            ScoreKeeper.SetActive(false);
        }

        if (P1hp <= 0)
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

    public void BtnPressRestart()
    {
        player1.SetActive(true);
        Vector3 player1Pos = new Vector3(-4, -10, 0);
        player1.transform.position = player1Pos;
        P1hp = 10;
        player2.SetActive(true);
        Vector3 player2Pos = new Vector3(20, -8, 0);
        player2.transform.position = player2Pos;
        P2hp = 10;
        p1Wins.SetActive(false);
        p2Wins.SetActive(false);

    }
}
