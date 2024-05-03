using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public string bossName;
    public int health;

   




    public virtual void Attack()
    {
        Debug.Log($"{bossName} ataca");
    }
}
