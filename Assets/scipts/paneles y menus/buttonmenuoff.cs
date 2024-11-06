using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonmenuoff : MonoBehaviour
{
    public GameObject panelToDeactivate;

    public void DeactivatePanel()
    {
        panelToDeactivate.SetActive(false);
    }



}
