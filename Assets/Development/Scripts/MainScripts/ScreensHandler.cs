using UnityEngine;
using UnityEngine.UI;

public class ScreensHandler : MonoBehaviour
{
    [Header("Screens")]
    public GameObject homeScreen;
    public GameObject editScreen;
    public GameObject shopScreen;
    public GameObject quizScreen;
    public GameObject quizSummaryScreen;
    public GameObject quizResultScreen;
    public GameObject libraryScreen;

    
    [Header("Bottom panel buttons")]
    public Image homeIcon;
    public Image editIcon;
    public Image shopIcon;

    [Header("Bottom panel buttons' colors")]
    public Color activeButtonColor;
    public Color inactiveButtonColor;


    void Awake()
    {
        SetActiveScreen("Shop"); // Не фиксирует изменения монет пока не открою экран магазина (???)
        SetActiveScreen("Home");
    }

    private void ResetScreens()
    {
        homeIcon.color = inactiveButtonColor;
        editIcon.color = inactiveButtonColor;
        shopIcon.color = inactiveButtonColor;

        homeScreen.SetActive(false);
        editScreen.SetActive(false);
        shopScreen.SetActive(false);
        quizScreen.SetActive(false);
        quizSummaryScreen.SetActive(false);
        quizResultScreen.SetActive(false);
        libraryScreen.SetActive(false);
    }

    public void SetActiveScreen(string screen)
    {
        ResetScreens();

        switch (screen)
        {
            case "Home":
                homeIcon.color = activeButtonColor;
                homeScreen.SetActive(true);
                break;
            case "Edit":
                editIcon.color = activeButtonColor;
                editScreen.SetActive(true);
                break;
            case "Shop":
                shopIcon.color = activeButtonColor;
                shopScreen.SetActive(true);
                break;
            case "Quiz":
                quizScreen.SetActive(true);
                break;
            case "Library":
                libraryScreen.SetActive(true);
                break;
            case "QuizSummary":
                quizSummaryScreen.SetActive(true);
                break;
            case "QuizResult":
                quizResultScreen.SetActive(true);
                break;
            default:
                homeIcon.color = activeButtonColor;
                homeScreen.SetActive(true);
                break;
        }
    }

    public void StartQuiz(int quizId)
    {
        SetActiveScreen("Quiz");
        quizScreen.GetComponent<QuizScreenHandler>().StartQuiz(quizId);
    }
}
