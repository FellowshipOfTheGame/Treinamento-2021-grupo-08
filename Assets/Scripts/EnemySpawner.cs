using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
   	public GameObject[] enemy;
	
	public int numberOfEnemies;
	public float spawnTime;
	
	private int currEnemies; // current count of enemies alive in the scene.
	
	public float minZ, maxZ;

	public Transform player;

	// Start is called before the first frame update
    void Start()
    {
		player = GameObject.FindGameObjectWithTag("Player").transform;
		GetComponent<BoxCollider>().center = player.position;
    }

	void Update()
	{
		if(currEnemies >= numberOfEnemies)
		{
			int enemies = FindObjectsOfType<Enemy>().Length;
			if(enemies <= 0)
			{
				FindObjectOfType<CameraFollow>().maxXAndY.x = 200;
				gameObject.SetActive(false);
			}
		}	
	}

	void Spawn()
	{
		bool positionX = Random.Range(0, 2) == 0 ? true : false; // 0 or 1
		Vector3 spawnPosition;
		spawnPosition.z = Random.Range(minZ, maxZ);
		if(positionX)
		{
			spawnPosition = new Vector3(transform.position.x + 10, 0, spawnPosition.z);
		} else {
			spawnPosition = new Vector3(transform.position.x - 10, 0, spawnPosition.z);
			
		}

		GameObject clone = Instantiate(enemy[Random.Range(0, enemy.Length)], spawnPosition, enemy[0].transform.rotation);
		currEnemies++;
		if(currEnemies <= numberOfEnemies)
		{
			Invoke("Spawn", spawnTime);
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if(other.CompareTag("Player"))
		{
			GetComponent<BoxCollider>().enabled = false;
			FindObjectOfType<CameraFollow>().maxXAndY.x = transform.position.x;
			Spawn();
		}
	}

}
