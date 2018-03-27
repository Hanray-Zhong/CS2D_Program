using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Unit {
    private float speed = 5;                //移动速度
    private float shootCoolDown = 0;       //射击冷却
    private Transform transform;           //定义transfor组件
    private Weapons w;                     //定义weapon组件
    private LayerMask enemyMask;           //定义layermask组件

    void Start () {
        transform = gameObject.GetComponent<Transform>();       //获取transform组件
        w = gameObject.GetComponent<Weapons>();                 //实例化w
        w.ChooseWeapon();                                       //拿上枪
        enemyMask = new TeamManager().ChooseEnemy(team);        //选择敌人
	}

    void FixedUpdate()
    {
        /**************控制移动****************/
        if (Input.GetKey(KeyCode.W) == true)
            transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.Self);
        if (Input.GetKey(KeyCode.A) == true)
            transform.Translate(Vector3.left * speed * Time.deltaTime, Space.Self);
        if (Input.GetKey(KeyCode.D) == true)
            transform.Translate(Vector3.right * speed * Time.deltaTime, Space.Self);
        if (Input.GetKey(KeyCode.S) == true)
            transform.Translate(Vector3.back * speed * Time.deltaTime, Space.Self);

        /**************控制旋转***************/
        Vector3 obj = Camera.main.WorldToScreenPoint(transform.position);
        obj.z = obj.y;
        obj.y = 0;
        Vector3 myMouse = new Vector3(Input.mousePosition.x, 0, Input.mousePosition.y);
        Vector3 direction = myMouse - obj;
        direction = direction.normalized;
        transform.forward = direction;

        /****************武器**************/
        shootCoolDown++;
        if (Input.GetKey(KeyCode.Mouse0) && shootCoolDown >= w.bulletSpeed)
        {
            shootCoolDown = 0;
            w.Shoot();
        }
    }
}
