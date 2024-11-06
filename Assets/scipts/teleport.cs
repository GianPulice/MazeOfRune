using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleport : MonoBehaviour
{
public GameObject teleportTarget;

void OnTriggerEnter2D(Collider2D other) // Cambiado a Collider2D
{
    other.transform.position = teleportTarget.transform.position;
}



}
