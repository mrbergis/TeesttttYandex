using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour
{
    [SerializeField] private GameObject bricksEffectPrefab;

    public static event Action EventBarrier;
    
    private void OnTriggerEnter(Collider other)
    {
        EventBarrier?.Invoke();
        
        Destroy(gameObject);

        Instantiate(bricksEffectPrefab, transform.position, transform.rotation);
    }
}
