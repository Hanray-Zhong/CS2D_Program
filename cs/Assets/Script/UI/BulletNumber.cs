using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletNumber : MonoBehaviour {
    public GameObject player;

    private Text Health_text;
    private PlayerController pc;

    private void Start()
    {
        Health_text = gameObject.GetComponent<Text>();
        pc = player.GetComponent<PlayerController>();
    }

    private void Update()
    {
        Health_text.text = pc.bulletNumber.ToString();
    }
}
