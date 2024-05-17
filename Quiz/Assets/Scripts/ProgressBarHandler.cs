using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarHandler : MonoBehaviour
{
    [Header("UI Element")]
    public Image image;

    [Header("Properties")]
    public int currentValue;
    public int maxValue;

    void Update() => image.fillAmount = (float) currentValue/maxValue;
    public void SetValue(int value) => this.currentValue = value;
    public void SetMaxValue(int value) => this.maxValue = value;
}
