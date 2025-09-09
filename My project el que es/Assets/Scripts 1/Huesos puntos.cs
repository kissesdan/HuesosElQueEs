using UnityEngine;

public class Huesospuntos : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameManager.instance.SumarPuntos(1);
            Destroy(gameObject);
        }
    }
}