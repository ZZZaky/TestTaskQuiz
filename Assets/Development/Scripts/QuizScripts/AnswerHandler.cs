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

    [Header("Text color")]
    public Color RightAnswerColor;
    public Color WrongAnswerColor;
    public Color DefaultAnswerOnColor;
    public Color DefaultAnswerOffColor;

    private int clicked = 0;

    public void ResetBoxes()
    {
        answerBox1.TurnOff();
        answerBox2.TurnOff();
        answerBox3.TurnOff();
        answerBox4.TurnOff();
    }

    public void ResetHints()
    {
        ResetHintOnAnswerBox(answerBox1);
        ResetHintOnAnswerBox(answerBox2);
        ResetHintOnAnswerBox(answerBox3);
        ResetHintOnAnswerBox(answerBox4);
    }

    private void ResetHintOnAnswerBox(CheckboxConfig checkbox)
    {
        checkbox.GetComponent<Toggle>().enabled = true;
        checkbox.GetComponent<RippleConfig>().enabled = true;
        checkbox.onColor = DefaultAnswerOnColor;
        checkbox.offColor = DefaultAnswerOffColor;
        checkbox.textNormalColor = DefaultAnswerOffColor;
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

    public void SetupUsedHints(List<bool> hints, int correctAnswer)
    {
        ResetHints();
        ResetBoxes();
        
        if (hints[0])
        {
            SetupHintOnAnswerBox(answerBox1, 1, correctAnswer);
        }
        if (hints[1])
        {
            SetupHintOnAnswerBox(answerBox2, 2, correctAnswer);
        }
        if (hints[2])
        {
            SetupHintOnAnswerBox(answerBox3, 3, correctAnswer);
        }
        if (hints[3])
        {
            SetupHintOnAnswerBox(answerBox4, 4, correctAnswer);
        }

        if (hints[correctAnswer - 1])
        {
            clicked = 0;
            ToggleCheckBoxState(correctAnswer);
        }
        else if (clicked > 0)
        {
            if (!hints[clicked - 1]) 
            {
                int temp = clicked;
                clicked = 0;
                ToggleCheckBoxState(temp);
            }
        }
    }

    private void SetupHintOnAnswerBox(CheckboxConfig checkbox, int currentNumber, int correctAnswer)
    {
        checkbox.GetComponent<Toggle>().enabled = false;
        checkbox.GetComponent<RippleConfig>().enabled = false;
        if (currentNumber == correctAnswer) { checkbox.onColor = RightAnswerColor; }
        else
        {
            checkbox.offColor = WrongAnswerColor;
            checkbox.textNormalColor = WrongAnswerColor;
        }
    }

    public int GetUserAnswer()
    {
        return clicked;
    }
}
