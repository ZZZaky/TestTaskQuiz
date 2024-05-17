using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopScreenHandler : MonoBehaviour
{
    [Header("User's coins")]
    public Text coins;
    private int coinsCurrent = 600;

    void Start()
    {
        UpdateCoins();
    }

    private void UpdateCoins()
    {
        coins.text = coinsCurrent.ToString();
    }

    public void ChangeCoins(int amount)
    {
        coinsCurrent += amount;
        UpdateCoins();
    }


}
