using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [Header("HUD")]
    [SerializeField] private TextMeshProUGUI textoPuntos;
    [SerializeField] private TextMeshProUGUI textoTiempo;
    [SerializeField] private Image[] corazones; 
    [SerializeField] private GameObject iconoLlave;

    // 🧠 Actualiza los corazones según la cantidad de vidas
    public void ActualizarCorazones(int vidas)
    {
        if (corazones == null || corazones.Length == 0)
        {
            Debug.LogWarning("⚠️ No hay corazones asignados en el UIManager.");
            return;
        }

        for (int i = 0; i < corazones.Length; i++)
        {
            corazones[i].enabled = i < vidas;
        }
    }

    // 🧠 Actualiza los puntos
    public void ActualizarPuntos(int puntos)
    {
        if (textoPuntos != null)
            textoPuntos.text = "Puntos: " + puntos;
    }

    // 🧠 Actualiza el tiempo
    public void ActualizarTiempo(float tiempoRestante)
    {
        if (textoTiempo != null)
        {
            int minutos = Mathf.FloorToInt(tiempoRestante / 60);
            int segundos = Mathf.FloorToInt(tiempoRestante % 60);
            textoTiempo.text = $"{minutos:00}:{segundos:00}";
        }
    }

    // 🧠 Muestra o esconde la llave
    public void MostrarLlave(bool visible)
    {
        if (iconoLlave != null)
            iconoLlave.SetActive(visible);
    }
}