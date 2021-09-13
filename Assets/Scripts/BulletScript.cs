using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public int damage;
    public float speed;
    public float bulletDuration;

    private bool hit = false;
    private Vector3 direction;
    //verificar colisão
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 6)
        {
            Debug.Log("atacado " + collision.gameObject.name);
			collision.gameObject.GetComponent<Character>().Hit(damage);
        }
        hit = true;
    }

    void Start()
    {
        direction = new Vector3(transform.localScale.x, 0, 0);
        bulletDuration += Time.time;
    }

    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
        if(Time.time > bulletDuration || hit)
        {
            Destroy(this.gameObject);
        }
    }
}
