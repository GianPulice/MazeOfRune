using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateFactory : ItemFactory
{
    public Item CreateSpeedBoostItem()
    {
        return new SpeedBoostItem();
    }

    public Item CreateManaRegenBoostItem()
    {
        return new ManaRegenBoostItem();
    }
}
