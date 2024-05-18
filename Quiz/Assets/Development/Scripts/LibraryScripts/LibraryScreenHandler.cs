using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LibraryScreenHandler : MonoBehaviour
{
    public ThemesInLibrary themesHandler;

    private GameObject EventSystem;
    private Themes allQuestions;


    void Awake()
    {
        EventSystem = GameObject.FindWithTag("EventSystem");
        allQuestions = EventSystem.GetComponent<AllQuestions>().allThemes;
        LoadThemes();
    }

    public void LoadThemes()
    {
        Debug.Log("Loading themes...");
        foreach (Theme theme in allQuestions.themes)
        {
            themesHandler.CreateTheme(theme.themeId, theme.themeTitle, theme.questions.Count);
        }
    }
}
