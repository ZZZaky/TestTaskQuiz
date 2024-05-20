using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThemesInEdit : MonoBehaviour
{
    public GameObject ThemePrefab;

    private List<GameObject> themes = new List<GameObject>();

    void Awake()
    {
        themes = new List<GameObject>();
    }

    public void CreateTheme(int quizId, string title)
    {
        themes.Add(ThemePrefab);

        themes[^1].GetComponent<ThemeInEdit>().Initialization(title, quizId);
        themes[^1] = Instantiate(themes[^1], this.transform);
    }
}
