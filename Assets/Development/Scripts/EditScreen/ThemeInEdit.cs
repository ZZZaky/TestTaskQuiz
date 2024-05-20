using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThemeInEdit : MonoBehaviour
{
    public Text TitleText;
    public Text IdText;

    private int quizId;
    private ScreensHandler EventSystem;

    void Awake()
    {
        EventSystem = GameObject.FindWithTag("EventSystem").GetComponent<ScreensHandler>();
    }

    public void Initialization(string title, int quizId)
    {
        TitleText.text = title;
        IdText.text = quizId.ToString();
        this.quizId = quizId;
    }

    public void StartEditing()
    {
        EventSystem.EditQuiz(quizId);
    }
}
