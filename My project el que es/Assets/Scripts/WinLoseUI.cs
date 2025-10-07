using UnityEngine;
using UnityEngine.SceneManagement;

public class WinLoseUI : MonoBehaviour
{
    void Start()
    {
        // Asegurarse de que el tiempo esté corriendo
        Time.timeScale = 1f;
    }

    // Reiniciar el nivel principal
    public void Reiniciar()
    {
        Time.timeScale = 1f;
        Debug.Log("Reiniciando nivel...");
        SceneManager.LoadScene("Taller"); // Cambia esto si tu escena tiene otro nombre
    }

    // Salir del juego
    public void Salir()
    {
        Time.timeScale = 1f;
        Debug.Log("Cerrando juego...");
        
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}