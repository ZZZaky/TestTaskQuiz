using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizResultScreenHandler : MonoBehaviour
{
    public Text Title;
    public Text CorrectAnswers;
    public Text MaxAnswers;
    public QuestionsInQuizEndHandler QuestionsHandler;

    private GameObject EventSystem;
    private List<int> userAnswers;
    private List<int> correctAnswers;

    private List<bool> Result;

    void Awake()
    {
        EventSystem = GameObject.FindWithTag("EventSystem");
    }

    public void CreateResult(int quizId, List<int> answers)
    {
        Title.text = EventSystem.GetComponent<SavableInfoHandler>().allThemes.themes[quizId].themeTitle;
        MaxAnswers.text = EventSystem.GetComponent<SavableInfoHandler>().allThemes.themes[quizId].questions.Count.ToString();

        userAnswers = new List<int>(answers);

        correctAnswers = new List<int>();
        foreach (Question question in EventSystem.GetComponent<SavableInfoHandler>().allThemes.themes[quizId].questions)
        { correctAnswers.Add(question.correctAnswer); }

        Result = new List<bool>();
        for (int i = 0; i < correctAnswers.Count; i++)
        { Result.Add(userAnswers[i] == correctAnswers[i]); }

        GenerateResult();
    }

    private void GenerateResult()
    {
        int correctAnswersCounter = 0;
        for (int i = 0; i < correctAnswers.Count; i++)
        {
            QuestionsHandler.CreateQuestion(i, correctAnswers[i]);

            if (userAnswers[i] == correctAnswers[i])
            {
                correctAnswersCounter++;
                QuestionsHandler.ChangeQuestionColor(i, "Correct");
            }
            else
            {
                QuestionsHandler.ChangeQuestionColor(i, "Wrong");
            }
        }

        CorrectAnswers.text = correctAnswersCounter.ToString();
    }
}
