using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadinBar : MonoBehaviour
{
    
    void Start()
    {
        PlayerPrefs.SetInt("level", 1);
    }
    void Update()
    {
        
    }
    public void loadGame()
    {
        SceneManager.LoadScene(1);
    }
}
