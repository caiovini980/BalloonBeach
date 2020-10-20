using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCollision : MonoBehaviour
{
    private PlayerMovement player;
    private AudioSource audioSource;
    private GameManager gameManager;
    public AudioClip damage;

    void Awake()
    {
        player = GameObject.Find("Player").GetComponent<PlayerMovement>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        audioSource = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start()
    {
        if(!player)
            return;
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider collider)
    {
        if(collider.CompareTag("Player"))
        {
            audioSource.PlayOneShot(damage, 0.1f);
            player.CheckForBestScore();
            gameManager.PlayerDeath();
        }
    }
}
