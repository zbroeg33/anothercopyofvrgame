using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class menuScript : MonoBehaviour {


    public Button startText;
    public Button settingsText;
    public Button exitText;
    
    public Button backButton;

    public Text howText;

    public GameObject Canvas;
	// Use this for initialization
	void Start ()
    {
        startText = startText.GetComponent<Button>();
        settingsText = settingsText.GetComponent<Button>();
        exitText = exitText.GetComponent<Button>();
      
        
        Canvas = Canvas.GetComponent<GameObject>();

        

      
       


	}

    public void StartLevel ()
    {
        SceneManager.LoadScene("networkLobby");
    }

    public void StartVRLevel()
    {
        SceneManager.LoadScene("SinglePlayerLobby");
    }

    public void HowToPlay () {
        startText.enabled = false;
        settingsText.enabled = false;
        exitText.enabled =false;
        howText.enabled = true;
        backButton.enabled = true;
    }

    public void backToStart() {
         startText.enabled = true;
        settingsText.enabled = true;
        exitText.enabled = true;
        howText.enabled = false;
        backButton.enabled = false;
    }

    public void ExitGame()
    {
       // application.quit;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
