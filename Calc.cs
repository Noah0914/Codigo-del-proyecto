using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Calc : MonoBehaviour
{
    public TextMeshProUGUI display;
    public GameObject PasaNivel;
    public GameObject textoCorrecto;
    public GameObject textoIncorrecto;

    private string claveCorrecta = "πms";

    public void VerificarRespuesta()
    {
        if (display.text == claveCorrecta)
        {
            PasaNivel.SetActive(true);
            textoCorrecto.SetActive(true);
            textoIncorrecto.SetActive(false);
        }
        else
        {
            textoIncorrecto.SetActive(true);
            textoCorrecto.SetActive(false);
        }
    }
    public void BorrarUltimo()
    {
        if (display.text.Length > 0)
            display.text = display.text.Substring(0, display.text.Length - 1);
    }
}
