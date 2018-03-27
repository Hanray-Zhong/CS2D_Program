using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI : Unit {

    public float searchRange;
    private float speed = 5;                //移动速度
    private float attackRange = 15;         //攻击范围
    private float shootCoolDown = 0;        //射击冷却
    private NavMeshAgent nma;               //自动寻路

    private  GameObject enemy;               //射击目标
    private Weapons w;
    private LayerMask enemyLayer;           //敌人的层

    private void Start()
    {
        w = gameObject.GetComponent<Weapons>();
        w.ChooseWeapon();
        w.Init(team);
        nma = gameObject.GetComponent<NavMeshAgent>();
        enemyLayer = new TeamManager().ChooseEnemy(team);
    }

    private void Update()
    {
        if (enemy == null)
        {
            searchEnemy();
            return;
        }
        float distance = Vector3.Distance(enemy.transform.position, transform.position);
        /************自动寻路************/
        if (distance > attackRange)
            nma.SetDestination(enemy.transform.position);
        /***********自动攻击*************/
        else
        {
            nma.ResetPath();
            gameObject.transform.LookAt(enemy.transform.position);
            if (shootCoolDown >= w.bulletSpeed)
            {
                w.Shoot();
                shootCoolDown = 0;
            }
        }
        shootCoolDown++;
        /******************************/
    }

    private void searchEnemy()
    {
        Collider[] cols = Physics.OverlapSphere(transform.position, searchRange, enemyLayer);
        enemy = cols[Random.Range(0, cols.Length)].gameObject;
    }
}
