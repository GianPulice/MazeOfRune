using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonmenu : MonoBehaviour
{


public GameObject panel;

void Start()
{
    panel.SetActive(false);
}

public void TogglePanel()
{
    panel.SetActive(!panel.activeSelf);
}




}
