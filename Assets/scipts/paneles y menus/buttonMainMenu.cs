using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttonMainMenu : MonoBehaviour
{


public void GoToMenuScene() 
{
    SceneManager.LoadScene("Menu");
}

public void GoToGame() 
{
    SceneManager.LoadScene("Game");
}



}
