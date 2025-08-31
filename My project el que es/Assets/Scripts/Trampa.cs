using UnityEngine;

public class Trampa : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameManager.instance.CambiarVida(-1);
        }
    }
}