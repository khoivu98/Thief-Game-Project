using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour {

    public Animator animator;
    float verticalMovement;
    float horizontalMovement;
    float crouch;
    //float run;

	// Use this for initialization
	void Start () {
        animator = this.gameObject.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        crouch = Input.GetAxis("Crouch");
        verticalMovement = Input.GetAxis("Vertical");
        horizontalMovement = Input.GetAxis("Horizontal");
        //run = Input.GetAxis("Run");
        //Debug.Log(run);
        animator.SetFloat("Crouch", crouch);
        animator.SetFloat("VerticalMovement", verticalMovement);
        animator.SetFloat("HorizontalMovement", horizontalMovement);
        //animator.SetFloat("Running", run);
        if (verticalMovement != 0 && horizontalMovement == 0)
        {
            animator.SetBool("isVertical", true);
            animator.SetBool("isHorizontal", false);
        }
        else if(verticalMovement == 0 && horizontalMovement != 0)
        {
            animator.SetBool("isVertical", false);
            animator.SetBool("isHorizontal", true);
        }
        if (verticalMovement > 0 && isRunning())
        {
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }
        
	}

    public bool isCrouching()
    {
        if (crouch != 0) return true;
        else return false;
    }
    
    public bool isForward()
    {
        if (verticalMovement > 0) return true;
        else return false;
    }

    public bool isBackward()
    {
        if (verticalMovement < 0) return true;
        else return false;
    }

    public bool isRunning()
    {
        if (Input.GetKey(KeyCode.LeftShift))
            return true;
        else return false;
    }
}
