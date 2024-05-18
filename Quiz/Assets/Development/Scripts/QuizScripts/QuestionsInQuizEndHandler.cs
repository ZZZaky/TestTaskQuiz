using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionsInQuizEndHandler : MonoBehaviour
{
    public GameObject QuestionPrefab;

    private List<GameObject> questions;
    private GameObject EventSystem;

    void Awake()
    {
        EventSystem = GameObject.FindWithTag("EventSystem");
        questions = new List<GameObject>();
    }

    public void Clear()
    {
        questions = new List<GameObject>();
    }

    public void CreateQuestion(int questionId, int userAnswer)
    {
        questions.Add(QuestionPrefab);

        questions[^1].GetComponent<QuestionInQuizEnd>().Initialization(questionId, userAnswer);
        questions[^1] = Instantiate(questions[^1], this.transform);
    }

    public void ChangeQuestionAnswer(int questionId, int answer)
    {
        questions[questionId].GetComponent<QuestionInQuizEnd>().UpdateAnswerAnswer(answer);
    }

    public void ChangeQuestionColor(int questionId, string color)
    {
        questions[questionId].GetComponent<QuestionInQuizEnd>().UpdateAnswerColor(color);
    }
}
