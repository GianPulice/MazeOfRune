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
        castRunes castRunes = player.GetComponent<castRunes>();
        if (castRunes != null)
        {
            castRunes.mana += 50;
            castRunes.maxMana += 30;
            Debug.Log("tuki");
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