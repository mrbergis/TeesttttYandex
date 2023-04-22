using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void AddCoinsExtern(int value);
    
    public static CoinManager Instance = null;
    
    public int numberOfCoins;

    [SerializeField] private TMP_Text text;
    [SerializeField] private GameObject advButton;
    
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
    
    private void Start()
    {
        numberOfCoins = Progress.Instance.playerInfo.coins;
        text.text = numberOfCoins.ToString();

        transform.parent = null;
        
        GameManager.GoToExit += SaveToProgress;
    }

    private void OnDestroy()
    {
        GameManager.GoToExit -= SaveToProgress;
    }

    public void AddOne()
    {
        numberOfCoins++;// numberOfCoinsInLevel+=1
        text.text = numberOfCoins.ToString();
    }

    public void SaveToProgress()
    {
        Progress.Instance.playerInfo.coins = numberOfCoins;
    }

    public void TakeCoins(int coin)
    {
        numberOfCoins -= coin;
        Progress.Instance.playerInfo.coins = numberOfCoins;
        text.text = numberOfCoins.ToString();
    }

    public void ShowAdvButton()
    {
        AddCoinsExtern(100);
        advButton.SetActive(false);
    }

    public void AddCoins(int value)
    {
        numberOfCoins += value;
        text.text = numberOfCoins.ToString();
        SaveToProgress();
    }
}
