using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour {
    public GameObject player;

    private Text Health_text;
    private Unit player_unit;

    private void Start()
    {
        Health_text = gameObject.GetComponent<Text>();
        player_unit = player.GetComponent<Unit>();
    }

    private void Update()
    {
        Health_text.text = player_unit.health.ToString();
    }
}
