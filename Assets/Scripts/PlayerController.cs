using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float speed = 5f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        Movimentacao();
    }

    void Movimentacao()
    {
        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, this.transform.position.y);
    }
}
