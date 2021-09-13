using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Movement : MonoBehaviour
{
	// References
    public CharacterController controller;
	public Animator animator; 
    public SpriteRenderer sprite;
	//public Rigidbody rb;    
	public float speed = 6f; 
	public float minHeight = -1f;
	public 	float maxHeight = 4.4f;		
	
	float dist;
    Vector3 direction;

    void Update()
    {
		float horizontal = Input.GetAxisRaw("Horizontal");
	
		// Flipping character	
		switch (horizontal)
        {
            case 1: transform.localScale = new Vector3(-1f, 1f, 1f);
            break;
            case -1: transform.localScale = new Vector3(1f, 1f, 1f);
            break;
        }
        
		float vertical = Input.GetAxisRaw("Vertical");
		// Can walk only on the ground
		if (transform.position.z < minHeight+0.1f && vertical < 0)
		{
			vertical = 0f;
		}
		if (transform.position.z > maxHeight-0.1f && vertical > 0)
		{
			vertical = 0f;
		}	
		
		direction = new Vector3(horizontal, 0f, vertical).normalized;
  	}

    void FixedUpdate()
    {
   		if (direction.magnitude >= 0.1f)
        {
            controller.Move(direction*speed*Time.deltaTime);
			//rb.MovePosition(transform.position + direction*speed*Time.deltaTime);
			animator.SetBool("Walking", true); 
		} else 
		{
			animator.SetBool("Walking", false); 
		}
    }
}
