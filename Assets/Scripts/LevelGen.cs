using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGen : MonoBehaviour
{
    void OnTriggerEnter(Collider collider)
    {
        StartCoroutine(Transfer(1));
    }

    IEnumerator Transfer(int timer)
    {
        yield return new WaitForSeconds(timer);
        transform.parent.position = new Vector3(0, 0, transform.position.z + 400);
    }
}
