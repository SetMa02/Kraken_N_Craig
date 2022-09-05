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
            if (_otherBorder.transform.position.x > 0)
            {
               MovePlayer(col.gameObject, _step * -1);
            }
            else if (_otherBorder.transform.position.x < 0)
            { 
                MovePlayer(col.gameObject, _step );
            }
        }
    }

    private void MovePlayer(GameObject player, float moveStep)
    {
        var transformPosition = player.transform.position;
        transformPosition.x = _otherBorder.transform.position.x + moveStep;
        player.transform.position = transformPosition;
       
    }
}
