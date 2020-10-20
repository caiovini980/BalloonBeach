using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointCollision : MonoBehaviour
{
    private PlayerMovement player;
    private AudioSource score;
    public AudioClip scoreUp;
    
    void Awake()
    {
        //get the point script on canvas
        player = GameObject.Find("Player").GetComponent<PlayerMovement>();
        score = GetComponent<AudioSource>();
    }
    void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            //add a point
            player.AddScore(1);
            //play score sound
            score.PlayOneShot(scoreUp, 0.1f);
        }
    }
}
