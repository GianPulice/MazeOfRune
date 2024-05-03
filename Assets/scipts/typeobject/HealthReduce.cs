using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthReduce : MonoBehaviour
{
    private void OnDisable()
    {
        
        Warrior warrior = FindObjectOfType<Warrior>();
        if (warrior != null)
        {
            warrior.TakeDamage(100);
        }

        
        Mage mage = FindObjectOfType<Mage>();
        if (mage != null)
        {
            mage.TakeDamage(100);
        }
    }
}
