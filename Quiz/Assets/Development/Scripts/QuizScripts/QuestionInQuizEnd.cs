using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionInQuizEnd : MonoBehaviour
{
    public Text questionIdText;
    public Text answerText;
    public Color CorrectAnswer;
    public Color WrongAnswer;
    public Color NeutralAnswer;

    public int questionId;
    private int answer;

    public void Initialization(int id, int answer)
    {
        questionId = id;
        questionIdText.text = questionId.ToString() + ".";

        UpdateAnswerAnswer(answer);
        UpdateAnswerColor("");
    }

    public void UpdateAnswerColor(string colorChoice)
    {
        switch (colorChoice)
        {
            case "Correct":
                answerText.color = CorrectAnswer;
                break;
            case "Wrong":
                answerText.color = WrongAnswer;
                break;
            default:
                answerText.color = NeutralAnswer;
                break;
        }
    }

    public void UpdateAnswerAnswer(int answer)
    {
        this.answer = answer;
        answerText.text = this.answer.ToString();
    }
}
