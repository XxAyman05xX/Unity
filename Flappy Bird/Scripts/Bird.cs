using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Bird : MonoBehaviour
{
    public GameObject ReplayButton;
    public GameObject StartButton;
    public Text scoreText;
    Rigidbody2D rb2d;
    public float speed = 5f;
    [SerializeField]
    private float flapforce = 20f;
    bool isDead;
    int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        StartButton.SetActive(true);
        Time.timeScale = 0;
        ReplayButton.SetActive(false);
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = Vector2.right * speed * Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isDead)
        {
            
            rb2d.AddForce(Vector2.up * flapforce);
        }
        
    }
    private void FixedUpdate()
    {
        
    }
    public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag != "Plafond")
        {
            isDead = true;
            rb2d.velocity = Vector2.zero;
            ReplayButton.SetActive(true);
            GetComponent<Animator>().SetBool("isDead", true);
            
        }
        
    }
    public void Replay()
    {
        SceneManager.LoadScene(0);
    }
    public void Unfreeze()
    {
        Time.timeScale = 1;
        StartButton.SetActive(false);
    }
    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Score")
        {
            score++;
            scoreText.text = score.ToString();
        }
    }

}
