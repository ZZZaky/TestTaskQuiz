using System;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SavableInfoHandler : MonoBehaviour
{
    public int coins;
    public int hints;
    public int lastEnter;
    public Themes allThemes;

    void Awake()
    {
        Debug.Log($"Savable files located in: [{Application.persistentDataPath}]");
        LoadFromJson();
        CheckHints();
    }

    public void CheckHints()
    {
        Debug.Log($"day rn [{DateTime.Now.Day}], last day [{lastEnter}]");

        if (lastEnter != DateTime.Now.Day)
        {
            lastEnter = DateTime.Now.Day;

            hints += 4;
        }
    }

    public void SaveToJson()
    {
        SavableData toSave = new SavableData(allThemes, coins, hints, lastEnter);

        string data = JsonUtility.ToJson(toSave, true);
        string filePath = Application.persistentDataPath + "/SaveQuiz.json";

        System.IO.File.WriteAllText(filePath, data);
    }

    public void LoadFromJson()
    {
        string filePath = Application.persistentDataPath + "/SaveQuiz.json";
        if (System.IO.File.Exists(filePath))
        {
            string data = System.IO.File.ReadAllText(filePath);
            SavableData toLoad = JsonUtility.FromJson<SavableData>(data);
            
            allThemes = toLoad.themes;
            coins = toLoad.coins;
            hints = toLoad.hints;
            lastEnter = toLoad.lastEnter;
        }
    }
}



[System.Serializable]
public class SavableData
{
    public int coins;
    public int hints;
    public int lastEnter;
    public Themes themes;

    public SavableData() {}
    public SavableData(Themes themes, int coins, int hints, int lastEnter)
    {
        this.themes = themes;
        this.coins = coins;
        this.hints = hints;
        this.lastEnter = lastEnter;
    }
}

#region Question's Architecture
[System.Serializable]
public class Themes
{
    public List<Theme> themes;


    public string toString()
    {
        string _return = "";
        foreach (Theme theme in themes) { _return += theme.themeTitle + "; "; }
        return _return;
    }
}

[System.Serializable]
public class Theme
{
    public string themeTitle;
    public int themeId;
    public List<Question> questions;

    public Theme() {}
    public Theme(Theme Copy)
    {
        this.themeTitle = Copy.themeTitle;
        this.themeId = Copy.themeId;
        this.questions = new List<Question>();
        foreach (Question questions in Copy.questions) 
        {
            this.questions.Add(new Question(questions));
        }
    }
    public Theme(string themeTitle, int themeId, List<Question> questions)
    {
        this.themeTitle = themeTitle;
        this.themeId = themeId;
        this.questions = questions;
    }

    public override string ToString() => $"id: {themeId}; Title: {themeTitle}; Questions amount: {questions.Count}";
}

[System.Serializable]
public class Question
{
    public string question;
    public List<string> answers;
    public int correctAnswer;

    public Question() {}
    public Question(Question Copy)
    {
        this.question = Copy.question;
        this.correctAnswer = Copy.correctAnswer;

        this.answers = new List<string>();
        for (int i = 0; i < 4; i++)
        {
            answers.Add(Copy.answers[i]);
        }
    }
    public Question(string question, List<string> answers, int correctAnswer)
    {
        this.question = question;
        this.answers = answers;
        this.correctAnswer = correctAnswer;
    }

    public string toString() => $"Question: {question}; Correct answer: {correctAnswer}";
}
#endregion
