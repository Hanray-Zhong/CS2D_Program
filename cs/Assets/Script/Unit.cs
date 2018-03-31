using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Team
{
    T,
    CT
}

public class Unit : MonoBehaviour {
    public GameObject deadBody;
    public Team team;
    public float health = 100;             //生命值
    public Text Health_text;

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
            health = 0;
            if (isDead)
            {
                Destruct();
            }
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
