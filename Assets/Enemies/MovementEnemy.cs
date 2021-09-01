using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementEnemy : MonoBehaviour
{

    public Transform transformEnemy;
    public CharacterController controller;
    public float speed = 2f;

    void Update()
    {
        Transform transformPlayer = GameObject.Find("Main Character").GetComponent<Transform>();
        Vector3 positionEnemy = transformEnemy.position;
        Vector3 positionPlayer = transformPlayer.position;

        Vector3 direction = (positionPlayer - positionEnemy).normalized;

        if(direction.magnitude >= 0.1f)
        {
            controller.Move(direction*speed*Time.deltaTime);
        }    
    }
}
