using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMovementStrategy
{
    Vector3 GetNextDirection(Vector3 currentPosition);
}
