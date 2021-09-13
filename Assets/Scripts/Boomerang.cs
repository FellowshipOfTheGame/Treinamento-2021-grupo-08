using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boomerang : MonoBehaviour
{
	bool go;

	GameObject player;
	GameObject hat;

	public float speed = 6f;
	public int damage = 5;	

	public float attackRange = 4f;
	Transform sprite;
	private Transform attackPoint;
    public LayerMask enemyLayers, mandacuruLayer;

	Vector3 direction;
	Vector3 locationInFrontOfPlayer;

	// Start is called before the first frame update
	void Start()
	{
		go = false; 
		player = GameObject.Find("Player");
		hat = GameObject.Find("Hat");

		hat.GetComponent<SpriteRenderer>().enabled = false;
		
		// Hat sprite to rotate
		sprite = gameObject.transform.GetChild(0);
		
		attackPoint = gameObject.transform.GetChild(1);	
		// Direction in which the player is facing
		direction = new Vector3(-player.transform.localScale.x, 0, 0);

		// Location in which we will throw the hat
		locationInFrontOfPlayer = new Vector3(player.transform.position.x, player.transform.position.y + 1, player.transform.position.z) + direction * attackRange;

		StartCoroutine(Boom());

		// Check if the hat hit any enemy
		InvokeRepeating("Hit", 0, 0.2f);
	}

	IEnumerator Boom() {
		go = true;
		yield return new WaitForSeconds(1f);
		go = false;
	}

	// Update is called once per frame
	void Update()
	{
		sprite.transform.Rotate(new Vector3(0, 0, 45), Time.deltaTime * 10, 0);
		
		// The player is throwing the hat
		if (go) 
		{
			transform.position = Vector3.MoveTowards(transform.position, locationInFrontOfPlayer, Time.deltaTime * speed);
		} 
		// The hat is returning to the player
		if (!go) 
		{
			transform.position = Vector3.MoveTowards(transform.position, new Vector3(player.transform.position.x, player.transform.position.y + 1, player.transform.position.z), Time.deltaTime * speed);
		}
		// The player catches the hat
		if (!go && Vector3.Distance(player.transform.position, transform.position) == 1 ) {
			// For the player to catch the hat, we enable the visibility and destroy the clone.
			hat.GetComponent<SpriteRenderer>().enabled = true;
			Destroy(this.gameObject);
		}
	}

	void Hit() 
	{
		Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, 0.7f, enemyLayers);
		Collider[] hitMandacuru = Physics.OverlapSphere(attackPoint.position, attackRange, mandacuruLayer);
		foreach (Collider enemy in hitEnemies)
		{
			Debug.Log("-" + damage + "(" + enemy.name + ")");
			enemy.gameObject.GetComponent<Character>().Hit(damage);
		}
		foreach (Collider mandacuru in hitMandacuru)
		{
			Debug.Log("cortou o mandacuru ");
			mandacuru.gameObject.GetComponent<SpriteRenderer>().flipX = true;
			transform.parent.gameObject.GetComponent<Character>().Heal(20);	
		}

	}

}
