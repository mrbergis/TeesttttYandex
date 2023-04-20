using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Progress : MonoBehaviour
{
    public static Progress Instance = null;
    
    public int coins;
    public int width;
    public int height;

    private void Awake()
    {
        if (Instance == null)
        {
            transform.parent = null;
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
}
