// Credits to code by GamesplusJames https://www.youtube.com/user/gamesplusjames
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOverTime : MonoBehaviour {
    public float lifeTime;

	
	// Update is called once per frame
	void Update () {
        // A simple timer that destroys given gameObject after a certain amount of time (Can be set here aswell, just easier to work with values in unity)
        lifeTime -= Time.deltaTime;
        if(lifeTime < 0)
        {
            Destroy(gameObject); // Gamebject and time is decided inside of unity
        }
	}
}
