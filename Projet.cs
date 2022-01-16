using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projet : MonoBehaviour
{
    public float a;
    public float b;
    float c;
    float d;
    float e;
    string r = "Error";
    // Start is called before the first frame update
    void Start()
    {
        Sum(a, b);
        Prod(a, b);
        Div(a, b);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("La somme est de :" + c);
        Debug.Log("Le produit est de :" + d);
        
        if (b != 0)
        {
            Debug.Log("Le dividende est de :" + e);
        }
        else
        {
            Debug.Log("Error");
        }
    }
    float Sum(float a, float b)
    {
        return c=  a + b;
    }

    float Prod(float a, float b)
    {
        return d= a * b;
    }
    float Div(float a, float b)
    {
        return e= a / b;
            
        

    }
}
