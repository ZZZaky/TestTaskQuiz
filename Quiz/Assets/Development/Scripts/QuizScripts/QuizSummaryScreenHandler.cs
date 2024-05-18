using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class QuizSummaryScreenHandler : MonoBehaviour
{
    public Text Title;
    public QuestionsInQuizEndHandler QuestionsHandler;
    public Text QuestionsProgress;

    private GameObject EventSystem;
    private int quizId;
    private List<int> userAnswers;
    private bool Created;

    void Awake()
    {
        EventSystem = GameObject.FindWithTag("EventSystem");
        userAnswers = new List<int>();
        Created = false;
    }

    public void CreateSummary(string title, int quizId)
    {
        if (!Created) 
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
            Created = true;
            UpdateProgress();
        }
    }

    public void DeleteSummary()
    {
        Created = false;
    }

    public void UpdateSummary(List<int> answers)
    {
        for(int i = 0; i < answers.Count; i++) 
        {
            QuestionsHandler.ChangeQuestionAnswer(i, answers[i]);
        }

        userAnswers = new List<int>(answers);
        UpdateProgress();
    }

    public void UpdateProgress()
    {
        int answeredQuestions = 0;
        foreach (int answer in userAnswers)
        {
            if (answer > 0)
            {
                answeredQuestions++;
            }
        }
        QuestionsProgress.text = answeredQuestions.ToString() + " / " + userAnswers.Count.ToString();
    }

#region Buttons
    public void BackToQuiz()
    {
        EventSystem.GetComponent<ScreensHandler>().SetActiveScreen("Quiz");
        EventSystem.GetComponent<ScreensHandler>().quizScreen.GetComponent<QuizScreenHandler>().ResetCurrentQuestion();
    }

    public void QuizDone()
    {
        EventSystem.GetComponent<ScreensHandler>().SetActiveScreen("QuizResult");
        EventSystem.GetComponent<ScreensHandler>().quizResultScreen.GetComponent<QuizResultScreenHandler>().CreateResult(quizId, userAnswers);
    }
#endregion
}
