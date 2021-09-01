using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Movement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 6f; 
    public SpriteRenderer sprite;
    Vector3 direction;

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        switch (horizontal)
        {
            case 1: transform.localScale = new Vector3(-1,1,1);
            break;
            case -1: transform.localScale = new Vector3(1,1,1);
            break;
        }
        float vertical = Input.GetAxisRaw("Vertical");
        direction = new Vector3(horizontal,0f,vertical).normalized;
    }

    void FixedUpdate()
    {
        if(direction.magnitude >= 0.1f)
        {
            controller.Move(direction*speed*Time.deltaTime);
        }
    }
}
