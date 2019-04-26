using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

    public string mainGameScene; // Sets a public string to be able to pick a map in Unity
    public string controlsScene;

    public void StartGame()
    {
        SceneManager.LoadScene(mainGameScene);  // Press the button with the function StartGame, and the chosen level will load
    }

    public void Controls()
    {
        SceneManager.LoadScene(controlsScene); // Same thing as StartGame but for another level scene
    }

	public void QuitGame()
    {
        Debug.Log("Quit");      // Displays Quit in the debug to be sure this works!
        Application.Quit();     // Quits the game if it is built and running outside of the editor
    }
}
