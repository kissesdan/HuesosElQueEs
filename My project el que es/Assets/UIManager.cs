using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEditor.Experimental.GraphView;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TMP_Text textIntroduccion;
    [SerializeField] private TMP_InputField inputField;

    private int edad;
    //si mi jugador es menor de 12 anos es un nino
    //si mi jugador es mayor a 12 anos pero menor a 18 es un adolecente
    //si mi jugador es mayor a 18 pero menor a 25 anos es un adulto joven
    //si mi jugador es mayor a 25 anos y menor a 60 anos es un adulto
    // si mi jugador es mayor a 60 anos es un adulto mayor

    //< > = >= <=
    // || &&

    private void Start()
    {
        textIntroduccion.text = "Introduce tu edad";
    }
    public void CalcularGrupo()
    {
        edad = int.Parse(inputField.text);

        switch (edad)
        {
            case 18:

                print("Tienes 18 a�os");

                break;

            case 25:
                print("Tienes 25 a�os");
                break;

            case 40:

                print("Tienes 40 a�os");
                break;
            default:

                print("Tienes otra edad");
                break;
        }


        if (edad <= 12)
        {
            Debug.Log("eres un ni�o");
        }
        else if (edad > 12 && edad <= 18)
        {
            Debug.Log("Eres un adolecente");
        }
        else if (edad > 18 && edad <= 25)
        {
            Debug.Log("Eres un adulto joven");
        }
        else if (edad > 25 && edad <= 60)
        {
            Debug.Log("Eres un adulto");
        }
        else if (edad > 60)
        {
            Debug.Log("Eres un adulto mayor");
        }



    }
}
