using System.Collections.Generic;
using UnityEngine;

public class EditScreenHandler : MonoBehaviour
{
    public ThemesInEdit themesHandler;

    private GameObject EventSystem;
    private Themes allThemes;

    void Awake()
    {
        EventSystem = GameObject.FindWithTag("EventSystem");
        allThemes = EventSystem.GetComponent<SavableInfoHandler>().allThemes;
        LoadThemes();
    }

    public void LoadThemes()
    {
        foreach (Theme theme in allThemes.themes)
        {
            themesHandler.CreateTheme(theme.themeId, theme.themeTitle);
        }
    }

    public void CreateTheme()
    {
        Theme newTheme = new Theme("", allThemes.themes[^1].themeId + 1, new List<Question>());
        newTheme.questions.Add(new Question("", new List<string>{ "", "", "", "" }, 0));
        EventSystem.GetComponent<SavableInfoHandler>().allThemes.themes.Add(newTheme);

        EventSystem.GetComponent<ScreensHandler>().EditQuiz(allThemes.themes[^1].themeId);
    }
}