using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class QuizScreenHandler : MonoBehaviour
{
    public Text Title;
    public Text QuestionTxt;
    public AnswerHandler Answers;
    public ProgressBarHandler ProgressBar;
    public Text currentQuestionText;
    public Text hintsAmountText;

    private GameObject EventSystem;
    private Theme currentQuiz;
    private int currentQuestion;
    private int quizId;

    private int hintsUsed;

    private List<int> answers;
    private List<List<bool>> hints;

    void Update()
    {
        answers[currentQuestion] = Answers.GetUserAnswer();
        UpdateProgressBar();
        SaveQuizProgress();
    }

    #region Starting quiz
    public void StartQuiz(int quizId)
    {
        this.quizId = quizId;
        EventSystem = GameObject.FindWithTag("EventSystem");
        currentQuiz = EventSystem.GetComponent<SavableInfoHandler>().allThemes.themes[quizId];
        currentQuestion = 0;

        answers = new List<int>();
        for (int i = 0; i < currentQuiz.questions.Count; i++) { answers.Add(0); }
        UpdateCurrentQuestionText();

        hintsUsed = 0;
        hints = new List<List<bool>>();
        for (int i = 0; i < currentQuiz.questions.Count; i++)
        {
            hints.Add(new List<bool>{false, false, false, false});
        }
        UpdateHintsAmount();

        Title.text = currentQuiz.themeTitle;
        UpdateQuestion();
    }

    public void LoadLastQuiz()
    {
        EventSystem = GameObject.FindWithTag("EventSystem");
        if (EventSystem.GetComponent<SavableInfoHandler>().lastTheme.id != -1)
        {
            LastUnfinishedTheme lastQuiz = EventSystem.GetComponent<SavableInfoHandler>().lastTheme;
            quizId = lastQuiz.id;
            currentQuiz = EventSystem.GetComponent<SavableInfoHandler>().allThemes.themes[quizId];
            currentQuestion = lastQuiz.question;

            answers = lastQuiz.userAnswers;
            UpdateCurrentQuestionText();

            hintsUsed = 0;
            hints = new List<List<bool>>();

            for (int i = 0; i < currentQuiz.questions.Count; i++)
            {
                hints.Add(new List<bool> { false, false, false, false });
                for (int j = 0; j < 4; j++)
                {
                    hints[i][j] = lastQuiz.usedHints[i * 4 + j] == 1 ? true : false;
                    Debug.Log($"[{i * 4 + j}] :: {hints[i][j]}");
                }
            }

            for (int i = 0; i < currentQuiz.questions.Count; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (hints[i][j])
                    {
                        hintsUsed++;
                    }
                }
            }
            UpdateHintsAmount();

            Title.text = currentQuiz.themeTitle;
            UpdateQuestion();
        }
    }
    #endregion Starting quiz

    public void SaveQuizProgress()
    {
        EventSystem.GetComponent<SavableInfoHandler>().lastTheme = new LastUnfinishedTheme(quizId, currentQuestion, answers, hints);
    }

    #region UpdateInfo
    public void UpdateCurrentQuestionText()
    {
        currentQuestionText.text = $"{currentQuestion + 1} / {answers.Count}";
    }

    public void ResetCurrentQuestion()
    {
        currentQuestion = 0;
        UpdateQuestion();
    }

    public void UpdateProgressBar()
    {
        ProgressBar.SetValue(answers.Count((x) => x > 0));
        ProgressBar.SetMaxValue(currentQuiz.questions.Count);
    }

    public void UpdateHintsAmount()
    {
        hintsAmountText.text = EventSystem.GetComponent<SavableInfoHandler>().hints.ToString();
    }
    #endregion


    #region Buttons
    public void NextQuestion()
    {
        if (currentQuestion != currentQuiz.questions.Count - 1)
        {
            answers[currentQuestion] = Answers.GetUserAnswer();
            UpdateProgressBar();

            currentQuestion++;
            UpdateQuestion();
        }
        else if (currentQuestion == currentQuiz.questions.Count - 1)
        {
            EventSystem.GetComponent<ScreensHandler>().SetActiveScreen("QuizSummary");
            QuizSummaryScreenHandler quizSummary = EventSystem.GetComponent<ScreensHandler>().quizSummaryScreen.GetComponent<QuizSummaryScreenHandler>();
            quizSummary.CreateSummary(Title.text, quizId, hintsUsed);
            quizSummary.UpdateSummary(answers, hintsUsed);
        }
    }

    public void PreviousQuestion()
    {
        if (currentQuestion != 0)
        {
            answers[currentQuestion] = Answers.GetUserAnswer();
            UpdateProgressBar();

            currentQuestion--;
            UpdateQuestion();
        }
    }

    public void UseHint()
    {
        if (hints[currentQuestion].Contains(false) && EventSystem.GetComponent<SavableInfoHandler>().hints > 0)
        {
            int currentAnswer = currentQuiz.questions[currentQuestion].correctAnswer;

            System.Random rnd = new System.Random();
            int randomAnswer;

            while(true)
            {
                randomAnswer = rnd.Next(0, 4);
                if (randomAnswer != (currentAnswer - 1) && !hints[currentQuestion][randomAnswer])
                {
                    hints[currentQuestion][randomAnswer] = true;
                    hintsUsed++;
                    EventSystem.GetComponent<SavableInfoHandler>().hints--;
                    break;
                }
            }

            int answeredWithHintsCounter = 0;
            foreach (bool answer in hints[currentQuestion])
            {
                if(answer) { answeredWithHintsCounter++; }
            }
            if (answeredWithHintsCounter == 3)
            {
                hints[currentQuestion][currentAnswer - 1] = true;
            }

            Answers.SetupUsedHints(hints[currentQuestion], currentAnswer);
            UpdateHintsAmount();
        }
    }

    private void UpdateQuestion()
    {
        UpdateCurrentQuestionText();
        QuestionTxt.text = currentQuiz.questions[currentQuestion].question;
        Answers.SetupQuestion(currentQuiz.questions[currentQuestion], answers[currentQuestion]);
        Answers.SetupUsedHints(hints[currentQuestion], currentQuiz.questions[currentQuestion].correctAnswer);
    }
    #endregion
}