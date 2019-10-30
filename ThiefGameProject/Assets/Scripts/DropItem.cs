using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItem : MonoBehaviour {

    public GameObject item;
    public Transform player;
    Vector3 playerPos;
    Vector3 playerDirection;
    Quaternion playerRotation;
    float spawnDistance = 3f;
    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerPos = new Vector3(player.transform.position.x, player.transform.position.y + 3f, player.transform.position.z);
        playerDirection = player.transform.forward;
        playerRotation = player.transform.rotation;
    }

    public void SpawnDroppedItem()
    {
        playerPos = playerPos + playerDirection * spawnDistance;
        Instantiate(item, playerPos, playerRotation);
    }
}
