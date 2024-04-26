using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InitialMenu : MonoBehaviour
{

    public string sceneName;
    public float delay = 2f;
    private bool countdownStarted = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !countdownStarted)
        {
            countdownStarted = true;
            Invoke("ChangeScene", delay);
        }
    }

    private void ChangeScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
