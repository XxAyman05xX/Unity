using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blocks : MonoBehaviour
{
    public int vie = 0;
    public static int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        vie--;
        if (vie == 0)
        {
            score++;
            Destroy(gameObject);
            
        }
    }
}
