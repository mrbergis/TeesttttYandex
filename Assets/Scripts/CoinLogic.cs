using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinLogic : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 180;
    
    void Update()
    {
        transform.Rotate(0, rotationSpeed * Time.deltaTime,0);
    }

    private void OnTriggerEnter(Collider other)
    {
        FindObjectOfType<CoinManager>()?.AddOne();

        Debug.Log(other.name);
        Destroy(gameObject);
    }
}
