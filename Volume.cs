using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Volume : MonoBehaviour
{
    public Slider slider;
    public float SliderValue;
    public Image imageMute;

    void Start()
    {
        slider.value = PlayerPrefs.GetFloat("volumenAudio", 0.5f);
        AudioListener.volume = slider.value;
        imInMute();
    }
    public void ChangeSlider (float valor) {
        SliderValue = valor;
        PlayerPrefs.SetFloat("volumenAudio", SliderValue);
        AudioListener.volume = slider.value;
        imInMute();
    }
    public void imInMute ()
    {
        if(SliderValue == 0)
        {
            imageMute.enabled = true;  
        }   
        else
        {
            imageMute.enabled = false;
        }
    }

    
}
