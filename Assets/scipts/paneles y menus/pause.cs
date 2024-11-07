using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pause : MonoBehaviour
{
public GameObject panel; // Assign your panel in the inspector



void Update()
{
    if (Input.GetKeyDown(KeyCode.Escape))
    {
        panel.SetActive(true);

    }
}


}
