using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{

    [SerializeField] private Transform target;

    private void Awake()
    {
        transform.parent = null;
    }

    void LateUpdate()
    {
        if (target)
        {
            transform.position = target.position;
        }
    }
}
