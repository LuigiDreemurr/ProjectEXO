using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuControl : MonoBehaviour {

    //This script can be placed anywhere, but is best to put it on the main camera (easier to find when setting the buttons OnClick events)
    
    public bool gamePaused = false;
    public GameObject[] pauseObjects;
    
    
    public void BtnExitGame()
    {
        Application.Quit();
    }

    void Start()
    {
        pauseObjects = GameObject.FindGameObjectsWithTag("ShowOnPause");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetButtonUp("Pause (X-Box)"))
        {
            gamePaused = !gamePaused;
        }

        if (Input.GetButtonUp("Grab") && gamePaused == true)
        {
            gamePaused = false;
        }

        if (Input.GetButtonUp("Jump") && gamePaused == true)
        {
            BtnExitGame();
        }

        if (gamePaused)
        {
            Time.timeScale = 0f;

            foreach (GameObject obj in pauseObjects)
            {
                obj.SetActive(true);
            }
        }
        else
        {
            Time.timeScale = 1f;

            foreach (GameObject obj in pauseObjects)
            {
                obj.SetActive(false);
            }
        }
    }
}
