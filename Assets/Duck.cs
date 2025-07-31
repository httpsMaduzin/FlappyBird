using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Duck : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool jumping;
    [SerializeField] private float JumpSpeed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jumping = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Teclou espaço");
            jumping = true;
        }
    }
    void FixedUpdate()
    {
        if (jumping)
        {
            rb.velocity = Vector2.up * JumpSpeed;//(0,1)
            jumping = false;
        }
    }
    void OnCollisionEnter2D(Collider2D other)
    {
        if (other.CompareTag("pipes"))
        {
            GameStart.Instance.GameOver();
        }
    }
}
