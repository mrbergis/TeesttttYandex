using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance = null;

    public static event Action GoToPlay;
    
    [SerializeField] private GameObject startMenu;
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
    
    public void Play()
    {
        startMenu.SetActive(false);
        GoToPlay?.Invoke();
    }
    
}
