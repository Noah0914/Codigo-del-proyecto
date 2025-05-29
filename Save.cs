using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Save : MonoBehaviour
{
    public GameObject CajaAbierta;
    public GameObject CajaCerrada;
    public GameObject Key;
    public GameObject pistaResuelta;

    public void GuardarEstado()
    {
        PlayerPrefs.SetInt("CajaAbierta", CajaAbierta.activeSelf ? 1 : 0);
        PlayerPrefs.SetInt("CajaCerrada", CajaCerrada.activeSelf ? 1 : 0);
        PlayerPrefs.SetInt("KeyVisible", Key.activeSelf ? 1 : 0);
        PlayerPrefs.SetInt("PistaResuelta", pistaResuelta.activeSelf ? 1 : 0);

        PlayerPrefs.Save();
        Debug.Log("Guardado..");
    }

    public void CargarEstado()
    {
        CajaAbierta.SetActive(PlayerPrefs.GetInt("CajaAbierta", 0) == 1);
        CajaCerrada.SetActive(PlayerPrefs.GetInt("CajaCerrada", 1) == 1);
        Key.SetActive(PlayerPrefs.GetInt("KeyVisible", 1) == 1);
        pistaResuelta.SetActive(PlayerPrefs.GetInt("PistaResuelta", 0) == 1);

        Debug.Log("Juego Cargado..");
    }
}
