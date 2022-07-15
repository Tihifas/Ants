using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ant : MonoBehaviour
{
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start");
        StartWalking();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartWalking()
    {
        Debug.Log($"speed: {speed}");

        Vector2 forward = transform.up; //https://answers.unity.com/questions/609527/how-do-i-make-a-game-object-move-in-the-direction.html
        Debug.Log($"forward: {forward}");

        Vector2 velocity = forward * speed;
        Debug.Log($"velocity: {velocity}");
        SetVelocity(velocity);

        //GetVelocity
        Debug.Log("StartWalking");
         
        Debug.Log(transform.position.x);
        Debug.Log(transform.position.y);
    }

    public Vector2 GetVelocity()
    {
        Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();
        Vector2 velocity = rb.velocity;
        return velocity;
    }

    public void SetVelocity(Vector2 velocity)
    {
        Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();
        rb.velocity = velocity;
    }
}
