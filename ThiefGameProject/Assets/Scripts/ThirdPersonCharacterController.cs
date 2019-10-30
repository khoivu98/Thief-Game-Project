using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCharacterController : MonoBehaviour {

    public float speed;
    float hor;
    float ver;
    public CharacterAnimation charAnim;
    public bool isSeen = false;
    public bool isHiding = false;

    // Use this for initialization
    void Start () { }
	
	// Update is called once per frame
	void Update () {
        PlayerMovement();
	}

    void PlayerMovement()
    {
        hor = Input.GetAxis("Horizontal");
        ver = Input.GetAxis("Vertical");
        Vector3 playerMovement = new Vector3(hor, 0f, ver) * speed * Time.deltaTime;

        if (charAnim.isForward() == true && charAnim.isCrouching() == true)
            speed = 2.5f;
        else if (charAnim.isRunning() && charAnim.isForward())
            speed = 10.0f;
        else if (charAnim.isForward())
            speed = 4f;
        else if (charAnim.isBackward() == true && charAnim.isCrouching() == true)
            speed = 2.3f;
        else
            speed = 3f;

        transform.Translate(playerMovement, Space.Self);
    }

}
