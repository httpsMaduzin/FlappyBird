using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Duck : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool jumping;
    [SerializeField] private float JumpSpeed;
    [SerializeField] private AudioClip PointSound;
    [SerializeField] private AudioClip JumpSound; 

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
            jumping = true;
        }
    }
    void FixedUpdate()
    {
        if (jumping)
        {
            rb.velocity = Vector2.up * JumpSpeed;//(0,1)
            jumping = false;
            AudioController.instance.PlayAudioClip(JumpSound, false);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Score"))
        {
            GameStart.Instance.IncreaseScore(1);
            AudioController.instance.PlayAudioClip(PointSound, false);
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Pipes") || other.gameObject.CompareTag("Ground"))
        {
            GameStart.Instance.GameOver();
            Destroy(gameObject);
        }
    }
}
