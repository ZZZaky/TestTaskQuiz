using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizResultScreenHandler : MonoBehaviour
{

    private GameObject EventSystem;
    private List<int> userAnswers;
    private List<int> correctAnswers;

    List<bool> Result;

    void Start()
    {
        EventSystem = GameObject.FindWithTag("EventSystem");
    }

    public void CreateResult(int quizId, List<int> answers)
    {
        userAnswers = new List<int>(answers);

        correctAnswers = new List<int>();
        foreach (Question answer in EventSystem.GetComponent<AllQuestions>().allThemes.themes[quizId].questions)
        { correctAnswers.Add(answer.correctAnswer); }

        Result = new List<bool>();
        for (int i = 0; i < correctAnswers.Count; i++)
        { Result.Add(userAnswers[i] == correctAnswers[i]); }
    }
}
