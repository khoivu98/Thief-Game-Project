using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAnimation : MonoBehaviour {

    Animator anim;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
    private void OnTriggerEnter(Collider col)
    {
        print("door opened");
        anim.SetTrigger("open");
    }

    private void OnTriggerExit(Collider col)
    {
        print("door close");
        anim.SetTrigger("close");
    }
}
