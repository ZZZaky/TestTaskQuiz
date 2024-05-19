using MaterialUI;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class AnswerHandler : MonoBehaviour
{
    [Header("Answers' texts")]
    public Text answer1;
    public Text answer2;
    public Text answer3;
    public Text answer4;

    [Header("Answers' boxes")]
    public CheckboxConfig answerBox1;
    public CheckboxConfig answerBox2;
    public CheckboxConfig answerBox3;
    public CheckboxConfig answerBox4;

    private int clicked = 0;

    public void ResetBoxes()
    {
        answerBox1.TurnOff();
        answerBox2.TurnOff();
        answerBox3.TurnOff();
        answerBox4.TurnOff();
    }

    public void ToggleCheckBoxState(int checkBoxNumber)
    {
        clicked = (clicked == checkBoxNumber) ? 0 : checkBoxNumber;

        ResetBoxes();
        switch (clicked)
        {
            case 1:
                answerBox1.TurnOn();
                break;
            case 2:
                answerBox2.TurnOn();
                break;
            case 3:
                answerBox3.TurnOn();
                break;
            case 4:
                answerBox4.TurnOn();
                break;
            default:
                break;
        }
    }

    public void SetupQuestion(Question question, int answered)
    {
        clicked = 0;

        answer1.text = question.answers[0];
        answer2.text = question.answers[1];
        answer3.text = question.answers[2];
        answer4.text = question.answers[3];

        ToggleCheckBoxState(answered);
    }

    public int GetUserAnswer()
    {
        return clicked;
    }
}
