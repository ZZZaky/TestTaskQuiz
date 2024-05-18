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
    
    private GameObject EventSystem;
    private Theme currentQuiz;
    private int currentQuestion = 0;

    private List<int> answers;

    public void Update()
    {
        answers[currentQuestion] = Answers.GetUserAnswer();
        UpdateProgressBar();
    }

    public void StartQuiz(int quizId)
    {
        EventSystem = GameObject.FindWithTag("EventSystem");
        currentQuiz = EventSystem.GetComponent<AllQuestions>().allThemes.themes[quizId];
        currentQuestion = 0;

        answers = new List<int>();
        for (int i = 0; i < currentQuiz.questions.Count; i++) { answers.Add(0); }
        SetCurrentQuestion();

        Title.text = currentQuiz.themeTitle;
        QuestionTxt.text = currentQuiz.questions[currentQuestion].question;
        Answers.SetupQuestion(currentQuiz.questions[currentQuestion], answers[currentQuestion]);
        UpdateProgressBar();
    }
    
    public void NextQuestion()
    {
        if(currentQuestion != currentQuiz.questions.Count - 1) 
        {
            answers[currentQuestion] = Answers.GetUserAnswer();
            UpdateProgressBar();

            currentQuestion++;
            SetCurrentQuestion();
            QuestionTxt.text = currentQuiz.questions[currentQuestion].question;
            Answers.SetupQuestion(currentQuiz.questions[currentQuestion], answers[currentQuestion]);
        }
        else if(currentQuestion == currentQuiz.questions.Count - 1)
        {
            EventSystem.GetComponent<ScreensHandler>().SetActiveScreen("QuizSummary");
            currentQuestion++;
        }
    }

    public void PreviousQuestion()
    {
        if (currentQuestion != 0)
        {
            answers[currentQuestion] = Answers.GetUserAnswer();
            UpdateProgressBar();

            currentQuestion--;
            SetCurrentQuestion();
            QuestionTxt.text = currentQuiz.questions[currentQuestion].question;
            Answers.SetupQuestion(currentQuiz.questions[currentQuestion], answers[currentQuestion]);
        }
    }

    public void SetCurrentQuestion()
    {
        currentQuestionText.text = $"{currentQuestion + 1} / {answers.Count}";
    }

    public void UpdateProgressBar()
    {
        ProgressBar.SetValue(answers.Count((x) => x > 0));
        ProgressBar.SetMaxValue(currentQuiz.questions.Count);
    }
}
