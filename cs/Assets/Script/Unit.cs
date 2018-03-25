using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour {

    public float health = 100;             //生命值
    public GameObject deadBody;
    private bool isDead = false;

    public void ApplyDamage(float damage)
    {
        if (damage < health)
        {
            health -= damage;
        }

        else
        {
            isDead = true;
            if (isDead)
                Destruct();
        }
    }

    public void Destruct()
    {
        Instantiate(deadBody, transform.position, transform.rotation);
        Destroy(gameObject);
        isDead = false;
    }
}
