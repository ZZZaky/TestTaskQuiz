using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextInputHandler : MonoBehaviour
{
    private InputField input;
    private TouchScreenKeyboard keyboard;

    void Start()
    {
        input = gameObject.GetComponent<InputField>();
        //var se = new InputField.SubmitEvent();
        //se.AddListener(SubmitName);
        //input.onEndEdit = se;

        //or simply use the line below, 
        input.onEndEdit.AddListener(SubmitName);  // This also works
    }

    public void OpenKeyboard()
    {
        keyboard = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default);
    }

    private void SubmitName(string arg0)
    {
        arg0.Trim();
        Debug.Log(arg0);
        if (arg0 == "")
        {
            input.text = "¬ведите...";
        }
    }
}
