using UnityEngine;
using UnityEngine.UI;

public class ShopScreenHandler : MonoBehaviour
{
    [Header("User's coins")]
    public Text CoinsText;

    [Header("Prices")]
    public Text HintPriceText;
    public int HintPrice;

    private GameObject EventSystem;

    void Awake()
    {
        EventSystem = GameObject.FindWithTag("EventSystem");
        HintPriceText.text = HintPrice.ToString();
        UpdateCoins();
    }

    public void UpdateCoins()
    {
        CoinsText.text = EventSystem.GetComponent<SavableInfoHandler>().coins.ToString();
    }

    public void BuyHint()
    {
        SavableInfoHandler info = EventSystem.GetComponent<SavableInfoHandler>();
        if (info.coins >= HintPrice)
        {

            info.coins -= HintPrice;
            info.hints += 1;
            UpdateCoins();
        }
    }
}
