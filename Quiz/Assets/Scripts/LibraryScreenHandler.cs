using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LibraryScreenHandler : MonoBehaviour
{
    public ThemesInLibrary themesHandler;

    private GameObject eventSystem;
    private Themes allQuestions;
    


    void Start()
    {
        eventSystem = GameObject.FindWithTag("EventSystem");
        allQuestions = eventSystem.GetComponent<AllQuestions>().allThemes;

        LoadThemes();
    }

    private void LoadThemes()
    {
        foreach (Theme theme in allQuestions.themes)
        {
            themesHandler.CreateTheme(this, theme.themeId, theme.themeTitle, theme.questions.Count);
        }
    }
}
