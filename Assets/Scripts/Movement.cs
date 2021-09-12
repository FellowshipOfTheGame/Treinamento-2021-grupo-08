using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Movement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 6f; 
    public SpriteRenderer sprite;
    Vector3 direction;
	public Animator animator; 

	public float minHeight = 17.5f;
	public 	float maxHeight = 19.5f;		
	
	float dist;

    void Update()
    {

//		dist = transform.position.z - Camera.main.transform.position.z*Mathf.Cos(Camera.main.transform.eulerAngles.x);
//		var frustumHeight = 2.0f * distance * Mathf.Tan(Camera.main.fieldOfView * 0.5f * Mathf.Deg2Rad);

//		Debug.Log(frustumHeight);
//		var zCamera =  Camera.main.transform.position.z//*Mathf.Cos(Camera.main.transform.eulerAngles.x);
	
//		var rightLimit = Camera.main.ViewportToWorldPoint(new Vector3(0,0,dist)).x;
//        var leftLimit = Camera.main.ViewportToWorldPoint(new Vector3(1,0,dist)).x;
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
//		float minWidth = Camera.main.ViewportToWorldPoint(new Vector3(0f, 1f, yCamera)).x;
//		float maxWidth = Camera.main.ViewportToWorldPoint(new Vector3(1f, 1f, yCamera)).x;
//		float minHeight = Camera.main.ViewportToWorldPoint(new Vector3(0f, 0f, yCamera)).z + 1;
//		float maxHeight = Camera.main.ViewportToWorldPoint(new Vector3(0f, 1f, yCamera)).y;
	
//		float minWidth = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, zCamera)).x;
//		float maxWidth = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, zCamera)).x;	
//			Debug.Log("min:" + minWidth + " max: " + maxWidth);
//		if (transform.position.x < minWidth+0.1f && horizontal < 0){
//				horizontal = 0f;
//		}
//		if (transform.position.x > maxWidth-0.1f && horizontal > 0){
//			horizontal = 0f;
//		}
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
   		if(direction.magnitude >= 0.1f)
        {
            controller.Move(direction*speed*Time.deltaTime);
			animator.SetBool("Walking", true); 
		} else{
			animator.SetBool("Walking", false); 
		}
    }
}
