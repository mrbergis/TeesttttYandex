using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public static CoinManager Instance = null;
    
    public int numberOfCoins;

    [SerializeField] private TMP_Text text;

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
}
