using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour {
    public GameObject Shell;
    public Transform ShootPoint;
    public float ShootForce;

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
        if(weaponInHand == weapons.UZI)
        {
            this.bulletSpeed = 10;
            this.bulletDamege = 15;
            this.bulletNumber = 25;
            this.bulletTotalNumber = 150;
        }
        if (weaponInHand == weapons.Ak47)
        {
            this.bulletSpeed = 20;
            this.bulletDamege = 40;
            this.bulletNumber = 30;
            this.bulletTotalNumber = 90;
        }
        if (weaponInHand == weapons.M249)
        {
            this.bulletSpeed = 20;
            this.bulletDamege = 25;
            this.bulletNumber = 100;
            this.bulletTotalNumber = 200;
        }
        if (weaponInHand == weapons.AWP)
        {
            this.bulletSpeed = 75;
            this.bulletDamege = 100;
            this.bulletNumber = 10;
            this.bulletTotalNumber = 30;
        }
    }

    public void Shoot()
    {
        GameObject newShell = Instantiate(Shell, ShootPoint.position, ShootPoint.rotation) as GameObject;
        Vector3 shootDirection = ShootPoint.forward;
        newShell.GetComponent<Rigidbody>().AddForce(shootDirection * ShootForce, ForceMode.Impulse);
    }
}
