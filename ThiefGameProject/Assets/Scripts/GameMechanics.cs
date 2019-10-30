using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMechanics : MonoBehaviour {

    public ThirdPersonCharacterController Liam;

    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Player")
        {
            Liam.isHiding = true;
            print("Inside and hiding.");
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if(col.gameObject.tag == "Player")
        {
            Liam.isHiding = false;
            print("Exit");
        }
    }
}
