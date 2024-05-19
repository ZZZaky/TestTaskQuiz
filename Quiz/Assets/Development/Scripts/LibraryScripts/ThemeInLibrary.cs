using UnityEngine;
using UnityEngine.UI;

public class ThemeInLibrary : MonoBehaviour
{
    public Text TitleText;
    public Text QuestionCounterText;
    public Button button;

    private int quizId;
    private ScreensHandler EventSystem;

    void Awake()
    {
        EventSystem = GameObject.FindWithTag("EventSystem").GetComponent<ScreensHandler>();
    }

    public void Initialization(string title, int counter, int quizId)
    {
        TitleText.text = title;
        QuestionCounterText.text = counter.ToString();

        this.quizId = quizId;
    }

    public void StartQuiz()
    {
        EventSystem.StartQuiz(quizId);
    }
}
