using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMovement : MonoBehaviour
{
    public float speed = 5;

    private Vector3 velocity;

    private void Start()
    {
        velocity = new Vector3(0, 0, speed);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(velocity * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(-velocity * Time.deltaTime);
        }
    }
}
