using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private float playerDistance = 10f;
    private PlayerMovement player;

    void Awake()
    {
        player = GameObject.Find("Player").GetComponent<PlayerMovement>();
    }

    // Start is called before the first frame update
    void Start()
    {
        if (!player)
            return;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, 
            new Vector3(0, transform.position.y, player.transform.position.z - playerDistance), 
            Time.deltaTime * 100);
    }
}
