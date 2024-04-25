using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaRegenBoostItem : Item
{
    public override Item Clone()
    {
        return Instantiate(this);
    }

    public override void ApplyEffect(PlayerObs player)
    {
        castRunes mana = player.GetComponent<castRunes>();
        if (mana != null)
        {
            mana.IncreaseManaRegen();
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