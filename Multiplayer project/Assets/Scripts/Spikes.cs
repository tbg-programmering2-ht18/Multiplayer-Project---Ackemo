using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour {

    
    void OnTriggerEnter2D(Collider2D other) // If other object collide with collider (Spikes in this case)
    {
        if (other.tag == "Player 1")
        {
            FindObjectOfType<GameManager>().KillPlayer1();  // Runs the function KillPlayer1 from Gamemanager;
        }
        if (other.tag == "Player 2")
        {
            FindObjectOfType<GameManager>().KillPlayer2(); // Same as before but KillPlayer2
        }
    }
}
