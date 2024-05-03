using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveBoss : MonoBehaviour
{
    public GameObject objectToActivate1; 
    public GameObject objectToActivate2;
    public GameObject objectToActivate3;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (objectToActivate1 != null)
            {
                objectToActivate1.SetActive(true);
            }

            if (objectToActivate2 != null)
            {
                objectToActivate2.SetActive(true);
            }

            if (objectToActivate3 != null)
            {
                objectToActivate3.SetActive(true);
            }
        }
    }
}
