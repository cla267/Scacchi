using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public Button multiplayerButton;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void EnterMultiplayer()
    {
        SceneManager.LoadScene(1);
    }
}
