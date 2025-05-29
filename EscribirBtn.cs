using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EscribirBtn : MonoBehaviour
{
    public TextMeshProUGUI display;
    public string textoBoton;

    public void Escribir()
    {
        Debug.Log("Botón presionado: [" + textoBoton + "]");
            if (display != null)
        {
            display.text += textoBoton;
        }
        else
        {
            Debug.LogWarning("El campo 'display' no está asignado en el botón: " + gameObject.name);
        }
    }
}
