using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    public GameObject player; 
    public GameObject spawner;
	public CameraFollow cameraFollow;

	public int numberScenes = 10;

	private int currScene = 1;
	public Vector2 sceneLimits = new Vector2(5f, 15f);
	public float xScene = 10f;

	private bool[] spawned;

	// Start is called before the first frame update
    void Start()
    {
		player = GameObject.FindGameObjectWithTag("Player");
		cameraFollow = FindObjectOfType<CameraFollow>();
		spawned = new bool[10];
		for(int i=0; i<10; i++) spawned[i] = false;
	}	

    // Update is called once per frame
    void Update()
    {
		// First scene
		if(player.transform.position.x >= 5f)
		{
			if(!spawned[0])
			{
				GameObject clone;
				clone = Instantiate(spawner, player.transform.position, spawner.transform.rotation);
				clone.GetComponent<EnemySpawner>().numberOfEnemies = 1;	
				spawned[0] = true;
			}
		}
		// Second Scene
		if(player.transform.position.x >= 15f)
		{
			if(!spawned[1])
			{
				GameObject clone;
				clone = Instantiate(spawner, player.transform.position, spawner.transform.rotation);
				clone.GetComponent<EnemySpawner>().numberOfEnemies = 2;	
				spawned[1] = true;
			}
		}
    }
}
