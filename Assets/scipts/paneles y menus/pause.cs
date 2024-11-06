using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pause : MonoBehaviour
{
public GameObject panel; // Assign your panel in the inspector
public GameObject enemys;

private bool isPaused = false;
private bool isenemys = true;

void Update()
{
    if (Input.GetKeyDown(KeyCode.Escape))
    {
        isPaused = !isPaused;
        panel.SetActive(isPaused);

        isenemys = !isenemys;
        enemys.SetActive(isenemys);

    }
}


}
