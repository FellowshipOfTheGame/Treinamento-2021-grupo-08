using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    public GameObject player; 
    public GameObject spawner;
	public CameraFollow cameraFollow;
	public GameObject familyUI;	

	public int numberScenes = 10;

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
		Debug.Log("currScene = " + currScene());
		switch(currScene())
		{
			case 1:
				SpawnEnemies(1, currScene());
				break;
			case 2:
				SpawnEnemies(2, currScene());	
				break;
			case 3:	
				Family();
				break;
			default:
				break;
				// GameEnd;
		}
		
    }

	private int currScene()
	{
		return (int)((player.transform.position.x-5f) / 10f + 1);	
	}

	private void SpawnEnemies(int numberOfEnemies, int sceneNumber)
	{
		if(!spawned[sceneNumber-1])
		{
			Debug.Log("create spawn");
			GameObject clone;
			clone = Instantiate(spawner, player.transform.position, spawner.transform.rotation);
			clone.GetComponent<EnemySpawner>().numberOfEnemies = numberOfEnemies;	
			spawned[sceneNumber-1] = true;
		}		
	}

	private void Family()
	{
		familyUI.SetActive(true);
	}

}
