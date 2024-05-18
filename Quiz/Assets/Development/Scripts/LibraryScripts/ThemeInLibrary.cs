using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ThemeInLibrary : MonoBehaviour
{
    public Text TitleText;
    public Text QuestionCounterText;
    public Button button;

    private int quizId;
    private ScreensHandler eventSystem;

    void Awake()
    {
        eventSystem = GameObject.FindWithTag("EventSystem").GetComponent<ScreensHandler>();
    }

    public void Initialization(string title, int counter, int quizId)
    {
        TitleText.text = title;
        QuestionCounterText.text = counter.ToString();

        this.quizId = quizId;
    }

    public void StartQuiz()
    {
        eventSystem.StartQuiz(quizId);
    }
}
