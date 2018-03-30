using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M249_bullet : MonoBehaviour {

    private float damage = 25;

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        //Debug.Log(other.name);
        Unit u = other.GetComponent<Unit>();
        if (u != null)
            u.ApplyDamage(damage);
        else
            return;
    }

    private void Update()
    {
        GameObject.Destroy(gameObject, 2);
    }
}
