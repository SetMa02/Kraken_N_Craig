using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringPlatform : Platform
{
   public float JumpHeight = 10;
   
   private void OnCollisionEnter2D(Collision2D col)
   {
      if (col.gameObject.TryGetComponent<Player>(out Player player))
      {
         player.Jump(JumpHeight);
      }
   }
}
