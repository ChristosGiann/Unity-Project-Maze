using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class gameStartMessage : MonoBehaviour
{

    public float fadeTime;
    private TextMeshProUGUI fadeAwayText;
    public float alphaValue;
    public float fadeAwayPerSecond;
   
    void Start()
    {
        fadeAwayText = GetComponent<TextMeshProUGUI>();
        fadeAwayPerSecond = 1/ fadeTime;
        alphaValue = fadeAwayText.color.a;
    }

    void Update()
    {
        if(fadeTime > 0)
        {
            fadeTime -= Time.deltaTime;
            alphaValue -= fadeAwayPerSecond * Time.deltaTime;
            fadeAwayText.color = new Color(fadeAwayText.color.r, fadeAwayText.color.g, fadeAwayText.color.b, alphaValue);
        }
    }
}
