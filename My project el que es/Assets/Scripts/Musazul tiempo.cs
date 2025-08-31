using UnityEngine;

public class Musazultiempo : MonoBehaviour
{
    public float tiempoExtra = 10f; 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
           
            Tiempo.instance.SumarTiempo(tiempoExtra);

            Destroy(gameObject); 
        }
    }
}