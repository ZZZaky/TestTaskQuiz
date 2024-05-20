using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EditThemeScreen : MonoBehaviour
{
    public Text Title;
    public Text QuestionTxt;
    public AnswerHandler Answers;
    public Text currentQuestionText;

    private GameObject EventSystem;
    private Theme currentQuiz;

    private int currentQuestion;
    private List<int> answers;

    public void Update()
    {
        answers[currentQuestion] = Answers.GetUserAnswer();
    }

    public void StartEditing(int quizId)
    {
        EventSystem = GameObject.FindWithTag("EventSystem");
        currentQuiz = new Theme(EventSystem.GetComponent<SavableInfoHandler>().allThemes.themes[quizId]);

        currentQuestion = 0;
        answers = new List<int>();
        for (int i = 0; i < currentQuiz.questions.Count; i++) 
        {
            answers.Add(currentQuiz.questions[i].correctAnswer);
        }

        Title.text = currentQuiz.themeTitle;
        QuestionTxt.text = currentQuiz.questions[currentQuestion].question;
        Answers.SetupQuestion(currentQuiz.questions[currentQuestion], answers[currentQuestion]);
        UpdateCurrentQuestionText();
    }

    public void UpdateCurrentQuestionText()
    {
        currentQuestionText.text = $"{currentQuestion + 1} / {answers.Count}";
    }


#region Buttons
    public void NextQuestion()
    {
        if (currentQuestion != currentQuiz.questions.Count - 1)
        {
            answers[currentQuestion] = Answers.GetUserAnswer();

            currentQuestion++;
            UpdateQuestion();
        }
    }

    public void PreviousQuestion()
    {
        if (currentQuestion != 0)
        {
            answers[currentQuestion] = Answers.GetUserAnswer();

            currentQuestion--;
            UpdateQuestion();
        }
    }

    public void DeleteQuestion()
    {
        currentQuiz.questions.RemoveAt(currentQuestion);
        answers.RemoveAt(currentQuestion);

        currentQuestion = currentQuestion > 0 ? currentQuestion - 1 : 0;
        UpdateQuestion();
    }

    public void AddQuestion()
    {
        string newQuestion = "Enter question";
        List<string> newAnswers = new List<string>();
        for (int i = 0; i < 4; i++)
        {
            newAnswers.Add("Enter answer");
        }
        int newCorrectAnswer = 1;

        
        currentQuestion = currentQuiz.questions.Count;
        currentQuiz.questions.Add(new Question(newQuestion, newAnswers, newCorrectAnswer));
        answers.Add(newCorrectAnswer);
        UpdateQuestion();
    }

    public void Done()
    {
        for (int i = 0; i < answers.Count; i++)
        {
            currentQuiz.questions[i].correctAnswer = answers[i];
        }

        EventSystem.GetComponent<SavableInfoHandler>().allThemes.themes[currentQuiz.themeId] = currentQuiz;
    }

    private void UpdateQuestion()
    {
        UpdateCurrentQuestionText();
        QuestionTxt.text = currentQuiz.questions[currentQuestion].question;
        Answers.SetupQuestion(currentQuiz.questions[currentQuestion], answers[currentQuestion]);
    }
    #endregion
}
