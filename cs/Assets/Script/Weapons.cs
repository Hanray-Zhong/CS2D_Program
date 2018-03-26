using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour {
    private GameObject bullet;
    private float ShootForce = 100;
    public Transform ShootPoint;

    public enum weapons
    {
        UZI,
        Ak47,
        M249,
        AWP,
    }
    public weapons weaponInHand;

    public float bulletSpeed;
    public float bulletDamege;
    public float bulletNumber;
    public float bulletTotalNumber;

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

    public void Shoot()
    {
        GameObject newShell = Instantiate(bullet, ShootPoint.position, ShootPoint.rotation) as GameObject;
        Vector3 shootDirection = ShootPoint.forward;
        newShell.GetComponent<Rigidbody>().AddForce(shootDirection * ShootForce, ForceMode.Impulse);
    }
}
