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
}