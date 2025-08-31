using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Tiempo : MonoBehaviour
{
    [SerializeField] private TMP_Text tiempoTexto;
    [SerializeField] private int minutos;
    [SerializeField] private float segundos;

    public bool tiempoAgotado;

    private void Start()
    {
        ActualizarTiempo();
    }

    private void Update()
    {
        if (tiempoAgotado)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            return; 
        }

        segundos -= Time.deltaTime;

        if (segundos <= 0f)
        {
            if (minutos > 0)
            {
                segundos = 59;
                minutos -= 1;
            }
            else
            {
                segundos = 0;
                minutos = 0;
                tiempoAgotado = true;
            }
        }

        ActualizarTiempo();
    }

    private void ActualizarTiempo()
    {
        tiempoTexto.text = minutos.ToString("00") + ":" + segundos.ToString("00");
    }

    public void Accion()
    {
        tiempoAgotado = true;
    }
}