using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class intro : MonoBehaviour

{

void Start()
{
    Invoke("ChangeScene", 2.0f);
}

void ChangeScene()
{
    SceneManager.LoadScene("Menu");
}
}

