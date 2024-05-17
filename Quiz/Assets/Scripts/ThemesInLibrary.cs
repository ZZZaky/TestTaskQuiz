using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThemesInLibrary : MonoBehaviour
{
    public GameObject ThemePrefab;

    private List<GameObject> themes;

    void Start()
    {
        themes = new List<GameObject>();
    }

    public void CreateTheme(LibraryScreenHandler onClickDo, int quizId, string title, int questionCount)
    {
        themes.Add(ThemePrefab);

        themes[^1].GetComponent<ThemeInLibrary>().Initialization(title, questionCount, quizId);
        themes[^1] = Instantiate(themes[^1], this.transform);
    }
}
