using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
	public float xMargin = 2f; // Distance the player can move before the camera follows.
	public float xSmooth = 8f; // How smoothly the camera catches up.
	public Vector2 maxXAndY;
	public Vector2 minXAndY;

	public Transform player;

	private void Awake()
	{
		player = GameObject.FindGameObjectWithTag("Player").transform;
	}

	// Returns true if the camera should be moved
	private bool CheckXMargin()
	{
		return (transform.position.x - player.position.x) < xMargin;
	}

    // Update is called once per frame
    private void Update()
    {
        TrackPlayer();
    }

	private void TrackPlayer()
	{
		float targetX = transform.position.x;
		float targetY = transform.position.y;
		if(CheckXMargin())
		{
			targetX = Mathf.Lerp(transform.position.x, player.position.x, xSmooth * Time.deltaTime);
		}
		targetX = Mathf.Clamp(targetX, minXAndY.x, maxXAndY.x);

		transform.position = new Vector3(targetX, transform.position.y, transform.position.z);
	}



}
