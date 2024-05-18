using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AllQuestions : MonoBehaviour
{
    public Themes allThemes;

    public void SaveAllQuestionsToJson()
    {
        string themesData = JsonUtility.ToJson(allThemes);
        string filePath = Application.persistentDataPath + "/Questions.json";
        Debug.Log($"Questions saved to: {filePath}");
        System.IO.File.WriteAllText(filePath, themesData);
    }

    public void LoadAllQuestionsFromJson()
    {
        string filePath = Application.persistentDataPath + "/Questions.json";
        if (System.IO.File.Exists(filePath))
        {
            Debug.Log($"Questions loaded from: {filePath}");
            string themesData = System.IO.File.ReadAllText(filePath);
            allThemes = JsonUtility.FromJson<Themes>(themesData);
        }
    }
}

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