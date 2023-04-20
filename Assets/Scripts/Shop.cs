using System;

using UnityEngine;

public class Shop : MonoBehaviour
{
    private CoinManager _coinManager;
    
    private PlayerModifier _playerModifie;

    private void Start()
    {
        _coinManager = CoinManager.Instance;
        _playerModifie = FindObjectOfType<PlayerModifier>();
    }

    public void BuyWidth()
    {
        if (_coinManager.numberOfCoins >= 20)
        {
            _coinManager.TakeCoins(20);
            _playerModifie.SetWidth(25);
        }
    }

    public void BuyHeight()
    {
        if (_coinManager.numberOfCoins >= 20)
        {
            _coinManager.TakeCoins(20);
            _playerModifie.SetHeight(20);
        }
    }
}
