using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreFinishTrigger : MonoBehaviour
{
   public static event Action EventPreFinishTrigger;
   
   private void OnTriggerEnter(Collider other)
   {
      EventPreFinishTrigger?.Invoke();
      Destroy(gameObject);
   }
}
