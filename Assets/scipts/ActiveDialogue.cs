using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActiveDialogue : MonoBehaviour
{
    public GameObject Dialogue;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (Dialogue != null)
            {

                Dialogue.SetActive(true);

            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (Dialogue != null)
            {

                Dialogue.SetActive(false);

            }
        }
    }
}
