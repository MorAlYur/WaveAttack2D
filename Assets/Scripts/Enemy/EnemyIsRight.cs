using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIsRight : MonoBehaviour
{
    public bool IsRight = true;

    public void Rot()
    {
        IsRight = !IsRight;
    }
}
