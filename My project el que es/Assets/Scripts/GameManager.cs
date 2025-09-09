using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("UI")]
    [SerializeField] private TextMeshProUGUI puntosText;
    [SerializeField] private TextMeshProUGUI vidaText;
    [SerializeField] private TextMeshProUGUI llaveText;
    [SerializeField] private TextMeshProUGUI mensajeFinal;

    [Header("Objetos")]
    [SerializeField] private GameObject obstaculo; // Bloquea la llave

    private int puntos = 0;
    private int vida = 4;
    public bool tieneLlave = false;
    private bool juegoTerminado = false;
    
    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    private void Start()
    {
        ActualizarUI();
        mensajeFinal.gameObject.SetActive(false);
    }

    public void SumarPuntos(int cantidad)
    {
        puntos += cantidad;
        puntosText.text = "Puntos: " + puntos;

        if (puntos >= 10 && obstaculo != null)
        {
            Destroy(obstaculo);
        }
    }

    public void CambiarVida(int cantidad)
    {
        vida += cantidad;
        vidaText.text = "Vida: " + vida;

        if (vida <= 0)
        {
            ReiniciarJuego();
        }
    }

    public void TomarLlave()
    {
        tieneLlave = true;
        llaveText.text = "Llave: Sí";
    }

    public void GanarJuego()
    {
        juegoTerminado = true;
        mensajeFinal.gameObject.SetActive(true);
        mensajeFinal.text = "¡GANASTE!";
        Time.timeScale = 0f;
    }

    private void ReiniciarJuego()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void ActualizarUI()
    {
        puntosText.text = "Puntos: " + puntos;
        vidaText.text = "Vida: " + vida;
        llaveText.text = "Llave: No";
    }
}
public void EstadosDelJuego(string estado)
{
    switich(estado)
}