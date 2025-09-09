using UnityEngine;

public class Musnaranjavida : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameManager.instance.CambiarVida(+1);
            Destroy(gameObject);
        }
    }
}