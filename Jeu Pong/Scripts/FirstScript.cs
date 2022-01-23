using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FirstScript : MonoBehaviour
{
    // Start is called before the first frame update
    public int x = 0;
    public int y = 0;
    public Text scorerightText;
    public Text scoreleftText;
    public Text RightplayerwonText;
    public Text LeftplayerwonText;
    string leftplayerwon = "Left Player Won";
    string rightplayerwon = "Right Player Won";
    int scoreRight;
    int scoreLeft;
    public float speed = 12f;
    float hitFactor(Vector2 ballPos, Vector2 racketPos, float racketHeight)
    {
        return (ballPos.y - racketPos.y) / racketHeight;
    }
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;
    }

    // Update is called once per frame
    void Update()
    {
        float hitFactor(Vector2 ballPos, Vector2 racketPos, float racketHeight)
        {
            return (ballPos.y - racketPos.y) / racketHeight;
        }
        
    }
    void FixedUpdate()
    {
             
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "RacketLeft")
        {
            float y = hitFactor(transform.position,col.transform.position,col.collider.bounds.size.y);
            
            Vector2 dir = new Vector2(1, y).normalized;

            GetComponent<Rigidbody2D>().velocity = dir * speed;

        }
        if (col.gameObject.name == "RacketRight")
        {
            float y = hitFactor(transform.position,col.transform.position,col.collider.bounds.size.y);

            Vector2 dir = new Vector2(-1, y).normalized;

            GetComponent<Rigidbody2D>().velocity = dir * speed;
        }
        if (col.gameObject.name == "Wallleft")
        {
            scoreRight++;
            scorerightText.text = scoreRight.ToString();
            x++;
            if (x == 3)
            {
                GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                RightplayerwonText.text = rightplayerwon;
            }
        }
        if (col.gameObject.name == "Wallright")
        {
            scoreLeft++;
            scoreleftText.text = scoreLeft.ToString();
            y++;
            if (y == 3)
            {
                GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                LeftplayerwonText.text = leftplayerwon;
            }
        } 
        if (col.gameObject.name == "Wallright" || col.gameObject.name == "Wallleft")
        {
            speed++;
        }
    }

}
