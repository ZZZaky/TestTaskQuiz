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
    public LastUnfinishedTheme lastTheme;


    void Awake()
    {
        Debug.Log($"Savable files located in: [{Application.persistentDataPath}]");
        LoadFromJson();
        CheckHints();
    }

    void Update()
    {
        SaveToJson();
    }

    public void CheckHints()
    {
        if (lastEnter != DateTime.Now.Day)
        {
            lastEnter = DateTime.Now.Day;

            hints += 4;
        }
    }

    public void SaveToJson()
    {
        SavableData toSave = new SavableData(allThemes, coins, hints, lastEnter, lastTheme);

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
            lastTheme = toLoad.lastTheme;
        }
        Debug.Log($"id: {lastTheme.id}");
    }
}



[System.Serializable]
public class SavableData
{
    public int coins;
    public int hints;
    public int lastEnter;
    public Themes themes;
    public LastUnfinishedTheme lastTheme;

    public SavableData() {}
    public SavableData(Themes themes, int coins, int hints, int lastEnter, LastUnfinishedTheme lastTheme)
    {
        this.themes = themes;
        this.coins = coins;
        this.hints = hints;
        this.lastEnter = lastEnter;
        this.lastTheme = lastTheme;
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


[System.Serializable]
public class LastUnfinishedTheme
{
    public int id;
    public int question;
    public List<int> userAnswers;
    public List<List<int>> usedHints;

    public LastUnfinishedTheme() 
    {
        userAnswers = new List<int>();
        usedHints = new List<List<int>>();
    }

    public LastUnfinishedTheme(int id, int question, List<int> userAnswers, List<List<int>> usedHints)
    {
        this.id = id;
        this.question = question;
        this.userAnswers = userAnswers;
        this.usedHints = usedHints;
    }

    public LastUnfinishedTheme(int id, int question, List<int> userAnswers, List<List<bool>> usedHints)
    {
        this.id = id;
        this.question = question;
        this.userAnswers = userAnswers;

        this.usedHints = new List<List<int>>();
        for (int i = 0; i < usedHints.Count; i++)
        {
            this.usedHints.Add(new List<int> { 0, 0, 0, 0 });
            for (int j = 0; j < usedHints[i].Count; j++)
            {
                this.usedHints[i][j] = usedHints[i][j] ? 1 : 0;
            }
        }
    }

    public void Clear()
    {
        id = -1;
        question = -1;
        userAnswers = null;
        usedHints = null;
    }
}