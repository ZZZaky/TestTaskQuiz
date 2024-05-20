using UnityEngine;

public class LibraryScreenHandler : MonoBehaviour
{
    public ThemesInLibrary themesHandler;

    private GameObject EventSystem;
    private Themes allQuestions;


    void Awake()
    {
        EventSystem = GameObject.FindWithTag("EventSystem");
        allQuestions = EventSystem.GetComponent<SavableInfoHandler>().allThemes;
        LoadThemes();
    }

    public void LoadThemes()
    {
        foreach (Theme theme in allQuestions.themes)
        {
            themesHandler.CreateTheme(theme.themeId, theme.themeTitle, theme.questions.Count);
        }
    }
}
