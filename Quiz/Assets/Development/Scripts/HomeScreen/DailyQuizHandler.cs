using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DailyQuizHandler : MonoBehaviour
{
    private GameObject EventSystem;

    [Header("Daily Quizes on scene")]
    public List<Text> Title;
    public List<Text> QuestionCount;

    private int[] themesId = { -1, -1, -1};


    void Start()
    {
        EventSystem = GameObject.FindWithTag("EventSystem");
        Themes allquizes = EventSystem.GetComponent<AllQuestions>().allThemes;

        System.DateTime theTime = System.DateTime.Now;
        int keyForSelection = theTime.Year + theTime.Month + theTime.Day;

        for (int i = 0; i < Title.Count; i++)
        {
            Title[i].text = allquizes.themes[(keyForSelection + i) % allquizes.themes.Count % 7].themeTitle;
            QuestionCount[i].text = allquizes.themes[(keyForSelection + i) % allquizes.themes.Count % 7].questions.Count.ToString();
            themesId[i] = allquizes.themes[(keyForSelection + i) % allquizes.themes.Count % 7].themeId;
        }
    }

    public void StartQuiz(int number)
    {
        EventSystem.GetComponent<ScreensHandler>().StartQuiz(themesId[number]);
    }
}