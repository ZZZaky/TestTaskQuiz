using UnityEngine;
using UnityEngine.UI;

public class ShopScreenHandler : MonoBehaviour
{
    [Header("User's coins")]
    public Text coins;

    [Header("Bonuses")]
    public int CoinsForCorrectAnswer;
    public int PenaltyForUsingHint;

    private int coinsCurrent;
    private GameObject EventSystem;

    void Awake()
    {
        EventSystem = GameObject.FindWithTag("EventSystem");
        SavableInfoHandler savedData = EventSystem.GetComponent<SavableInfoHandler>();

        if (savedData.coins == 0)
        {
            coinsCurrent = 600;
        }
        else
        {
            coinsCurrent = savedData.coins;
        }
        UpdateCoins();
    }

    private void UpdateCoins()
    {
        coins.text = coinsCurrent.ToString();
    }

    public void AddCoinsForCorrectAnswer(int amount)
    {
        coinsCurrent += amount;
        UpdateCoins();
    }

    public void RemoveCoinsForUsingHints(int amount) 
    {
        coinsCurrent -= amount;
        UpdateCoins();
    }
}
