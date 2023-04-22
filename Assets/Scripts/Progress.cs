using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;

[System.Serializable]
public class PlayerInfo
{
    public int coins;
    public int width;
    public int height;
    public int level = 1;
}

public class Progress : MonoBehaviour
{
    public static Progress Instance = null;

    public PlayerInfo playerInfo;

    [DllImport("__Internal")]
    private static extern void SaveExtern(string date);
    
    [DllImport("__Internal")]
    private static extern void LoadExtern();

    [SerializeField] private TMP_Text playerInfoText;
    
    private void Awake()
    {
        if (Instance == null)
        {
            transform.parent = null;
            DontDestroyOnLoad(gameObject);
            Instance = this;
            LoadExtern();
        }
        else
        {
            Destroy(this);
        }
    }

    public void Save()
    {
        string jsonString = JsonUtility.ToJson(playerInfo);
        SaveExtern(jsonString);
    }

    public void SetPlayerInfo(string value)
    {
        playerInfo = JsonUtility.FromJson<PlayerInfo>(value);
        playerInfoText.text = playerInfo.coins 
                               + "\n" + playerInfo.width
                               + "\n" + playerInfo.height 
                               + "\n" + playerInfo.level;
    }
}
