﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour {

    private float health = 100;             //生命值
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

    private void Destruct()
    {
        GameObject dead = Instantiate(deadBody, transform.position, transform.rotation);
        dead.transform.forward = new Vector3(0, 1, 0);
        Destroy(gameObject);
        isDead = false;
    }
}
