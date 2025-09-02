using UnityEngine;

public class Musazultiempo : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)

    {
        if (collision.CompareTag("Player"))
        {
           
            Tiempo.instance.SumarTiempo(10f);

            Destroy(gameObject); 
        }
    }
}