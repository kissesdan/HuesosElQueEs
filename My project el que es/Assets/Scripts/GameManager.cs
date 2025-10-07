using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("Referencias UI")]
    [SerializeField] private UIManager uiManager;
    [SerializeField] private GameObject panelPausa;
    [SerializeField] private GameObject botonMenu; // Botón de menú en el HUD (opcional)

    [Header("Objetos del juego")]
    [SerializeField] private GameObject obstaculo;
    
    [Header("Configuración")]
    [SerializeField] private float tiempoInicial = 60f;
    [SerializeField] private int maxVidas = 5;

    [Header("Estado del juego")]
    public string State = "Play";

    // Variables del juego
    private int puntos = 6;
    private int vida = 5;
    private float tiempo;
    public bool tieneLlave = false;

    // ---------------- SINGLETON (SIN DontDestroyOnLoad) ----------------
    void Awake()
    {
    if (instance == null)
    {
        instance = this;
    }
    else
    {
        Destroy(gameObject);
    }
}

    void Start()
    {
        // Inicializar valores del juego
        tiempo = tiempoInicial;
        vida = maxVidas;
        puntos = 0;
        tieneLlave = false;

        // Configurar estado inicial
        State = "Play";
        Time.timeScale = 1;

        // Ocultar panel de pausa al inicio
        if (panelPausa != null)
            panelPausa.SetActive(false);

        // Mostrar botón de menú si existe
        if (botonMenu != null)
            botonMenu.SetActive(true);

        // Actualizar UI inicial
        if (uiManager != null)
        {
            uiManager.ActualizarPuntos(puntos);
            uiManager.ActualizarTiempo(tiempo);
            uiManager.ActualizarCorazones(vida);
            uiManager.MostrarLlave(false);
        }
        else
        {
            Debug.LogError("⚠️ UIManager no está asignado en el GameManager!");
        }

        Debug.Log("🎮 Juego iniciado - Estado: " + State);
    }

    void Update()
    {
        // Control de pausa con Esc
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }

        // Timer solo en estado "Play"
        if (State == "Play")
        {
            tiempo -= Time.deltaTime;
            
            if (uiManager != null)
                uiManager.ActualizarTiempo(tiempo);

            // Si el tiempo llega a 0, pierde
            if (tiempo <= 0)
            {
                tiempo = 0;
                SetState("Lose");
            }
        }
    }

    // ---------------- SISTEMA DE ESTADOS ----------------
    public void SetState(string next)
    {
        Debug.Log($" Cambiando estado: {State} → {next}");
        State = next;

        switch (State)
        {
            case "Play":
                Time.timeScale = 1;
                if (panelPausa != null) panelPausa.SetActive(false);
                if (botonMenu != null) botonMenu.SetActive(true);
                break;

            case "Pause":
                Time.timeScale = 0;
                if (panelPausa != null) panelPausa.SetActive(true);
                if (botonMenu != null) botonMenu.SetActive(false);
                break;

            case "Win":
                Time.timeScale = 1;
                Debug.Log(" ¡VICTORIA! Cargando escena Win...");
                SceneManager.LoadScene("Win");
                break;

            case "Lose":
                Time.timeScale = 1;
                Debug.Log(" Game Over. Cargando escena Lose...");
                SceneManager.LoadScene("Lose");
                break;

            case "Exit":
                Time.timeScale = 1;
                Debug.Log(" Saliendo del juego...");
                #if UNITY_EDITOR
                    UnityEditor.EditorApplication.isPlaying = false;
                #else
                    Application.Quit();
                #endif
                break;
        }
    }

    // ---------------- MÉTODOS DE PAUSA ----------------
    public void TogglePause()
    {
        if (State == "Play")
            SetState("Pause");
        else if (State == "Pause")
            SetState("Play");
    }

    public void ResumeFromUI()
    {
        SetState("Play");
    }

    public void QuitFromUI()
    {
        SetState("Exit");
    }

    public void AbrirMenuPausa()
    {
        if (State == "Play")
            SetState("Pause");
    }

    // ---------------- LÓGICA DEL JUEGO ----------------
    public void SumarPuntos(int cantidad)
    {
        puntos += cantidad;

        if (uiManager != null)
            uiManager.ActualizarPuntos(puntos);

        Debug.Log($"🦴 Puntos: {puntos}/10");

        // Destruir obstáculo al llegar a 10 puntos
        if (puntos >= 10 && obstaculo != null)
        {
            Destroy(obstaculo);
            Debug.Log(" ¡Obstáculo destruido! Puedes avanzar a la llave");
        }
    }

    public void CambiarVida(int cantidad)
    {
        vida += cantidad;
        vida = Mathf.Clamp(vida, 0, maxVidas);

        if (uiManager != null)
            uiManager.ActualizarCorazones(vida);

        Debug.Log($" Vidas: {vida}/{maxVidas}");

        // Si la vida llega a 0, pierde
        if (vida <= 0)
        {
            SetState("Lose");
        }
    }

    public void TomarLlave()
    {
        tieneLlave = true;

        if (uiManager != null)
            uiManager.MostrarLlave(true);

        Debug.Log(" ¡Llave obtenida! Ahora ve a la puerta");
    }

    public void AgregarTiempo(float cantidad)
    {
        tiempo += cantidad;

        if (uiManager != null)
            uiManager.ActualizarTiempo(tiempo);

        Debug.Log($" +{cantidad}s de tiempo (Total: {Mathf.Ceil(tiempo)}s)");
    }

    public void GanarJuego()
    {
        // Solo gana si tiene la llave Y los 10 puntos
        if (tieneLlave && puntos >= 10)
        {
            SetState("Win");
        }
        else
        {
            string mensaje = " No puedes pasar. Necesitas: ";
            if (!tieneLlave) mensaje += "[Llave] ";
            if (puntos < 10) mensaje += $"[{10 - puntos} huesos más]";
            Debug.Log(mensaje);
        }
    }

    public void ReiniciarNivel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(2);
    }
}