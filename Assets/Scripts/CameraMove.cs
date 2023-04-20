using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{

    [SerializeField] private Transform target;
    
    void LateUpdate()
    {
        if (target)
        {
            transform.position = target.position;
        }
    }
}
