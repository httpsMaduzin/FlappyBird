using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStart : MonoBehaviour
{
    [SerializeField] private GameObject message, duck;
    [SerializeField] private GameObject pipes, source;
    [SerializeField] private GameObject gameover;
    private float interval = 1f;
    private bool started;
    public static GameStart Instance;
    private void Awake()
    {
        Instance = this;
    }
    public void GameOver()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        started = false;
        InvokeRepeating("SpawnPipes", 0f, interval); 
    }
    private void SpawnPipes()
    {
        if (!started) return;
        Instantiate(
            pipes,
            source.transform.position,
            Quaternion.identity
        );
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Destroy(message);
            duck.SetActive(true);
            started = true;
        }
    }
}
