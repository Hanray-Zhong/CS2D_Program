using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UZI_Bullet : MonoBehaviour {
    public float damage;

    private void OnCollisionEnter(Collider other)
    {
        GameObject.Destroy(gameObject);
        Unit u = other.GetComponent<Unit>();
        if (u != null)
            u.ApplyDamage(damage);
    }

    private void Update()
    {
        GameObject.Destroy(gameObject, 1.5f);
    }
}
