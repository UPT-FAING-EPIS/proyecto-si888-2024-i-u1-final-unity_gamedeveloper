using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vida : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            bool VidaRecuperada = GameManager.Instance.RecuperarVida();
            if (VidaRecuperada)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
