using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimpiarPared : MonoBehaviour

{
    public AudioClip Sound;
   private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("EsponjaInv"))
        {
            Destroy(gameObject, 0.5f);
            Camera.main.GetComponent<AudioSource>().PlayOneShot(Sound);

            Destroy(collision.gameObject, 0.5f);
        }
        
    }
}
