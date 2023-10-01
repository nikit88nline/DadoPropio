using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dice : MonoBehaviour
{
    Rigidbody rb;
    bool enElSuelo;
    bool tirado;

    Vector3 posicionInicial;
    
    public int valorDado;

    public CarasDado[] caraDado;

    Text boton;

    Manager manager;

    void Start ()
    {
        manager = FindObjectOfType<Manager>();
        boton = GameObject.FindWithTag("boton").GetComponent<Text>();
        rb = GetComponent<Rigidbody>();
        posicionInicial = transform.position;
        rb.useGravity = false;
    }

    void Update ()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            TirarDado();
        }

        if (rb.IsSleeping() && !enElSuelo && tirado)
        {
            enElSuelo = true;
            rb.useGravity = false;
            rb.isKinematic = true;

            ValorCaraCheck();
        }

        else if(rb.IsSleeping() && enElSuelo && valorDado == 0)
        {
            TirarDeNuevo();
        }
    }

    public void TirarDado ()
    {
        if (!tirado && !enElSuelo)
        {
            boton.text = "Resetear dado";
            tirado = true;
            rb.useGravity = true;
            rb.AddTorque(Random.Range(0, 500), Random.Range(0, 500), Random.Range(0, 500));
        }

        else if(tirado && enElSuelo)
        {
            Reset();
        }
    }

    void Reset()
    {
        boton.text = "Lanzar dado";
        transform.position = posicionInicial;
        tirado = false;
        enElSuelo = false;
        rb.useGravity = false;
        rb.isKinematic = false;
    }

    void TirarDeNuevo()
    {
        Reset();

        tirado = true;
        rb.useGravity = true;
        rb.AddTorque(Random.Range(0, 500), Random.Range(0, 500), Random.Range(0, 500));
    }

    void ValorCaraCheck()
    {
        valorDado = 0;

        foreach (CarasDado cara in caraDado)
        {
            if(cara.EnElSuelo())
            {
                valorDado = cara.valorCara;
                //Debug.Log("Valor: " + valorDado);
                manager.valoresDados++;
            }
        }
    }
}
