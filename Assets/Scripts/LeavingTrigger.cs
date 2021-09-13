using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LeavingTrigger : MonoBehaviour
{
	public UnityEvent onTriggerEnter;

    // Start is called before the first frame update
    void Start()
    {
        
    }

	private void OnTriggerEnter(Collider other)
	{
		if(other.CompareTag("Player"))
		{
			onTriggerEnter?.Invoke();
		}		
	}		

}
