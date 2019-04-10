
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
        // 2 simple button presses to display or hide the ScoreKeeper object
        if (Input.GetKeyDown(scorekprShow))
        {
            ScoreKeeper.SetActive(true);
        }
        if (Input.GetKeyDown(scorekprHide))
        {
            ScoreKeeper.SetActive(false);
        }

        // Simple funktion to "kill" the player if hp(Health point) is less or equal to 0
        if (P1hp <= 0)
        {
            player1.SetActive(false);   // The object "player1" isn't destroyed, just hidden
            p2Wins.SetActive(true);     // Activates a screen object in the Canvas displays

        }

        if (P2hp <= 0)
        {
            player2.SetActive(false);   // Same structure as for player one
            p1Wins.SetActive(true);     // Same as for p2Wins structure
        }
    }
    public void HurtP1() // These funktions are used in Weapon.cs
    {
        P1hp -= 1; // Takes away 1 value from decided value in unity (Can be set here aswell, just easier to work with values in unity)
        for(int i = 0; i < p1Bar.Length; i++) // Creates an list object without specific value. Decided in unity by adding objects to list
        {
            if (P1hp > i){

                p1Bar[i].SetActive(true);   //Activates the HPbar's hp values (light green boxes)
            }else
            {
                p1Bar[i].SetActive(false);  // Each time P1 takes damage, one box deactivates
            }
        }
    }
    public void HurtP2() // Same function as above, just different names!
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
    public void KillPlayer1()
    {
        P1hp = 0;
    }
    public void KillPlayer2()
    {
        P2hp = 0;
    }

    public void BtnPressRestart() // Resets each players position and Hp value, (Known issue: Boxes don't reactivate until taken one hit damage!)
    {
        player1.SetActive(true);    // Reactivate player1
        Vector3 player1Pos = new Vector3(-4, -10, 0);   // Decides player1 starting position
        player1.transform.position = player1Pos;    // Place player1 on starting position
        P1hp = 10;  // Sets player1 hp back to 10
        player2.SetActive(true);    // Same as player1 
        Vector3 player2Pos = new Vector3(20, -8, 0);
        player2.transform.position = player2Pos;
        P2hp = 10;
        p1Wins.SetActive(false);    //Deactivates victory screens
        p2Wins.SetActive(false);

    }
}
