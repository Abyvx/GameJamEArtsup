using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DVD : MonoBehaviour
{
    public float speed = 2f;
    void Start()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.one * speed;
    }
}
