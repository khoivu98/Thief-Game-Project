using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCameraController : MonoBehaviour {

    public float RotationSpeed = 1;
    public Transform target, player;
    float mouseX, mouseY;

	// Use this for initialization
	void Start () {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
	}

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            if(Cursor.visible == false)
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
    }

    void LateUpdate()
    {
        CamControl();
    }
	
    void CamControl()
    {
        mouseX += Input.GetAxis("Mouse X") * RotationSpeed;
        mouseY -= Input.GetAxis("Mouse Y") * RotationSpeed;
        mouseY = Mathf.Clamp(mouseY, -35, 60);

        transform.LookAt(target);

        if (Input.GetKey(KeyCode.LeftAlt))
        {
            target.rotation = Quaternion.Euler(mouseY, mouseX, 0);
        }
        else
        {
            target.rotation = Quaternion.Euler(mouseY, mouseX, 0);
            player.rotation = Quaternion.Euler(0, mouseX, 0);
        }
        
    }
}
