using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LibraryScreenHandler : MonoBehaviour
{
    public ThemesInLibrary themesHandler;

    private GameObject eventSystem;
    private Themes allQuestions;


    void Awake()
    {
        Debug.Log("LibraryScreen awake");
        eventSystem = GameObject.FindWithTag("EventSystem");
        allQuestions = eventSystem.GetComponent<AllQuestions>().allThemes;
    }

    public void LoadThemes()
    {
        Debug.Log("Loading themes...");
        foreach (Theme theme in allQuestions.themes)
        {
            themesHandler.CreateTheme(this, theme.themeId, theme.themeTitle, theme.questions.Count);
        }
    }
}
