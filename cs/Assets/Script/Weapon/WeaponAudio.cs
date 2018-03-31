using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAudio : MonoBehaviour {
    private Weapons weapon;
    private AudioSource weapon_audio;                 //开枪声音

    public AudioClip[] music;

    private void Start()
    {
        weapon = gameObject.GetComponent<Weapons>();
        weapon_audio = gameObject.GetComponent<AudioSource>();
    }

    private void Update()
    {
        ChooseWeaponAudio();
    }

    public void ChooseWeaponAudio()
    {
        if (weapon.weaponInHand == weapons.Usp)
        {
            weapon_audio.clip = music[0];
        }
        if (weapon.weaponInHand == weapons.UZI)
        {
            weapon_audio.clip = music[1];
        }
        if (weapon.weaponInHand == weapons.Ak47)
        {
            weapon_audio.clip = music[2];
        }
        if (weapon.weaponInHand == weapons.M249)
        {
            weapon_audio.clip = music[3];
        }
        if (weapon.weaponInHand == weapons.AWP)
        {
            weapon_audio.clip = music[4];
        }
        if (weapon.weaponInHand == weapons.M3)
        {
            weapon_audio.clip = music[5];
        }
    }
}
