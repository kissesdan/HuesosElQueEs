using UnityEngine;

public class Puerta : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && GameManager.instance.tieneLlave)
        {
            GameManager.instance.GanarJuego(); 
        }
    }
}
