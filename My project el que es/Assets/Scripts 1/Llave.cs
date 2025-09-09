using UnityEngine;

public class Llave : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameManager.instance.TomarLlave(); 
            Destroy(gameObject); 
        }
    }
}