using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "DetectionSettings", menuName = "ScriptableObjects/DetectionSettings", order = 1)]
public class DetectionSettings : ScriptableObject
{
    public float range = 5f;
    public float time = 1f;
}
