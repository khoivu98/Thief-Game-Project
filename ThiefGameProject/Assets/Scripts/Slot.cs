using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour {

    private Inventory inventory;
    public int i;

    public void DropItem()
    {
        foreach(Transform child in transform)
        {
            child.GetComponent<DropItem>().SpawnDroppedItem();
            GameObject.Destroy(child.gameObject);
        }
    }

    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    void Update()
    {
        if(transform.childCount <= 0)
        {
            inventory.isFull[i] = false;
        }
    }
   
}
