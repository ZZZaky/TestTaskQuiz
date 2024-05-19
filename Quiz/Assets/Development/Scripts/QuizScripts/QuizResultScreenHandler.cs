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

    public void CreateResult(int quizId, List<int> answers, int hintsUsed)
    {
        QuestionsHandler.Clear();
        Theme currentTheme = EventSystem.GetComponent<SavableInfoHandler>().allThemes.themes[quizId];
        Title.text = currentTheme.themeTitle;
        MaxAnswers.text = currentTheme.questions.Count.ToString();

        userAnswers = new List<int>(answers);

        correctAnswers = new List<int>();
        foreach (Question question in currentTheme.questions)
        { correctAnswers.Add(question.correctAnswer); }

        Result = new List<bool>();
        for (int i = 0; i < correctAnswers.Count; i++)
        { Result.Add(userAnswers[i] == correctAnswers[i]); }

        AddBonuses(GenerateResult(), hintsUsed);
    }

    private int GenerateResult()
    {
        int correctAnswersCounter = 0;
        for (int i = 0; i < correctAnswers.Count; i++)
        {
            QuestionsHandler.CreateQuestion(i, userAnswers[i]);

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
        return correctAnswersCounter;
    }

    private void AddBonuses(int correctAnswersCounter, int hintsCounter)
    {
        ShopScreenHandler shopScreen = EventSystem.GetComponent<ScreensHandler>().shopScreen.GetComponent<ShopScreenHandler>();

        int plusCoins = correctAnswersCounter * shopScreen.CoinsForCorrectAnswer;
        int minusCoins = hintsCounter * shopScreen.PenaltyForUsingHint;

        shopScreen.AddCoinsForCorrectAnswer(plusCoins);
        shopScreen.RemoveCoinsForUsingHints(minusCoins);
    }
}
