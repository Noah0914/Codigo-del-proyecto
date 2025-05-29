using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbrirCaja : MonoBehaviour
{
    public GameObject CajaAbierta;
    public GameObject CajaCerrada;
    public AudioClip Sound;
    
   private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Key"))
        {
            if (CajaAbierta != null) CajaAbierta.SetActive(true);
            if (CajaCerrada != null) CajaCerrada.SetActive(false);

            AudioSource audio = Camera.main.GetComponent<AudioSource>();
            if (audio != null && Sound != null)
            {
                audio.PlayOneShot(Sound);
            }

            Destroy(collision.gameObject);
        }
    }
}
