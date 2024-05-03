using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour, IObserver
{

    private PlayerObs player;
    private ItemFactory itemFactory;

    private void Awake()
    {
        player = FindObjectOfType<PlayerObs>();
        player.RegisterObserver(this);
        itemFactory = new CreateFactory();
    }

    public void OnItemPickup(Item item)
    {
        Debug.Log("Item  " + item.GetType().Name);

        
    }

    public void CreateSpeedBoostItem(Vector3 position)
    {
        Item speedBoostItem = itemFactory.CreateSpeedBoostItem();
        Instantiate(speedBoostItem, position, Quaternion.identity);
    }

    
    public void CreateManaRegenBoostItem(Vector3 position)
    {
        Item manaRegenBoostItem = itemFactory.CreateManaRegenBoostItem();
        Instantiate(manaRegenBoostItem, position, Quaternion.identity);
    }
}

