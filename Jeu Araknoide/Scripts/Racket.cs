using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Racket : MonoBehaviour
{
    public float speed = 5;
    public Ball ball;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        GetComponent<Rigidbody2D>().velocity = Vector2.right * h * speed;
        if (Blocks.score == 41)
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }

        if (ball.gameover == true)
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            Debug.Log("You loose");
        }
    }
}
