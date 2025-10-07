using UnityEngine;

public class Musazultiempo : MonoBehaviour
{
    [SerializeField] private float tiempoExtra = 10f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameManager.instance.AgregarTiempo(tiempoExtra);
            Destroy(gameObject);
        }
    }
}
    