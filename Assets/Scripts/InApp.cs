using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;

public class InApp : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void BuyCrown();
    
    [DllImport("__Internal")]
    private static extern void CheckCrown();
    
    public bool hasCrown;

    [SerializeField] private TMP_Text crownText;
    
    public static InApp Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            CheckCrown(); //проверяем, покупал он корону или нет
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void BuyCrownWithButton()
    {
        BuyCrown();
    }

    public void SetCrownTrue()
    {
        hasCrown = true;
        crownText.text = "У тебя есть корона!";
    }
}
