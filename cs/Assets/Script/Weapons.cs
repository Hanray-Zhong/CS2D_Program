using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum weapons                                    //建立所有枪的枚举
{
    UZI,
    Ak47,
    M249,
    AWP,
}

public class Weapons : MonoBehaviour {
    private GameObject bullet;                        //对应枪的子弹
    private float ShootForce = 100;                   //射出子弹的力
    public LayerMask enemyLayer;                     //敌人的layermask

    public Transform ShootPoint;                      //子弹射出位置方向
    public weapons weaponInHand;                      //拿上的武器

    public float bulletSpeed;                         //子弹射速
    public float bulletDamege;                        //子弹威力
    public float bulletNumber;                        //子弹弹夹数
    public float bulletTotalNumber;                   //子弹总数

    /**************选择枪，得到数据*************/
    public void ChooseWeapon()
    {
        if (weaponInHand == weapons.UZI)
        {
            this.bulletSpeed = 10;
            this.bulletDamege = 15;
            this.bulletNumber = 25;
            this.bulletTotalNumber = 150;
            bullet = (GameObject)Resources.Load("Prefabs/bulletUZI", typeof(GameObject));
        }
        if (weaponInHand == weapons.Ak47)
        {
            this.bulletSpeed = 20;
            this.bulletDamege = 40;
            this.bulletNumber = 30;
            this.bulletTotalNumber = 90;
            bullet = (GameObject)Resources.Load("Prefabs/bulletAk47", typeof(GameObject));
        }
        if (weaponInHand == weapons.M249)
        {
            this.bulletSpeed = 20;
            this.bulletDamege = 25;
            this.bulletNumber = 100;
            this.bulletTotalNumber = 200;
            bullet = (GameObject)Resources.Load("Prefabs/bulletM249", typeof(GameObject));
        }
        if (weaponInHand == weapons.AWP)
        {
            this.bulletSpeed = 75;
            this.bulletDamege = 100;
            this.bulletNumber = 10;
            this.bulletTotalNumber = 30;
            bullet = (GameObject)Resources.Load("Prefabs/bulletAWP", typeof(GameObject));
        }
    }
    /***************得到敌人的layermask*****************/
    public void Init(Team team)
    {
        enemyLayer = new TeamManager().ChooseEnemy(team);
    }
    /******************开枪*********************/
    public void Shoot()
    {
        GameObject newBullet = Instantiate(bullet, ShootPoint.position, ShootPoint.rotation) as GameObject;
        Vector3 shootDirection = ShootPoint.forward;
        newBullet.GetComponent<Rigidbody>().AddForce(shootDirection * ShootForce, ForceMode.Impulse);
    }
}
