using UnityEngine;
using UnityEngine.UI;

public class HomeScreenHandler : MonoBehaviour
{
    private GameObject EventSystem;

    public Text HintsText;

    void Awake()
    {
        EventSystem = GameObject.FindWithTag("EventSystem");
    }

    void Update()
    {
        HintsText.text = EventSystem.GetComponent<SavableInfoHandler>().hints.ToString();
    }
}
