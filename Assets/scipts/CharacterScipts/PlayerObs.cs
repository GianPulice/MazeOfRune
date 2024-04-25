using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObs : MonoBehaviour
{



    private List<IObserver> observers = new List<IObserver>();

    public void RegisterObserver(IObserver observer)
    {
        observers.Add(observer);
    }

    public void UnregisterObserver(IObserver observer)
    {
        observers.Remove(observer);
    }

    public void PickupItem(Item item)
    {
        item.ApplyEffect(this);
        NotifyObservers(item);
    }

    private void NotifyObservers(Item item)
    {
        foreach (var observer in observers)
        {
            observer.OnItemPickup(item);
        }
    }

   
}
