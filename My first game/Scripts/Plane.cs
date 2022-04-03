using System.Collections;
using UnityEngine;

public class Plane : MonoBehaviour
{
    public PlayerProjectile projectile;
    public int speed = 15;
    public float secondstowait = 1;
    bool canspawn = true;
    float vie = 100f;
    float timeinsec = 0;
    public GameObject youloosetext;
    private void Awake()
    {
        youloosetext.SetActive(false);
    }
    void Start()
    {

    }
    void Update()
    {
        timeinsec += Time.deltaTime;
        if (vie <= 0)
        {
            Destroy(gameObject);
            Time.timeScale = 0;
            youloosetext.SetActive(true);
        }
    }
    private void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            StartCoroutine(spawn());
        }
        StartCoroutine(move());
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "bullet2")
        {
            vie -= 35;
        }
        if (collision.gameObject.tag == "asteroid")
        {
            vie -= 100;
        }
        if (collision.gameObject.tag == "Missile")
        {
            vie -= 70;
        }
    }
    IEnumerator spawn()
    {
        if (canspawn == true)
        {
            canspawn = false;
            GameObject clone = GameObject.Instantiate(projectile).gameObject;
            clone.transform.position = GetComponentsInChildren<Transform>()[1].position;
            clone.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 1) * speed;
            yield return new WaitForSeconds(secondstowait);
            canspawn = true;
        }
    }
    IEnumerator move()
    {
        Vector3 initialposition = transform.position;
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 endposition = new Vector3(worldPosition.x, worldPosition.y, transform.position.z);
        float timetomove = 0.1f;
        timeinsec = 0;
        while (timeinsec <= timetomove)
        {
            transform.position = Vector3.Lerp(initialposition, endposition, timeinsec / timetomove);
            yield return new WaitForEndOfFrame();
        }
    }
    public void Unfreeze()
    {
        Time.timeScale = 1;

    }
}
