using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Asteroid : MonoBehaviour
{
    int sec = 3;
    void Start()
    {
        StartCoroutine(death());
    }
    void Update()
    {

    }
    private void FixedUpdate()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "Joueur")
        {
            Destroy(gameObject);
        }
    }
    IEnumerator death()
    {
        yield return new WaitForSeconds(sec);
        Destroy(gameObject);
    }

}
