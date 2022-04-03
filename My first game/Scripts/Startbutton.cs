using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Startbutton : MonoBehaviour
{
    public GameObject loadingbar;
    public GameObject loadingbar1;
    public GameObject startbutton;
    void Start()
    {
        loadingbar.SetActive(false);
        loadingbar1.SetActive(false);
        startbutton.SetActive(true);
    }

    
    void Update()
    {
        
    }
    public void startgame()
    {
        loadingbar.SetActive(true);
        loadingbar1.SetActive(true);
        startbutton.SetActive(false);
    }
}
