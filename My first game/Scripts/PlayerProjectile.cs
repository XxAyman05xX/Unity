using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerProjectile : MonoBehaviour
{    void Start()
    {
        
    }
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "Alien" || col.gameObject.name == "Bordhaut")
        {
            Destroy(gameObject);
        }
    }
}

