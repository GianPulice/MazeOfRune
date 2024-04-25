using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ItemObserver : MonoBehaviour, IObserver
{
    public void OnItemPickup(Item item)
    {
        Debug.Log($"Player picked up {item.GetType().Name}.");
    }
}