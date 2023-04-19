using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    [SerializeField] private int numberOfCoinsInLevel;

    [SerializeField] private TMP_Text text;
    
    public void AddOne()
    {
        numberOfCoinsInLevel++;// numberOfCoinsInLevel+=1
        text.text = numberOfCoinsInLevel.ToString();
    }
}
