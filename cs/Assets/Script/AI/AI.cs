using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI : Unit {

    private float searchRange = 1000;
    private float speed = 5;                //移动速度
    private float attackRange = 15;         //攻击范围
    private float shootCoolDown = 0;        //射击冷却
    private NavMeshAgent nma;               //自动寻路

    private GameObject enemy;               //射击目标
    private Weapons w;
    private LayerMask enemyLayer;           //敌人的层
    private Ray shootWay;                   //用射线模拟弹道

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
        /***********寻找最近的敌人********/
        if (enemy == null)
        {
            //searchEnemy();
            getNearestEnemy();
            return;
        }
        /************自动寻路************/
        Vector3 shootDistinction = enemy.transform.position - gameObject.transform.position;
        shootWay = new Ray(gameObject.transform.position, shootDistinction);
        RaycastHit hit;
        float distance = Vector3.Distance(enemy.transform.position, transform.position);
        if (distance > attackRange || Physics.Raycast(shootWay, out hit, distance, 1 << LayerMask.NameToLayer("wall")))
            nma.SetDestination(enemy.transform.position);
        /***********自动攻击*************/
        else
        {
            nma.ResetPath();
            gameObject.transform.LookAt(enemy.transform.position);
            if (shootCoolDown >= w.bulletSpeed)     //判断子弹能否打到目标
            {
                w.Shoot();
                shootCoolDown = 0;
            }
        }
        shootCoolDown++;
        /******************************/
    }

    /*
    private void searchEnemy()
    {
        Collider[] cols = Physics.OverlapSphere(transform.position, searchRange, enemyLayer);
        enemy = cols[Random.Range(0, cols.Length)].gameObject;
    }
    */
    
    private void getNearestEnemy()
    {
        Collider[] cols = Physics.OverlapSphere(transform.position, searchRange, enemyLayer);
        float distance = 10000;
        foreach (var item in cols)
        {
            if (distance > Vector3.Distance(item.gameObject.transform.position, transform.position))
            {
                enemy = item.gameObject;
                distance = Vector3.Distance(item.gameObject.transform.position, transform.position);
            }
        }
        
    }
    
}
