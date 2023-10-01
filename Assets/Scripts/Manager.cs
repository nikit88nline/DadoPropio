using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    public Dice dado1;
    public Dice dado2;

    public int valorDado1;
    public int valorDado2;

    public bool dobles;

    public Text textoValoresFinales;

    public int valoresDados = 0;

    private void Update() 
    {
        if(valoresDados == 2)
        {
            JuntarValoresDados();
        }
    }
    public void JuntarValoresDados()
    {
        valorDado1 = dado1.valorDado;
        valorDado2 = dado2.valorDado;

        if(valorDado1 == valorDado2 && valorDado1 != 0 && valorDado2 != 0)
        {
            dobles = true;
            textoValoresFinales.text = "Dado 1: " + valorDado1 +
                                        "\nDado 2: " + valorDado2 +
                                        "\nDobles: Sí";
        }

        else
        {
            dobles = false;
            textoValoresFinales.text = "Dado 1: " + valorDado1 +
                                        "\nDado 2: " + valorDado2 +
                                        "\nDobles: No";
        }
    }
}
