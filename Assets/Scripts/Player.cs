using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : Character
{
	public Animator animator;
    public Transform attackPoint;
    public float attackRange = 5f;
    public LayerMask enemyLayers;
	public LayerMask mandacuruLayer;
    public float attackRate = 0.5f;
    float nextAttackTime = 0f;

	[SerializeField] private int basicAttackDamage = 10;

	public GameObject hat;
	
    void Update()
    {
    	if (Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.Z)) {
                BasicAttack();
                nextAttackTime = Time.time + 1f/attackRate;
            }
			if (Input.GetKeyDown(KeyCode.X)) {
		        LongRangeAttack();
                nextAttackTime = Time.time + 1f/attackRate;
        
			}
        }
		if (GetHealth() <= 0)
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}
    }

	void BasicAttack() {
        animator.SetTrigger("BasicAttack");
        Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, attackRange, enemyLayers);
		Collider[] hitMandacuru = Physics.OverlapSphere(attackPoint.position, attackRange, mandacuruLayer);
		foreach (Collider enemy in hitEnemies)
        {
            Debug.Log("atacado " + enemy.name);
			enemy.gameObject.GetComponent<Character>().Hit(basicAttackDamage);
		}
		foreach (Collider mandacuru in hitMandacuru)
		{
			Debug.Log("cortou o mandacuru ");
			mandacuru.gameObject.GetComponent<SpriteRenderer>().flipX = true;
			healthSystem.Heal(20);	
		}
    }

	void LongRangeAttack() 
	{
	    animator.SetTrigger("HatAttack");
 		GameObject[] throwed = GameObject.FindGameObjectsWithTag("Hat");
		if(throwed.Length == 0) 
		{
			GameObject clone;
			clone = Instantiate(hat, new Vector3(transform.position.x-0.6f, transform.position.y + 0.7f, transform.position.z), transform.rotation) as GameObject;
		}
}

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
        return;
        Gizmos.DrawWireSphere(attackPoint.position,attackRange);
    }


}
