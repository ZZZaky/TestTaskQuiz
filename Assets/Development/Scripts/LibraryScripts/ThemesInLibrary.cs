using System.Collections.Generic;
using UnityEngine;

public class ThemesInLibrary : MonoBehaviour
{
    public GameObject ThemePrefab;

    private List<GameObject> themes;

    void Awake()
    {
        themes = new List<GameObject>();
    }

    public void CreateTheme(int quizId, string title, int questionCount)
    {
        themes.Add(ThemePrefab);

        themes[^1].GetComponent<ThemeInLibrary>().Initialization(title, questionCount, quizId);
        themes[^1] = Instantiate(themes[^1], this.transform);
    }
}
