using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextInputHandler : MonoBehaviour
{
    private InputField input;

    void Start()
    {
        input = gameObject.GetComponent<InputField>();
        //input.onEndEdit.AddListener(SubmitName);  // This also works
    }

    //private void SubmitName(string arg0)
    //{
    //    arg0.Trim();
    //    Debug.Log($"{arg0[0]}");
    //    Debug.Log(arg0);
    //    if (arg0 == "")
    //    {
    //        input.text = "¬ведите...";
    //    }
    //}

    public string GetText()
    {
        return input.text;
    }
}
