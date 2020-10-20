using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public ParticleSystem speedParticles;
    public AudioClip scoreUp;
    public AudioClip Damage;
    public float speed = 1500f;
    public int bestScore;

    private Rigidbody rb;
    private UIManager uiManager;
    private int score;
    private float maxSpeed = 3500f;
    private bool isMaxSpeed = false;
    [SerializeField] private float directionalSpeed = 20f;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        if (!rb || !uiManager)
            return;
            
        score = 0;

        bestScore = PlayerPrefs.GetInt("bestscore");
    }

    // Update is called once per frame
    void Update()
    {
        if(score > bestScore)
        {
            bestScore = score;
            PlayerPrefs.SetInt("bestscore", score);
        }

        SpeedParticles();

    #if UNITY_EDITOR || UNITY_STANDALONE || UNITY_WEBPLAYER

        float moveHorizontal = Input.GetAxis("Horizontal");

        transform.position = Vector3.Lerp(transform.position, 
            new Vector3(Mathf.Clamp(transform.position.x + moveHorizontal, -2.5f, 2.5f), 
            transform.position.y, 
            transform.position.z), directionalSpeed * Time.deltaTime);

    #endif
        rb.velocity = Vector3.forward * speed * Time.deltaTime;
        transform.Rotate((Vector3.right * rb.velocity.z) / 4);

        //MOBILE CONTROLS
        Vector2 touch = Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(0, 0, 10f));
        if (Input.touchCount > 0)
        {
            if (Input.mousePosition.y < (Screen.height) * 0.33f)
                transform.position = new Vector3(touch.x, transform.position.y, transform.position.z);
            else
                return;
        }
    }

    public void AddScore(int points)
    {
        score = score + points;
        if (score % 5 == 0)
            speed += 250;

        if (speed >= maxSpeed)
        {
            speed = maxSpeed;
            isMaxSpeed = true;
        }
        uiManager.UpdateScore(score);
    }

    void SpeedParticles()
    {
        if (speed >= maxSpeed && isMaxSpeed)
        {
            speedParticles.Play();
        }
        else
            speedParticles.Stop();
    }

    public void CheckForBestScore()
    {
        uiManager.highScoreUI.text = "" + bestScore;
    }
}
