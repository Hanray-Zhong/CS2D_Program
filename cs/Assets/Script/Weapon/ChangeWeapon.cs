using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeWeapon : MonoBehaviour {
    public GameObject player;

    private Weapons weapon_of_player;
    private PlayerController PC;

    private void Start()
    {
        weapon_of_player = player.GetComponent<Weapons>();
        PC = player.GetComponent<PlayerController>();
    }

    public void ChangeGun(string WeaponName)
    {
        if(WeaponName.Equals("UZI"))
        {
            weapon_of_player.weaponInHand = weapons.UZI;
            weapon_of_player.ChooseWeapon();
            PC.bulletNumber = PC.w.bulletNumber;
            PC.bulletTotalNumber = PC.w.bulletTotalNumber;
        }
        if (WeaponName.Equals("AK47"))
        {
            weapon_of_player.weaponInHand = weapons.Ak47;
            weapon_of_player.ChooseWeapon();
            PC.bulletNumber = PC.w.bulletNumber;
            PC.bulletTotalNumber = PC.w.bulletTotalNumber;
        }
        if (WeaponName.Equals("M249"))
        {
            weapon_of_player.weaponInHand = weapons.M249;
            weapon_of_player.ChooseWeapon();
            PC.bulletNumber = PC.w.bulletNumber;
            PC.bulletTotalNumber = PC.w.bulletTotalNumber;
        }
        if (WeaponName.Equals("AWP"))
        {
            weapon_of_player.weaponInHand = weapons.AWP;
            weapon_of_player.ChooseWeapon();
            PC.bulletNumber = PC.w.bulletNumber;
            PC.bulletTotalNumber = PC.w.bulletTotalNumber;
        }
        if (WeaponName.Equals("M3"))
        {
            weapon_of_player.weaponInHand = weapons.M3;
            weapon_of_player.ChooseWeapon();
            PC.bulletNumber = PC.w.bulletNumber;
            PC.bulletTotalNumber = PC.w.bulletTotalNumber;
        }
    }
}
