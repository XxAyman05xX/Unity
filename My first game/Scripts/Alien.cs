using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Alien : MonoBehaviour
{
    public float vie = 100f;
    public Projectile projectile;
    public float speed = 3;
    float secondstowait = 2;
    bool canspawn = true;
    float timeinsec = 0;
    bool aliencanchangepos = true;
    public GameObject youwintext;
    private void Awake()
    {
        
    }
    void Start()
    {
        StartCoroutine(move1());
        youwintext.SetActive(false);
    }
    void Update()
    {
        if (vie <= 0)
        {
            Destroy(gameObject);
            Time.timeScale = 0;
            youwintext.SetActive(true);
        }
        timeinsec += Time.deltaTime;
    }
    private void FixedUpdate()
    {
        StartCoroutine(spawn());
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "bullet1")
        {
            vie -= 10;
        }
    }
    IEnumerator spawn()
    {
        if (canspawn == true)
        {
            canspawn = false;
            GameObject clone = GameObject.Instantiate(projectile).gameObject;
            clone.transform.position = GetComponentsInChildren<Transform>()[1].position;
            clone.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0,-1) * speed;
            yield return new WaitForSeconds(secondstowait);
            canspawn = true;
        }
    }
    IEnumerator move1()
    {
        while (aliencanchangepos)
        {
            Vector3 initialposition = transform.position;
            Vector3 endposition = new Vector3(Random.Range(-2.35f, 2.35f), Random.Range(1.3f, 3.8f), 0);
            float timetomove = 2;
            timeinsec = 0;
            while (timeinsec <= timetomove)
            {
                transform.position = Vector3.Lerp(initialposition, endposition, timeinsec / timetomove);
                yield return new WaitForEndOfFrame();
            }
            yield return new WaitForSeconds(2);
        }
    }
}
