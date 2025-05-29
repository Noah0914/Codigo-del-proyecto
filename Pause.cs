using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject Stop;
    public void Pausa()
    {
        Time.timeScale = 0f;
    }
    public void Resume ()
    {
        Time.timeScale = 1f;
    }
}
