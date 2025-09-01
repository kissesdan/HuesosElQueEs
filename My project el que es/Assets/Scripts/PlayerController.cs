using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rb2d;
    [SerializeField] private float velocidad = 5f;
    [SerializeField] private float fuerzaSalto = 4f;

    private bool enSuelo = true;

    void Update()
    {
        // Movimiento horizontal
        float move = 0;

        if (Input.GetKey(KeyCode.RightArrow))
            move = 1;
        else if (Input.GetKey(KeyCode.LeftArrow))
            move = -1;

        // Solo cambiamos la velocidad en X, mantenemos la Y
        _rb2d.linearVelocity = new Vector2(move * velocidad, _rb2d.linearVelocity.y);

        // Salto
        if (Input.GetKeyDown(KeyCode.Space) && enSuelo)
        {
            _rb2d.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
        }
    }
}