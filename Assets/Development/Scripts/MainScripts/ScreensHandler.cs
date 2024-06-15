using UnityEngine;
using UnityEngine.UI;

public class ScreensHandler : MonoBehaviour
{
    [Header("Screens")]
    [Header("Home")]
    public GameObject homeScreen;
    [Header("Edit")]
    public GameObject editScreens;
    public GameObject editScreen;
    public GameObject editThemeScreen;
    [Header("Shop")]
    public GameObject shopScreen;
    [Header("Quiz")]
    public GameObject quizScreens;
    public GameObject quizScreen;
    public GameObject quizSummaryScreen;
    public GameObject quizResultScreen;
    [Header("Library")]
    public GameObject libraryScreen;

    
    [Header("Bottom panel buttons")]
    public Image homeIcon;
    public Image editIcon;
    public Image shopIcon;

    [Header("Bottom panel buttons' colors")]
    public Color activeButtonColor;
    public Color inactiveButtonColor;

    public string CurrentScreen;

    void Awake()
    {
        editScreens.SetActive(true);
        quizScreens.SetActive(true);
        SetActiveScreen("Shop"); // Не фиксирует изменения монет пока не открою экран магазина (???)
        SetActiveScreen("EditTheme");
        SetActiveScreen("Home");
    }

    private void ResetScreens()
    {
        homeIcon.color = inactiveButtonColor;
        editIcon.color = inactiveButtonColor;
        shopIcon.color = inactiveButtonColor;
        CurrentScreen = "";

        homeScreen.SetActive(false);
        editScreen.SetActive(false);
        editThemeScreen.SetActive(false);
        shopScreen.SetActive(false);
        quizScreen.SetActive(false);
        quizSummaryScreen.SetActive(false);
        quizResultScreen.SetActive(false);
        libraryScreen.SetActive(false);
    }

    public void SetActiveScreen(string screen)
    {
        if ((CurrentScreen == "Quiz" && screen != "QuizSummary") || (CurrentScreen == "QuizSummary" && screen != "QuizResult" && screen != "Quiz"))
        {
            quizScreen.GetComponent<QuizScreenHandler>().SaveQuizProgress();
        }

        ResetScreens();

        switch (screen)
        {
            case "Home":
                homeIcon.color = activeButtonColor;
                homeScreen.SetActive(true);
                CurrentScreen = "Home";
                break;
            case "Edit":
                editIcon.color = activeButtonColor;
                editScreen.SetActive(true);
                CurrentScreen = "Edit";
                break;
            case "EditTheme":
                editThemeScreen.SetActive(true);
                CurrentScreen = "EditTheme";
                break;
            case "Shop":
                shopIcon.color = activeButtonColor;
                shopScreen.SetActive(true);
                CurrentScreen = "Shop";
                break;
            case "Quiz":
                quizScreen.SetActive(true);
                CurrentScreen = "Quiz";
                break;
            case "Library":
                libraryScreen.SetActive(true);
                CurrentScreen = "Library";
                break;
            case "QuizSummary":
                quizSummaryScreen.SetActive(true);
                CurrentScreen = "QuizSummary";
                break;
            case "QuizResult":
                quizResultScreen.SetActive(true);
                CurrentScreen = "QuizResult";
                break;
            default:
                homeIcon.color = activeButtonColor;
                homeScreen.SetActive(true);
                CurrentScreen = "Home";
                break;
        }
    }

    public void StartQuiz(int quizId)
    {
        SetActiveScreen("Quiz");
        quizScreen.GetComponent<QuizScreenHandler>().StartQuiz(quizId);
    }

    public void EditQuiz(int quizId)
    {
        SetActiveScreen("EditTheme");
        editThemeScreen.GetComponent<EditThemeScreen>().StartEditing(quizId);
    }

    public void ContinueQuiz()
    {
        SetActiveScreen("Quiz");
        //quizScreen.GetComponent<QuizScreenHandler>().StartQuiz(0);
        quizScreen.GetComponent<QuizScreenHandler>().LoadLastQuiz();
    }

    public void AddCoinsForCorrectAnswer(int amount)
    {
        this.gameObject.GetComponent<SavableInfoHandler>().coins += amount;
        shopScreen.GetComponent<ShopScreenHandler>().UpdateCoins();
    }

    public void RemoveCoinsForUsingHints(int amount)
    {
        this.gameObject.GetComponent<SavableInfoHandler>().coins -= amount;
        shopScreen.GetComponent<ShopScreenHandler>().UpdateCoins();
    }
}
