using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destoyer : MonoBehaviour
{
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player"); //add a string for this player
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z < player.transform.position.z - 15)
        {
            Destroy(gameObject);
        }
    }
}
