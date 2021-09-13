using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackStateRanged : AttackState
{
    public Transform bulletPrefab;

    protected override void Attack()
    {
        Transform bullet = Instantiate(bulletPrefab, attackPoint.position, Quaternion.identity);
        Vector3 direction = new Vector3(-bullet.parent.parent.localScale.x,1,1);
        bullet.transform.localScale = direction;
    }
}

