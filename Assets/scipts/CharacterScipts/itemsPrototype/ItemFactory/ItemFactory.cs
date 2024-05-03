using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ItemFactory
{
    Item CreateSpeedBoostItem();
    Item CreateManaRegenBoostItem();
}