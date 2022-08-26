using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Border : MonoBehaviour
{
    [SerializeField] private Border _otherBorder;
    [SerializeField] private float _step;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.TryGetComponent(out Player player))
        {
            MovePlayer(col.gameObject);
        }
    }

    private void MovePlayer(GameObject player)
    {
        if (_otherBorder.transform.position.x > 0)
        {
            var transformPosition = player.transform.position;
            transformPosition.x = _otherBorder.transform.position.x - _step;
            player.transform.position = transformPosition;
        }
        else if (_otherBorder.transform.position.x < 0)
        {
            var transformPosition = player.transform.position;
            transformPosition.x = _otherBorder.transform.position.x + _step;
            player.transform.position = transformPosition;
        }
    }
}
