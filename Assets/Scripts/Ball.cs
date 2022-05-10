using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed = 4;
    public GameManager manager;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(new Vector3(0, -1));
        manager = GameManager.instance;
    }


    private void Update()
    {
        if (Vector3.Distance(transform.position, Vector3.zero) > GameManager.instance.deathDistance)
        {
            GameManager.instance.ResetLevel();
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = rb.velocity.normalized * speed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        manager.BallCollision(collision.gameObject);
    }
}
