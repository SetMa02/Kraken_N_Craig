using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.Events;

public class Platform : MonoBehaviour
{
    public event UnityAction<Platform> DeadLineReached;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.TryGetComponent<Platform>(out Platform platform))
        {
            DeadLineReached?.Invoke(this);
        }
    }
}
