using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class Timer : MonoBehaviour
{
    public TextMeshProUGUI time;
    private float TimeLeft;
    public int min, sec;
    void cronometro()
    {
        TimeLeft += Time.deltaTime;
        /*if(TimeLeft < 1) 
        {
            isRunning = false;   
        }*/
        int TMin = Mathf.FloorToInt(TimeLeft / 60);
        int TSec = Mathf.FloorToInt(TimeLeft % 60);
        time.text = string.Format("{00:00}:{01:00}", TMin, TSec);
    }
    void Update()
    {
        cronometro();   
    }

        
}

