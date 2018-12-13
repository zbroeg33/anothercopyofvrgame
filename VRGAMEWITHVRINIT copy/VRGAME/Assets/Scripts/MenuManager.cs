using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    
    public GameObject[] playerArray;
    public GameObject serverMenu;
    public Text serverIP;
    private bool Toggle = true;
    

    public void StartServer()
    {
        NetworkManager.singleton.StartHost();
        serverMenu.SetActive(false);
    }

    public void StartClient()
    {
        getIP();
        NetworkManager.singleton.StartClient();
        serverMenu.SetActive(false);
    }

    private void Update()
    {
        if(SceneManager.GetActiveScene().name != "networkLobby" || SceneManager.GetActiveScene().name != "SinglePlayerLobby")
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                serverMenu.SetActive(Toggle);
                Toggle = !Toggle;

            }
        }
        
       


       
    }
    public void getIP(){
        if (serverIP.text.Length > 0 && serverIP.text!= null){
            NetworkManager.singleton.networkAddress = serverIP.text;
        }
    }

}
