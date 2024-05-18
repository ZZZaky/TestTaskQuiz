using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopScreenHandler : MonoBehaviour
{
    [Header("User's coins")]
    public Text coins;

    private int coinsCurrent;
    private GameObject EventSystem;

    void Awake()
    {
        EventSystem = GameObject.FindWithTag("EventSystem");

        if (EventSystem.GetComponent<SavableInfoHandler>().coins == 0)
        {
            coinsCurrent = 600;
        }
        else
        {
            coinsCurrent = EventSystem.GetComponent<SavableInfoHandler>().coins;
        }
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
