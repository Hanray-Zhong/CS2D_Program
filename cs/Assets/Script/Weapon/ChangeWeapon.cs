using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeWeapon : MonoBehaviour {
    public GameObject player;

    private Weapons weapon_of_player;

    private void Start()
    {
        weapon_of_player = player.GetComponent<Weapons>();
    }

    public void ChangeGun(string WeaponName)
    {
        if(WeaponName.Equals("UZI"))
        {
            weapon_of_player.weaponInHand = weapons.UZI;
            weapon_of_player.ChooseWeapon();
        }
        if (WeaponName.Equals("AK47"))
        {
            weapon_of_player.weaponInHand = weapons.Ak47;
            weapon_of_player.ChooseWeapon();
        }
        if (WeaponName.Equals("M249"))
        {
            weapon_of_player.weaponInHand = weapons.M249;
            weapon_of_player.ChooseWeapon();
        }
        if (WeaponName.Equals("AWP"))
        {
            weapon_of_player.weaponInHand = weapons.AWP;
            weapon_of_player.ChooseWeapon();
        }
    }
}
