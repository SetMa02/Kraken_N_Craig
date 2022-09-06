using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrackPlatform : Platform
{
   private float _speed = 3;
   
   private void OnCollisionEnter2D(Collision2D col)
   {
      if (col.gameObject.TryGetComponent<Player>(out Player player))
      {
         StartCoroutine(Crack());
      }
   }

   private IEnumerator Crack()
   {
      while (true)
      {
         gameObject.transform.position += Vector3.down * (_speed * Time.deltaTime);
         yield return null;
      }
   }
}
