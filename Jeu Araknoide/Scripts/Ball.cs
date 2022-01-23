using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{
    public float speed = 15f;
    public Text scoreText;
    public Text youlooseText;
    public Text youwinText;
    public bool gameover = false;

    float hitFactor(Vector2 ballPos, Vector2 racketPos, float racketWidth)
    {
        return (ballPos.x - racketPos.x) / racketWidth;
    }

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.down * speed;

    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Blocs détruits :" + Blocks.score;
    }
    private void FixedUpdate()
    {
        if (Blocks.score == 41)
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            youwinText.text = "You win";
        }
        if (gameover == true)
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            youlooseText.text = "You loose";
        }
        Debug.Log(GetComponent<Rigidbody2D>().velocity);
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
         
        if (col.gameObject.name == "Racket")
        {
            float x = hitFactor(transform.position, col.transform.position, col.collider.bounds.size.x);
            Vector2 dir = new Vector2(x, 1).normalized;
            GetComponent<Rigidbody2D>().velocity = dir * speed;
        }

        if (col.gameObject.name == "Square")
        {
            gameover = true;
        }
    }



}
