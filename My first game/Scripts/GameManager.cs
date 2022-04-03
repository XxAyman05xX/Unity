using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool canspawnasteroid = true;
    public Asteroid asteroid;
    public float speedasteroid = 3f;
    public float secondstowaitspawnasteroid = 2f;
    int level;
    public Alien alien;
    public GameObject buttonlvl2;
    bool gameover = false;
    void Start()
    {
        Time.timeScale = 1;
        if (PlayerPrefs.GetInt("level") == 0)
            level = 1;
        else
            level = PlayerPrefs.GetInt("level");
        buttonlvl2.SetActive(false);
        StartCoroutine(spawnmis());
    }
    void Update()
    {
        if (alien.vie <= 0 && gameover == false)
        {
            gameover = true;
            level++;
            PlayerPrefs.SetInt("level", level);
            buttonlvl2.SetActive(true);
        }

    }
    private void FixedUpdate()
    {
        if (level > 1)
        {
            StartCoroutine(spawn());
        }
    }
    Vector2[] setpos()
    {
        Vector2 initialpos;
        Vector2 endpos;
        int cote = Random.Range(0, 11) % 2; // 0 is left , and 1 is right
        float xright = 3.67f;
        float xleft = -3.54f;
        float x;
        if (cote == 1)
        {
            x = xright;
            endpos = new Vector2(Random.Range(-6f, 0f), -5.84f);
        }
        else
        {
            x = xleft;
            endpos = new Vector2(Random.Range(0f, 6f), -5.84f);
        }
        initialpos = new Vector2(x, Random.Range(0.61f, 4.80f));
        Vector2[] pos = new Vector2[2];
        pos[0] = initialpos;
        pos[1] = endpos;
        return pos;
    }
    IEnumerator spawn()
    {
        if (canspawnasteroid == true)
        {
            Vector2[] pos = setpos();
            canspawnasteroid = false;
            GameObject clone = GameObject.Instantiate(asteroid).gameObject;
            clone.transform.position = pos[0];
            clone.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(pos[1].x, pos[1].y);
            yield return new WaitForSeconds(secondstowaitspawnasteroid);
            canspawnasteroid = true;
        }
    }
    public void nextlevel()
    {
        SceneManager.LoadScene(level);
    }
    bool canspawn = true;
    float secondstowait = 1;
    float speed = 3f;
    public Missile missile;
    IEnumerator spawnmis()
    {
        if (canspawn == true)
        {
            canspawn = false;
            GameObject clone = GameObject.Instantiate(missile).gameObject;
            clone.transform.position = alien.GetComponentsInChildren<Transform>()[1].position;
            clone.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -1) * speed;
            yield return new WaitForSeconds(secondstowait);
            canspawn = true;
            StartCoroutine(spawnmis());

        }
    }
}
