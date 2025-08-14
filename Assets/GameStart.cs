using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStart : MonoBehaviour
{
    [SerializeField] private GameObject message, duck;
    [SerializeField] private GameObject pipes, source;
    [SerializeField] private GameObject gameover;
    [SerializeField] private Text scoreText;
    private float interval = 1f;
    private bool started;
    private int score;
    public static GameStart Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void GameOver()
    {
        gameover.SetActive(true);
        Time.timeScale = 0; //fica frio ai
    }

    // Start is called before the first frame update
    void Start()
    {
        started = false;
        InvokeRepeating("SpawnPipes", 0f, interval);
        score = 0;
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
    public void IncreaseScore(int score)
    {
        this.score += score;
        scoreText.text = this.score.ToString();
    }
    public int GetScore()
    {
        return score;
    }
}
