using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarasDado : MonoBehaviour
{
    bool enElSuelo;

    public int valorCara;
    void OnTriggerStay(Collider col)
    {
        if(col.tag == "suelo")
        {
            enElSuelo = true;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if(col.tag == "suelo")
        {
            enElSuelo = false;
        }
    }

    public bool EnElSuelo()
    {
        return enElSuelo;
    }
}
