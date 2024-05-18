using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class QuizSummaryScreenHandler : MonoBehaviour
{
    public Text Title;
    public QuestionsInQuizEndHandler QuestionsHandler;

    private GameObject EventSystem;
    private int quizId;
    private List<int> userAnswers;

    void Start()
    {
        EventSystem = GameObject.FindWithTag("EventSystem");
    }

    public void CreateSummary(string title, int quizId)
    {
        Title.text = title;
        this.quizId = quizId;

        userAnswers = new List<int>();
        foreach (var dummy in EventSystem.GetComponent<AllQuestions>().allThemes.themes[this.quizId].questions)
        {
            userAnswers.Add(0);
        }

        for (int i = 0; i < userAnswers.Count; i++)
        {
            QuestionsHandler.CreateQuestion(i, userAnswers[i]);
        }
    }

    public void UpdateSummary(List<int> answers)
    {
        userAnswers = new List<int>(answers);
    }
}
