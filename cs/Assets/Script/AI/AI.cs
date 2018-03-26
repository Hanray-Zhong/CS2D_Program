using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI : Unit {

    private float speed = 5;                //移动速度
    private float attackRange = 15;         //攻击范围
    private float shootCoolDown = 0;        //射击冷却
    private NavMeshAgent nma;               //自动寻路

    public GameObject player;               //射击目标
    Weapons w;

    private void Start()
    {
        w = gameObject.GetComponent<Weapons>();
        w.ChooseWeapon();
        nma = gameObject.GetComponent<NavMeshAgent>();
    }

    /*
    private void FixedUpdate()
    {
        if (player == null) return;
        float distance = Vector3.Distance(player.transform.position, transform.position);
        
        if(distance > attackRange)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        if (distance <= attackRange && shootCoolDown >= w.bulletSpeed)
        {
            shootCoolDown = 0;
            w.Shoot();
        }
        transform.LookAt(player.transform.position);
        shootCoolDown++;

    }
    */

    private void Update()
    {
        if (player == null) return;
        float distance = Vector3.Distance(player.transform.position, transform.position);
        if (distance > attackRange)
            nma.SetDestination(player.transform.position);
        else
        {
            nma.Stop();
            gameObject.transform.LookAt(player.transform.position);
            w.Shoot();
        }
    }
}
