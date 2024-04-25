using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpeedBoostItem : Item
{
    public override Item Clone()
    {
        return Instantiate(this);
    }

    public override void ApplyEffect(PlayerObs player)
    {
        characterMovment speed = player.GetComponent<characterMovment>();
        if (speed != null)
        {
            speed.IncreaseSpeed();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag("Player"))
        {
            
            PlayerObs player = other.GetComponent<PlayerObs>();

            
            if (player != null)
            {
               
                player.PickupItem(this);

                
                gameObject.SetActive(false);
            }
        }
    }
}