using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    public GameObject player; 
    public GameObject spawner;
	public CameraFollow cameraFollow;
	public GameObject familyUI;	
	public Transform t_cenario;
	private List<Cenario> cenarios = new List<Cenario>();
	public int numberScenes = 10;

	public int currScene = 0;

	private bool[] spawned;

	// Start is called before the first frame update
    void Start()
    {
		player = GameObject.FindGameObjectWithTag("Player");
		cameraFollow = FindObjectOfType<CameraFollow>();
		spawned = new bool[10];
		for(int i=0; i<10; i++) spawned[i] = false;
		foreach(Transform child in t_cenario)
		{
			cenarios.Add(child.GetComponent<Cenario>());	
		}
	}	

    // Update is called once per frame
    void Update()
    {
		switch(currScene)
		{
			case 0:
				SpawnEnemies(1);
				break;
			case 1:
				SpawnEnemies(2);	
				break;
			case 2:	
				Family();
				break;
			default:
				break;
				// GameEnd;
		}
		
    }

	public void nextScene()
	{
		FindObjectOfType<CameraFollow>().minXAndY.x = cenarios[currScene].LeftWall.transform.position.x;
		cenarios[currScene].RightWall.enabled = false;	
		currScene++;
		cenarios[currScene].LeftWall.enabled = false;		
		FindObjectOfType<CameraFollow>().maxXAndY.x = cenarios[currScene].center.position.x;
			
	}

	public void onScene()
	{
		FindObjectOfType<CameraFollow>().minXAndY.x = cenarios[currScene].center.position.x;
		FindObjectOfType<CameraFollow>().maxXAndY.x = cenarios[currScene].center.position.x;
		cenarios[currScene].LeftWall.enabled = true;				
		SpawnEnemies(currScene+1);	
	}

	private void SpawnEnemies(int numberOfEnemies)
	{
		if(!spawned[currScene])
		{
			Debug.Log("create spawn");
			GameObject clone;
			clone = Instantiate(spawner, cenarios[currScene].center.position, spawner.transform.rotation);
			clone.GetComponent<EnemySpawner>().numberOfEnemies = numberOfEnemies;	
			spawned[currScene] = true;
		} else
		{
			if( FindObjectsOfType<Enemy>().Length == 0 )
			{
				cenarios[currScene].LeavingTrigger.enabled = true;	
				cenarios[currScene+1].ComingTrigger.enabled = true;	
			}
		}	
	}

	private void Family()
	{
		familyUI.SetActive(true);
	}

}
