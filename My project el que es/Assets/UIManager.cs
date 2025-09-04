using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEditor.Experimental.GraphView;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TMP_Text textIntroduccion;
    [SerializeField] private TMP_InputField inputField;

    private int edad;
    // si mi jugador es menor a 12 años es un nino
    // si mi jugador es mayor a 12 años pero menor  a 18 años es un adolescente 
    // si mi jugador es mayor a 18 anos pero nmeor a 25 años es un adulto joven 
    // si mi jugador es mayor a 25 anos y menor a 60 anos es un adlto 
    // si mi jugador es mayor a 60 anos es un adulto mayor 

    public void Star()
    {
        {
            textIntroduccion.text = "Introduce tu edad";
        }

        public void CalcularGrupo()
        {
            edad = int.Parse(inputField.text);

            if (edad <= 12)
            {
                Debug.Log("Eres un nino");
            }
            else if (edad > 12 && edad <= 18)
            {
                Debug.Log("Eres un adolescente");
            }
            else if (edad > 18 && edad < 25)
            {
                Debug.Log("Eres un adulto joven");
            }
        
            else if (edad > 25 && edad < 60)
            {
                Debug.Log("Eres un adulto");
            }
            else if (edad > 60)
            {
                Debug.Log("Eres un adulto mayor");
            }

        }
    }



