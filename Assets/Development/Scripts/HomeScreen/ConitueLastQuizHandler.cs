using MaterialUI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ConitueLastQuizHandler : MonoBehaviour
{
    public GameObject ConitueButton;
    public Color ActiveColor;
    public Color InactiveColor;

    private GameObject EventSystem;
    private Button button;
    private Image image;
    private RippleConfig rippleConfig;


    void Start()
    {
        EventSystem = GameObject.FindWithTag("EventSystem");
        button = ConitueButton.GetComponent<Button>();
        image = ConitueButton.GetComponent<Image>();
        rippleConfig = ConitueButton.GetComponent<RippleConfig>();
    }

    void Update()
    {
        if (EventSystem.GetComponent<SavableInfoHandler>().lastTheme.id != -1)
        {
            button.enabled = true;
            rippleConfig.enabled = true;
            image.color = ActiveColor;
        }
        else
        {
            button.enabled = false;
            rippleConfig.enabled = false;
            image.color = InactiveColor;
        }    
    }
        
}
