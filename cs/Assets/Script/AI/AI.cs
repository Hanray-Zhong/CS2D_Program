using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI : Unit {

    private float searchRange = 1000;
    private float attackRange = 15;         //攻击范围
    private float shootCoolDown = 0;        //射击冷却
    private float renewBullet_time = 0;     //换弹时间
    private NavMeshAgent nma;               //自动寻路
    private AudioSource audioSource;       //定义audioSourse组件
    private GameObject enemy;               //射击目标
    private Weapons w;
    private LayerMask enemyLayer;           //敌人的层
    private Ray shootWay;                   //用射线模拟弹道
    private int bulletNumber;
    private int bulletTotalNumber;

    private void Start()
    {
        w = gameObject.GetComponent<Weapons>();
        w.ChooseWeapon();
        bulletNumber = w.bulletNumber;                      //得到弹夹子弹数
        bulletTotalNumber = w.bulletTotalNumber;            //得到总子弹数
        nma = gameObject.GetComponent<NavMeshAgent>();
        enemyLayer = new TeamManager().ChooseEnemy(team);
        audioSource = gameObject.GetComponent<AudioSource>();   //获取audioSourse组件

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
            if (shootCoolDown >= w.bulletSpeed && HaveBullet())     //判断子弹能否打到目标
            {
                w.Shoot();
                shootCoolDown = 0;
                bulletNumber--;
                audioSource.Play();
            }
        }
        shootCoolDown++;
        /******************************/
    }

    private void getNearestEnemy()                           //将离自己最近的敌人设为目标
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

    private bool HaveBullet()                               //判断是否还有子弹
    {
        if (bulletNumber <= 0)
        {
            if (bulletTotalNumber > 0)
            {
                renewBullet_time++;                        //判断换子弹是否结束
                if (renewBullet_time > w.renewBullet_time)
                {
                    bulletNumber = w.bulletNumber;
                    bulletTotalNumber -= bulletNumber;
                    renewBullet_time = 0;
                    return true;
                }
                else
                    return false;
            }
            else
                return false;
        }
        else
            return true;
    }

}
