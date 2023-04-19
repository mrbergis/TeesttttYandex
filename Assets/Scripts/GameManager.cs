using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject startMenu;
    
    public void Play()
    {
        startMenu.SetActive(false);
    }
}
