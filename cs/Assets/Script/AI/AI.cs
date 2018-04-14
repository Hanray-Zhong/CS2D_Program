using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI : Unit {

    private enum State
    {
        Search,
        Chase,
        Attack,
    }

    /******************搜索参数*******************/
    public GameObject[] searchArea;             //搜索时的地域目标
    private float sightRange = 20;              //视野范围
    private float attackRange = 17;             //攻击范围
    private NavMeshAgent nma;                   //定义NMA
    /********************************************/
    /******************攻击参数*******************/
    private float shootCoolDown = 0;            //射击冷却
    private float renewBullet_time = 0;         //换弹时间
    private int bulletNumber;                   //弹夹子弹数
    private int bulletTotalNumber;              //武器子弹总数
    private AudioSource audioSource;            //定义子弹射击声音组件
    private GameObject enemy;                   //定义射击目标
    private Weapons w;                          //定义武器组件
    /********************************************/
    /******************通用参数*******************/
    private LayerMask enemyLayer;               //敌人的层
    private Ray shootWay;                       //用射线模拟弹道
    /********************************************/
    /******************状态管理*******************/
    private State stateManager;

    private void Start()
    {
        w = gameObject.GetComponent<Weapons>();                 //实例化武器
        w.ChooseWeapon();                                       //获取武器
        nma = gameObject.GetComponent<NavMeshAgent>();          //实例化NMA
        enemyLayer = new TeamManager().ChooseEnemy(team);       //获取敌人的层
        audioSource = gameObject.GetComponent<AudioSource>();   //实例化audioSourse组件
        bulletNumber = w.bulletNumber;                          //得到弹夹子弹数
        bulletTotalNumber = w.bulletTotalNumber;                //得到总子弹数

        stateManager = State.Search;                            //先处于追逐状态
    }




    private void Update()
    {
        /***********改变状态*************/
        ChangeState();
        shootCoolDown++;
    }




    /**************改变状态***************/
    private void ChangeState()
    {
        switch(stateManager)
        {
            case State.Search : SearchState();
                                Debug.Log("I am searching!");
                                break;
            case State.Chase : ChaseState();
                                Debug.Log("I am chasing!");
                                break;
            case State.Attack : AttackState();
                                Debug.Log("I am attacking!");
                                break;
        }
    }

    /**************状态函数***************/
    /// <summary>
    /// 搜索状态
    /// </summary>
    private void SearchState()
    {
        /**********没有敌人时的巡逻***********/
        if (enemy == null)
        {
            int areNumber = Random.Range(0, searchArea.Length);
            enemy = searchArea[areNumber];
            nma.SetDestination(enemy.transform.position);
        }
        float distance = Vector3.Distance(enemy.transform.position, transform.position);
        if (distance < 1)
        {
            enemy = null;
        }
        /*********判断视野里有没有敌人*********/
        Collider[] cols = Physics.OverlapSphere(transform.position, sightRange, enemyLayer);
        if(cols.Length != 0)
        {
            foreach (var item in cols)
            {
                enemy = item.gameObject;
                stateManager = State.Chase;
                return;
            }
        }
    }

    /// <summary>
    /// 追逐状态
    /// </summary>
    private void ChaseState()
    {
        if (enemy == null)
        {
            stateManager = State.Search;
            return;
        }
        else
        {
            nma.SetDestination(enemy.transform.position);
            RaycastHit hit;
            float distance = Vector3.Distance(enemy.transform.position, transform.position);
            Vector3 shootDistinction = enemy.transform.position - gameObject.transform.position;
            shootWay = new Ray(gameObject.transform.position, shootDistinction);
            if (distance > attackRange || Physics.Raycast(shootWay, out hit, distance, 1 << LayerMask.NameToLayer("wall")))
                stateManager = State.Chase;
            else
            {
                stateManager = State.Attack;
                return;
            }
        }
            
    }

    /// <summary>
    /// 攻击函数
    /// </summary>
    private void AttackState()
    {
        if(enemy == null)
        {
            stateManager = State.Search;
            return;
        }
        nma.ResetPath();
        gameObject.transform.LookAt(enemy.transform.position);
        if (shootCoolDown >= w.bulletSpeed && HaveBullet())
        {
            w.Shoot();
            shootCoolDown = 0;
            bulletNumber--;
            audioSource.Play();
        }
        RaycastHit hit;
        float distance = Vector3.Distance(enemy.transform.position, transform.position);
        if (distance > attackRange || Physics.Raycast(shootWay, out hit, distance, 1 << LayerMask.NameToLayer("wall")))
        {
            stateManager = State.Chase;
            return;
        }
    }
    /***********************************/

    
    



    /// <summary>
    /// 判断是否还有子弹
    /// </summary>
    /// <returns></returns>
    private bool HaveBullet()
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
