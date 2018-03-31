using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum weapons                                    //建立所有枪的枚举
{
    Usp,
    UZI,
    Ak47,
    M249,
    AWP,
    M3,
}

public class Weapons : MonoBehaviour {
    private GameObject bullet;                        //对应枪的子弹
    private float ShootForce = 100;                   //射出子弹的力
    /*public LayerMask enemyLayer;*/                  //敌人的layermask,可以设置队友是否造成伤害

    public Transform ShootPoint;                      //子弹射出位置方向
    public weapons weaponInHand;                      //拿上的武器
    public float bulletSpeed;                         //子弹射速
    public float bulletDamege;                        //子弹威力
    public int bulletNumber;                          //子弹弹夹数
    public int bulletTotalNumber;                     //子弹总数
    public int renewBullet_time;                      //换弹的时间

    /**************选择枪，得到数据*************/
    public void ChooseWeapon()
    {
        if (weaponInHand == weapons.Usp)
        {
            this.bulletSpeed = 20;
            this.bulletDamege = 20;
            this.bulletNumber = 12;
            this.bulletTotalNumber = 48;
            this.renewBullet_time = 120;
            bullet = (GameObject)Resources.Load("Prefabs/bulletUsp", typeof(GameObject));
        }
        if (weaponInHand == weapons.UZI)
        {
            this.bulletSpeed = 5;
            this.bulletDamege = 15;
            this.bulletNumber = 25;
            this.bulletTotalNumber = 150;
            this.renewBullet_time = 120;
            bullet = (GameObject)Resources.Load("Prefabs/bulletUZI", typeof(GameObject));
        }
        if (weaponInHand == weapons.Ak47)
        {
            this.bulletSpeed = 10;
            this.bulletDamege = 40;
            this.bulletNumber = 30;
            this.bulletTotalNumber = 90;
            this.renewBullet_time = 160;
            bullet = (GameObject)Resources.Load("Prefabs/bulletAk47", typeof(GameObject));
        }
        if (weaponInHand == weapons.M249)
        {
            this.bulletSpeed = 10;
            this.bulletDamege = 25;
            this.bulletNumber = 100;
            this.bulletTotalNumber = 200;
            this.renewBullet_time = 260;
            bullet = (GameObject)Resources.Load("Prefabs/bulletM249", typeof(GameObject));
        }
        if (weaponInHand == weapons.AWP)
        {
            this.bulletSpeed = 100;
            this.bulletDamege = 100;
            this.bulletNumber = 10;
            this.bulletTotalNumber = 30;
            this.renewBullet_time = 180;
            bullet = (GameObject)Resources.Load("Prefabs/bulletAWP", typeof(GameObject));
        }
        if (weaponInHand == weapons.M3)
        {
            this.bulletSpeed = 50;
            this.bulletDamege = 10;
            this.bulletNumber = 8;
            this.bulletTotalNumber = 32;
            this.renewBullet_time = 180;
            bullet = (GameObject)Resources.Load("Prefabs/bulletM3", typeof(GameObject));
        }
    }
    /******************开枪*********************/
    public void Shoot()
    {
        GameObject newBullet = Instantiate(bullet, ShootPoint.position, ShootPoint.rotation) as GameObject;
        Vector3 shootDirection = ShootPoint.forward;
        newBullet.GetComponent<Rigidbody>().AddForce(shootDirection * ShootForce, ForceMode.Impulse);
    }
}
