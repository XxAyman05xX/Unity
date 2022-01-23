using UnityEngine;

public class MoveRacketRight : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 10f;
    public FirstScript firstScript;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        if (firstScript.x == 3 || firstScript.y == 3)
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
        else
        {
            float v = Input.GetAxisRaw("Vertical2") * speed;
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, v);
        }
    }
}
