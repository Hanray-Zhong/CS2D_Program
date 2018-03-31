using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Unit {
    private float speed = 5;               //移动速度
    private float shootCoolDown = 0;       //射击冷却
    private float renewBullet_time = 0;    //换弹时间
    private Transform transf;           //定义transf组件
    private AudioSource audioSource;       //定义audioSourse组件

    public Weapons w;                     //定义weapon组件
    public int bulletNumber;
    public int bulletTotalNumber;
    public GameObject Change_Bullet_text;
    public GameObject No_bullet_text;
    public GameObject Audio_changeBullet;

    void Start () {
        transf = gameObject.GetComponent<Transform>();       //获取transf组件
        w = gameObject.GetComponent<Weapons>();                 //实例化w
        w.ChooseWeapon();                                       //拿上枪
        bulletNumber = w.bulletNumber;                          //得到弹夹子弹数
        bulletTotalNumber = w.bulletTotalNumber;                //得到总子弹数
        audioSource = gameObject.GetComponent<AudioSource>();   //获取audioSourse组件
    }

    void FixedUpdate()
    {
        /**************控制移动****************/
        if (Input.GetKey(KeyCode.W) == true)
            transf.Translate(Vector3.forward * speed * Time.deltaTime, Space.Self);
        if (Input.GetKey(KeyCode.A) == true)
            transf.Translate(Vector3.left * speed * Time.deltaTime, Space.Self);
        if (Input.GetKey(KeyCode.D) == true)
            transf.Translate(Vector3.right * speed * Time.deltaTime, Space.Self);
        if (Input.GetKey(KeyCode.S) == true)
            transf.Translate(Vector3.back * speed * Time.deltaTime, Space.Self);

        /**************控制旋转***************/
        Vector3 obj = Camera.main.WorldToScreenPoint(transf.position);
        obj.z = obj.y;
        obj.y = 0;
        Vector3 myMouse = new Vector3(Input.mousePosition.x, 0, Input.mousePosition.y);
        Vector3 direction = myMouse - obj;
        direction = direction.normalized;
        transf.forward = direction;

        /****************武器**************/
        shootCoolDown++;
        if (HaveBullet() && shootCoolDown >= w.bulletSpeed && Input.GetKey(KeyCode.Mouse0))
        {
            shootCoolDown = 0;
            w.Shoot();
            audioSource.Play();
            bulletNumber--;
        }
    }

    private bool HaveBullet()                               //判断是否还有子弹
    {
        if (bulletNumber <= 0)
        {
            if (bulletTotalNumber > 0)
            {
                Change_Bullet_text.SetActive(false);
                renewBullet_time++;                        //判断换子弹是否结束
                if (renewBullet_time > w.renewBullet_time)
                {
                    bulletNumber = w.bulletNumber;
                    bulletTotalNumber -= bulletNumber;
                    renewBullet_time = 0;
                    return true;
                }
                else
                {
                    Change_Bullet_text.SetActive(true);
                    if (!Audio_changeBullet.activeInHierarchy)
                        Audio_changeBullet.SetActive(true);

                    return false;
                }
            }
            else
            {
                No_bullet_text.SetActive(true);
                return false;
            }
        }
        else
        {
            Audio_changeBullet.SetActive(false);
            return true;
        }
    }
}
