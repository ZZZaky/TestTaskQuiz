using MaterialUI;
using System.Collections;
using System.Collections.Generic;
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

    public void ToggleCheckBox(int checkBoxNumber)
    {
        ResetBoxes();
        clicked = (clicked == checkBoxNumber) ? 0 : checkBoxNumber;

        switch (checkBoxNumber)
        {
            case 1:
                answerBox1.ToggleCheckbox();
                break;
            case 2:
                answerBox2.ToggleCheckbox();
                break;
            case 3:
                answerBox3.ToggleCheckbox();
                break;
            case 4:
                answerBox4.ToggleCheckbox();
                break;
            default:
                break;
        }
    }

    public void SetupQuestion(Question question, int answered)
    {
        clicked = 0;
        ResetBoxes();
        answer1.text = question.answers[0];
        answer2.text = question.answers[1];
        answer3.text = question.answers[2];
        answer4.text = question.answers[3];

        switch (answered)
        {
            case 1:
                answerBox1.ToggleCheckbox();
                answerBox1.TurnOn();
                break;
            case 2:
                answerBox2.ToggleCheckbox();
                answerBox2.TurnOn();
                break;
            case 3:
                answerBox3.ToggleCheckbox();
                answerBox3.TurnOn();
                break;
            case 4:
                answerBox4.ToggleCheckbox();
                answerBox4.TurnOn();
                break;
            default:
                break;
        }
        clicked = answered;
    }

    public int GetUserAnswer()
    {
        return clicked;
    }
}
