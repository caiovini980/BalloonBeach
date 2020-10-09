using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointCollision : MonoBehaviour
{
    private PlayerMovement player;
    
    void Awake()
    {
        //get the point script on canvas
        player = GameObject.Find("Player").GetComponent<PlayerMovement>();
    }
    void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            //add a point
            player.AddScore(1);
        }
    }
}
