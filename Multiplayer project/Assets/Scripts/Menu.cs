using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

    public string mainGameScene;
    public string controlsScene;

    public void StartGame()
    {
        SceneManager.LoadScene(mainGameScene);
    }

    public void Controls()
    {
        SceneManager.LoadScene(controlsScene);
    }

	public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
