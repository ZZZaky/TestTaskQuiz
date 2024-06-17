using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EditThemeScreen : MonoBehaviour
{
    public InputField Title;
    public InputField QuestionText;
    public InputAnswerHandler Answers;
    public Text QuestionCounterText;

    private GameObject EventSystem;
    private Theme currentQuiz;

    private int currentQuestion;
    private List<int> answers;

    public void Update()
    {
        currentQuiz.themeTitle = Title.text;
        currentQuiz.questions[currentQuestion].question = QuestionText.text;
        currentQuiz.questions[currentQuestion].answers = new List<string>(Answers.GetAnswersText());

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

        UpdateQuestion();
    }

    public void UpdateQuestionCounterText()
    {
        QuestionCounterText.text = $"{currentQuestion + 1} / {answers.Count}";
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
        string newQuestion = "";
        List<string> newAnswers = new List<string>();
        for (int i = 0; i < 4; i++)
        {
            newAnswers.Add("");
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
        EventSystem.GetComponent<ScreensHandler>().SetActiveScreen("Edit");
    }

    private void UpdateQuestion()
    {
        UpdateQuestionCounterText();
        QuestionText.text = currentQuiz.questions[currentQuestion].question;
        Answers.SetupQuestion(currentQuiz.questions[currentQuestion], answers[currentQuestion]);
    }
    #endregion
}
