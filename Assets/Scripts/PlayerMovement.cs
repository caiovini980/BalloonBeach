using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    private UIManager uiManager;
    private int score;
    [SerializeField] private float playerSpeed = 1000f;
    [SerializeField] private float directionalSpeed = 20f;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        if (!rb)
            return;
            
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
    #if UNITY_EDITOR || UNITY_STANDALONE || UNITY_WEBPLAYER

        float moveHorizontal = Input.GetAxis("Horizontal");

        transform.position = Vector3.Lerp(transform.position, 
            new Vector3(Mathf.Clamp(transform.position.x + moveHorizontal, -2.5f, 2.5f), 
            transform.position.y, 
            transform.position.z), directionalSpeed * Time.deltaTime);

    #endif
        rb.velocity = Vector3.forward * playerSpeed * Time.deltaTime;

        //MOBILE CONTROLS
        Vector2 touch = Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(0, 0, 10f));
        if (Input.touchCount > 0)
        {
            transform.position = new Vector3(touch.x, transform.position.y, transform.position.z);
        }
    }

    public void AddScore(int points)
    {
        score = score + points;
        Debug.Log(score);
        uiManager.UpdateScore(score);
    }
}
