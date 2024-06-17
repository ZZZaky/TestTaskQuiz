using UnityEngine;
using UnityEngine.UI;

public class DownPanel : MonoBehaviour
{
    [Header("Bottom panel buttons")]
    public GameObject homeIcon;
    public GameObject editIcon;
    public GameObject shopIcon;

    [Header("Bottom panel buttons' colors")]
    public Color activeButtonColor;
    public Color inactiveButtonColor;

    [Header("Screens")]
    public GameObject homeScreen;
    public GameObject editScreen;
    public GameObject shopScreen;


    void Start()
    {
        SetActiveScreen("Home");
    }

    private void ResetScreen()
    {
        homeIcon.GetComponent<Image>().color = inactiveButtonColor;
        editIcon.GetComponent<Image>().color = inactiveButtonColor;
        shopIcon.GetComponent<Image>().color = inactiveButtonColor;

        homeScreen.SetActive(false);
        editScreen.SetActive(false);
        shopScreen.SetActive(false);
    }

    private void SetActiveScreen(string screen)
    {
        ResetScreen();

        switch (screen)
        {
            case "Home":
                homeIcon.GetComponent<Image>().color = activeButtonColor;
                homeScreen.SetActive(true);
                break;
            case "Edit":
                editIcon.GetComponent<Image>().color = activeButtonColor;
                editScreen.SetActive(true);
                break;
            case "Shop":
                shopIcon.GetComponent<Image>().color = activeButtonColor;
                shopScreen.SetActive(true);
                break;
            default:
                homeIcon.GetComponent<Image>().color = activeButtonColor;
                homeScreen.SetActive(true);
                break;
        }
    }


#region functions for 3 main buttons
    public void SetActiveHome()
    {
        SetActiveScreen("Home");
    }

    public void SetActiveEdit()
    {
        SetActiveScreen("Edit");
    }

    public void SetActiveShop()
    {
        SetActiveScreen("Shop");
    }
#endregion
}
