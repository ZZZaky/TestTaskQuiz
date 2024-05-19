using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SavableInfoHandler : MonoBehaviour
{
    public Themes allThemes;
    public int coins;

    void Awake()
    {
        Debug.Log($"Savable files located in: [{Application.persistentDataPath}]");
    }

    public void SaveToJson()
    {
        SavableData toSave = new SavableData(allThemes, coins);

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
        }
    }
}



[System.Serializable]
public class SavableData
{
    public int coins;
    public Themes themes;

    public SavableData() {}
    public SavableData(Themes themes, int coins)
    {
        this.themes = themes;
        this.coins = coins;
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


    public override string ToString() => $"id: {themeId}; Title: {themeTitle}; Questions amount: {questions.Count}";
}

[System.Serializable]
public class Question
{
    public string question;
    public List<string> answers;
    public int correctAnswer;

    public string toString() => $"Question: {question}; Correct answer: {correctAnswer}";
}
#endregion
