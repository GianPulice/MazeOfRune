using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spellbook : MonoBehaviour
{

    public GameObject panel; // Assign your panel in the inspector

    void Update()
    {
        if (Input.GetKey(KeyCode.F1))
        {
            panel.SetActive(true);
        }
        else
        {
            panel.SetActive(false);
        }
    }
}


