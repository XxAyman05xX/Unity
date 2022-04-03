using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Missile : MonoBehaviour
{
    Missile missile;
    Plane plane;
    Alien alien;
    public float steppoint = 0.1f, steppointx = 0.1f;
    List<Vector2> listofpoints = new List<Vector2>();
    int index = 0;
    GameObject cube;
    bool right = true;
    float speed = 3f;
    bool canspawn = true;
    float secondstowait = 5;
    GameObject lastdirection;
    void Start()
    {
        cube = GameObject.Find("Square");
        lastdirection = GameObject.Find("last direction");
        plane = GameObject.FindObjectOfType<Plane>();
        alien = GameObject.FindObjectOfType<Alien>();
        missile = GameObject.FindObjectOfType<Missile>();
        Generatewaypoint(plane.transform.position);
        Spawncubes();
    }
    void Update()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, listofpoints[index], step);
    }
    private void FixedUpdate()
    {

    }
    void Generatewaypoint(Vector2 playerpos)
    {
        float yA = alien.transform.position.y;
        float y = yA;
        float x = alien.transform.position.x;
        float xmax = 2.8f, xmin = -2.8f;
        steppointx *= Random.Range(0, 3) > 1 ? -1 : 1;
        while (y > playerpos.y)
        {
            if (x < xmax && right == true && x > xmin)
            {
                x += steppointx;
            }
            else
            {
                right = false;
                x -= steppointx;
            }
            y -= steppoint;
            Vector2 waypoint = new Vector2(x, y);
            listofpoints.Add(waypoint);
        }
        listofpoints.Add(lastdirection.transform.position);
    }
    void Spawncubes()
    {
        GameObject waypoints = GameObject.Find("Waypoints");
        foreach (Vector2 point in listofpoints)
        {
            GameObject c = Instantiate(cube);
            c.transform.position = point;
            c.transform.parent = waypoints.transform;
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "way" && index<listofpoints.Count-1)
        {
            index++;
        }
        if (col.name=="Joueur" || col.name == "last direction")
        {
            Destroy(gameObject);
        }
    }
    

}
