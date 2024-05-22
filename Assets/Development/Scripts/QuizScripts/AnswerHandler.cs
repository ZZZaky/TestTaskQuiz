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
        answerBox1.GetComponent<Toggle>().enabled = true;
        answerBox1.GetComponent<RippleConfig>().enabled = true;
        answerBox1.onColor = DefaultAnswerOnColor;
        answerBox1.offColor = DefaultAnswerOffColor;
        answerBox1.textNormalColor = DefaultAnswerOffColor;

        answerBox2.GetComponent<Toggle>().enabled = true;
        answerBox2.GetComponent<RippleConfig>().enabled = true;
        answerBox2.onColor = DefaultAnswerOnColor;
        answerBox2.offColor = DefaultAnswerOffColor;
        answerBox2.textNormalColor = DefaultAnswerOffColor;

        answerBox3.GetComponent<Toggle>().enabled = true;
        answerBox3.GetComponent<RippleConfig>().enabled = true;
        answerBox3.onColor = DefaultAnswerOnColor;
        answerBox3.offColor = DefaultAnswerOffColor;
        answerBox3.textNormalColor = DefaultAnswerOffColor;

        answerBox4.GetComponent<Toggle>().enabled = true;
        answerBox4.GetComponent<RippleConfig>().enabled = true;
        answerBox4.onColor = DefaultAnswerOnColor;
        answerBox4.offColor = DefaultAnswerOffColor;
        answerBox4.textNormalColor = DefaultAnswerOffColor;
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
            answerBox1.GetComponent<Toggle>().enabled = false;
            answerBox1.GetComponent<RippleConfig>().enabled = false;
            if (1 == correctAnswer) { answerBox1.onColor = RightAnswerColor; }
            else 
            { 
                answerBox1.offColor = WrongAnswerColor;
                answerBox1.textNormalColor = WrongAnswerColor;
            }
        }
        if (hints[1])
        {
            answerBox2.GetComponent<Toggle>().enabled = false;
            answerBox2.GetComponent<RippleConfig>().enabled = false;
            if (2 == correctAnswer) { answerBox2.onColor = RightAnswerColor; }
            else
            {
                answerBox2.offColor = WrongAnswerColor;
                answerBox2.textNormalColor = WrongAnswerColor;
            }
        }
        if (hints[2])
        {
            answerBox3.GetComponent<Toggle>().enabled = false;
            answerBox3.GetComponent<RippleConfig>().enabled = false;
            if (3 == correctAnswer) { answerBox3.onColor = RightAnswerColor; }
            else
            {
                answerBox3.offColor = WrongAnswerColor;
                answerBox3.textNormalColor = WrongAnswerColor;
            }
        }
        if (hints[3])
        {
            answerBox4.GetComponent<Toggle>().enabled = false;
            answerBox4.GetComponent<RippleConfig>().enabled = false;
            if (4 == correctAnswer) { answerBox4.onColor = RightAnswerColor; }
            else
            {
                answerBox4.offColor = WrongAnswerColor;
                answerBox4.textNormalColor = WrongAnswerColor;
            }
        }

        if (hints[correctAnswer - 1])
        {
            clicked = 0;
            ToggleCheckBoxState(correctAnswer);
        }
    }

    public int GetUserAnswer()
    {
        return clicked;
    }

    public List<string> GetAnswersText()
    {
        List<string> answersText = new List<string>
        {
            answer1.text,
            answer2.text,
            answer3.text,
            answer4.text
        };

        return answersText;
    }
}
